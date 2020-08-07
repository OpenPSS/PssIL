using System;
using Sce.PlayStation.Core.Imaging;

namespace Sce.PlayStation.Core.Graphics
{
	internal struct GraphicsState
	{
		/*
		 *	Global Variables
		 */
		
		public EnableMode Enable;
		public ImageRect Scissor;
		public ImageRect Viewport;
		public Vector2 DepthRange;
		public Vector4 ClearColor;
		public float ClearDepth;/// <summary>/
		public int ClearStencil;
		public CullFace CullFace;
		public BlendFunc BlendFuncRgb;
		public BlendFunc BlendFuncAlpha;
		public DepthFunc DepthFunc;
		public PolygonOffset PolygonOffset;
		public StencilFunc StencilFuncFront;
		public StencilOp StencilOpFront;
		public StencilFunc StencilFuncBack;
		public StencilOp StencilOpBack;
		public ColorMask ColorMask;
		public float LineWidth;
		
		public void Reset(FrameBuffer screen)
		{
			this.Enable = EnableMode.Dither;
			this.Scissor = new ImageRect(0, 0, screen.Width, screen.Height);
			this.Viewport = new ImageRect(0, 0, screen.Width, screen.Height);
			this.DepthRange = new Vector2(0f, 1f);
			this.ClearColor = new Vector4(0f, 0f, 0f, 0f);
			this.ClearDepth = 1f;
			this.ClearStencil = 0;
			this.CullFace = new CullFace(CullFaceMode.Back, CullFaceDirection.Ccw);
			this.BlendFuncRgb = new BlendFunc(BlendFuncMode.Add, BlendFuncFactor.One, BlendFuncFactor.Zero);
			this.BlendFuncAlpha = this.BlendFuncRgb;
			this.DepthFunc = new DepthFunc(DepthFuncMode.Less, true);
			this.PolygonOffset = new PolygonOffset(0f, 0f);
			this.StencilFuncFront = new StencilFunc(StencilFuncMode.Always, 0, 255, 255);
			this.StencilOpFront = new StencilOp(StencilOpMode.Keep, StencilOpMode.Keep, StencilOpMode.Keep);
			this.StencilFuncBack = this.StencilFuncFront;
			this.StencilOpBack = this.StencilOpFront;
			this.ColorMask = ColorMask.Rgba;
			this.LineWidth = 1f;
		}

	}
}
