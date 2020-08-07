using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Network request class</summary>
	[Obsolete("Scoreboard Service of PSM was discontinued.")]
	public class NetworkRequest : IDisposable
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int CreateRequestNative(int type, string function, string json, out int requestHandle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int QueueRequestNative(int type, string function, string json, out int requestHandle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int DestroyRequestNative(int requestHandle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetResponseNative(int requestHandle, out string response);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int RegisterThreadNative();
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int UnregisterThreadNative();
		
		/*
		 *	Global Variables
		 */
		
		private NetworkRequestType m_type = NetworkRequestType.Unknown;
		private string m_function = null;
		private string m_json = null;
		private int m_requestHandle = 0;
		private AsyncCallback m_responseCallback = null;
		private NetworkStreamReaderDelegate m_readerDelegate = null;
		private NetworkResponseDelegate m_afterResponseDelegate = null;
		private object m_callbackArg = null;
		private Thread m_thread = null;
		private NetworkAsyncResult m_asyncResult = null;
		private delegate void InternalNetworkResponseDelegate(string response);

		
		/*
		 *  IL Code..
		 */
		internal NetworkRequest(NetworkRequestType type, string function, string json)
		{
			this.m_type = type;
			this.m_json = json;
			this.m_function = function;
		}

		[SecuritySafeCritical]
		internal void QueueRequest()
		{
			int requestHandle = 0;
			int errorCode = NetworkRequest.QueueRequestNative((int)this.m_type, this.m_function, this.m_json, out requestHandle);
			if (requestHandle != 0)
			{
				this.m_requestHandle = requestHandle;
			}
		}

		[SecuritySafeCritical]
		internal void PostRequest(bool bPostAsync)
		{
			int requestHandle = 0;
			int errorCode = NetworkRequest.CreateRequestNative((int)this.m_type, this.m_function, this.m_json, out requestHandle);
			if (requestHandle != 0)
			{
				this.m_requestHandle = requestHandle;
			}
		}

		~NetworkRequest()
		{
			this.Dispose();
		}

		/// <summary>get the response from the server, blocking</summary>
		/// <returns>a response, or null if error</returns>
		[SecuritySafeCritical]
		public NetworkResponse GetResponse()
		{
			NetworkResponse resp;
			if (this.m_requestHandle == 0)
			{
				resp = null;
			}
			else
			{
				string response = "";
				if (NetworkRequest.GetResponseNative(this.m_requestHandle, out response) < 0)
				{
					resp = null;
				}
				else
				{
					resp = new NetworkResponse(response);
				}
			}
			return resp;
		}

		/// <summary>get the response from the server, asynchronous</summary>
		/// <param name="callback">callback function</param>
		/// <returns>a handle</returns>
		public IAsyncResult BeginGetResponse(AsyncCallback callback)
		{
			this.m_responseCallback = callback;
			this.m_callbackArg = this;
			return this.BeginGetResponse();
		}

		[SecuritySafeCritical]
		private IAsyncResult BeginGetResponse()
		{
			IAsyncResult result;
			if (this.m_requestHandle == 0)
			{
				result = null;
			}
			else
			{
				if (this.m_asyncResult == null)
				{
					this.m_asyncResult = new NetworkAsyncResult(this.m_responseCallback, this.m_callbackArg);
				}
				if (this.m_thread == null)
				{
					NetworkRequest.RegisterThreadNative();
					try
					{
						this.m_thread = new Thread(delegate()
						{
							string text = "";
							if (NetworkRequest.GetResponseNative(this.m_requestHandle, out text) < 0)
							{
							}
							if (this.m_asyncResult != null)
							{
								this.m_asyncResult.Complete();
							}
						});
					}
					finally
					{
						NetworkRequest.UnregisterThreadNative();
					}
					this.m_thread.Start();
				}
				result = this.m_asyncResult;
			}
			return result;
		}

		/// <summary>fetch a request</summary>
		/// <param name="callback">handle of request</param>
		/// <returns>a response</returns>
		[SecuritySafeCritical]
		public NetworkResponse EndGetResponse(IAsyncResult result)
		{
			NetworkResponse resp;
			if (this.m_requestHandle == 0)
			{
				resp = null;
			}
			else
			{
				try
				{
					NetworkAsyncResult.WaitOnCompletion(result);
				}
				catch (WebException ex)
				{
				}
				string response = "";
				if (NetworkRequest.GetResponseNative(this.m_requestHandle, out response) < 0)
				{
					resp = null;
				}
				else
				{
					resp = new NetworkResponse(response);
				}
			}
			return resp;
		}

		/// <summary>dispose an object</summary>
		[SecuritySafeCritical]
		public void Dispose()
		{
			if (this.m_requestHandle != 0)
			{
				NetworkRequest.DestroyRequestNative(this.m_requestHandle);
				this.m_requestHandle = 0;
			}
			this.m_thread = null;
			this.m_asyncResult = null;
		}
	}
}
