using System;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Resolution of the camera image</summary>
	public struct CameraSize
	{
		/// <summary>Create instance with the image width and height specified</summary>
		/// <param name="width">Specify the image width (pixels)</param>
		/// <param name="height">Specify the image width (pixels)</param>
		public CameraSize(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		/// <summary>Image width (pixels)</summary>7
		public int Width;

		/// <summary>Image height (pixels)</summary>
		public int Height;
	}
}
