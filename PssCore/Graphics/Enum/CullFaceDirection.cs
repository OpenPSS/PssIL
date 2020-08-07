using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Front direction for back-face culling</summary>
	public enum CullFaceDirection : byte
	{
		/// <summary>Clock-wise</summary>
		Cw,
		/// <summary>Counter clock-wise</summary>
		Ccw
	}
}
