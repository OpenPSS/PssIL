using System;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Location information</summary>
	public struct LocationData
	{
		/// <summary>Whether the latitude can be calculated</summary>
		public bool HasLatitude { get; internal set; }

		/// <summary>Valid latitude (deg) values are -90 to +90</summary>
		public double Latitude { get; internal set; }

		/// <summary>Whether the longitude can be calculated</summary>
		public bool HasLongitude { get; internal set; }

		/// <summary>Valid longitude (deg) values are -180 to +180</summary>
		public double Longitude { get; internal set; }

		/// <summary>Whether the altitude can be calculated</summary>
		public bool HasAltitude { get; internal set; }

		/// <summary>Altitude (m)</summary>
		public double Altitude { get; internal set; }

		/// <summary>Whether the speed can be calculated</summary>
		public bool HasSpeed { get; internal set; }

		/// <summary>Speed (km/h)</summary>
		public double Speed { get; internal set; }

		/// <summary>Whether the time can be calculated</summary>
		public bool HasTime { get; internal set; }

		/// <summary>Time (msec): UTC time from January 1, 1970 (00:00:00)</summary>
		public long Time { get; internal set; }

		/// <summary>Whether the direction can be calculated</summary>
		public bool HasBearing { get; internal set; }

		/// <summary>Valid direction values are clockwise from the North 0 - 360</summary>
		public double Bearing { get; internal set; }

		/// <summary>Whether the accuracy can be calculated</summary>
		public bool HasAccuracy { get; internal set; }

		/// <summary>Accuracy (m)</summary>
		public double Accuracy { get; internal set; }

		/// <summary>Devices by which calculation is possible</summary>
		public LocationDeviceType DeviceType { get; internal set; }
	}
}
