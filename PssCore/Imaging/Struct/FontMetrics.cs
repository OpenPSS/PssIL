using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Font metrics information</summary>
	public struct FontMetrics
	{
		/*
		 * Global Variables
		 */
		
		/// <summary>Length from the baseline to the upper edge of the character</summary>
		public int Ascent;
		/// <summary>Length from the baseline to the lower edge of the character</summary>
		public int Descent;
		/// <summary>Row spacing</summary>
		public int Leading;
		
		/// <summary>Distance between the baselines of the 2 lines</summary>
		public int Height
		{
			get
			{
				return this.Ascent + this.Descent + this.Leading;
			}
		}
	}
}
