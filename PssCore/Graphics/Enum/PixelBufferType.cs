using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Pixel buffer type</summary>
	public enum PixelBufferType : uint
	{
		/// <summary>None</summary>
		None,
		/// <summary>2D texture</summary>
		Texture2D,
		/// <summary>Cube texture</summary>
		TextureCube,
		/// <summary>Color buffer</summary>
		ColorBuffer,
		/// <summary>Depth buffer</summary>
		DepthBuffer
	}
}
