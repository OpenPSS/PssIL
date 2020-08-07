using System;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Primitive rendering mode</summary>
	public enum DrawMode : ushort
	{
		/// <summary>Point list</summary>
		Points,
		/// <summary>Line list</summary>
		Lines,
		/// <summary>Line strip</summary>
		LineStrip,
		/// <summary>Triangle list</summary>
		Triangles,
		/// <summary>Triangle strip</summary>
		TriangleStrip,
		/// <summary>Triangle fan</summary>
		TriangleFan
	}
}
