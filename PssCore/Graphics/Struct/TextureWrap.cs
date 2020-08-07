using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the texture wrap</summary>
	public struct TextureWrap
	{
		/*
		 *	Global Variables
		 */
		internal uint bits;
		
		/// <summary>Creates the structure representing the texture wrap</summary>
		/// <param name="s">S coordinate texture wrap mode</param>
		/// <param name="t">T coordinate texture wrap mode</param>
		public TextureWrap(TextureWrapMode s, TextureWrapMode t)
		{
			this.bits = (uint)(s | (uint)t << 8);
		}

		/// <summary>Sets a value to the structure representing the texture wrap</summary>
		/// <param name="s">S coordinate texture wrap mode</param>
		/// <param name="t">T coordinate texture wrap mode</param>
		public void Set(TextureWrapMode s, TextureWrapMode t)
		{
			this.bits = (uint)(s | (uint)t << 8);
		}

		/// <summary>S coordinate texture wrap mode</summary>
		public TextureWrapMode S
		{
			get
			{
				return (TextureWrapMode)this.bits;
			}
			set
			{
				this.bits = ((this.bits & 0xFFFFFF00) | (uint)value);
			}
		}

		/// <summary>T coordinate texture wrap mode</summary>
		public TextureWrapMode T
		{
			get
			{
				return (TextureWrapMode)(this.bits >> 8);
			}
			set
			{
				this.bits = ((this.bits & 0xFFFF00FF) | (uint)((uint)value << 8));
			}
		}
	}
}
