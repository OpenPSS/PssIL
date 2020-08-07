using System;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Metrics information per character</summary>
	public struct CharMetrics
	{
		/// <summary>X coordinate of the character's standard position</summary>
		public float X;
		/// <summary>Y coordinate of the character's standard position</summary>
		public float Y;
		/// <summary>Character width</summary>
		public float Width;
		/// <summary>Character height</summary>
		public float Height;
		/// <summary>Distance from the standard position to the left edge of the character (right is positive)</summary>
		public float HorizontalBearingX;
		/// <summary>Distance from the standard position to the top of the character (up is positive)</summary>
		public float HorizontalBearingY;
		/// <summary>Distance from the standard position of one character to the next</summary>
		public float HorizontalAdvance;
		private int reserved0;
		private int reserved1;
		private int reserved2;
		private int reserved3;
	}
}
