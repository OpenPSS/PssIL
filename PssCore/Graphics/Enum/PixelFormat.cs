using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Pixel format</summary>
	public enum PixelFormat : uint
	{
		/// <summary>None</summary>
		None,
		/// <summary>RGBA (byte)</summary>
		Rgba,
		/// <summary>RGBA (half float)</summary>
		RgbaH,
		/// <summary>RGBA (ushort 4:4:4:4)</summary>
		Rgba4444,
		/// <summary>RGBA (ushort 5:5:5:1)</summary>
		Rgba5551,
		/// <summary>RGB (ushort 5:6:5)</summary>
		Rgb565,
		/// <summary>Luminance and alpha (byte)</summary>
		LuminanceAlpha,
		/// <summary>Luminance and alpha (half float)</summary>
		LuminanceAlphaH,
		/// <summary>Luminance (byte)</summary>
		Luminance,
		/// <summary>Luminance (half float)</summary>
		LuminanceH,
		/// <summary>Alpha (byte)</summary>
		Alpha,
		/// <summary>Alpha (half float)</summary>
		AlphaH,
		/// <summary>Depth 16-bit</summary>
		Depth16,
		/// <summary>Depth 24-bit</summary>
		Depth24,
		/// <summary>Depth 16-bit stencil 8-bit</summary>
		Depth16Stencil8,
		/// <summary>Depth 24-bit stencil 8-bit</summary>
		Depth24Stencil8,
		/// <summary>S3TC compression texture (DXT1)</summary>
		Dxt1,
		/// <summary>S3TC compression texture (DXT2)</summary>
		Dxt2,
		/// <summary>S3TC compression texture (DXT3)</summary>
		Dxt3,
		/// <summary>S3TC compression texture (DXT4)</summary>
		Dxt4,
		/// <summary>S3TC compression texture (DXT5)</summary>
		Dxt5
	}
}
