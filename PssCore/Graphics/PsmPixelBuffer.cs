using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	internal static class PsmPixelBuffer
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Create(PixelBufferType type, int width, int height, bool mipmap, PixelFormat format, PixelBufferOption option, InternalOption option2, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Delete(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int AddRef(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetInfo(int handle, out PixelBufferType type, out int width, out int height, out int level, out PixelFormat format, out PixelBufferOption option);
	}
}
