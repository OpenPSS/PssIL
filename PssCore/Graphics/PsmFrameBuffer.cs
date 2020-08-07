using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	internal static class PsmFrameBuffer
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Create(out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Delete(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int AddRef(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetColorTarget(int handle, int colorBuffer, int level, TextureCubeFace cubeFace, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetDepthTarget(int handle, int depthBuffer, int level, TextureCubeFace cubeFace, out int result);
	}
}
