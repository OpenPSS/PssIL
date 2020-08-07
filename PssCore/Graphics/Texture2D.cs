using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing a 2D texture</summary>
	public class Texture2D : Texture, IShallowCloneable
	{
		/// <summary>Creates a 2D texture</summary>
		/// <param name="width">Texture width</param>
		/// <param name="height">Texture height</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates the 2D texture using the specified parameters. Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, AlphaH, Dxt1, Dxt2, Dxt3, Dxt4, or Dxt5 can be specified to the pixel format.
		/// <para>When the pixel format is DXT, the width and height must be a power of 2.</para>
		/// </remarks>
		public Texture2D(int width, int height, bool mipmap, PixelFormat format) : base(PixelBufferType.Texture2D, width, height, mipmap, format, PixelBufferOption.None, InternalOption.None) { }

		/// <summary>Creates a 2D texture (with options)</summary>
		/// <param name="width">Texture width</param>
		/// <param name="height">Texture height</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <param name="option">Pixel buffer creation option</param>
		/// <remarks>Creates the 2D texture using the specified parameters. Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, AlphaH, Dxt1, Dxt2, Dxt3, Dxt4, or Dxt5 can be specified to the pixel format. However, if the Renderable option is specified, only Rgba, Rgba4444, Rgba5551, or Rgb565 can be specified.
		/// <para>When the pixel format is DXT, the width and height must be a power of 2.</para>
		/// </remarks>
		public Texture2D(int width, int height, bool mipmap, PixelFormat format, PixelBufferOption option) : base(PixelBufferType.Texture2D, width, height, mipmap, format, option, InternalOption.None) { }

		internal Texture2D(int width, int height, bool mipmap, PixelFormat format, PixelBufferOption option, InternalOption option2) : base(PixelBufferType.Texture2D, width, height, mipmap, format, option, option2) { }

		/// <summary>Creates a 2D texture (from a file)</summary>
		/// <param name="fileName">Filename</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <remarks>Creates a 2D texture from a specified file. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported).
		/// <para>When a DDS file, the mipmap argument is ignored. When the pixel format is DXT, the width and height must be a power of 2.</para>
		/// </remarks>
		public Texture2D(string fileName, bool mipmap) : base(PixelBufferType.Texture2D, fileName, mipmap, PixelFormat.None) { }

		/// <summary>Creates a 2D texture (from a file, with format conversion)</summary>
		/// <param name="fileName">Filename</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates a 2D texture from a specified file. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported). Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, or AlphaH can be specified to the pixel format.
		/// <para>When a DDS file, the mipmap and format arguments are ignored. When the pixel format is DXT, the width and height must be a power of 2.</para>
		/// </remarks>
		public Texture2D(string fileName, bool mipmap, PixelFormat format) : base(PixelBufferType.Texture2D, fileName, mipmap, format) { }

		/// <summary>Creates a 2D texture (from a file image)</summary>
		/// <param name="fileImage">File image</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <remarks>Creates a 2D texture from a specified file image. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported).
		/// <para>When a DDS file, the mipmap arguments is ignored. When the pixel format is DXT, the width and height must be a power of 2.</para>
		/// </remarks>
		public Texture2D(byte[] fileImage, bool mipmap) : base(PixelBufferType.Texture2D, fileImage, mipmap, PixelFormat.None) { }

		/// <summary>Creates a 2D texture (from a file image, with format conversion)</summary>
		/// <param name="fileImage">File image</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates a 2D texture from a specified file image. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported). Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, or AlphaH can be specified to the pixel format.
		/// <para>When a DDS file, the mipmap and format arguments are ignored. When the pixel format is DXT, the width and height must be a power of 2.</para>
		/// </remarks>
		public Texture2D(byte[] fileImage, bool mipmap, PixelFormat format) : base(PixelBufferType.Texture2D, fileImage, mipmap, format) { }

		/// <summary>Creates a copy of a 2D texture</summary>
		/// <param name="texture">2D texture</param>
		/// <remarks>Creates a copy of the texture. The 2 2D textures will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		protected Texture2D(Texture2D texture) : base(texture) { }

		/// <summary>Creates a copy of a 2D texture</summary>
		/// <returns>Clones a 2D texture</returns>
		/// <remarks>Creates a copy of the texture. The 2 2D textures will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public override object ShallowClone()
		{
			return new Texture2D(this);
		}

		/// <summary>Sets pixel data</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="pixels">Pixel data</param>
		/// <remarks>Sets the pixel data to the specified mipmap level.
		/// <para>This overload sets data to all pixels of the specified mipmap level. When the size of the array differs from the required size, an exception is thrown. When the array size is bigger than the required size, please use a different overload.</para></remarks>
		[SecuritySafeCritical]
		public void SetPixels(int level, Array pixels)
		{
			int errorCode = PsmTexture.SetPixels(this.handle, level, TextureCubeFace.PositiveX, pixels, PixelFormat.None, 0, 0, 0, 0, -1, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets pixel data (with range)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="dx">X coordinate of the transfer destination</param>
		/// <param name="dy">Y coordinate of the transfer destination</param>
		/// <param name="dw">Width of the transfer destination</param>
		/// <param name="dh">Height of the transfer destination</param>
		/// <remarks>Sets the pixel data to the specified mipmap level.
		/// <para>When the pixel format is DXT, the dx, dy, dw, and dh must be a multiple of 4.</para>
		/// </remarks>
		public void SetPixels(int level, Array pixels, int dx, int dy, int dw, int dh)
		{
			if (dw < 0 || dh < 0)
			{
				dh = (dw = int.MaxValue);
			}
			this.SetPixels(level, pixels, PixelFormat.None, 0, 0, dx, dy, dw, dh);
		}

		/// <summary>Sets pixel data (with byte offset)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="offset">Byte offset of pixel data</param>
		/// <param name="pitch">Byte pitch of pixel data</param>
		/// <remarks>Sets the pixel data to the specified mipmap level.</remarks>
		public void SetPixels(int level, Array pixels, int offset, int pitch)
		{
			int mipmapWidth = base.GetMipmapWidth(level);
			int mipmapHeight = base.GetMipmapHeight(level);
			this.SetPixels(level, pixels, PixelFormat.None, offset, pitch, 0, 0, mipmapWidth, mipmapHeight);
		}

		/// <summary>Sets pixel data (with format conversion)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Sets the pixel data to the specified mipmap level. Rgba or the same format as the texture can be specified to the pixel format.
		/// <para>Conversion of DXT pixel format is not supported.</para>
		/// </remarks>
		public void SetPixels(int level, Array pixels, PixelFormat format)
		{
			int mipmapWidth = base.GetMipmapWidth(level);
			int mipmapHeight = base.GetMipmapHeight(level);
			this.SetPixels(level, pixels, format, 0, 0, 0, 0, mipmapWidth, mipmapHeight);
		}

		/// <summary>Sets pixel data (with format conversion, with byte offset, with range)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="format">Pixel format</param>
		/// <param name="offset">Byte offset of pixel data</param>
		/// <param name="pitch">Byte pitch of pixel data</param>
		/// <param name="dx">X coordinate of the transfer destination</param>
		/// <param name="dy">Y coordinate of the transfer destination</param>
		/// <param name="dw">Width of the transfer destination</param>
		/// <param name="dh">Height of the transfer destination</param>
		/// <remarks>Sets the pixel data to the specified mipmap level. Rgba or the same format as the texture can be specified to the pixel format.
		/// <para>When the pixel format is DXT, the dx, dy, dw, and dh must be a multiple of 4. Conversion of DXT pixel format is not supported.</para>
		/// </remarks>
		[SecuritySafeCritical]
		public void SetPixels(int level, Array pixels, PixelFormat format, int offset, int pitch, int dx, int dy, int dw, int dh)
		{
			if (dw < 0 || dh < 0)
			{
				dh = (dw = int.MaxValue);
			}
			int errorCode = PsmTexture.SetPixels(this.handle, level, TextureCubeFace.PositiveX, pixels, format, offset, pitch, dx, dy, dw, dh);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Automatically creates a mipmap image</summary>
		/// <remarks>Automatically creates a mipmap image from the current zero level image. Nothing will be performed if mipmaps are not present.
		/// <para>When the pixel format is DXT, nothing will be performed.</para>
		/// </remarks>
		[SecuritySafeCritical]
		public void GenerateMipmap()
		{
			int errorCode = PsmTexture.GenerateMipmap(this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}
	}
}
