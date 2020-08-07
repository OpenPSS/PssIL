using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>Class representing the touch panel device</summary>
	public static class Touch
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetDataNative(int deviceIndex, TouchData[] touchData, int numElements, ref int numFinger);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetRearTouchDataNative(int deviceIndex, TouchData[] touchData, int numElements, ref int numFinger);
		
		/*
		 *	IL Code.
		 */
		
		/// <summary>Obtains the front touch panel data</summary>
		/// <param name="deviceIndex">Device number (from 0)</param>
		/// <returns>Touch panel data</returns>
		/// <seealso cref="T:Sce.PlayStation.Core.Input.TouchData" />
		[SecuritySafeCritical]
		public static List<TouchData> GetData(int deviceIndex)
		{
			TouchData[] touchData = new TouchData[10];
			int numFingers = 0;
			int errorCode = Touch.GetDataNative(deviceIndex, touchData, 10, ref numFingers);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			List<TouchData> touchList = new List<TouchData>();
			for (int i = 0; i < numFingers; i++)
			{
				touchList.Add(touchData[i]);
			}
			return touchList;
		}

		/// <summary>Obtains the rear touch panel data</summary>
		/// <param name="deviceIndex">Device number (from 0)</param>
		/// <returns>Touch panel data</returns>
		/// <seealso cref="T:Sce.PlayStation.Core.Input.TouchData" />
		[SecuritySafeCritical]
		public static List<TouchData> GetRearTouchData(int deviceIndex)
		{
			TouchData[] touchData = new TouchData[10];
			int numFingers = 0;
			int errorCode = Touch.GetRearTouchDataNative(deviceIndex, touchData, 10, ref numFingers);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			List<TouchData> touchList = new List<TouchData>();
			for (int i = 0; i < numFingers; i++)
			{
				touchList.Add(touchData[i]);
			}
			return touchList;
		}
	}
}
