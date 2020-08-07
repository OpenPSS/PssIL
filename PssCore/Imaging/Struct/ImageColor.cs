using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Pixel color</summary>
	public struct ImageColor
	{
		/*
		 *	Global Variables
		 */
		
		/// <summary>Red element (0-255)</summary>
		public int R;
		/// <summary>Green element (0-255)</summary>
		public int G;
		/// <summary>Blue element (0-255)</summary>
		public int B;
		/// <summary>Alpha value (0-255)</summary>
		public int A;
		
		public ImageColor(int r, int g, int b, int a)
		{
			this.R = r;
			this.G = g;
			this.B = b;
			this.A = a;
		}
	}
}
