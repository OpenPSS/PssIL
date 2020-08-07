using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Alpha-blending function coefficient</summary>
	public enum BlendFuncFactor : byte
	{
		/// <summary>( 0, 0, 0, 0 )</summary>
		Zero,
		/// <summary>( 1, 1, 1, 1 )</summary>
		One,
		/// <summary>( Rs, Gs, Bs, As )</summary>
		SrcColor,
		/// <summary>( 1-Rs, 1-Gs, 1-Bs, 1-As )</summary>
		OneMinusSrcColor,
		/// <summary>( As, As, As, As )</summary>
		SrcAlpha,
		/// <summary>( 1-As, 1-As, 1-As, 1-As )</summary>
		OneMinusSrcAlpha,
		/// <summary>( Rd, Gd, Bd, Ad )</summary>
		DstColor,
		/// <summary>( 1-Rd, 1-Gd, 1-Bd, 1-Ad )</summary>
		OneMinusDstColor,
		/// <summary>( Ad, Ad, Ad, Ad )</summary>
		DstAlpha,
		/// <summary>( 1-Ad, 1-Ad, 1-Ad, 1-Ad )</summary>
		OneMinusDstAlpha,
		/// <summary>( min(As,1-Ad), min(As,1-Ad), min(As,1-Ad), 1 )</summary>
		SrcAlphaSaturate
	}
}
