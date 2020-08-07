using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Class representing location information</summary>
	public static class Location
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int StartNative();
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int StopNative();
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetDataNative(ref LocationData locationData);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern uint GetEnableDevicesNative();
		
				
		/*
		 *	IL Code.
		 */
		
		
		/// <summary>Starts tracking location information</summary>
		/// <returns>False when initialization is not correctly carried out. For example, when there is no mention of Location in app.xml.</returns>
		[SecuritySafeCritical]
		public static bool Start()
		{
			int errorCode = Location.StartNative();
			return errorCode == 0;
		}

		/// <summary>Stops tracking location information</summary>
		/// <returns>False when initialization is not correctly carried out.</returns>
		[SecuritySafeCritical]
		public static bool Stop()
		{
			int errorCode = Location.StopNative();
			return errorCode == 0;
		}

		/// <summary>Tracks location information</summary>
		/// <returns>Location information</returns>
		/// <seealso cref="T:Sce.PlayStation.Core.Device.LocationData" />
		[SecuritySafeCritical]
		public static LocationData GetData()
		{
			LocationData data = default(LocationData);
			int errorCode = Location.GetDataNative(ref data);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(dataNative);
			}
			return data;
		}

		/// <summary>Obtains device with which location information can be calculated</summary>
		/// <returns>Device information (LocationDeviceType)</returns>
		[SecuritySafeCritical]
		public static LocationDeviceType GetEnableDevices()
		{
			return (LocationDeviceType)Enum.Parse(typeof(LocationDeviceType), Location.GetEnableDevicesNative().ToString());
		}
	}
}
