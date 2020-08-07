using System;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Picture state</summary>
	public enum PictureState
	{
		/// <summary>Photograph is not yet taken</summary>
		Idle, /* 0 */
		/// <summary>Photograph is being taken</summary>
		Running, /* 1 */
		/// <summary>Photograph was taken</summary>
		Finishied, /* 2 */
		/// <summary>Failed to take a photograph</summary>
		Failed = -1
	}
}
