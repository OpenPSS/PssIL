using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the texture filter</summary>
	public struct TextureFilter
	{
		/*
		 *	Global Variables
		 */
			
		internal uint bits;
		
		/// <summary>Creates the structure representing the texture filter</summary>
		/// <param name="mag">Enlarged texture filter mode</param>
		/// <param name="min">Reduced texture filter mode</param>
		/// <param name="mip">Mipmap texture filter mode</param>
		public TextureFilter(TextureFilterMode mag, TextureFilterMode min, TextureFilterMode mip)
		{
			this.bits = (uint)(mag | (uint)min << 8 | (uint)mip << 16);
		}

		/// <summary>Sets a value to the structure representing the texture filter</summary>
		/// <param name="mag">Enlarged texture filter mode</param>
		/// <param name="min">Reduced texture filter mode</param>
		/// <param name="mip">Mipmap texture filter mode</param>
		public void Set(TextureFilterMode mag, TextureFilterMode min, TextureFilterMode mip)
		{
			this.bits = (uint)(mag | (uint)min << 8 | (uint)mip << 16);
		}

		/// <summary>Enlarged texture filter mode</summary>
		public TextureFilterMode Mag
		{
			get
			{
				return (TextureFilterMode)this.bits;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFFFF00) | (uint)value);
			}
		}

		/// <summary>Reduced texture filter mode</summary>
		public TextureFilterMode Min
		{
			get
			{
				return (TextureFilterMode)(this.bits >> 8);
			}
			set
			{
				this.bits = ((this.bits & 0xFFFF00FF) | (uint)((uint)value << 8));
			}
		}

		/// <summary>Mipmap texture filter mode</summary>
		public TextureFilterMode Mip
		{
			get
			{
				return (TextureFilterMode)(this.bits >> 16);
			}
			set
			{
				this.bits = ((this.bits & 0xFF00FFFF) | (uint)((uint)value << 16));
			}
		}
	}
}
