using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing a cube texture</summary>
	public class TextureCube : Texture, IShallowCloneable
	{
		/// <summary>Creates a cube texture</summary>
		/// <param name="width">Texture width</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates the cube texture using the specified parameters. The texture width must have a power of 2. Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, AlphaH, Dxt1, Dxt2, Dxt3, Dxt4, or Dxt5 can be specified to the pixel format.</remarks>
		public TextureCube(int width, bool mipmap, PixelFormat format) : base(PixelBufferType.TextureCube, width, width, mipmap, format, PixelBufferOption.None, InternalOption.None) { }

		/// <summary>Creates a cube texture (with options)</summary>
		/// <param name="width">Texture width</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <param name="option">Pixel buffer creation option</param>
		/// <remarks>Creates the cube texture using the specified parameters. The texture width must have a power of 2. Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, AlphaH, Dxt1, Dxt2, Dxt3, Dxt4, or Dxt5 can be specified to the pixel format. However, if the Renderable option is specified, only Rgba, Rgba4444, Rgba5551, or Rgb565 can be specified.</remarks>
		public TextureCube(int width, bool mipmap, PixelFormat format, PixelBufferOption option) : base(PixelBufferType.TextureCube, width, width, mipmap, format, option, InternalOption.None) { }

		internal TextureCube(int width, bool mipmap, PixelFormat format, PixelBufferOption option, InternalOption option2) : base(PixelBufferType.TextureCube, width, width, mipmap, format, option, option2) { }

		/// <summary>Creates a cube texture (from a file)</summary>
		/// <param name="fileName">Filename</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <remarks>Creates a cube texture from a specified file. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported). The texture width must have a power of 2. The short side of the image must be a power of 2, and the long side must be 6 times the short side.
		/// <para>When a DDS file, the image must be a cubemap, and the mipmap argument is ignored.</para>
		/// </remarks>
		public TextureCube(string fileName, bool mipmap) : base(PixelBufferType.TextureCube, fileName, mipmap, PixelFormat.None) { }

		/// <summary>Creates a cube texture (from a file, with format conversion)</summary>
		/// <param name="fileName">Filename</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates a cube texture from a specified file. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported). The texture width must have a power of 2. The short side of the image must be a power of 2, and the long side must be 6 times the short side. Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, or AlphaH can be specified to the pixel format.
		/// <para>When a DDS file, the image must be a cubemap, and the mipmap and format arguments are ignored.</para>
		/// </remarks>
		public TextureCube(string fileName, bool mipmap, PixelFormat format) : base(PixelBufferType.TextureCube, fileName, mipmap, format) { }

		/// <summary>Creates a cube texture (from a file image)</summary>
		/// <param name="fileImage">File image</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <remarks>Creates a cube texture from a specified file image. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported). The texture width must have a power of 2. The short side of the image must be a power of 2, and the long side must be 6 times the short side.
		/// <para>When a DDS file, the image must be a cubemap, and the mipmap argument is ignored.</para>
		/// </remarks>
		public TextureCube(byte[] fileImage, bool mipmap) : base(PixelBufferType.TextureCube, fileImage, mipmap, PixelFormat.None) { }

		/// <summary>Creates a cube texture (from a file image, with format conversion)</summary>
		/// <param name="fileImage">File image</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Creates a cube texture from a specified file image. The usable file formats are DDS, PNG, JPG, BMP, and GIF (however, animated GIFs are not supported). The texture width must have a power of 2. The short side of the image must be a power of 2, and the long side must be 6 times the short side. Rgba, Rgba4444, Rgba5551, Rgb565, LuminanceAlpha, Luminance, Alpha, RgbaH, LuminanceAlphaH, LuminanceH, or AlphaH can be specified to the pixel format.
		/// <para>When a DDS file, the image must be a cubemap, and the mipmap and format arguments are ignored.</para>
		/// </remarks>
		public TextureCube(byte[] fileImage, bool mipmap, PixelFormat format) : base(PixelBufferType.TextureCube, fileImage, mipmap, format) { }

		/// <summary>Creates a copy of a cube texture</summary>
		/// <param name="texture">Cube texture</param>
		/// <remarks>Creates a copy of a cube texture. The 2 cube textures will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		protected TextureCube(TextureCube texture) : base(texture) { }

		/// <summary>Creates a copy of a cube texture</summary>
		/// <returns>Clones a cube texture</returns>
		/// <remarks>Creates a copy of a cube texture. The 2 cube textures will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public override object ShallowClone()
		{
			return new TextureCube(this);
		}

		/// <summary>Sets pixel data</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube surface</param>
		/// <param name="pixels">Pixel data</param>
		/// <remarks>Sets the pixel data to the cube surface of the specified mipmap level.
		/// <para>This overload sets data to all pixels of the specified mipmap level's cube surface. When the size of the array differs from the required size, an exception is thrown. When the array size is bigger than the required size, please use a different overload.</para></remarks>
		[SecuritySafeCritical]
		public void SetPixels(int level, TextureCubeFace cubeFace, Array pixels)
		{
			int num = PsmTexture.SetPixels(this.handle, level, cubeFace, pixels, PixelFormat.None, 0, 0, 0, 0, -1, -1);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
			}
		}

		/// <summary>Sets pixel data (with range)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube surface</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="dx">X coordinate of the transfer destination</param>
		/// <param name="dy">Y coordinate of the transfer destination</param>
		/// <param name="dw">Width of the transfer destination</param>
		/// <param name="dh">Height of the transfer destination</param>
		/// <remarks>Sets the pixel data to the cube surface of the specified mipmap level.
		/// <para>When the pixel format is DXT, the dx, dy, dw, and dh must be a multiple of 4.</para>
		/// </remarks>
		public void SetPixels(int level, TextureCubeFace cubeFace, Array pixels, int dx, int dy, int dw, int dh)
		{
			if (dw < 0 || dh < 0)
			{
				dh = (dw = int.MaxValue);
			}
			this.SetPixels(level, cubeFace, pixels, PixelFormat.None, 0, 0, dx, dy, dw, dh);
		}

		/// <summary>Sets pixel data (with byte offset)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube surface</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="offset">Byte offset of pixel data</param>
		/// <param name="pitch">Byte pitch of pixel data</param>
		/// <remarks>Sets the pixel data to the cube surface of the specified mipmap level.</remarks>
		public void SetPixels(int level, TextureCubeFace cubeFace, Array pixels, int offset, int pitch)
		{
			int mipmapWidth = base.GetMipmapWidth(level);
			int mipmapHeight = base.GetMipmapHeight(level);
			this.SetPixels(level, cubeFace, pixels, PixelFormat.None, offset, pitch, 0, 0, mipmapWidth, mipmapHeight);
		}

		/// <summary>Sets pixel data (with format conversion)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube surface</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="format">Pixel format</param>
		/// <remarks>Sets the pixel data to the cube surface of the specified mipmap level. Rgba or the same format as the texture can be specified to the pixel format.
		/// <para>Conversion of DXT pixel format is not supported.</para>
		/// </remarks>
		public void SetPixels(int level, TextureCubeFace cubeFace, Array pixels, PixelFormat format)
		{
			int mipmapWidth = base.GetMipmapWidth(level);
			int mipmapHeight = base.GetMipmapHeight(level);
			this.SetPixels(level, cubeFace, pixels, format, 0, 0, 0, 0, mipmapWidth, mipmapHeight);
		}

		/// <summary>Sets pixel data (with format conversion, with byte offset, with range)</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube surface</param>
		/// <param name="pixels">Pixel data</param>
		/// <param name="format">Pixel format</param>
		/// <param name="offset">Byte offset of pixel data</param>
		/// <param name="pitch">Byte pitch of pixel data</param>
		/// <param name="dx">X coordinate of the transfer destination</param>
		/// <param name="dy">Y coordinate of the transfer destination</param>
		/// <param name="dw">Width of the transfer destination</param>
		/// <param name="dh">Height of the transfer destination</param>
		/// <remarks>Sets the pixel data to the cube surface of the specified mipmap level. Rgba or the same format as the texture can be specified to the pixel format.
		/// <para>When the pixel format is DXT, the dx, dy, dw, and dh must be a multiple of 4. Conversion of DXT pixel format is not supported.</para>
		/// </remarks>
		[SecuritySafeCritical]
		public void SetPixels(int level, TextureCubeFace cubeFace, Array pixels, PixelFormat format, int offset, int pitch, int dx, int dy, int dw, int dh)
		{
			if (dw < 0 || dh < 0)
			{
				dh = (dw = int.MaxValue);
			}
			int num = PsmTexture.SetPixels(this.handle, level, cubeFace, pixels, format, offset, pitch, dx, dy, dw, dh);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
			}
		}

		/// <summary>Automatically creates a mipmap image</summary>
		/// <remarks>Automatically creates a mipmap image from the current zero level image. Nothing will be performed if mipmaps are not present.
		/// <para>When the pixel format is DXT, nothing will be performed.</para>
		/// </remarks>
		[SecuritySafeCritical]
		public void GenerateMipmap()
		{
			int num = PsmTexture.GenerateMipmap(this.handle);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
			}
		}
	}
}
