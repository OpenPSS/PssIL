using System;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Operational state of the camera</summary>
	public enum CameraState
	{
		/// <summary>Stream is not opened</summary>
		Closed, /* 0 */
		/// <summary>Stream is stopped</summary>4
		Stopped, /* 1 */
		/// <summary>Stream is running</summary>
		Running, /* 2 */
		/// <summary>Photograph is being taken</summary>
		TakingPicture /* 3 */
	}
}
