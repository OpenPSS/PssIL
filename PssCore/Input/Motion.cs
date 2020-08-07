using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>Class representing a motion sensor</summary>
	public static class Motion
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetDataNative(int deviceIndex, ref MotionData gamePadData);
		
		/*
		 *	IL Code.
		 */
		
		/// <summary>Obtains motion sensor data</summary>
		/// <param name="deviceIndex">Device number (from 0)</param>
		/// <returns>Motion sensor data</returns>
		/// <seealso cref="T:Sce.PlayStation.Core.Input.MotionData" />
		[SecuritySafeCritical]
		public static MotionData GetData(int deviceIndex)
		{
			MotionData motionData = default(MotionData);
			int errorCode = Motion.GetDataNative(deviceIndex, ref motionData);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return motionData;
		}
	}
}
