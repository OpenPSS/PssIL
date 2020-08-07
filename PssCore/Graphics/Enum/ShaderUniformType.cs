using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Uniform variable type</summary>
	public enum ShaderUniformType : uint
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
		Float4,
		/// <summary>2D matrix (float)</summary>
		Float2x2 = 273U,
		/// <summary>3D matrix (float)</summary>
		Float3x3 = 290U,
		/// <summary>4D matrix (float)</summary>
		Float4x4 = 307U,
		/// <summary>Scalar (int)</summary>
		Int = 1024U,
		/// <summary>2D vector (int)</summary>
		Int2,
		/// <summary>3D vector (int)</summary>
		Int3,
		/// <summary>4D vector (int)</summary>
		Int4,
		/// <summary>Scalar (bool)</summary>
		Bool = 768U,
		/// <summary>2D vector (bool)</summary>
		Bool2,
		/// <summary>3D vector (bool)</summary>
		Bool3,
		/// <summary>4D vector (bool)</summary>
		Bool4,
		/// <summary>2D texture sampler</summary>
		Sampler2D = 32769U,
		/// <summary>Cube texture sampler</summary>
		SamplerCube
	}
}
