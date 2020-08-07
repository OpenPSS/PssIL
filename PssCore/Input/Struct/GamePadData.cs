using System;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>Gamepad data</summary>
	public struct GamePadData
	{
		/// <summary>Flag to control whether the subsequent processing will ignore this input data or not</summary>
		/// <remarks>Use this flag to store/obtain whether the input data has already been consumed by another object.</remarks>
		public bool Skip;
		/// <summary>Current button state</summary>
		public GamePadButtons Buttons;
		/// <summary>Previous button state</summary>
		public GamePadButtons ButtonsPrev;
		/// <summary>Button pushed-in this time</summary>
		public GamePadButtons ButtonsDown;
		/// <summary>Button released this time</summary>
		public GamePadButtons ButtonsUp;
		/// <summary>X axis of the left analog stick (-1.0 to 1.0)</summary>
		public float AnalogLeftX;
		/// <summary>Y axis of the left analog stick (-1.0 to 1.0)</summary>
		public float AnalogLeftY;
		/// <summary>X axis of the right analog stick (-1.0 to 1.0)</summary>
		public float AnalogRightX;
		/// <summary>Y axis of the right analog stick (-1.0 to 1.0)</summary>
		public float AnalogRightY;
	}
}
