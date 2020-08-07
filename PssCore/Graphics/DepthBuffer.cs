using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing the depth buffer</summary>
	public class DepthBuffer : PixelBuffer, IShallowCloneable
	{
		/// <summary>Creates a depth buffer</summary>
		/// <param name="width">Depth buffer width</param>
		/// <param name="height">Depth buffer height</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates a depth buffer. Depth16, Depth24, Depth16Stencil8, or Depth24Stencil8 can be specified to the pixel format. If the specified format cannot be used by the device, a separate format close to the specified value will be used.</remarks>
		public DepthBuffer(int width, int height, PixelFormat format) : base(PixelBufferType.DepthBuffer, width, height, false, format, PixelBufferOption.None, InternalOption.None)
		{
		}

		internal DepthBuffer(int width, int height, PixelFormat format, PixelBufferOption option, InternalOption option2) : base(PixelBufferType.DepthBuffer, width, height, false, format, option, option2)
		{
		}

		/// <summary>Creates a copy of the depth buffer</summary>
		/// <returns>Clones the depth buffer</returns>
		/// <remarks>Creates a copy of the depth buffer. The 2 depth buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		protected DepthBuffer(DepthBuffer buffer) : base(buffer)
		{
		}

		/// <summary>Creates a copy of the depth buffer</summary>
		/// <returns>The copy of depth buffer</returns>
		/// <remarks>Creates a copy of the depth buffer. The 2 depth buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public override object ShallowClone()
		{
			return new DepthBuffer(this);
		}
	}
}
