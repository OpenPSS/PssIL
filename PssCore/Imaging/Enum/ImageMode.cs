using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Image mode (pixel format)</summary>
	public enum ImageMode : uint
	{
		/// <summary>8-bit for each RGBA, total 32-bit mode</summary>
		Rgba, /* 0 */
		/// <summary>Alpha-only 8-bit mode</summary>
		A /* 1 */
	}
}
