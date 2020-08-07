using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Buffer clear mask</summary>
	[Flags]
	public enum ClearMask : uint
	{
		/// <summary>None</summary>
		None = 0U,
		/// <summary>Color buffer</summary>
		Color = 1U,
		/// <summary>Depth buffer</summary>
		Depth = 2U,
		/// <summary>Stencil buffer</summary>
		Stencil = 4U,
		/// <summary>All buffers</summary>
		All = 7U
	}
}
