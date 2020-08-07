using System;
using System.Security;
using Sce.PlayStation.Core.Imaging;

namespace Sce.PlayStation.Core.Graphics
{
	internal class ScreenBuffer : FrameBuffer
	{
		/*
		 *	Global Variables
		 */
				
		private ShaderProgram shaderProgram;
		private VertexBuffer vertexBuffer;
		private Texture2D colorTexture;
		private DepthBuffer depthBuffer;
		private static ushort[] indexData = new ushort[] {0, 1, 2, 2, 1, 3, 4, 5, 6, 6, 5, 7, 8, 9, 10, 10, 9, 11};
		private static float[] vertexData = new float[] {-1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, -1f, -1f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 1f, -1f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, -1f, 1f, 0f, 0f, 1f, 1f, 1f, 1f, 1f, -1f, -1f, 0f, 0f, 0f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, -1f, 0f, 1f, 0f, 1f, 1f, 1f, 1f, -1f, 1f, 0f, 1f, 1f, 0f, 0f, 0f, 1f, -1f, -1f, 0f, 1f, 1f, 0f, 0f, 0f, 1f, 1f, 1f, 0f, 1f, 1f, 0f, 0f, 0f, 1f, 1f, -1f, 0f, 1f, 1f, 0f, 0f, 0f, 1f};
		private static byte[] programData = new byte[] {88, 71, 67, 46, 53, 57, 46, 48, 48, 50, 83, 69, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 1, 0, 0, 0, 112, 0, 0, 0, 1, 0, 0, 0, 80, 0, 0, 0, 120, 1, 0, 0, 180, 6, 0, 0, 180, 6, 0, 0, 76, 7, 0, 0, 36, 14, 178, 41, 147, 110, 1, 42, 76, 225, 212, 75, 146, 23, 140, 205, byte.MaxValue, 174, 13, 16, 180, 6, 0, 0, 144, 0, 0, 0, 2, 0, 0, 0, 208, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 188, 6, 0, 0, 176, 0, 0, 0, 2, 0, 0, 0, 208, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 71, 67, 0, 0, 120, 1, 0, 0, 58, 1, 0, 0, 0, 0, 0, 0, 76, 83, 76, 71, 180, 2, 0, 0, 235, 1, 0, 0, 0, 0, 0, 0, 71, 67, 0, 0, 160, 4, 0, 0, 214, 0, 0, 0, 0, 0, 0, 0, 76, 83, 76, 71, 120, 5, 0, 0, 60, 1, 0, 0, 0, 0, 0, 0, 196, 6, 0, 0, 205, 6, 0, 0, 0, 0, 0, 0, 1, 128, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 214, 6, 0, 0, 225, 6, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 234, 6, 0, 0, 245, 6, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, byte.MaxValue, 6, 0, 0, 7, 7, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 17, 7, 0, 0, 28, 7, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 37, 7, 0, 0, 48, 7, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 58, 7, 0, 0, 66, 7, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 118, 111, 105, 100, 32, 109, 97, 105, 110, 40, 102, 108, 111, 97, 116, 52, 32, 105, 110, 32, 97, 95, 80, 111, 115, 105, 116, 105, 111, 110, 9, 58, 32, 80, 79, 83, 73, 84, 73, 79, 78, 44, 13, 10, 9, 9, 102, 108, 111, 97, 116, 50, 32, 105, 110, 32, 97, 95, 84, 101, 120, 67, 111, 111, 114, 100, 9, 58, 32, 84, 69, 88, 67, 79, 79, 82, 68, 48, 44, 13, 10, 9, 9, 102, 108, 111, 97, 116, 52, 32, 105, 110, 32, 97, 95, 67, 111, 108, 111, 114, 32, 32, 32, 32, 32, 32, 32, 58, 32, 84, 69, 88, 67, 79, 79, 82, 68, 49, 44, 13, 10, 9, 9, 102, 108, 111, 97, 116, 52, 32, 111, 117, 116, 32, 118, 95, 80, 111, 115, 105, 116, 105, 111, 110, 9, 58, 32, 80, 79, 83, 73, 84, 73, 79, 78, 44, 13, 10, 9, 9, 102, 108, 111, 97, 116, 50, 32, 111, 117, 116, 32, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 9, 58, 32, 84, 69, 88, 67, 79, 79, 82, 68, 48, 44, 13, 10, 9, 9, 102, 108, 111, 97, 116, 52, 32, 111, 117, 116, 32, 118, 95, 67, 111, 108, 111, 114, 9, 9, 58, 32, 84, 69, 88, 67, 79, 79, 82, 68, 49, 41, 13, 10, 123, 13, 10, 9, 118, 95, 80, 111, 115, 105, 116, 105, 111, 110, 32, 61, 32, 97, 95, 80, 111, 115, 105, 116, 105, 111, 110, 59, 13, 10, 9, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 32, 61, 32, 97, 95, 84, 101, 120, 67, 111, 111, 114, 100, 59, 13, 10, 9, 118, 95, 67, 111, 108, 111, 114, 32, 61, 32, 97, 95, 67, 111, 108, 111, 114, 59, 13, 10, 125, 13, 10, 0, 0, 0, 13, 10, 13, 10, 32, 47, 47, 32, 109, 97, 105, 110, 32, 112, 114, 111, 99, 101, 100, 117, 114, 101, 44, 32, 116, 104, 101, 32, 111, 114, 105, 103, 105, 110, 97, 108, 32, 110, 97, 109, 101, 32, 119, 97, 115, 32, 109, 97, 105, 110, 13, 10, 97, 116, 116, 114, 105, 98, 117, 116, 101, 32, 118, 101, 99, 52, 32, 97, 95, 80, 111, 115, 105, 116, 105, 111, 110, 59, 13, 10, 97, 116, 116, 114, 105, 98, 117, 116, 101, 32, 118, 101, 99, 50, 32, 97, 95, 84, 101, 120, 67, 111, 111, 114, 100, 59, 13, 10, 97, 116, 116, 114, 105, 98, 117, 116, 101, 32, 118, 101, 99, 52, 32, 97, 95, 67, 111, 108, 111, 114, 59, 13, 10, 118, 97, 114, 121, 105, 110, 103, 32, 118, 101, 99, 52, 32, 118, 95, 80, 111, 115, 105, 116, 105, 111, 110, 59, 13, 10, 118, 97, 114, 121, 105, 110, 103, 32, 118, 101, 99, 50, 32, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 59, 13, 10, 118, 97, 114, 121, 105, 110, 103, 32, 118, 101, 99, 52, 32, 118, 95, 67, 111, 108, 111, 114, 59, 13, 10, 118, 111, 105, 100, 32, 109, 97, 105, 110, 40, 41, 13, 10, 123, 13, 10, 13, 10, 32, 32, 32, 32, 118, 101, 99, 52, 32, 95, 118, 95, 80, 111, 115, 105, 116, 105, 111, 110, 59, 13, 10, 32, 32, 32, 32, 118, 101, 99, 50, 32, 95, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 59, 13, 10, 32, 32, 32, 32, 118, 101, 99, 52, 32, 95, 118, 95, 67, 111, 108, 111, 114, 59, 13, 10, 13, 10, 32, 32, 32, 32, 95, 118, 95, 80, 111, 115, 105, 116, 105, 111, 110, 32, 61, 32, 97, 95, 80, 111, 115, 105, 116, 105, 111, 110, 59, 13, 10, 32, 32, 32, 32, 95, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 32, 61, 32, 97, 95, 84, 101, 120, 67, 111, 111, 114, 100, 46, 120, 121, 59, 13, 10, 32, 32, 32, 32, 95, 118, 95, 67, 111, 108, 111, 114, 32, 61, 32, 97, 95, 67, 111, 108, 111, 114, 59, 13, 10, 32, 32, 32, 32, 118, 95, 67, 111, 108, 111, 114, 32, 61, 32, 97, 95, 67, 111, 108, 111, 114, 59, 13, 10, 32, 32, 32, 32, 103, 108, 95, 80, 111, 115, 105, 116, 105, 111, 110, 32, 61, 32, 97, 95, 80, 111, 115, 105, 116, 105, 111, 110, 59, 13, 10, 32, 32, 32, 32, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 46, 120, 121, 32, 61, 32, 97, 95, 84, 101, 120, 67, 111, 111, 114, 100, 46, 120, 121, 59, 13, 10, 125, 32, 47, 47, 32, 109, 97, 105, 110, 32, 101, 110, 100, 13, 10, 0, 0, 117, 110, 105, 102, 111, 114, 109, 32, 115, 97, 109, 112, 108, 101, 114, 50, 68, 32, 84, 101, 120, 116, 117, 114, 101, 48, 9, 9, 58, 32, 84, 69, 88, 85, 78, 73, 84, 48, 59, 13, 10, 13, 10, 118, 111, 105, 100, 32, 109, 97, 105, 110, 40, 102, 108, 111, 97, 116, 50, 32, 105, 110, 32, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 9, 58, 32, 84, 69, 88, 67, 79, 79, 82, 68, 48, 44, 13, 10, 9, 9, 102, 108, 111, 97, 116, 52, 32, 105, 110, 32, 118, 95, 67, 111, 108, 111, 114, 32, 32, 32, 32, 32, 32, 32, 58, 32, 84, 69, 88, 67, 79, 79, 82, 68, 49, 44, 13, 10, 9, 9, 102, 108, 111, 97, 116, 52, 32, 111, 117, 116, 32, 67, 111, 108, 111, 114, 9, 9, 58, 32, 67, 79, 76, 79, 82, 41, 13, 10, 123, 13, 10, 9, 67, 111, 108, 111, 114, 32, 61, 32, 116, 101, 120, 50, 68, 40, 84, 101, 120, 116, 117, 114, 101, 48, 44, 32, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 41, 32, 42, 32, 118, 95, 67, 111, 108, 111, 114, 59, 13, 10, 125, 13, 10, 0, 0, 0, 13, 10, 112, 114, 101, 99, 105, 115, 105, 111, 110, 32, 104, 105, 103, 104, 112, 32, 102, 108, 111, 97, 116, 59, 13, 10, 112, 114, 101, 99, 105, 115, 105, 111, 110, 32, 104, 105, 103, 104, 112, 32, 105, 110, 116, 59, 13, 10, 118, 97, 114, 121, 105, 110, 103, 32, 118, 101, 99, 50, 32, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 59, 13, 10, 118, 97, 114, 121, 105, 110, 103, 32, 118, 101, 99, 52, 32, 118, 95, 67, 111, 108, 111, 114, 59, 13, 10, 117, 110, 105, 102, 111, 114, 109, 32, 115, 97, 109, 112, 108, 101, 114, 50, 68, 32, 84, 101, 120, 116, 117, 114, 101, 48, 59, 13, 10, 13, 10, 32, 47, 47, 32, 109, 97, 105, 110, 32, 112, 114, 111, 99, 101, 100, 117, 114, 101, 44, 32, 116, 104, 101, 32, 111, 114, 105, 103, 105, 110, 97, 108, 32, 110, 97, 109, 101, 32, 119, 97, 115, 32, 109, 97, 105, 110, 13, 10, 118, 111, 105, 100, 32, 109, 97, 105, 110, 40, 41, 13, 10, 123, 13, 10, 13, 10, 32, 32, 32, 32, 118, 101, 99, 52, 32, 95, 67, 111, 108, 111, 114, 59, 13, 10, 13, 10, 32, 32, 32, 32, 95, 67, 111, 108, 111, 114, 32, 61, 32, 116, 101, 120, 116, 117, 114, 101, 50, 68, 40, 84, 101, 120, 116, 117, 114, 101, 48, 44, 32, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 46, 120, 121, 41, 42, 118, 95, 67, 111, 108, 111, 114, 59, 13, 10, 32, 32, 32, 32, 103, 108, 95, 70, 114, 97, 103, 67, 111, 108, 111, 114, 32, 61, 32, 95, 67, 111, 108, 111, 114, 59, 13, 10, 125, 32, 47, 47, 32, 109, 97, 105, 110, 32, 101, 110, 100, 13, 10, 0, 85, 112, 115, 99, 97, 108, 101, 0, 85, 112, 115, 99, 97, 108, 101, 0, 84, 101, 120, 116, 117, 114, 101, 48, 0, 84, 69, 88, 85, 78, 73, 84, 48, 0, 97, 95, 80, 111, 115, 105, 116, 105, 111, 110, 0, 80, 79, 83, 73, 84, 73, 79, 78, 0, 97, 95, 84, 101, 120, 67, 111, 111, 114, 100, 0, 84, 69, 88, 67, 79, 79, 82, 68, 48, 0, 97, 95, 67, 111, 108, 111, 114, 0, 84, 69, 88, 67, 79, 79, 82, 68, 49, 0, 118, 95, 80, 111, 115, 105, 116, 105, 111, 110, 0, 80, 79, 83, 73, 84, 73, 79, 78, 0, 118, 95, 84, 101, 120, 67, 111, 111, 114, 100, 0, 84, 69, 88, 67, 79, 79, 82, 68, 48, 0, 118, 95, 67, 111, 108, 111, 114, 0, 84, 69, 88, 67, 79, 79, 82, 68, 49, 0};
			
		
		public ScreenBuffer(GraphicsContext graphics, FrameBuffer deviceScreen, int width, int height, PixelFormat colorFormat, PixelFormat depthFormat, MultiSampleMode multiSampleMode)
		{
			if (width == 0)
			{
				width = deviceScreen.Width;
			}
			if (height == 0)
			{
				height = deviceScreen.Height;
			}
			colorFormat = deviceScreen.ColorFormat;
			depthFormat = deviceScreen.DepthFormat;
			this.AdjustAspect(graphics, deviceScreen, width, height);
			this.shaderProgram = new ShaderProgram(ScreenBuffer.programData);
			this.vertexBuffer = new VertexBuffer(12, 18, new VertexFormat[]
			{
				VertexFormat.Float3,
				VertexFormat.Float2,
				VertexFormat.Float4
			});
			this.vertexBuffer.SetVertices(ScreenBuffer.vertexData);
			this.vertexBuffer.SetIndices(ScreenBuffer.indexData);
			this.colorTexture = new Texture2D(width, height, false, colorFormat, PixelBufferOption.Renderable, InternalOption.SystemResource);
			this.depthBuffer = new DepthBuffer(width, height, depthFormat, PixelBufferOption.Renderable, InternalOption.SystemResource);
			base.SetColorTarget(this.colorTexture, 0);
			base.SetDepthTarget(this.depthBuffer);
		}

