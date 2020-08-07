using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing the vertex buffer</summary>
	public class VertexBuffer : IDisposable, IShallowCloneable
	{
		/*
		 *	Global Variables
		 */
		
		private static Vector4 zero = new Vector4(0f, 0f, 0f, 0f);
		private static Vector4 one = new Vector4(1f, 1f, 1f, 1f);
		internal int handle;
		private VertexFormat[] formats;
		private int vertexCount;
		private int indexCount;
		private int instDivisor;
		
		/// <summary>Creates the vertex buffer</summary>
		/// <param name="vertexCount">Number of vertices (no vertex array if 0)</param>
		/// <param name="formats">Vertex format</param>
		/// <remarks>Creates a vertex buffer. Specify the datatype for each vertex stream for the vertex format.</remarks>
		public VertexBuffer(int vertexCount, params VertexFormat[] formats) : this(vertexCount, 0, 0, formats) { }

		/// <summary>Creates a vertex buffer (with an index array)</summary>
		/// <param name="vertexCount">Number of vertices (no vertex array if 0)</param>
		/// <param name="indexCount">Number of indices (no index array if 0)</param>
		/// <param name="formats">Vertex format</param>
		/// <remarks>Creates a vertex buffer. Index arrays can be used by specifying the number of indices. Specify the datatype for each vertex stream for the vertex format.</remarks>
		public VertexBuffer(int vertexCount, int indexCount, params VertexFormat[] formats) : this(vertexCount, indexCount, 0, formats) { }

		/// <summary>Creates a vertex buffer (with an index array, with an instance divisor)</summary>
		/// <param name="vertexCount">Number of vertices (no vertex array if 0)</param>
		/// <param name="indexCount">Number of indices (no index array if 0)</param>
		/// <param name="instDivisor">Instance divisor (0 or 1)</param>
		/// <param name="formats">Vertex format</param>
		/// <remarks>Creates a vertex buffer. Index arrays can be used by specifying the number of indices. Specify the datatype for each vertex stream for the vertex format.
		/// <para>The instance divisor will be used to render the instance. For details, refer to GraphicsContext.DrawArraysInstanced().</para></remarks>
		[SecuritySafeCritical]
		public VertexBuffer(int vertexCount, int indexCount, int instDivisor, params VertexFormat[] formats)
		{
			int errorCode = PsmVertexBuffer.Create(vertexCount, indexCount, instDivisor, 0, formats, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.formats = formats;
			this.vertexCount = vertexCount;
			this.indexCount = indexCount;
			this.instDivisor = instDivisor;
		}

		/// <summary>Creates a copy of the vertex buffer</summary>
		/// <param name="buffer">Vertex buffer</param>
		/// <remarks>Creates a copy of the vertex buffer. The 2 vertex buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		[SecuritySafeCritical]
		protected VertexBuffer(VertexBuffer buffer)
		{
			int errorCode = PsmVertexBuffer.AddRef(buffer.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.handle = buffer.handle;
			this.formats = buffer.formats;
			this.vertexCount = buffer.vertexCount;
			this.indexCount = buffer.indexCount;
		}

		/// <summary>Creates a copy of the vertex buffer</summary>
		/// <returns>Clones the vertex buffer</returns>
		/// <remarks>Creates a copy of the vertex buffer. The 2 vertex buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public virtual object ShallowClone()
		{
			return new VertexBuffer(this);
		}

		/// <summary>Deletes the vertex buffer</summary>
		~VertexBuffer()
		{
			this.Dispose(false);
		}

		/// <summary>Frees the unmanaged resources of the vertex buffer</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			PsmVertexBuffer.Delete(this.handle);
			this.handle = 0;
		}

		/// <summary>Vertex format</summary>
		public VertexFormat[] Formats
		{
			get
			{
				return this.formats;
			}
		}

		/// <summary>Number of vertices</summary>
		public int VertexCount
		{
			get
			{
				return this.vertexCount;
			}
		}

		/// <summary>Number of indices</summary>
		public int IndexCount
		{
			get
			{
				return this.indexCount;
			}
		}

		/// <summary>Number of streams</summary>
		public int StreamCount
		{
			get
			{
				return this.formats.Length;
			}
		}

		/// <summary>Instance divisor</summary>
		public int InstanceDivisor
		{
			get
			{
				return this.instDivisor;
			}
		}

		/// <summary>Sets vertex data</summary>
		/// <param name="vertices">Vertex data</param>
		/// <remarks>Sets vertex data. Specify the vertex data in interleaved format.
		/// <para>This overload sets data to all vertices. When the size of the array differs from the required size, an exception is thrown. When the array size is bigger than the required size, please use a different overload.</para></remarks>
		[SecuritySafeCritical]
		public void SetVertices(Array vertices)
		{
			int errorCode = PsmVertexBuffer.SetVertices(this.handle, vertices, 0, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets vertex data (with range)</summary>
		/// <param name="vertices">Vertex data</param>
		/// <param name="to">Transfer destination vertex number</param>
		/// <param name="from">Transfer source vertex number</param>
		/// <param name="count">Number of vertices to be transferred</param>
		/// <remarks>Sets vertex data. Specify the vertex data in interleaved format.</remarks>
		[SecuritySafeCritical]
		public void SetVertices(Array vertices, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmVertexBuffer.SetVertices(this.handle, vertices, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets vertex data (for single stream)</summary>
		/// <param name="stream">Stream number (0 to StreamCount-1)</param>
		/// <param name="vertices">Vertex data</param>
		/// <remarks>Sets the vertex data to a specified stream.
		/// <para>This overload sets data to all vertices. When the size of the array differs from the required size, an exception is thrown. When the array size is bigger than the required size, please use a different overload.</para></remarks>
		[SecuritySafeCritical]
		public void SetVertices(int stream, Array vertices)
		{
			int errorCode = PsmVertexBuffer.SetVertices2(this.handle, stream, vertices, VertexFormat.None, ref VertexBuffer.zero, ref VertexBuffer.one, 0, 0, 0, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets vertex data (for single stream, with range)</summary>
		/// <param name="stream">Stream number (0 to StreamCount-1)</param>
		/// <param name="vertices">Vertex data</param>
		/// <param name="to">Transfer destination vertex number</param>
		/// <param name="from">Transfer source vertex number</param>
		/// <param name="count">Number of vertices to be transferred</param>
		/// <remarks>Sets the vertex data to a specified stream.</remarks>
		[SecuritySafeCritical]
		public void SetVertices(int stream, Array vertices, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmVertexBuffer.SetVertices2(this.handle, stream, vertices, VertexFormat.None, ref VertexBuffer.zero, ref VertexBuffer.one, 0, 0, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets vertex data (for single stream, with byte offset)</summary>
		/// <param name="stream">Stream number (0 to StreamCount-1)</param>
		/// <param name="vertices">Vertex data</param>
		/// <param name="offset">Byte offset of vertex data</param>
		/// <param name="stride">Byte stride of vertex data</param>
		/// <remarks>Sets the vertex data to a specified stream.</remarks>
		[SecuritySafeCritical]
		public void SetVertices(int stream, Array vertices, int offset, int stride)
		{
			int errorCode = PsmVertexBuffer.SetVertices2(this.handle, stream, vertices, VertexFormat.None, ref VertexBuffer.zero, ref VertexBuffer.one, offset, stride, 0, 0, this.vertexCount);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets vertex data (for single stream, with format conversion)</summary>
		/// <param name="stream">Stream number (0 to StreamCount-1)</param>
		/// <param name="vertices">Vertex data</param>
		/// <param name="format">Vertex format</param>
		/// <param name="trans">Translation value</param>
		/// <param name="scale">Scale value</param>
		/// <remarks>Sets the vertex data to a specified stream. The same format as the vertex buffer or the float vector format of the same dimensionality can be specified to the vertex format. When specifying the float vector format to the vertex format, the vertex data can be converted using the (vertex-trans)/scale formula. </remarks>
		[SecuritySafeCritical]
		public void SetVertices(int stream, Array vertices, VertexFormat format, Vector4 trans, Vector4 scale)
		{
			int errorCode = PsmVertexBuffer.SetVertices2(this.handle, stream, vertices, format, ref trans, ref scale, 0, 0, 0, 0, this.vertexCount);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets vertex data (for single stream, with format conversion, with byte offset, with range)</summary>
		/// <param name="stream">Stream number (0 to StreamCount-1)</param>
		/// <param name="vertices">Vertex data</param>
		/// <param name="format">Vertex format</param>
		/// <param name="trans">Translation value</param>
		/// <param name="scale">Scale value</param>
		/// <param name="offset">Byte offset of vertex data</param>
		/// <param name="stride">Byte stride of vertex data</param>
		/// <param name="to">Transfer destination vertex number</param>
		/// <param name="from">Transfer source vertex number</param>
		/// <param name="count">Number of vertices to be transferred</param>
		/// <remarks>Sets the vertex data to a specified stream. The same format as the vertex buffer or the float vector format of the same dimensionality can be specified to the vertex format. When specifying the float vector format to the vertex format, the vertex data can be converted using the (vertex-trans)/scale formula. </remarks>
		[SecuritySafeCritical]
		public void SetVertices(int stream, Array vertices, VertexFormat format, Vector4 trans, Vector4 scale, int offset, int stride, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmVertexBuffer.SetVertices2(this.handle, stream, vertices, format, ref trans, ref scale, offset, stride, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets index data</summary>
		/// <param name="indices">Index data</param>
		/// <remarks>Sets index data.
		/// <para>This overload sets data to all indices. When the size of the array differs from the required size, an exception is thrown. When the array size is bigger than the required size, please use a different overload.</para></remarks>
		[SecuritySafeCritical]
		public void SetIndices(ushort[] indices)
		{
			int errorCode = PsmVertexBuffer.SetIndices(this.handle, indices, 0, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets index data (with range)</summary>
		/// <param name="indices">Index data</param>
		/// <param name="to">Transfer destination index number</param>
		/// <param name="from">Transfer source index number</param>
		/// <param name="count">Number of indices to be transferred</param>
		/// <remarks>Sets index data.</remarks>
		[SecuritySafeCritical]
		public void SetIndices(ushort[] indices, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmVertexBuffer.SetIndices(this.handle, indices, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}
	}
}
