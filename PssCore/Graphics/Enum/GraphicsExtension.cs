using System;

namespace Sce.PlayStation.Core.Graphics
{
	[Flags]
	internal enum GraphicsExtension : uint
	{
		None = 0U,
		DepthTexture = 1U,
		Texture3D = 2U,
		TextureNpot = 4U,
		TextureFilterAnisotropic = 8U,
		Rgb8Rgba8 = 16U,
		Depth24 = 32U,
		Depth32 = 64U,
		PackedDepthStencil = 128U,
		VertexHalfFloat = 256U,
		Vertex1010102 = 512U,
		TextureFloat = 1024U,
		TextureHalfFloat = 2048U,
		TextureFloatLinear = 4096U,
		TextureHalfFloatLinear = 8192U,
		Texture2101010Rev = 16384U
	}
}
