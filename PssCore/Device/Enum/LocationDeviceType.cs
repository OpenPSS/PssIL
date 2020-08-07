using System;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Type of location device</summary>
	[Flags]
	public enum LocationDeviceType : uint
	{
		/// <summary>There is no device that can calculate location or the device is not ON</summary>
		None = 0x00,
		/// <summary>GPS</summary>
		Gps = 0x01,
		/// <summary>Wi-Fi</summary>
		Wifi = 0x02,
		/// <summary>3G</summary>
		Cell3G = 0x04,
		/// <summary>Unknown device</summary>
		Unknown = 0x80000000
	}
}
