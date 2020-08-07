using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Cube texture surface</summary>
	public enum TextureCubeFace : byte
	{
		/// <summary>Positive direction on the X axis</summary>
		PositiveX,
		/// <summary>Negative direction on the X axis</summary>
		NegativeX,
		/// <summary>Positive direction on the Y axis</summary>
		PositiveY,
		/// <summary>Negative direction on the Y axis</summary>
		NegativeY,
		/// <summary>Positive direction on the Z axis</summary>
		PositiveZ,
		/// <summary>Negative direction on the Z axis</summary>
		NegativeZ
	}
}
