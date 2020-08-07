using System;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>Motion sensor data</summary>
	public struct MotionData
	{
		/// <summary>Flag to control whether the subsequent processing will ignore this input data or not</summary>
		/// <remarks>Use this flag to store/obtain whether the input data has already been consumed by another object.</remarks>
		public bool Skip;
		/// <summary>Acceleration</summary>
		/// <remarks>This is the data of the acceleration sensor. The right direction of the display's X axis and the upper direction of the Y axis, as well as the nearer direction of the Z axis, are positive. Units are in G. For example, when the display is turned upward and the device is still, the coordinates will be (0, 0, -1). When the display is vertically standing in relation to the ground and still, the coordinates will be (0, -1, 0).</remarks>
		public Vector3 Acceleration;
		/// <summary>Angular velocity</summary>
		/// <remarks>This is the data of the Gyro sensor. Depending on the device, this data will not be obtained.</remarks>
		public Vector3 AngularVelocity;
	}
}
