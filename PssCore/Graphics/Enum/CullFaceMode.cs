using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Back-face culling mode</summary>
	[Flags]
	public enum CullFaceMode : byte
	{
		/// <summary>None</summary>
		None = 0,
		/// <summary>Front surface</summary>
		Front = 1,
		/// <summary>Back surface</summary>
		Back = 2,
		/// <summary>Both front and back surfaces</summary>
		FrontAndBack = 3
	}
}
