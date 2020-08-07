using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>Class representing the gamepad device</summary>
	public static class GamePad
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetDataNative(int deviceIndex, ref GamePadData gamePadData);
		
		/*
		 *	IL Code.
		 */
		
		/// <summary>Obtains the gamepad data</summary>
		/// <param name="deviceIndex">Device number (from 0)</param>
		/// <returns>Gamepad data</returns>
		/// <seealso cref="T:Sce.PlayStation.Core.Input.GamePadData" />
		[SecuritySafeCritical]
		public static GamePadData GetData(int deviceIndex)
		{
			GamePadData padData = default(GamePadData);
			int errorCode = GamePad.GetDataNative(deviceIndex, ref padData);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return padData;
		}
	}
}
