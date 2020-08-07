using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Coordinate within the image (upper left being the origin)</summary>
	public struct ImagePosition
	{
		/*
		 *	Global Variables
		 */
		
		/// <summary>X coordinate</summary>
		public int X;
		/// <summary>Y coordinate</summary>
		public int Y;
		
		/// <summary>ImagePosition constructor</summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		public ImagePosition(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
	}
}
