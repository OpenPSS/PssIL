using System;
using System.IO;
using System.Json;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace Sce.PlayStation.Core.Services
{
	/// <summary>Network class which handles scoreboard usage.</summary>
	[Obsolete("Scoreboard Service of PSM was discontinued.")]
	public static class Network
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int CheckStateNative(out uint state);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetOnlineIdNative(out string id);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetAccountIdNative(out ulong id);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetAuthTicketDataNative(out string data);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ResetAuthTicketNative();
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void SetAppIdNative(string appId);
		
		/*
		 *	Global Variables
		 */
		
		private static Network.WebRequestDelegate web_request_delegate;
		private static GCHandle web_request_handle;
		private static string npTicket = "";
		private static string serverTicket = "";
		private static NetworkState serverStatus = NetworkState.NetworkServerIdle;
		private static string appToken;
		internal delegate byte[] WebRequestDelegate(string url, string method, IntPtr headers_ptr, int num_headers, IntPtr payload, int payload_length);

		
		/*
		 * IL Code.
		 */
		
		[SecuritySafeCritical]
		static Network()
		{
			Network.web_request_delegate = new Network.WebRequestDelegate(Network.DoNetworkRequest);
			Network.web_request_handle = GCHandle.Alloc(Network.web_request_delegate, GCHandleType.Pinned);
			Network.SetWebRequestDelegate((IntPtr)Network.web_request_handle);
		}

		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void SetWebRequestDelegate(IntPtr handle);

		/// <summary>initialize scoreboard class with application data</summary>
		/// <param name="applicationToken">application token</param>
		[SecuritySafeCritical]
		public static void Initialize(string applicationToken)
		{
			Network.appToken = applicationToken;
			Network.SetAppIdNative(Network.appToken);
		}

		/// <summary>Retrieve the Network Services server ticket</summary>
		public static string ServerTicket
		{
			get
			{
				return Network.serverTicket;
			}
		}

		/// <summary>get ticket from Network Services server, upon startup or ticket expiration</summary>
		/// <returns>server state</returns>
		[SecuritySafeCritical]
		public static NetworkState AuthGetTicket()
		{
			if (Network.npTicket.Length == 0)
			{
				Network.GetAuthTicketDataNative(out Network.npTicket);
			}
			NetworkState state;
			if (Network.npTicket.Length == 0)
			{
				Network.serverStatus = NetworkState.NetworkServerIdle;
				state = Network.State;
			}
			else if (Network.serverTicket.Length > 0)
			{
				Network.serverStatus = NetworkState.NetworkServerReady;
				state = Network.serverStatus;
			}
			else
			{
				string json = Telemetry.ConstructAuthJson(Network.npTicket);
				NetworkRequest networkRequest = Network.CreateAuthRequest(json);
				IAsyncResult asyncResult = networkRequest.BeginGetResponse(new AsyncCallback(Network.OnAuthResponse));
				if (asyncResult == null)
				{
					Network.serverStatus = NetworkState.NetworkServerFailed;
				}
				else
				{
					Network.serverStatus = NetworkState.NetworkServerRequested;
				}
				state = Network.serverStatus;
			}
			return state;
		}

		internal static void OnAuthResponse(IAsyncResult rs)
		{
			NetworkRequest networkRequest = rs.AsyncState as NetworkRequest;
			NetworkResponse networkResponse = networkRequest.EndGetResponse(rs);
			NetworkStreamReader streamReader = networkResponse.GetStreamReader();
			string text = streamReader.ReadToEnd();
			if (text.Length > 0)
			{
				JsonValue jsonValue = JsonValue.Parse(text);
				if (jsonValue.ContainsKey("b"))
				{
					Network.serverTicket = (string)jsonValue.GetValue("b").GetValue("w");
					Network.serverStatus = NetworkState.NetworkServerReady;
				}
				else
				{
					Network.serverStatus = NetworkState.NetworkServerFailed;
				}
			}
			else
			{
				Network.serverStatus = NetworkState.NetworkServerFailed;
			}
		}

		[SecuritySafeCritical]
		internal static byte[] DoNetworkRequest(string url, string method, IntPtr headers_ptr, int num_headers, IntPtr payload_ptr, int payload_length)
		{
			byte[] result = null;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = method;
			for (int i = 0; i < num_headers; i += 2)
			{
				try
				{
					IntPtr intPtr = Marshal.ReadIntPtr(headers_ptr, i * IntPtr.Size);
					string text = Marshal.PtrToStringAnsi(intPtr);
					IntPtr intPtr2 = Marshal.ReadIntPtr(headers_ptr, (i + 1) * IntPtr.Size);
					string text2 = Marshal.PtrToStringAnsi(intPtr2);
					httpWebRequest.Headers.Add(text, text2);
				}
				catch (Exception ex)
				{
					return null;
				}
			}
			try
			{
				if (payload_length > 0 && payload_ptr != IntPtr.Zero)
				{
					byte[] array = new byte[payload_length];
					Marshal.Copy(payload_ptr, array, 0, payload_length);
					using (Stream requestStream = httpWebRequest.GetRequestStream())
					{
						requestStream.Write(array, 0, payload_length);
					}
				}
			}
			catch (Exception ex)
			{
				return null;
			}
			try
			{
				using (WebResponse response = httpWebRequest.GetResponse())
				{
					string text3 = ((HttpWebResponse)response).StatusCode.ToString();
					using (Stream responseStream = response.GetResponseStream())
					{
						result = Network.ReadFully(responseStream);
					}
				}
			}
			catch (WebException ex2)
			{
				try
				{
					using (Stream responseStream = ex2.Response.GetResponseStream())
					{
						result = Network.ReadFully(responseStream);
					}
				}
				catch (Exception ex3)
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				return null;
			}
			return result;
		}

		internal static byte[] ReadFully(Stream input)
		{
			byte[] outputBytes = new byte[16384];
			byte[] result;
			using (MemoryStream ms = new MemoryStream())
			{
				int readBytes;
				while ((readBytes = input.Read(outputBytes, 0, outputBytes.Length)) > 0)
				{
					ms.Write(outputBytes, 0, readBytes);
				}
				result = ms.ToArray();
			}
			return result;
		}

		/// <summary>Creates a network request. </summary>
		/// <param name="type">Request type</param>
		/// <param name="function">Network service type</param>
		/// <param name="json">A valid Json string</param>
		/// <returns>request</returns>
		public static NetworkRequest CreateRequest(NetworkRequestType type, string function, string json)
		{
			if (Network.serverTicket == "")
			{
				throw new ArgumentException("Scoreboard must get ticket from NetworkServices server before calling CreateRequest.");
			}
			NetworkRequest networkRequest = new NetworkRequest(type, function, json);
			if (networkRequest != null)
			{
				networkRequest.PostRequest(false);
			}
			return networkRequest;
		}

		private static NetworkRequest CreateAuthRequest(string json)
		{
			NetworkRequest networkRequest = new NetworkRequest(NetworkRequestType.Get, "auth_token", json);
			if (networkRequest != null)
			{
				networkRequest.PostRequest(false);
			}
			return networkRequest;
		}

		/// <summary>Returns the state of the server. If status is NetworkServerReady scoreboards can be queried.</summary>
		/// <returns>server status</returns>
		public static NetworkState State
		{
			[SecuritySafeCritical]
			get
			{
				uint networkStateNative;
				int errorCode = Network.CheckStateNative(out networkStateNative);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				NetworkState networkState = NetworkState.NotConnected;
				switch (networkStateNative)
				{
				case 0x00:
					networkState = NetworkState.NotConnected;
					break;
				case 0x01:
					networkState = NetworkState.SignedOut;
					break;
				case 0x02:
					networkState = NetworkState.SignedIn;
					break;
				case 0x03:
					networkState = NetworkState.Online;
					break;
				}
				switch (networkStateNative >> 16)
				{
				case 0x01:
					networkState = NetworkState.AuthRequested;
					break;
				case 0x02:
					networkState = NetworkState.AuthRequestReady;
					break;
				case 0x03:
					networkState = NetworkState.AuthRequestFailed;
					break;
				}
				if (networkState == NetworkState.AuthRequestReady)
				{
					switch (Network.serverStatus)
					{
					case NetworkState.NetworkServerIdle:
						Network.AuthGetTicket();
						break;
					case NetworkState.NetworkServerRequested:
					case NetworkState.NetworkServerReady:
					case NetworkState.NetworkServerFailed:
						networkState = Network.serverStatus;
						break;
					}
				}
				return networkState;
			}
		}
	}
}
