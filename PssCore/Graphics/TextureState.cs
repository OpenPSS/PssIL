using System;

namespace Sce.PlayStation.Core.Graphics
{
	internal class TextureState
	{
		/*
		 *	Global Variables
		 */
		public TextureFilter filter;
		public TextureWrap wrap;
		public float maxAnisotropy;
		
		public TextureState()
		{
			this.filter = new TextureFilter(TextureFilterMode.Linear, TextureFilterMode.Linear, TextureFilterMode.Linear);
			this.wrap = new TextureWrap(TextureWrapMode.ClampToEdge, TextureWrapMode.ClampToEdge);
			this.maxAnisotropy = 1f;
		}
	}
}
