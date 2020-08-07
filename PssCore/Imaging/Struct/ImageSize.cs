using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Image size</summary>
	public struct ImageSize
	{
		/*
		 * 	Global Variables
		 */
		
		/// <summary>Width</summary>
		public int Width;
		/// <summary>Height</summary>
		public int Height;
		
		/// <summary>ImageSize constructor</summary>
		/// <param name="width">Width</param>
		/// <param name="height">Height</param>
		public ImageSize(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}
		
	}
}
