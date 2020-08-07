using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Class providing persistent memory area</summary>
	public static class PersistentMemory
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int WriteNative(byte[] fileImage);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ReadNative(byte[] fileImage);
		
		/*
		 *	IL Code
		 */
		
		/// <summary>Write data to persistent memory</summary>
		/// <param name="data">Write content (maximum 64KB)</param>
		[SecuritySafeCritical]
		public static void Write(byte[] data)
		{
			int errorCode = PersistentMemory.WriteNative(data);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Read data from persistent memory</summary>
		/// <returns>Read data (64KB)</returns>
		[SecuritySafeCritical]
		public static byte[] Read()
		{
			byte[] persistantMemory = new byte[0x10000];
			int errorCode = PersistentMemory.ReadNative(persistantMemory);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return persistantMemory;
		}
	}
}
