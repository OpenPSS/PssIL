using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Stencil test operation mode</summary>
	public enum StencilOpMode : byte
	{
		/// <summary>Keeps the stencil buffer value</summary>
		Keep,
		/// <summary>Sets the stencil buffer value to 0</summary>
		Zero,
		/// <summary>Sets the stencil buffer value to the reference value</summary>
		Replace,
		/// <summary>Flips the stencil buffer value per bit</summary>
		Invert,
		/// <summary>Increments the stencil buffer value (clamped)</summary>
		Incr,
		/// <summary>Decrements the stencil buffer value (clamped)</summary>
		Decr,
		/// <summary>Increments the stencil buffer value (not clamped)</summary>
		IncrWrap,
		/// <summary>Decrements the stencil buffer value (not clamped)</summary>
		DecrWrap
	}
}
