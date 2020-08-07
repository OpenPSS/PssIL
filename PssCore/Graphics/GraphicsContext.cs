using System;
using System.Security;
using Sce.PlayStation.Core.Imaging;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing the graphics context</summary>
	public class GraphicsContext : IDisposable
	{
		/*
		 *	Global Variables
		 */
		
		internal int handle;
		private ShaderProgram shaderProgram;
		private VertexBuffer[] vertexBuffers = new VertexBuffer[4];
		private Texture[] textures = new Texture[8];
		private FrameBuffer frameBuffer;
		private static ImageSize[] screenSizes;
		private FrameBuffer screen;
		private GraphicsCaps caps;
		private static GraphicsUpdate notifyUpdate;
		private GraphicsState state;
		private int[] handles = new int[16];
		private ScreenBuffer virtualScreen;
		private FrameBuffer deviceScreen;
		
		/// <summary>Creates the graphics context</summary>
		/// <remarks>Creates the graphics context using standard settings. Note that multiple graphics context cannot be created.</remarks>
		public GraphicsContext() : this(0, 0, PixelFormat.None, PixelFormat.None, MultiSampleMode.None) { }

		/// <summary>Creates the graphics context (with screen parameters)</summary>
		/// <param name="width">Screen width (default if 0)</param>
		/// <param name="height">Screen height (default if 0)</param>
		/// <param name="colorFormat">Screen color format (default if PixelFormat.None)</param>
		/// <param name="depthFormat">Screen depth format (default if PixelFormat.None)</param>
		/// <param name="multiSampleMode">Screen multisample mode (default if MultiSampleMode.None)</param>
		/// <remarks>Creates the graphics context using the specified parameters. Rgba, Rgba4444, Rgba5551, or Rgb565 can be specified to the color format. Depth16, Depth24, Depth16Stencil8, or Depth24Stencil8 can be specified to the depth format. Note that multiple graphics context cannot be created.
		/// <para>When the specified screen size differs from the display resolution of the device, a virtual screen of the specified size is created and the rendered content will be scaled and displayed. The screen's aspect ratio will be maintained and a pillar box or letter box will be displayed as necessary.</para><para>The screen size is restricted to the maximum size or lower. The default value for the maximum size is 1280x800. The maximum size can be specified with PublishingUtility. Correct operation is requested of applications even when the screen size is equivalent to the maximum size.</para><para>If the specified format cannot be used by the device, a separate format close to the specified value will be used.</para></remarks>
		[SecuritySafeCritical]
		public GraphicsContext(int width, int height, PixelFormat colorFormat, PixelFormat depthFormat, MultiSampleMode multiSampleMode)
		{
			int errorCode = PsmGraphicsContext.Create(width, height, colorFormat, depthFormat, multiSampleMode, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.caps = new GraphicsCaps(this);
			this.screen = (this.deviceScreen = new FrameBuffer(this));
			if (ScreenBuffer.NeedVirtualScreen(this.screen, ref width, ref height))
			{
				this.screen = (this.virtualScreen = new ScreenBuffer(this, this.deviceScreen, width, height, colorFormat, depthFormat, multiSampleMode));
				GraphicsContext.notifyUpdate |= (GraphicsUpdate)6U;
			}
			this.SetFrameBuffer(null);
			this.state.Reset(this.screen);
			GraphicsContext.notifyUpdate |= GraphicsUpdate.Viewport;
		}

		/// <summary>Deletes the graphics context</summary>
		~GraphicsContext()
		{
			this.Dispose(false);
		}

		/// <summary>Frees unmanaged resources of the graphics context</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.virtualScreen != null)
				{
					this.virtualScreen.Dispose();
				}
				this.virtualScreen = null;
			}
			PsmGraphicsContext.Delete(this.handle);
			this.handle = 0;
		}

		/// <summary>Array of the screen size that can be specified upon initialization</summary>
		/// <remarks>This is used to determine the screen size to be specified when creating the graphics context. This is a static property, and it can be used even before creating the graphics context.</remarks>
		public static ImageSize[] ScreenSizes
		{
			get
			{
				return GraphicsContext.screenSizes;
			}
		}

		/// <summary>Frame buffer representing the default screen</summary>
		/// <remarks>This is used to set the default screen to the frame buffer and obtain the screen size and pixel format. This frame buffer is read-only, and the color target and depth target cannot be changed.</remarks>
		public FrameBuffer Screen
		{
			get
			{
				return this.screen;
			}
		}

		/// <summary>Class representing the graphics capacity</summary>
		/// <remarks>This is used to obtain the allowable range of the parameters and supported extensions.</remarks>
		public GraphicsCaps Caps
		{
			get
			{
				return this.caps;
			}
		}

		/// <summary>Updates the screen</summary>
		[SecuritySafeCritical]
		public void SwapBuffers()
		{
			if (this.virtualScreen != null)
			{
				this.virtualScreen.Present(this, this.deviceScreen);
			}
			int errorCode = PsmGraphicsContext.SwapBuffers(this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			GraphicsContext.notifyUpdate |= GraphicsUpdate.Viewport;
		}

		/// <summary>Clears the frame buffer</summary>
		public void Clear()
		{
			this.Clear(ClearMask.All);
		}

		/// <summary>Clears the frame buffer (with mask)</summary>
		/// <param name="mask">Buffer clear mask</param>
		[SecuritySafeCritical]
		public void Clear(ClearMask mask)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.Clear(this.handle, mask);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Renders the primitive</summary>
		/// <param name="mode">Primitive rendering mode</param>
		/// <param name="first">Starting vertex of the primitive</param>
		/// <param name="count">Number of vertices in the primitive</param>
		[SecuritySafeCritical]
		public void DrawArrays(DrawMode mode, int first, int count)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.DrawArrays(this.handle, mode, first, count, 1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Renders the primitive (for multiple primitives)</summary>
		/// <param name="mode">Primitive rendering mode</param>
		/// <param name="first">Starting vertex of the primitive</param>
		/// <param name="count">Number of vertices in the primitive</param>
		/// <param name="repeat">Number of primitives</param>
		/// <remarks>Renders multiple primitives.</remarks>
		/// \image html image/graphics_draw_multiple.png
		[SecuritySafeCritical]
		public void DrawArrays(DrawMode mode, int first, int count, int repeat)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.DrawArrays(this.handle, mode, first, count, repeat);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Renders the primitive (for a primitive array)</summary>
		/// <param name="primitives">Primitive array</param>
		[SecuritySafeCritical]
		public void DrawArrays(Primitive[] primitives)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.DrawArrays2(this.handle, primitives, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Renders the primitive (for primitive array, with specified range)</summary>
		/// <param name="primitives">Primitive array</param>
		/// <param name="first">Starting number for primitives</param>
		/// <param name="count">Number of primitives</param>
		[SecuritySafeCritical]
		public void DrawArrays(Primitive[] primitives, int first, int count)
		{
			this.CheckUpdate();
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmGraphicsContext.DrawArrays2(this.handle, primitives, first, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Renders the primitive (for instance rendering)</summary>
		/// <param name="mode">Primitive rendering mode</param>
		/// <param name="first">Starting vertex of the primitive</param>
		/// <param name="count">Number of vertices in the primitive</param>
		/// <param name="instFirst">Starting number of the instance</param>
		/// <param name="instCount">Number of instances</param>
		/// <remarks>Renders multiple instances of one primitive. To transfer parameters of each instance, specify the instance divisor and use the created vertex buffer. If the instance divisor is 0, each vertex data will be transferred per vertex. If the instance divisor is 1, each vertex data will be transferred per instance.</remarks>
		/// \image html image/graphics_draw_instanced.png
		[SecuritySafeCritical]
		public void DrawArraysInstanced(DrawMode mode, int first, int count, int instFirst, int instCount)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.DrawArraysInstanced(this.handle, mode, first, count, instFirst, instCount);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Reads the pixels of the frame buffer</summary>
		/// <param name="pixels">Pixel data storing destination</param>
		/// <param name="format">Pixel format</param>
		/// <param name="sx">X coordinate of the transfer source</param>
		/// <param name="sy">Y coordinate of the transfer source</param>
		/// <param name="sw">Width of the transfer source</param>
		/// <param name="sh">Height of the transfer source</param>
		/// <remarks>Copies the pixels of the frame buffer to the specified array. Rgba or the same format as the frame buffer can be specified to the pixel format.</remarks>
		[SecuritySafeCritical]
		public void ReadPixels(byte[] pixels, PixelFormat format, int sx, int sy, int sw, int sh)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.ReadPixels(this.handle, pixels, format, sx, sy, sw, sh);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Reads frame buffer pixels (copies to a 2D texture)</summary>
		/// <param name="texture">2D texture</param>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="dx">X coordinate of the transfer destination</param>
		/// <param name="dy">Y coordinate of the transfer destination</param>
		/// <param name="sx">X coordinate of the transfer source</param>
		/// <param name="sy">Y coordinate of the transfer source</param>
		/// <param name="sw">Width of the transfer source</param>
		/// <param name="sh">Height of the transfer source</param>
		/// <remarks>Copies the frame buffer pixels to the specified 2D texture. The usable texture formats are Rgba, Rgba4444, Rgba5551, and Rgb565. Note that copying cannot be performed from a frame buffer without an alpha component to a texture with an alpha component.</remarks>
		[SecuritySafeCritical]
		public void ReadPixels(Texture2D texture, int level, int dx, int dy, int sx, int sy, int sw, int sh)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.ReadPixels2(this.handle, texture.handle, level, TextureCubeFace.PositiveX, dx, dy, sx, sy, sw, sh);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Reads frame buffer pixels (copies to a cube texture)</summary>
		/// <param name="texture">Cube texture</param>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube surface</param>
		/// <param name="dx">X coordinate of the transfer destination</param>
		/// <param name="dy">Y coordinate of the transfer destination</param>
		/// <param name="sx">X coordinate of the transfer source</param>
		/// <param name="sy">Y coordinate of the transfer source</param>
		/// <param name="sw">Width of the transfer source</param>
		/// <param name="sh">Height of the transfer source</param>
		/// <remarks>Copies the frame buffer pixels to the specified cube texture. The usable texture formats are Rgba, Rgba4444, Rgba5551, and Rgb565. Note that copying cannot be performed from a frame buffer without an alpha component to a texture with an alpha component.</remarks>
		[SecuritySafeCritical]
		public void ReadPixels(TextureCube texture, int level, TextureCubeFace cubeFace, int dx, int dy, int sx, int sy, int sw, int sh)
		{
			this.CheckUpdate();
			int errorCode = PsmGraphicsContext.ReadPixels2(this.handle, texture.handle, level, cubeFace, dx, dy, sx, sy, sw, sh);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Obtains the shader program</summary>
		/// <returns>Shader Program</returns>
		public ShaderProgram GetShaderProgram()
		{
			return this.shaderProgram;
		}

		/// <summary>Sets a shader program</summary>
		/// <param name="program">Shader program (release when NULL)</param>
		public void SetShaderProgram(ShaderProgram program)
		{
			this.shaderProgram = program;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.ShaderProgram;
		}

		/// <summary>Obtains the vertex buffer</summary>
		/// <param name="index">Vertex buffer number (0-3)</param>
		/// <returns>Vertex buffer</returns>
		public VertexBuffer GetVertexBuffer(int index)
		{
			return this.vertexBuffers[index];
		}

		/// <summary>Sets the vertex buffer</summary>
		/// <param name="index">Vertex buffer number (0-3)</param>
		/// <param name="buffer">Vertex buffer (release when NULL)</param>
		public void SetVertexBuffer(int index, VertexBuffer buffer)
		{
			this.vertexBuffers[index] = buffer;
			this.handles[4 + index] = ((buffer == null) ? 0 : buffer.handle);
			GraphicsContext.notifyUpdate |= ((index == 0) ? GraphicsUpdate.VertexBuffer0 : GraphicsUpdate.VertexBufferN);
		}

		/// <summary>Obtains the texture</summary>
		/// <param name="index">Texture number (0-7)</param>
		/// <returns>Textures</returns>
		public Texture GetTexture(int index)
		{
			return this.textures[index];
		}

		/// <summary>Sets the texture</summary>
		/// <param name="index">Texture number (0-7)</param>
		/// <param name="texture">Texture (release when NULL)</param>
		public void SetTexture(int index, Texture texture)
		{
			this.textures[index] = texture;
			this.handles[8 + index] = ((texture == null) ? 0 : texture.handle);
			GraphicsContext.notifyUpdate |= ((index == 0) ? GraphicsUpdate.Texture0 : ((GraphicsUpdate)2147483648U));
		}

		/// <summary>Obtains the frame buffer</summary>
		/// <returns>FrameBuffer</returns>
		public FrameBuffer GetFrameBuffer()
		{
			return this.frameBuffer;
		}

		/// <summary>Sets the frame buffer</summary>
		/// <param name="buffer">Frame buffer (release when NULL)</param>
		public void SetFrameBuffer(FrameBuffer buffer)
		{
			this.frameBuffer = ((buffer != null) ? buffer : this.screen);
			this.handles[1] = this.frameBuffer.handle;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.FrameBuffer;
		}

		/// <summary>Obtains the logical OR of the flag that represents whether or not each graphics feature is enabled</summary>
		/// <returns>Logical OR of the flag that represents whether or not each graphics feature is enabled</returns>
		public EnableMode GetEnableMode()
		{
			return this.state.Enable;
		}

		/// <summary>Sets the logical OR of the flag that represents whether or not each graphics feature is enabled</summary>
		/// <param name="mode">Logical OR of the flag that represents whether or not each graphics feature is enabled</param>
		public void SetEnableMode(EnableMode mode)
		{
			if ((mode & ~(EnableMode.ScissorTest | EnableMode.CullFace | EnableMode.Blend | EnableMode.DepthTest | EnableMode.PolygonOffsetFill | EnableMode.StencilTest | EnableMode.Dither)) != EnableMode.None)
			{
				throw new ArgumentException();
			}
			if (this.state.Enable != mode)
			{
				this.state.Enable = mode;
				GraphicsContext.notifyUpdate |= GraphicsUpdate.Enable;
			}
		}

		/// <summary>Obtains whether or not the specified graphics feature is enabled</summary>
		/// <param name="mode">Graphics feature to enable or disable</param>
		/// <returns>Specify true to enable</returns>
		public bool IsEnabled(EnableMode mode)
		{
			if ((mode & ~(EnableMode.ScissorTest | EnableMode.CullFace | EnableMode.Blend | EnableMode.DepthTest | EnableMode.PolygonOffsetFill | EnableMode.StencilTest | EnableMode.Dither)) != EnableMode.None)
			{
				throw new ArgumentException();
			}
			return (mode & this.state.Enable) != EnableMode.None;
		}

		/// <summary>Enables or disables the specified graphics feature</summary>
		/// <param name="mode">Graphics feature to enable or disable</param>
		/// <param name="status">Specify true to enable</param>
		public void Enable(EnableMode mode, bool status)
		{
			EnableMode enableMode = this.state.Enable;
			if ((mode & ~(EnableMode.ScissorTest | EnableMode.CullFace | EnableMode.Blend | EnableMode.DepthTest | EnableMode.PolygonOffsetFill | EnableMode.StencilTest | EnableMode.Dither)) != EnableMode.None)
			{
				throw new ArgumentException();
			}
			enableMode = (status ? (enableMode | mode) : (enableMode & ~mode));
			if (this.state.Enable != enableMode)
			{
				this.state.Enable = enableMode;
				GraphicsContext.notifyUpdate |= GraphicsUpdate.Enable;
			}
		}

		/// <summary>Enables the specified graphics feature</summary>
		/// <param name="mode">Graphics feature to enable or disable</param>
		public void Enable(EnableMode mode)
		{
			this.Enable(mode, true);
		}

		/// <summary>Disables the specified graphics feature</summary>
		/// <param name="mode">Graphics feature to enable or disable</param>
		public void Disable(EnableMode mode)
		{
			this.Enable(mode, false);
		}

		/// <summary>Obtains the rectangle for the scissor test</summary>
		/// <returns>Rectangle for the scissor test</returns>
		public ImageRect GetScissor()
		{
			return this.state.Scissor;
		}

		/// <summary>Sets the rectangle for the scissor test</summary>
		/// <param name="rectangle">Rectangle for the scissor test</param>
		public void SetScissor(ImageRect rectangle)
		{
			this.state.Scissor = rectangle;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.Scissor;
		}

		/// <summary>Sets the rectangle for the scissor test</summary>
		/// <param name="x">Minimum value for the X coordinate of the rectangle for the scissor test</param>
		/// <param name="y">Minimum value for the Y coordinate of the rectangle for the scissor test</param>
		/// <param name="w">Width of the rectangle for the scissor test</param>
		/// <param name="h">Height of the rectangle for the scissor test</param>
		public void SetScissor(int x, int y, int w, int h)
		{
			this.SetScissor(new ImageRect(x, y, w, h));
		}

		/// <summary>Obtains the rectangle of the viewport</summary>
		/// <returns>Viewport rectangle</returns>
		public ImageRect GetViewport()
		{
			return this.state.Viewport;
		}

		/// <summary>Sets the rectangle of the viewport</summary>
		/// <param name="rectangle">Viewport rectangle</param>
		public void SetViewport(ImageRect rectangle)
		{
			this.state.Viewport = rectangle;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.Viewport;
		}

		/// <summary>Sets the rectangle of the viewport</summary>
		/// <param name="x">Minimum value for the X coordinate of the rectangle for the viewport</param>
		/// <param name="y">Minimum value for the Y coordinate of the rectangle for the viewport</param>
		/// <param name="w">Width of the viewport rectangle</param>
		/// <param name="h">Height of the viewport rectangle</param>
		public void SetViewport(int x, int y, int w, int h)
		{
			this.SetViewport(new ImageRect(x, y, w, h));
		}

		/// <summary>Obtains the range for the depth value</summary>
		/// <returns>Depth value range</returns>
		public Vector2 GetDepthRange()
		{
			return this.state.DepthRange;
		}

		/// <summary>Sets the range for the depth value</summary>
		/// <param name="range">Depth value range</param>
		public void SetDepthRange(Vector2 range)
		{
			this.state.DepthRange = range;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.DepthRange;
		}

		/// <summary>Sets the range for the depth value</summary>
		/// <param name="min">Minimum value for the depth value (0.0f-1.0f)</param>
		/// <param name="max">Maximum value for the depth value (0.0f-1.0f)</param>
		public void SetDepthRange(float min, float max)
		{
			this.SetDepthRange(new Vector2(min, max));
		}

		/// <summary>Obtains the color to be used for clearing the frame buffer</summary>
		/// <returns>Color</returns>
		public Vector4 GetClearColor()
		{
			return this.state.ClearColor;
		}

		/// <summary>Sets the color to be used for clearing the frame buffer</summary>
		/// <param name="color">Color</param>
		public void SetClearColor(Vector4 color)
		{
			this.state.ClearColor = color;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.ClearColor;
		}

		/// <summary>Sets the color to be used for clearing the frame buffer</summary>
		/// <param name="r">Color R value (0.0f-1.0f)</param>
		/// <param name="g">Color G value (0.0f-1.0f)</param>
		/// <param name="b">Color B value (0.0f-1.0f)</param>
		/// <param name="a">Color A value (0.0f-1.0f)</param>
		public void SetClearColor(float r, float g, float b, float a)
		{
			this.SetClearColor(new Vector4(r, g, b, a));
		}

		/// <summary>Sets the color to be used for clearing the frame buffer</summary>
		/// <param name="r">Color R value (0-255)</param>
		/// <param name="g">Color G value (0-255)</param>
		/// <param name="b">Color B value (0-255)</param>
		/// <param name="a">Color A value (0-255)</param>
		public void SetClearColor(int r, int g, int b, int a)
		{
			this.SetClearColor(new Vector4((float)r, (float)g, (float)b, (float)a) * 0.003921569f);
		}

		/// <summary>Obtains the depth value to be used for clearing the frame buffer</summary>
		/// <returns>Depth value (0.0f-1.0f)</returns>
		public float GetClearDepth()
		{
			return this.state.ClearDepth;
		}

		/// <summary>Sets the depth value to be used for clearing the frame buffer</summary>
		/// <param name="depth">Depth value (0.0f-1.0f)</param>
		public void SetClearDepth(float depth)
		{
			this.state.ClearDepth = depth;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.ClearDepth;
		}

		/// <summary>Obtains the stencil value to be used for clearing the frame buffer</summary>
		/// <returns>Stencil value (0-255)</returns>
		public int GetClearStencil()
		{
			return this.state.ClearStencil;
		}

		/// <summary>Sets the stencil value to be used for clearing the frame buffer</summary>
		/// <param name="stencil">Stencil value (0-255)</param>
		public void SetClearStencil(int stencil)
		{
			this.state.ClearStencil = (int)((byte)stencil);
			GraphicsContext.notifyUpdate |= GraphicsUpdate.ClearStencil;
		}

		/// <summary>Obtains back-face culling</summary>
		/// <returns>Structure representing back-face culling</returns>
		public CullFace GetCullFace()
		{
			return this.state.CullFace;
		}

		/// <summary>Sets back-face culling</summary>
		/// <param name="face">Structure representing back-face culling</param>
		public void SetCullFace(CullFace face)
		{
			this.state.CullFace = face;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.CullFace;
		}

		/// <summary>Sets back-face culling</summary>
		/// <param name="mode">Back-face culling mode</param>
		/// <param name="direction">Front direction for back-face culling</param>
		public void SetCullFace(CullFaceMode mode, CullFaceDirection direction)
		{
			this.SetCullFace(new CullFace(mode, direction));
		}

		/// <summary>Obtains the alpha-blending function</summary>
		/// <returns>Structure representing the alpha-blending function</returns>
		public BlendFunc GetBlendFunc()
		{
			return this.state.BlendFuncRgb;
		}

		/// <summary>Sets the alpha-blending function</summary>
		/// <param name="func">Structure representing the alpha-blending function</param>
		public void SetBlendFunc(BlendFunc func)
		{
			this.state.BlendFuncAlpha = func;
			this.state.BlendFuncRgb = func;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.BlendFunc;
		}

		/// <summary>Sets the alpha-blending function</summary>
		/// <param name="mode">Alpha-blending function mode</param>
		/// <param name="srcFactor">Alpha-blending function source coefficient</param>
		/// <param name="dstFactor">Alpha-blending function destination coefficient</param>
		public void SetBlendFunc(BlendFuncMode mode, BlendFuncFactor srcFactor, BlendFuncFactor dstFactor)
		{
			this.SetBlendFunc(new BlendFunc(mode, srcFactor, dstFactor));
		}

		/// <summary>Obtains the alpha-blending function (for the RGB channel)</summary>
		/// <returns>Structure representing the alpha-blending function</returns>
		public BlendFunc GetBlendFuncRgb()
		{
			return this.state.BlendFuncRgb;
		}

		/// <summary>Sets the alpha-blending function (for the RGB channel)</summary>
		/// <param name="func">Structure representing the alpha-blending function</param>
		public void SetBlendFuncRgb(BlendFunc func)
		{
			this.state.BlendFuncRgb = func;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.BlendFunc;
		}

		/// <summary>Sets the alpha-blending function (for the RGB channel)</summary>
		/// <param name="mode">Alpha-blending function mode</param>
		/// <param name="srcFactor">Alpha-blending function source coefficient</param>
		/// <param name="dstFactor">Alpha-blending function destination coefficient</param>
		public void SetBlendFuncRgb(BlendFuncMode mode, BlendFuncFactor srcFactor, BlendFuncFactor dstFactor)
		{
			this.SetBlendFuncRgb(new BlendFunc(mode, srcFactor, dstFactor));
		}

		/// <summary>Obtains the alpha-blending function (for the alpha channel)</summary>
		/// <returns>Structure representing the alpha-blending function</returns>
		public BlendFunc GetBlendFuncAlpha()
		{
			return this.state.BlendFuncAlpha;
		}

		/// <summary>Sets the alpha-blending function (for the alpha channel)</summary>
		/// <param name="func">Structure representing the alpha-blending function</param>
		public void SetBlendFuncAlpha(BlendFunc func)
		{
			this.state.BlendFuncAlpha = func;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.BlendFunc;
		}

		/// <summary>Sets the alpha-blending function (for the alpha channel)</summary>
		/// <param name="mode">Alpha-blending function mode</param>
		/// <param name="srcFactor">Alpha-blending function source coefficient</param>
		/// <param name="dstFactor">Alpha-blending function destination coefficient</param>
		public void SetBlendFuncAlpha(BlendFuncMode mode, BlendFuncFactor srcFactor, BlendFuncFactor dstFactor)
		{
			this.SetBlendFuncAlpha(new BlendFunc(mode, srcFactor, dstFactor));
		}

		/// <summary>Obtains the depth test function</summary>
		/// <returns>Structure representing the depth test function</returns>
		public DepthFunc GetDepthFunc()
		{
			return this.state.DepthFunc;
		}

		/// <summary>Sets the depth test function</summary>
		/// <param name="func">Structure representing the depth test function</param>
		public void SetDepthFunc(DepthFunc func)
		{
			this.state.DepthFunc = func;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.DepthFunc;
		}

		/// <summary>Sets the depth test function</summary>
		/// <param name="mode">Depth test function mode</param>
		/// <param name="writeMask">Depth test function write mask</param>
		public void SetDepthFunc(DepthFuncMode mode, bool writeMask)
		{
			this.SetDepthFunc(new DepthFunc(mode, writeMask));
		}

		/// <summary>Obtains the polygon offset</summary>
		/// <returns>Structure representing the polygon offset</returns>
		public PolygonOffset GetPolygonOffset()
		{
			return this.state.PolygonOffset;
		}

		/// <summary>Sets the polygon offset</summary>
		/// <param name="offset">Structure representing the polygon offset</param>
		public void SetPolygonOffset(PolygonOffset offset)
		{
			this.state.PolygonOffset = offset;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.PolygonOffset;
		}

		/// <summary>Sets the polygon offset</summary>
		/// <param name="factor">Polygon offset scaling coefficient</param>
		/// <param name="units">Polygon offset offset coefficient</param>
		public void SetPolygonOffset(float factor, float units)
		{
			this.SetPolygonOffset(new PolygonOffset(factor, units));
		}

		/// <summary>Obtains the stencil test function</summary>
		/// <returns>Structure representing the stencil test function</returns>
		public StencilFunc GetStencilFunc()
		{
			return this.state.StencilFuncFront;
		}

		/// <summary>Sets the stencil test function</summary>
		/// <param name="func">Structure representing the stencil test function</param>
		public void SetStencilFunc(StencilFunc func)
		{
			this.state.StencilFuncBack = func;
			this.state.StencilFuncFront = func;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.StencilFunc;
		}

		/// <summary>Sets the stencil test function</summary>
		/// <param name="mode">Stencil test function mode</param>
		/// <param name="reference">Reference value (0-255) of the stencil test function</param>
		/// <param name="readMask">Read mask (0-255) of the stencil test function</param>
		/// <param name="writeMask">Write mask (0-255) of the stencil test function</param>
		public void SetStencilFunc(StencilFuncMode mode, int reference, int readMask, int writeMask)
		{
			this.SetStencilFunc(new StencilFunc(mode, reference, readMask, writeMask));
		}

		/// <summary>Obtains the stencil test operation</summary>
		/// <returns>Structure representing the stencil test operation</returns>
		public StencilOp GetStencilOp()
		{
			return this.state.StencilOpFront;
		}

		/// <summary>Sets the stencil test operation</summary>
		/// <param name="op">Structure representing the stencil test operation</param>
		public void SetStencilOp(StencilOp op)
		{
			this.state.StencilOpBack = op;
			this.state.StencilOpFront = op;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.StencilOp;
		}

		/// <summary>Sets the stencil test operation</summary>
		/// <param name="fail">Stencil failure mode of the stencil test operation</param>
		/// <param name="zFail">Depth failure mode of the stencil test operation</param>
		/// <param name="zPass">Depth passing mode of the stencil test operation</param>
		public void SetStencilOp(StencilOpMode fail, StencilOpMode zFail, StencilOpMode zPass)
		{
			this.SetStencilOp(new StencilOp(fail, zFail, zPass));
		}

		/// <summary>Obtains the stencil test function (for the front surface)</summary>
		/// <returns>Structure representing the stencil test function</returns>
		public StencilFunc GetStencilFuncFront()
		{
			return this.state.StencilFuncFront;
		}

		/// <summary>Sets the stencil test function (for the front surface)</summary>
		/// <param name="func">Structure representing the stencil test function</param>
		public void SetStencilFuncFront(StencilFunc func)
		{
			this.state.StencilFuncFront = func;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.StencilFunc;
		}

		/// <summary>Sets the stencil test function (for the front surface)</summary>
		/// <param name="mode">Stencil test function mode</param>
		/// <param name="reference">Reference value (0-255) of the stencil test function</param>
		/// <param name="readMask">Read mask (0-255) of the stencil test function</param>
		/// <param name="writeMask">Write mask (0-255) of the stencil test function</param>
		public void SetStencilFuncFront(StencilFuncMode mode, int reference, int readMask, int writeMask)
		{
			this.SetStencilFuncFront(new StencilFunc(mode, reference, readMask, writeMask));
		}

		/// <summary>Obtains the stencil test operation (for the front surface)</summary>
		/// <returns>Structure representing the stencil test operation</returns>
		public StencilOp GetStencilOpFront()
		{
			return this.state.StencilOpFront;
		}

		/// <summary>Sets the stencil test operation (for the front surface)</summary>
		/// <param name="op">Structure representing the stencil test operation</param>
		public void SetStencilOpFront(StencilOp op)
		{
			this.state.StencilOpFront = op;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.StencilOp;
		}

		/// <summary>Sets the stencil test operation (for the front surface)</summary>
		/// <param name="fail">Stencil failure mode of the stencil test operation</param>
		/// <param name="zFail">Depth failure mode of the stencil test operation</param>
		/// <param name="zPass">Depth passing mode of the stencil test operation</param>
		public void SetStencilOpFront(StencilOpMode fail, StencilOpMode zFail, StencilOpMode zPass)
		{
			this.SetStencilOpFront(new StencilOp(fail, zFail, zPass));
		}

		/// <summary>Obtains the stencil test function (for the back surface)</summary>
		/// <returns>Structure representing the stencil test function</returns>
		public StencilFunc GetStencilFuncBack()
		{
			return this.state.StencilFuncBack;
		}

		/// <summary>Sets the stencil test function (for the back surface)</summary>
		/// <param name="func">Structure representing the stencil test function</param>
		public void SetStencilFuncBack(StencilFunc func)
		{
			this.state.StencilFuncBack = func;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.StencilFunc;
		}

		/// <summary>Sets the stencil test function (for the back surface)</summary>
		/// <param name="mode">Stencil test function mode</param>
		/// <param name="reference">Reference value (0-255) of the stencil test function</param>
		/// <param name="readMask">Read mask (0-255) of the stencil test function</param>
		/// <param name="writeMask">Write mask (0-255) of the stencil test function</param>
		public void SetStencilFuncBack(StencilFuncMode mode, int reference, int readMask, int writeMask)
		{
			this.SetStencilFuncBack(new StencilFunc(mode, reference, readMask, writeMask));
		}

		/// <summary>Obtains the stencil test operation (for the back surface)</summary>
		/// <returns>Structure representing the stencil test operation</returns>
		public StencilOp GetStencilOpBack()
		{
			return this.state.StencilOpBack;
		}

		/// <summary>Sets the stencil test operation (for the back surface)</summary>
		/// <param name="op">Structure representing the stencil test operation</param>
		public void SetStencilOpBack(StencilOp op)
		{
			this.state.StencilOpBack = op;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.StencilOp;
		}

		/// <summary>Sets the stencil test operation (for the back surface)</summary>
		/// <param name="fail">Stencil failure mode of the stencil test operation</param>
		/// <param name="zFail">Depth failure mode of the stencil test operation</param>
		/// <param name="zPass">Depth passing mode of the stencil test operation</param>
		public void SetStencilOpBack(StencilOpMode fail, StencilOpMode zFail, StencilOpMode zPass)
		{
			this.SetStencilOpBack(new StencilOp(fail, zFail, zPass));
		}

		/// <summary>Obtains the color write mask</summary>
		/// <returns>Color write mask</returns>
		public ColorMask GetColorMask()
		{
			return this.state.ColorMask;
		}

		/// <summary>Sets the color write mask</summary>
		/// <param name="mask">Color write mask</param>
		public void SetColorMask(ColorMask mask)
		{
			this.state.ColorMask = mask;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.ColorMask;
		}

		/// <summary>Obtains the line width</summary>
		/// <returns>Line width</returns>
		public float GetLineWidth()
		{
			return this.state.LineWidth;
		}

		/// <summary>Sets the line width</summary>
		/// <param name="width">Line width</param>
		public void SetLineWidth(float width)
		{
			this.state.LineWidth = width;
			GraphicsContext.notifyUpdate |= GraphicsUpdate.LineWidth;
		}

		[SecuritySafeCritical]
		static GraphicsContext()
		{
			int screenSize;
			PsmGraphicsContext.GetScreenSizes(null, out screenSize);
			GraphicsContext.screenSizes = new ImageSize[screenSize];
			PsmGraphicsContext.GetScreenSizes(GraphicsContext.screenSizes, out screenSize);
			int width;
			int height;
			PsmGraphicsContext.GetMaxScreenSize(out x, out y);
			for (int i = 0; i < width; i++)
			{
				if (GraphicsContext.screenSizes[i].Width > width || GraphicsContext.screenSizes[i].Height > height)
				{
					ScreenBuffer.FitRect(width, height, ref GraphicsContext.screenSizes[i].Width, ref GraphicsContext.screenSizes[i].Height);
				}
			}
		}

		internal static void NotifyUpdate(GraphicsUpdate update)
		{
			GraphicsContext.notifyUpdate |= update;
		}

		[SecuritySafeCritical]
		private void CheckUpdate()
		{
			if (this.shaderProgram != null)
			{
				this.shaderProgram.UpdateShader();
			}
			if (GraphicsContext.notifyUpdate != GraphicsUpdate.None)
			{
				if ((GraphicsContext.notifyUpdate & GraphicsUpdate.ShaderProgram) != GraphicsUpdate.None)
				{
					this.handles[0] = ((this.shaderProgram == null) ? 0 : this.shaderProgram.handle);
				}
				PsmGraphicsContext.Update(this.handle, GraphicsContext.notifyUpdate, ref this.state, this.handles);
				GraphicsContext.notifyUpdate = GraphicsUpdate.None;
			}
		}

	}
}
