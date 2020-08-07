using System;

namespace Sce.PlayStation.Core.Graphics
{
	internal enum GraphicsUpdate : uint
	{
		None,
		Enable,
		Scissor,
		Viewport = 4U,
		DepthRange = 8U,
		ClearColor = 16U,
		ClearDepth = 32U,
		ClearStencil = 64U,
		CullFace = 128U,
		BlendFunc = 256U,
		DepthFunc = 512U,
		PolygonOffset = 1024U,
		StencilFunc = 2048U,
		StencilOp = 4096U,
		ColorMask = 8192U,
		LineWidth = 16384U,
		ShaderProgram = 16777216U,
		FrameBuffer = 33554432U,
		VertexBuffer = 805306368U,
		Texture = 3221225472U,
		VertexBuffer0 = 268435456U,
		VertexBufferN = 536870912U,
		Texture0 = 1073741824U,
		TextureN = 2147483648U
	}
}
