using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing the color buffer</summary>
	public class ColorBuffer : PixelBuffer, IShallowCloneable
	{
		/// <summary>Creates a color buffer</summary>
		/// <param name="width">Color buffer width</param>
		/// <param name="height">Color buffer height</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates a color buffer. Rgba, Rgba4444, Rgba5551, or Rgb565 can be specified to the pixel format.</remarks>
		public ColorBuffer(int width, int height, PixelFormat format) : base(PixelBufferType.ColorBuffer, width, height, false, format, PixelBufferOption.None, InternalOption.None)
		{
		}

		internal ColorBuffer(int width, int height, PixelFormat format, PixelBufferOption option, InternalOption option2) : base(PixelBufferType.ColorBuffer, width, height, false, format, option, option2)
		{
		}

		/// <summary>Creates a copy of the color buffer</summary>
		/// <returns>Clones a color buffer</returns>
		/// <remarks>Creates a copy of the color buffer. The 2 color buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		protected ColorBuffer(ColorBuffer buffer) : base(buffer)
		{
		}

		/// <summary>Creates a copy of the color buffer</summary>
		/// <returns>Copy of the color buffer</returns>
		/// <remarks>Creates a copy of the color buffer. The 2 color buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public override object ShallowClone()
		{
			return new ColorBuffer(this);
		}
	}
}
