using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Rectangular area within the image</summary>
	public struct ImageRect
	{
		/*
		 *	Global Variables
		 */
		
		/// <summary>X coordinate</summary>
		public int X;
		/// <summary>Y coordinate</summary>
		public int Y;
		/// <summary>Width</summary>
		public int Width;
		/// <summary>Height</summary>
		public int Height;
		
		/// <summary>ImageRect constructor</summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		/// <param name="width">Width</param>
		/// <param name="height">Height</param>
		public ImageRect(int x, int y, int width, int height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}
		
		[Obsolete("Use X")]
		public int Left
		{
			get
			{
				return this.X;
			}
			set
			{
				this.X = value;
			}
		}

		[Obsolete("Use Y")]
		public int Top
		{
			get
			{
				return this.Y;
			}
			set
			{
				this.Y = value;
			}
		}

		[Obsolete("Use X+Width")]
		public int Right
		{
			get
			{
				return this.X + this.Width;
			}
			set
			{
				this.Width = value - this.X;
			}
		}

		[Obsolete("Use Y+Height")]
		public int Bottom
		{
			get
			{
				return this.Y + this.Height;
			}
			set
			{
				this.Height = value - this.Y;
			}
		}

	}
}
