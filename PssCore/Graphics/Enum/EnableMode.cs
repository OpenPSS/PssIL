using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Graphics feature to enable or disable</summary>
	[Flags]
	public enum EnableMode : uint
	{
		/// <summary>None</summary>
		None = 0U,
		/// <summary>Scissor test</summary>
		ScissorTest = 1U,
		/// <summary>Back-face culling</summary>
		CullFace = 2U,
		/// <summary>Alpha-blending</summary>
		Blend = 4U,
		/// <summary>Depth test</summary>
		DepthTest = 8U,
		/// <summary>Polygon offset</summary>
		PolygonOffsetFill = 16U,
		/// <summary>Stencil test</summary>
		StencilTest = 32U,
		/// <summary>Dithering</summary>
		Dither = 64U,
		/// <summary>All features</summary>
		All = 127U
	}
}
