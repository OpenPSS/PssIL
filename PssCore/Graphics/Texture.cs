using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Base class representing a texture</summary>
	public abstract class Texture : PixelBuffer, IShallowCloneable
	{
		/*
		 *	Global Variables
		 */
		
		internal TextureState state;
		
		/// <summary>Creates a texture</summary>
		/// <param name="type">Texture type</param>
		/// <param name="width">Texture width</param>
		/// <param name="height">Texture height</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		/// <param name="option">Pixel buffer creation option</param>
		internal Texture(PixelBufferType type, int width, int height, bool mipmap, PixelFormat format, PixelBufferOption option, InternalOption option2) : base(type, width, height, mipmap, format, option, option2)
		{
			this.state = new TextureState();
		}

		/// <summary>Creates a texture (from a file)</summary>
		/// <param name="type">Pixel buffer type</param>
		/// <param name="fileName">Filename</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		[SecuritySafeCritical]
		internal Texture(PixelBufferType type, string fileName, bool mipmap, PixelFormat format)
		{
			int errorCode = PsmTexture.FromFile(type, fileName, mipmap, format, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			PsmPixelBuffer.GetInfo(this.handle, out this.type, out this.width, out this.height, out this.level, out this.format, out this.option);
			this.state = new TextureState();
		}

		/// <summary>Creates a texture (from a file image)</summary>
		/// <param name="type">Pixel buffer type</param>
		/// <param name="fileImage">File image</param>
		/// <param name="mipmap">Existence/Lack of mipmap</param>
		/// <param name="format">Pixel format</param>
		[SecuritySafeCritical]
		internal Texture(PixelBufferType type, byte[] fileImage, bool mipmap, PixelFormat format)
		{
			int errorCode = PsmTexture.FromImage(type, fileImage, mipmap, format, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			PsmPixelBuffer.GetInfo(this.handle, out this.type, out this.width, out this.height, out this.level, out this.format, out this.option);
			this.state = new TextureState();
		}

		/// <summary>Creates a copy of the texture</summary>
		/// <param name="texture">Textures</param>
		/// <remarks>Creates a copy of the texture. The 2 textures will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		internal Texture(Texture texture) : base(texture)
		{
			this.state = texture.state;
		}

		/// <summary>Creates a copy of the texture</summary>
		/// <returns>Clones the texture</returns>
		/// <remarks>Creates a copy of the texture. The 2 textures will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public override object ShallowClone()
		{
			return null;
		}

		/// <summary>Obtains the texture filter</summary>
		/// <returns>Structure representing the texture filter</returns>
		public TextureFilter GetFilter()
		{
			return this.state.filter;
		}

		/// <summary>Sets the texture filter</summary>
		/// <param name="filter">Structure representing the texture filter</param>
		/// <remarks>Sets the texture filter. If the device is not supported, note that the linear filter of the half float texture will not function.</remarks>
		[SecuritySafeCritical]
		public void SetFilter(TextureFilter filter)
		{
			if (this.state.filter.bits != filter.bits)
			{
				int errorCode = PsmTexture.SetFilter(this.handle, ref filter);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				this.state.filter = filter;
			}
		}

		/// <summary>Sets the texture filter</summary>
		/// <param name="mode">Texture filter mode</param>
		/// <remarks>Sets the texture filter. If the device is not supported, note that the linear filter of the half float texture will not function.</remarks>
		public void SetFilter(TextureFilterMode mode)
		{
			this.SetFilter(new TextureFilter(mode, mode, mode));
		}

		/// <summary>Sets the texture filter</summary>
		/// <param name="mag">Enlarged texture filter mode</param>
		/// <param name="min">Reduced texture filter mode</param>
		/// <param name="mip">Mipmap texture filter mode</param>
		/// <remarks>Sets the texture filter. If the device is not supported, note that the linear filter of the half float texture will not function.</remarks>
		public void SetFilter(TextureFilterMode mag, TextureFilterMode min, TextureFilterMode mip)
		{
			this.SetFilter(new TextureFilter(mag, min, mip));
		}

		/// <summary>Obtains the texture wrap</summary>
		/// <returns>Structure representing the texture wrap</returns>
		public TextureWrap GetWrap()
		{
			return this.state.wrap;
		}

		/// <summary>Sets the texture wrap</summary>
		/// <param name="wrap">Structure representing the texture wrap</param>
		/// <remarks>Sets the texture wrap. Note that textures that are not a power of 2 will always operate in clamp mode.</remarks>
		[SecuritySafeCritical]
		public void SetWrap(TextureWrap wrap)
		{
			if (this.state.wrap.bits != wrap.bits)
			{
				int errorCode = PsmTexture.SetWrap(this.handle, ref wrap);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				this.state.wrap = wrap;
			}
		}

		/// <summary>Sets the texture wrap</summary>
		/// <param name="mode">Texture wrap mode</param>
		/// <remarks>Sets the texture wrap. Note that textures that are not a power of 2 will always operate in clamp mode.</remarks>
		public void SetWrap(TextureWrapMode mode)
		{
			this.SetWrap(new TextureWrap(mode, mode));
		}

		/// <summary>Sets the texture wrap</summary>
		/// <param name="s">S coordinate texture wrap mode</param>
		/// <param name="t">T coordinate texture wrap mode</param>
		/// <remarks>Sets the texture wrap. Note that textures that are not a power of 2 will always operate in clamp mode.</remarks>
		public void SetWrap(TextureWrapMode s, TextureWrapMode t)
		{
			this.SetWrap(new TextureWrap(s, t));
		}

		/// <summary>Obtains the maximum value of the anisotropic filter</summary>
		/// <returns>Maximum value of the anisotropic filter (from 1.0f)</returns>
		public float GetMaxAnisotropy()
		{
			return this.state.maxAnisotropy;
		}

		/// <summary>Sets the maximum value of the anisotropic filter</summary>
		/// <param name="anisotropy">Maximum value of the anisotropic filter (from 1.0f)</param>
		/// <remarks>Sets the maximum value of the anisotropic filter. If the device is not supported, note that the anisotropic filter will not function.</remarks>
		[SecuritySafeCritical]
		public void SetMaxAnisotropy(float anisotropy)
		{
			if (this.state.maxAnisotropy != anisotropy)
			{
				int num = PsmTexture.SetMaxAnisotropy(this.handle, anisotropy);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
				}
				this.state.maxAnisotropy = anisotropy;
			}
		}
	}
}