		public new void Dispose()
		{
			this.Dispose(true);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.shaderProgram != null)
				{
					this.shaderProgram.Dispose();
				}
				if (this.vertexBuffer != null)
				{
					this.vertexBuffer.Dispose();
				}
				if (this.colorTexture != null)
				{
					this.colorTexture.Dispose();
				}
				if (this.depthBuffer != null)
				{
					this.depthBuffer.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		public void Present(GraphicsContext graphics, FrameBuffer deviceScreen)
		{
			EnableMode enableMode = graphics.GetEnableMode();
			ImageRect viewport = graphics.GetViewport();
			ColorMask colorMask = graphics.GetColorMask();
			FrameBuffer frameBuffer = graphics.GetFrameBuffer();
			ShaderProgram shaderProgram = graphics.GetShaderProgram();
			VertexBuffer buffer = graphics.GetVertexBuffer(0);
			Texture texture = graphics.GetTexture(0);
			graphics.SetEnableMode(EnableMode.None);
			graphics.SetViewport(deviceScreen.Rectangle);
			graphics.SetColorMask(ColorMask.Rgba);
			graphics.SetFrameBuffer(deviceScreen);
			graphics.SetShaderProgram(this.shaderProgram);
			graphics.SetVertexBuffer(0, this.vertexBuffer);
			graphics.SetTexture(0, this.colorTexture);
			graphics.DrawArrays(DrawMode.Triangles, 0, 18);
			graphics.SetEnableMode(enableMode);
			graphics.SetViewport(viewport);
			graphics.SetColorMask(colorMask);
			graphics.SetFrameBuffer(frameBuffer);
			graphics.SetShaderProgram(shaderProgram);
			graphics.SetVertexBuffer(0, buffer);
			graphics.SetTexture(0, texture);
		}

		[SecuritySafeCritical]
		private void AdjustAspect(GraphicsContext graphics, FrameBuffer deviceScreen, int width, int height)
		{
			int endPointY = 0;
			int endPointX = 0;
			int w = width;
			int h = height;
			int screenWidth = deviceScreen.Width;
			int screenHeight = deviceScreen.Height;
			ushort[] vertexData = new ushort[4];
			float multip;
			if (ScreenBuffer.FitRect(screenWidth, screenHeight, ref width, ref height))
			{
				endPointY = (screenWidth - width) / 2;
				multip = (float)endPointY / (float)screenWidth * 2f - 1f;
				vertexData[0] = 18;
				vertexData[1] = 27;
				vertexData[2] = 36;
				vertexData[3] = 45;
			}
			else
			{
				endPointX = (screenHeight - height) / 2;
				multip = (float)endPointX / (float)screenHeight * -2f + 1f;
				vertexData[0] = 10;
				vertexData[1] = 28;
				vertexData[2] = 37;
				vertexData[3] = 55;
			}
			for (int i = 0; i < 4; i++)
			{
				ScreenBuffer.vertexData[(int)vertexData[i]] = multip;
				ScreenBuffer.vertexData[(int)(vertexData[i] + 36)] = -multip;
			}
			PsmGraphicsContext.SetActiveScreen(graphics.handle, endPointY, endPointX, width, height);
			PsmGraphicsContext.SetVirtualScreen(graphics.handle, 0, 0, w, h);
		}

		[SecuritySafeCritical]
		public static bool NeedVirtualScreen(FrameBuffer screen, ref int width, ref int height)
		{
			if (width == 0)
			{
				width = screen.Width;
			}
			if (height == 0)
			{
				height = screen.Height;
			}
			int screenWidth;
			int screenHeight;
			PsmGraphicsContext.GetMaxScreenSize(out screenWidth, out screenHeight);
			if (width > screenWidth || height > screenHeight)
			{
				ScreenBuffer.FitRect(screenWidth, screenHeight, ref width, ref height);
			}
			return screen.Width != width || screen.Height != height;
		}

		public static bool FitRect(int fw, int fh, ref int width, ref int height)
		{
			bool result;
			if (fh * width <= fw * height)
			{
				width = (fh * width + height - 1) / height;
				height = fh;
				result = true;
			}
			else
			{
				height = (fw * height + width - 1) / width;
				width = fw;
				result = false;
			}
			return result;
		}
	}
}
