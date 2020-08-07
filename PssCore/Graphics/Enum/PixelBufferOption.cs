using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Pixel buffer creation option</summary>
	[Flags]
	public enum PixelBufferOption : uint
	{
		/// <summary>None</summary>
		None = 0U,
		/// <summary>Possible to render</summary>
		Renderable = 1U
	}
}
