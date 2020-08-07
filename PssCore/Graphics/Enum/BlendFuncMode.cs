using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Alpha-blending function mode</summary>
	public enum BlendFuncMode : byte
	{
		/// <summary>Sc*Sf+Dc*Df</summary>
		Add,
		/// <summary>Sc*Sf-Dc*Df</summary>
		Subtract,
		/// <summary>Dc*Df-Sc*Sf</summary>
		ReverseSubtract
	}
}
