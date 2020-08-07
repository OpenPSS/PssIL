using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Multi-sample mode</summary>
	public enum MultiSampleMode : uint
	{
		/// <summary>No multi-sample</summary>
		None,
		/// <summary>Multi-sample x2</summary>
		Msaa2x,
		/// <summary>Multi-sample x4</summary>
		Msaa4x
	}
}
