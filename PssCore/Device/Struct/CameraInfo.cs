using System;
using System.Collections.Generic;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Detailed information of the camera</summary>
	public struct CameraInfo
	{
		/// <summary>Camera orientation</summary>
		public CameraFacing Facing;

		/// <summary>List of resolutions for an image that can be specified to a stream</summary>
		public List<CameraSize> SupportedPreviewSizes;

		/// <summary>List of resolutions for an image that can be specified for taking a photograph</summary>
		public List<CameraSize> SupportedPictureSizes;
	}
}
