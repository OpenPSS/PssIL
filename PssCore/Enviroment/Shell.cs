using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Class for calling system features</summary>
	public static class Shell
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ExecuteNative(ref Shell.Action data);
		
		/*
		 *  IL Code
		 */
		
		/// <summary>Structure to represent the contents of system features</summary>
		public struct Action
		{
			/// <summary>Creates an Action structure for calling the browser</summary>
			/// <param name="url">URL to open the browser with</param>
			/// <returns>Action structure representing a browser call</returns>
			public static Shell.Action BrowserAction(string url)
			{
				return new Shell.Action
				{
					type = Shell.Action.ActionType.Browser,
					parameter0 = url
				};
			}

			private Shell.Action.ActionType type;

			private string parameter0;

			private string parameter1;

			private string parameter2;

			private string parameter3;

			private enum ActionType : uint
			{
				None, /* 0 */
				Browser /* 1 */
			}
		}
		/// <summary>Executes a system feature call</summary>
		/// <param name="action">Content of the system feature call</param>
		[SecuritySafeCritical]
		public static void Execute(ref Shell.Action action)
		{
			int errorCode = Shell.ExecuteNative(ref action);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		
	}
}
