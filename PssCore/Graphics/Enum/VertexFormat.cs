using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Vertex format</summary>
	public enum VertexFormat : uint
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
		/// <summary>Scalar (half float)</summary>
		Half = 512U,
		/// <summary>2D vector (half float)</summary>
		Half2,
		/// <summary>3D vector (half float)</summary>
		Half3,
		/// <summary>4D vector (half float)</summary>
		Half4,
		/// <summary>Scalar (short)</summary>
		Short = 1536U,
		/// <summary>2D vector (short)</summary>
		Short2,
		/// <summary>3D vector (short)</summary>
		Short3,
		/// <summary>4D vector (short)</summary>
		Short4,
		/// <summary>Scalar (ushort)</summary>
		UShort = 1792U,
		/// <summary>2D vector (ushort)</summary>
		UShort2,
		/// <summary>3D vector (ushort)</summary>
		UShort3,
		/// <summary>4D vector (ushort)</summary>
		UShort4,
		/// <summary>Scalar (sbyte)</summary>
		Byte = 2048U,
		/// <summary>2D vector (sbyte)</summary>
		Byte2,
		/// <summary>3D vector (sbyte)</summary>
		Byte3,
		/// <summary>4D vector (sbyte)</summary>
		Byte4,
		/// <summary>Scalar (byte)</summary>
		UByte = 2304U,
		/// <summary>2D vector (byte)</summary>
		UByte2,
		/// <summary>3D vector (byte)</summary>
		UByte3,
		/// <summary>4D vector (byte)</summary>
		UByte4,
		/// <summary>Scalar (normalized short)</summary>
		ShortN = 5632U,
		/// <summary>2D vector (normalized short)</summary>
		Short2N,
		/// <summary>3D vector (normalized short)</summary>
		Short3N,
		/// <summary>4D vector (normalized short)</summary>
		Short4N,
		/// <summary>Scalar (normalized ushort)</summary>
		UShortN = 5888U,
		/// <summary>2D vector (normalized ushort)</summary>
		UShort2N,
		/// <summary>3D vector (normalized ushort)</summary>
		UShort3N,
		/// <summary>4D vector (normalized ushort)</summary>
		UShort4N,
		/// <summary>Scalar (normalized sbyte)</summary>
		ByteN = 6144U,
		/// <summary>2D vector (normalized sbyte)</summary>
		Byte2N,
		/// <summary>3D vector (normalized sbyte)</summary>
		Byte3N,
		/// <summary>4D vector (normalized sbyte)</summary>
		Byte4N,
		/// <summary>Scalar (normalized byte)</summary>
		UByteN = 6400U,
		/// <summary>2D vector (normalized byte)</summary>
		UByte2N,
		/// <summary>3D vector (normalized byte)</summary>
		UByte3N,
		/// <summary>4D vector (normalized byte)</summary>
		UByte4N
	}
}
