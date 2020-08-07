using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Structure representing the rendering result storage destination</summary>
	public struct RenderTarget
	{
		/*
		 *	Global Variables
		 */
		
		/// <summary>Pixel buffer storing the rendering result</summary>
		public PixelBuffer Buffer;

		/// <summary>Mipmap level of the texture storing the rendering result</summary>
		public int Level;

		/// <summary>Cube surface of cube texture storing the rendering result</summary>
		public TextureCubeFace CubeFace;
		
		/// <summary>Creates a structure representing the rendering result storage destination</summary>
		/// <param name="buffer">Color buffer (release when NULL)</param>
		public RenderTarget(ColorBuffer buffer)
		{
			this.Buffer = buffer;
			this.Level = 0;
			this.CubeFace = TextureCubeFace.PositiveX;
		}

		/// <summary>Creates a structure representing the rendering result storage destination</summary>
		/// <param name="buffer">Depth buffer (release when NULL)</param>
		public RenderTarget(DepthBuffer buffer)
		{
			this.Buffer = buffer;
			this.Level = 0;
			this.CubeFace = TextureCubeFace.PositiveX;
		}

		/// <summary>Creates a structure representing the rendering result storage destination</summary>
		/// <param name="texture">2D texture (release when NULL)</param>
		/// <param name="level">Texture mipmap level (from 0 to LevelCount-1)</param>
		public RenderTarget(Texture2D texture, int level)
		{
			this.Buffer = texture;
			this.Level = level;
			this.CubeFace = TextureCubeFace.PositiveX;
		}

		/// <summary>Creates a structure representing the rendering result storage destination</summary>
		/// <param name="texture">Cube texture (release when NULL)</param>
		/// <param name="level">Texture mipmap level (from 0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube texture cube surface</param>
		public RenderTarget(TextureCube texture, int level, TextureCubeFace cubeFace)
		{
			this.Buffer = texture;
			this.Level = level;
			this.CubeFace = cubeFace;
		}

		/// <summary>Sets a value to the structure representing the rendering result storage destination</summary>
		/// <param name="buffer">Color buffer (release when NULL)</param>
		public void Set(ColorBuffer buffer)
		{
			this.Buffer = buffer;
			this.Level = 0;
			this.CubeFace = TextureCubeFace.PositiveX;
		}

		/// <summary>Sets a value to the structure representing the rendering result storage destination</summary>
		/// <param name="buffer">Depth buffer (release when NULL)</param>
		public void Set(DepthBuffer buffer)
		{
			this.Buffer = buffer;
			this.Level = 0;
			this.CubeFace = TextureCubeFace.PositiveX;
		}

		/// <summary>Sets a value to the structure representing the rendering result storage destination</summary>
		/// <param name="texture">2D texture (release when NULL)</param>
		/// <param name="level">Texture mipmap level (from 0 to LevelCount-1)</param>
		public void Set(Texture2D texture, int level)
		{
			this.Buffer = texture;
			this.Level = level;
			this.CubeFace = TextureCubeFace.PositiveX;
		}

		/// <summary>Sets a value to the structure representing the rendering result storage destination</summary>
		/// <param name="texture">Cube texture (release when NULL)</param>
		/// <param name="level">Texture mipmap level (from 0 to LevelCount-1)</param>
		/// <param name="cubeFace">Cube texture cube surface</param>
		public void Set(TextureCube texture, int level, TextureCubeFace cubeFace)
		{
			this.Buffer = texture;
			this.Level = level;
			this.CubeFace = cubeFace;
		}
	}
}
