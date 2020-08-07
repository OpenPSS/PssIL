using System;
using System.Threading;

namespace Sce.PlayStation.Core.Services
{
	internal class NetworkAsyncResult : IAsyncResult
	{
		/*
		 *	Global Variables
		 */
		
		private readonly AsyncCallback m_callback;
		private readonly object m_state;
		private ManualResetEvent m_waitHandle;
		private bool m_complete;
		private bool m_completedSyncronously;

		
		public NetworkAsyncResult(AsyncCallback callback, object state)
		{
			this.m_callback = callback;
			this.m_state = state;
			this.m_waitHandle = null;
			this.m_complete = false;
			this.m_completedSyncronously = false;
		}

		internal void Complete()
		{
			this.m_complete = true;
			if (this.m_waitHandle != null)
			{
				this.m_waitHandle.Set();
			}
			if (this.m_callback != null)
			{
				this.m_callback.Invoke(this);
			}
		}

		public static void WaitOnCompletion(IAsyncResult result)
		{
			NetworkAsyncResult networkAsyncResult = (NetworkAsyncResult)result;
			if (!networkAsyncResult.IsCompleted)
			{
				networkAsyncResult.m_waitHandle.WaitOne();
				networkAsyncResult.m_waitHandle.Close();
				networkAsyncResult.m_waitHandle = null;
			}
		}

		public object AsyncState
		{
			get
			{
				return this.m_state;
			}
		}

		public bool CompletedSynchronously
		{
			get
			{
				return this.m_completedSyncronously;
			}
		}

		public WaitHandle AsyncWaitHandle
		{
			get
			{
				if (this.m_waitHandle == null)
				{
					bool isCompleted = this.IsCompleted;
					ManualResetEvent manualResetEvent = new ManualResetEvent(isCompleted);
					if (Interlocked.CompareExchange<ManualResetEvent>(ref this.m_waitHandle, manualResetEvent, null) != null)
					{
						manualResetEvent.Close();
					}
					else if (!isCompleted && this.IsCompleted)
					{
						this.m_waitHandle.Set();
					}
				}
				return this.m_waitHandle;
			}
		}

		public bool IsCompleted
		{
			get
			{
				return this.m_complete;
			}
		}
	}
}
