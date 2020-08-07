using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Handles logging to stdin/stdout</summary>
	internal static class Log
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetNeedsRedirection();
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int WriteNative(string text);
		
		/*
		 * IL Code
		 */		
		private static bool console_set = false;

		
		/// <summary>enables console output.</summary>
		[SecuritySafeCritical]
		private static void SetToConsole()
		{
			if (!Log.console_set)
			{
				int needsRedirection = Log.GetNeedsRedirection();
				if (needsRedirection != 0)
				{
					Log.StreamToLog @out = new Log.StreamToLog();
					Log.StreamToLog error = new Log.StreamToLog();
					Console.SetOut(@out);
					Console.SetError(error);
					Console.WriteLine("------------ console switched ------------");
					Log.console_set = true;
				}
			}
		}
		
		/// <summary> Write the specified text to stdout.</summary>
		/// <param name='text'></para>Text to write.</param>
		[SecuritySafeCritical]
		public static void Write(string text)
		{
			int errorCode = Log.WriteNative(text);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}
		/// <summary>TextWriter for logging</summary>
		private class StreamToLog : TextWriter
		{
			public override Encoding Encoding
			{
				get
				{
					return Encoding.UTF8;
				}
			}

			public override void Write(string s)
			{
				Log.Write(s);
			}

			public override void WriteLine(string s)
			{
				Log.Write(s + "\n");
			}
		}
	}
}
