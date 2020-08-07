using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing the graphics capacity</summary>
	public struct GraphicsCaps
	{
		/*
		 *	Global Variables
		 */
		internal GraphicsCapsState state;
		
		[SecuritySafeCritical]
		internal GraphicsCaps(GraphicsContext graphics)
		{
			PsmGraphicsContext.GetCaps(graphics.handle, out this.state);
		}

		/// <summary>Viewport maximum width</summary>
		public int MaxViewportWidth
		{
			get
			{
				return this.state.MaxViewportWidth;
			}
		}

		/// <summary>Viewport maximum height</summary>
		public int MaxViewportHeight
		{
			get
			{
				return this.state.MaxViewportHeight;
			}
		}

		/// <summary>Texture maximum width and height</summary>
		public int MaxTextureSize
		{
			get
			{
				return this.state.MaxTextureSize;
			}
		}

		/// <summary>Cube texture maximum width and height</summary>
		public int MaxCubeMapTextureSize
		{
			get
			{
				return this.state.MaxCubeMapTextureSize;
			}
		}

		/// <summary>Render buffer maximum width and height</summary>
		public int MaxRenderbufferSize
		{
			get
			{
				return this.state.MaxRenderbufferSize;
			}
		}

		/// <summary>Maximum number of vectors for the uniform variable of the vertex shader</summary>
		public int MaxVertexUniformVectors
		{
			get
			{
				return this.state.MaxVertexUniformVectors;
			}
		}

		/// <summary>Maximum number of vectors for the uniform variable of the fragment shader</summary>
		public int MaxFragmentUniformVectors
		{
			get
			{
				return this.state.MaxFragmentUniformVectors;
			}
		}

		/// <summary>Maximum number of vectors for the vertex attribute</summary>
		public int MaxVertexAttribs
		{
			get
			{
				return this.state.MaxVertexAttribs;
			}
		}

		/// <summary>Maximum number of vectors for the varying variable</summary>
		public int MaxVaryingVectors
		{
			get
			{
				return this.state.MaxVaryingVectors;
			}
		}

		/// <summary>Maximum number of texture units for the fragment shader</summary>
		public int MaxTextureImageUnits
		{
			get
			{
				return this.state.MaxTextureImageUnits;
			}
		}

		/// <summary>Maximum number of anisotropies for the texture filter</summary>
		public float MaxTextureMaxAnisotropy
		{
			get
			{
				return this.state.MaxTextureMaxAnisotropy;
			}
		}

		/// <summary>Line maximum width</summary>
		public float MinAliasedLineWidth
		{
			get
			{
				return this.state.MinAliasedLineWidth;
			}
		}

		/// <summary>Line maximum height</summary>
		public float MaxAliasedLineWidth
		{
			get
			{
				return this.state.MaxAliasedLineWidth;
			}
		}

		/// <summary>Point minimum size</summary>
		public float MinAliasedPointSize
		{
			get
			{
				return this.state.MinAliasedPointSize;
			}
		}

		/// <summary>Point maximum size</summary>
		public float MaxAliasedPointSize
		{
			get
			{
				return this.state.MaxAliasedPointSize;
			}
		}

		/// <summary>Enables the application of anisotropic filtering to the texture</summary>
		public bool SupportTextureFilterAnisotropic
		{
			get
			{
				return (this.state.Extension & GraphicsExtension.TextureFilterAnisotropic) != GraphicsExtension.None;
			}
		}

		/// <summary>Enables the creation of a vertex buffer of the half float format</summary>
		public bool SupportVertexHalfFloat
		{
			get
			{
				return (this.state.Extension & GraphicsExtension.VertexHalfFloat) != GraphicsExtension.None;
			}
		}

		/// <summary>Enables the creation of a texture of the half float format</summary>
		public bool SupportTextureHalfFloat
		{
			get
			{
				return (this.state.Extension & GraphicsExtension.TextureHalfFloat) != GraphicsExtension.None;
			}
		}

		/// <summary>Enables the application of the linear mode to texture filtering to a texture of the half float format</summary>
		public bool SupportTextureHalfFloatLinear
		{
			get
			{
				return (this.state.Extension & GraphicsExtension.TextureHalfFloatLinear) != GraphicsExtension.None;
			}
		}

		/// <summary>Enables the creation of a color buffer of the RGBA 8-bit format</summary>
		public bool SupportRgb8Rgba8
		{
			get
			{
				return (this.state.Extension & GraphicsExtension.Rgb8Rgba8) != GraphicsExtension.None;
			}
		}

		/// <summary>Enables the creation of a depth buffer of the depth 24-bit format</summary>
		public bool SupportDepth24
		{
			get
			{
				return (this.state.Extension & GraphicsExtension.Depth24) != GraphicsExtension.None;
			}
		}

		/// <summary>Enables the creation of a depth buffer of the stencil 24-bit+8-bit format</summary>
		public bool SupportPackedDepthStencil
		{
			get
			{
				return (this.state.Extension & GraphicsExtension.PackedDepthStencil) != GraphicsExtension.None;
			}
		}

	}
}
