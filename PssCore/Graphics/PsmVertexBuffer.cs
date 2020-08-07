using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	internal static class PsmVertexBuffer
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Create(int vertexCount, int indexCount, int instDivisor, int option, VertexFormat[] formats, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Delete(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int AddRef(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetVertices(int handle, Array vertices, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetVertices2(int handle, int stream, Array vertices, VertexFormat format, ref Vector4 trans, ref Vector4 scale, int offset, int stride, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetIndices(int handle, ushort[] indices, int to, int from, int count);
	}
}
