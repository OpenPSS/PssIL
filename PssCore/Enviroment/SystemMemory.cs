using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary></summary>
	public static class SystemMemory
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern MemoryUsage GetMemoryUsage(bool details);
		
		/*
		 *	IL Code.
		 */
		/// <summary>Print some debug information, content might vary in the future.</summary>
		[SecuritySafeCritical]
		public static void Dump()
		{
			string text = "==== [START] SystemMemory.Dump() ====\r\n";
			MemoryUsage memoryUsage = SystemMemory.GetMemoryUsage(true);
			text += "[Resource Heap Information]\r\n";
			text += string.Format(" + Total : {0,0:D10} [bytes]\r\n", memoryUsage.total);
			text += string.Format(" + Used  : {0,0:D10} [bytes]\r\n", memoryUsage.used);
			text += string.Format(" + Free  : {0,0:D10} [bytes]\r\n", memoryUsage.free);
			text += "\r\n";
			text += memoryUsage.details;
			text += "==== [END] SystemMemory.Dump() ====\r\n";
			Console.Write(text);
		}
	}
}
