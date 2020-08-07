using System;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>Gamepad button enumerator</summary>
	[Flags]
	public enum GamePadButtons : uint
	{
		/// <summary>Left directional key</summary>
		Left = 0x01, 
		/// <summary>Up directional key</summary>
		Up = 0x02,
		/// <summary>Right directional key</summary>
		Right = 0x04,
		/// <summary>Down directional key</summary>
		Down = 0x08,
		/// <summary>Square button</summary>
		Square = 0x10,
		/// <summary>Triangle button</summary>
		Triangle = 0x20,
		/// <summary>Circle button</summary>
		Circle = 0x40,
		/// <summary>Cross button</summary>
		Cross = 0x80,
		/// <summary>Start button</summary>
		Start = 0x100,
		/// <summary>Select button</summary>
		Select = 0x200,
		/// <summary>L button</summary>
		L = 0x400,
		/// <summary>R button</summary>
		R = 0x800,
		/// <summary>Enter button</summary>
		/// <remarks>The circle or cross button that has the meaning of [Enter] with the value of SystemParameters.GamePadButtonMeaning is abstracted and notified as the Enter button.</remarks>
		Enter = 0x10000,
		/// <summary>Back button</summary>
		/// <remarks>The circle or cross button that has the meaning of [Back] with the value of SystemParameters.GamePadButtonMeaning is abstracted and notified as the Back button.</remarks>
		Back = 0x20000
	}
}
