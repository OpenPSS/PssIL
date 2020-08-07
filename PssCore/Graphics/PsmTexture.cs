using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	internal static class PsmTexture
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int FromFile(PixelBufferType type, string fileName, bool mipmap, PixelFormat format, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int FromImage(PixelBufferType type, byte[] fileImage, bool mipmap, PixelFormat format, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetFilter(int handle, ref TextureFilter filter);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetWrap(int handle, ref TextureWrap wrap);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetMaxAnisotropy(int handle, float anisotropy);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetPixels(int handle, int level, TextureCubeFace cubeFace, Array pixels, PixelFormat format, int offset, int pitch, int dx, int dy, int dw, int dh);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GenerateMipmap(int handle);
	}
}
