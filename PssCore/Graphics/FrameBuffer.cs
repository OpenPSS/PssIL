using System;
using System.Security;
using Sce.PlayStation.Core.Imaging;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing the frame buffer</summary>
	public class FrameBuffer : IDisposable, IShallowCloneable
	{
		/*
		 *	Global Variables
		 */

		internal int handle;
		internal FrameBufferState state;
		
		/// <summary>Creates a frame buffer</summary>
		/// <remarks>Creates a frame buffer. Use after setting the color and depth storage destinations.</remarks>
		public FrameBuffer()
		{
			this.DefaultConstruct();
		}

		[SecuritySafeCritical]
		private void DefaultConstruct()
		{
			int errorCode = PsmFrameBuffer.Create(out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.state = new FrameBufferState();
		}

		/// <summary>Creates a default frame buffer</summary>
		[SecuritySafeCritical]
		internal FrameBuffer(GraphicsContext graphics)
		{
			this.handle = 0;
			this.state = new FrameBufferState();
			this.state.status = true;
			PsmGraphicsContext.GetScreenInfo(graphics.handle, out this.state.width, out this.state.height, out this.state.colorFormat, out this.state.depthFormat, out this.state.multiSampleMode);
		}

		/// <summary>Creates a copy of the frame buffer</summary>
		/// <returns>Clones the frame buffer</returns>
		/// <remarks>Creates a copy of the frame buffer. The 2 frame buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		[SecuritySafeCritical]
		protected FrameBuffer(FrameBuffer buffer)
		{
			int errorCode = PsmFrameBuffer.AddRef(buffer.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.handle = buffer.handle;
			this.state = buffer.state;
		}

		/// <summary>Creates a copy of the frame buffer</summary>
		/// <returns>Copy of the frame buffer</returns>
		/// <remarks>Creates a copy of the frame buffer. The 2 frame buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public virtual object ShallowClone()
		{
			return new FrameBuffer(this);
		}

		/// <summary>Deletes the frame buffer</summary>
		~FrameBuffer()
		{
			this.Dispose(false);
		}

		/// <summary>Frees the unmanaged resources of the frame buffer</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (this.handle != 0)
			{
				if (disposing)
				{
					this.state = null;
				}
				PsmFrameBuffer.Delete(this.handle);
				this.handle = 0;
			}
		}

		/// <summary>Frame buffer state (true if rendering is enabled)</summary>
		public bool Status
		{
			get
			{
				return this.state.status;
			}
		}

		/// <summary>Frame buffer width</summary>
		public int Width
		{
			get
			{
				return this.state.width;
			}
		}

		/// <summary>Frame buffer height</summary>
		public int Height
		{
			get
			{
				return this.state.height;
			}
		}

		/// <summary>Frame buffer aspect ratio (width/height)</summary>
		public float AspectRatio
		{
			get
			{
				return (float)this.state.width / (float)this.state.height;
			}
		}

		/// <summary>Frame buffer entire size rectangle (0,0,width,height)</summary>
		public ImageRect Rectangle
		{
			get
			{
				return new ImageRect(0, 0, this.state.width, this.state.height);
			}
		}

		/// <summary>Frame buffer color format</summary>
		public PixelFormat ColorFormat
		{
			get
			{
				return this.state.colorFormat;
			}
		}

		/// <summary>Frame buffer depth format</summary>
		public PixelFormat DepthFormat
		{
			get
			{
				return this.state.depthFormat;
			}
		}

		/// <summary>Frame buffer multi-sample mode</summary>
		public MultiSampleMode MultiSampleMode
		{
			get
			{
				return this.state.multiSampleMode;
			}
		}

		/// <summary>Obtains the color storage destination</summary>
		/// <returns>Structure representing the color storage destination</returns>
		public RenderTarget GetColorTarget()
		{
			return this.state.colorTarget;
		}

		/// <summary>Sets the color storage destination</summary>
		/// <param name="target">Structure representing the color storage destination</param>
		/// <remarks>Sets the color storage destination with the structure. When setting the texture to a storage destination, the texture must be created by specifying the Renderable option.</remarks>
		[SecuritySafeCritical]
		public void SetColorTarget(RenderTarget target)
		{
			int colorBuffer = (target.Buffer == null) ? 0 : target.Buffer.handle;
			int status;
			int errorCode = PsmFrameBuffer.SetColorTarget(this.handle, colorBuffer, target.Level, target.CubeFace, out status);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.state.colorTarget = target;
			this.state.status = (status != 0);
			this.state.Update();
			GraphicsContext.NotifyUpdate(GraphicsUpdate.FrameBuffer);
		}

		/// <summary>Sets the color storage destination (for the color buffer)</summary>
		/// <param name="buffer">Color buffer (release when NULL)</param>
		/// <remarks>Sets the color buffer to the color storage destination.</remarks>
		public void SetColorTarget(ColorBuffer buffer)
		{
			this.SetColorTarget(new RenderTarget(buffer));
		}

		/// <summary>Sets the color storage destination (for the 2D textures)</summary>
		/// <param name="texture">2D texture (release when NULL)</param>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <remarks>Sets the 2D textures to the color storage destination. The texture must be created by specifying the Renderable option.</remarks>
		public void SetColorTarget(Texture2D texture, int level)
		{
			this.SetColorTarget(new RenderTarget(texture, level));
		}

		/// <summary>Sets the color storage destination (for the cube textures)</summary>
		/// <param name="texture">Cube texture (release when NULL)</param>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube surface</param>
		/// <remarks>Sets the cube textures to the color storage destination. The texture must be created by specifying the Renderable option.</remarks>
		public void SetColorTarget(TextureCube texture, int level, TextureCubeFace cubeFace)
		{
			this.SetColorTarget(new RenderTarget(texture, level, cubeFace));
		}

		/// <summary>Obtains the depth storage destination</summary>
		/// <returns>Structure representing the depth storage destination</returns>
		public RenderTarget GetDepthTarget()
		{
			return this.state.depthTarget;
		}

		/// <summary>Sets the depth storage destination</summary>
		/// <param name="target">Structure representing the depth storage destination</param>
		/// <remarks>Sets the depth storage destination with the structure.</remarks>
		[SecuritySafeCritical]
		public void SetDepthTarget(RenderTarget target)
		{
			int depthBuffer = (target.Buffer == null) ? 0 : target.Buffer.handle;
			int status;
			int errorCode = PsmFrameBuffer.SetDepthTarget(this.handle, depthBuffer, target.Level, target.CubeFace, out status);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.state.depthTarget = target;
			this.state.status = (status != 0);
			this.state.Update();
			GraphicsContext.NotifyUpdate(GraphicsUpdate.FrameBuffer);
		}

		/// <summary>Sets the depth storage destination (for the depth buffer)</summary>
		/// <param name="buffer">Depth buffer (release when NULL)</param>
		/// <remarks>Sets the depth buffer to the depth storage destination.</remarks>
		public void SetDepthTarget(DepthBuffer buffer)
		{
			this.SetDepthTarget(new RenderTarget(buffer));
		}
	}
}
