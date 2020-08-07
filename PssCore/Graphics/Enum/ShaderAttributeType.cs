using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Attribute variable type</summary>
	public enum ShaderAttributeType : uint
	{
		/// <summary>None</summary>
		None,
		/// <summary>Scalar (float)</summary>
		Float = 256U,
		/// <summary>2D vector (float)</summary>
		Float2,
		/// <summary>3D vector (float)</summary>
		Float3,
		/// <summary>4D vector (float)</summary>
		Float4
	}
}
