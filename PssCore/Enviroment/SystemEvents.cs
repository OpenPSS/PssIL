using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Class to receive events from the system</summary>
	public static class SystemEvents
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int CheckEventsNative(out SystemEvents.InternalData data);
		/*
		 *	Global Variables
		 */
		/// <summary>Event handler for recovering from the minimized state</summary>
		public static event SystemEvents.RestoredEventHandler OnRestored;

		/// <summary>Minimized event handler</summary>
		public static event SystemEvents.MinimizedEventHandler OnMinimized;

		private struct InternalData
		{
			[MarshalAs(4)]
			public bool QuitRequired;

			public bool Restored;

			public bool Minimized;
		}

		/// <summary>Event handler type for recovering from the minimized state</summary>
		/// <param name="sender">Send-source object</param>
		/// <param name="e">Event data</param>
		public delegate void RestoredEventHandler(object sender, RestoredEventArgs e);

		/// <summary>Minimized event handler type</summary>
		/// <param name="sender">Send-source object</param>
		/// <param name="e">Event data</param>
		public delegate void MinimizedEventHandler(object sender, MinimizedEventArgs e);
		
		/*
		 *	IL Code
		 */
		
		/// <summary>Checks for system events and updates the system state</summary>
		[SecuritySafeCritical]
		public static void CheckEvents()
		{
			SystemEvents.InternalData internalData;
			int errorCode = SystemEvents.CheckEventsNative(out internalData);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(num);
			}
			if (internalData.QuitRequired)
			{
				Thread.CurrentThread.Abort();
			}
			if (internalData.Restored)
			{
				if (SystemEvents.OnRestored != null)
				{
					RestoredEventArgs e = new RestoredEventArgs();
					SystemEvents.OnRestored(null, e);
				}
			}
			if (internalData.Minimized)
			{
				if (SystemEvents.OnMinimized != null)
				{
					MinimizedEventArgs e2 = new MinimizedEventArgs();
					SystemEvents.OnMinimized(null, e2);
				}
			}
		}

	}
}
