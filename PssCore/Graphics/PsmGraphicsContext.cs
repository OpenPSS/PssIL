using System;
using System.Runtime.CompilerServices;
using System.Security;
using Sce.PlayStation.Core.Imaging;

namespace Sce.PlayStation.Core.Graphics
{
	internal static class PsmGraphicsContext
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Create(int width, int height, PixelFormat colorFormat, PixelFormat depthFormat, MultiSampleMode multiSampleMode, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Delete(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Update(int handle, GraphicsUpdate update, ref GraphicsState state, int[] handles);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SwapBuffers(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Clear(int handle, ClearMask mask);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int DrawArrays(int handle, DrawMode mode, int first, int count, int repeat);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int DrawArrays2(int handle, Primitive[] primitives, int first, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int DrawArraysInstanced(int handle, DrawMode mode, int first, int count, int instFirst, int instCount);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int ReadPixels(int handle, byte[] pixels, PixelFormat format, int sx, int sy, int sw, int sh);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int ReadPixels2(int handle, int texture, int level, TextureCubeFace cubeFace, int dx, int dy, int sx, int sy, int sw, int sh);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetMaxScreenSize(out int width, out int height);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetScreenSizes(ImageSize[] sizes, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetScreenInfo(int handle, out int width, out int height, out PixelFormat colorFormat, out PixelFormat depthFormat, out MultiSampleMode multiSampleMode);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetCaps(int handle, out GraphicsCapsState caps);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetActiveScreen(int handle, int x, int y, int w, int h);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetVirtualScreen(int handle, int x, int y, int w, int h);
	}
}
