using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Class for accessing the clipboard</summary>
	public static class Clipboard
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetTextNative(out string text);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetTextNative(string text);
		
		/*
		 *  IL Code.
		 */
		
		/// <summary>Stores text in the clipboard</summary>
		/// <param name="text">Text to be stored</param>
		[SecuritySafeCritical]
		public static void SetText(string text)
		{
			int errorCode = Clipboard.SetTextNative(text);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(num);
			}
		}

		/// <summary>Obtains the clipboard text</summary>
		/// <returns>Clipboard text</returns>
		[SecuritySafeCritical]
		public static string GetText()
		{
			string text;
			int errorCode = Clipboard.GetTextNative(out text);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return text;
		}
	}
}
