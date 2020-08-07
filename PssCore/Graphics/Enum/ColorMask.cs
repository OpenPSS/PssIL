using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Color write mask</summary>
	[Flags]
	public enum ColorMask : byte
	{
		/// <summary>None</summary>
		None = 0,
		/// <summary>R element</summary>
		R = 1,
		/// <summary>G element</summary>
		G = 2,
		/// <summary>B element</summary>
		B = 4,
		/// <summary>A element</summary>
		A = 8,
		/// <summary>RGB elements</summary>
		Rgb = 7,
		/// <summary>RGBA elements</summary>
		Rgba = 15
	}
}
