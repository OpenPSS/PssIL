using System;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>Touch information for one finger on the touch panel</summary>
	public struct TouchData
	{
		/// <summary>Flag to control whether the subsequent processing will ignore this input data or not</summary>
		/// <remarks>Use this flag to store/obtain whether the input data has already been consumed by another object.</remarks>
		public bool Skip;
		/// <summary>Finger ID</summary>
		public int ID;
		/// <summary>Finger state</summary>
		public TouchStatus Status;
		/// <summary>X coordinate of the touch position</summary>
		public float X;
		/// <summary>Y coordinate of the touch position</summary>
		public float Y;
		private int reserved0;
		private int reserved1;
		private int reserved2;
	}
}
