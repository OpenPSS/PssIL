using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Base class representing the pixel buffer</summary>
	public abstract class PixelBuffer : IDisposable, IShallowCloneable
	{
		
		/*
		 *	Global Variables
		 */
		
		internal int handle;
		internal PixelBufferType type;
		internal PixelBufferOption option;
		internal PixelFormat format;
		internal int width;
		internal int height;
		internal int level;
		
		/// <summary>Creates the pixel buffer</summary>
		/// <param name="type">Pixel buffer type</param>
		/// <param name="width">Pixel buffer width</param>
		/// <param name="height">Pixel buffer height</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <param name="option">Pixel buffer creation option</param>
		[SecuritySafeCritical]
		internal PixelBuffer(PixelBufferType type, int width, int height, bool mipmap, PixelFormat format, PixelBufferOption option, InternalOption option2)
		{
			int errorCode = PsmPixelBuffer.Create(type, width, height, mipmap, format, option, option2, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			PsmPixelBuffer.GetInfo(this.handle, out this.type, out this.width, out this.height, out this.level, out this.format, out this.option);
		}

		/// <summary>Creates the pixel buffer</summary>
		internal PixelBuffer()
		{
		}

		/// <summary>Creates a copy of the pixel buffer</summary>
		/// <param name="buffer">Pixel buffer</param>
		/// <remarks>Creates a copy of the pixel buffer. The 2 pixel buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		[SecuritySafeCritical]
		internal PixelBuffer(PixelBuffer buffer)
		{
			int errorCode = PsmPixelBuffer.AddRef(buffer.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.handle = buffer.handle;
			this.type = buffer.type;
			this.option = buffer.option;
			this.format = buffer.format;
			this.width = buffer.width;
			this.height = buffer.height;
			this.level = buffer.level;
		}

		/// <summary>Creates a copy of the pixel buffer</summary>
		/// <returns>Clones the pixel buffer</returns>
		/// <remarks>Creates a copy of the pixel buffer. The 2 pixel buffers will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public virtual object ShallowClone()
		{
			return null;
		}

		/// <summary>Deletes the pixel buffer</summary>
		~PixelBuffer()
		{
			this.Dispose(false);
		}

		/// <summary>Frees the unmanaged resources of the pixel buffer</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			PsmPixelBuffer.Delete(this.handle);
			this.handle = 0;
		}

		/// <summary>Pixel buffer type</summary>
		public PixelBufferType Type
		{
			get
			{
				return this.type;
			}
		}

		/// <summary>Pixel buffer creation option</summary>
		public PixelBufferOption Option
		{
			get
			{
				return this.option;
			}
		}

		/// <summary>Pixel format</summary>
		public PixelFormat Format
		{
			get
			{
				return this.format;
			}
		}

		/// <summary>Pixel buffer width</summary>
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		/// <summary>Pixel buffer height</summary>
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		/// <summary>Number of mipmap levels</summary>
		public int LevelCount
		{
			get
			{
				return this.level;
			}
		}

		/// <summary>true if rendering is enabled</summary>
		public bool IsRenderable
		{
			get
			{
				return (this.option & PixelBufferOption.Renderable) != PixelBufferOption.None;
			}
		}

		/// <summary>true if the width and height are a power of 2</summary>
		public bool IsPowerOfTwo
		{
			get
			{
				return PixelBuffer.PowerOfTwo(this.width) && PixelBuffer.PowerOfTwo(this.height);
			}
		}

		/// <summary>Obtains the width of the specified mipmap level</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <returns>Width of the specified mipmap level</returns>
		public int GetMipmapWidth(int level)
		{
			return PixelBuffer.MipmapSize(level, this.level, this.width);
		}

		/// <summary>Obtains the height of the specified mipmap level</summary>
		/// <param name="level">Mipmap level (0 to LevelCount-1)</param>
		/// <returns>Height of the specified mipmap level</returns>
		public int GetMipmapHeight(int level)
		{
			return PixelBuffer.MipmapSize(level, this.level, this.height);
		}

		internal static int MipmapSize(int level, int levelCount, int baseSize)
		{
			if (level < 0 || level >= levelCount)
			{
				throw new ArgumentOutOfRangeException();
			}
			int mipmapSz = baseSize >> level;
			return (mipmapSz > 0) ? mipmapSz : ((baseSize > 0) ? 1 : 0);
		}

		internal static bool PowerOfTwo(int num)
		{
			return num != 0 && (num & num - 1) == 0;
		}
	}
}
