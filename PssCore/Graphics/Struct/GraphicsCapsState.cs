using System;

namespace Sce.PlayStation.Core.Graphics
{
	internal struct GraphicsCapsState
	{
		/*
		 *	Global Variables
		 */
		
		public GraphicsExtension Extension;
		public int MaxViewportWidth;
		public int MaxViewportHeight;
		public int MaxTextureSize;
		public int MaxCubeMapTextureSize;
		public int MaxRenderbufferSize;
		public int MaxVertexUniformVectors;
		public int MaxFragmentUniformVectors;
		public int MaxVertexAttribs;
		public int MaxVaryingVectors;
		public int MaxCombinedTextureImageUnits;
		public int MaxTextureImageUnits;
		public int MaxVertexTextureImageUnits;
		public float MaxTextureMaxAnisotropy;
		public float MinAliasedLineWidth;
		public float MaxAliasedLineWidth;
		public float MinAliasedPointSize;
		public float MaxAliasedPointSize;
	}
}
