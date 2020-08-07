using System;

namespace Sce.PlayStation.Core.Input
{
	/// <summary>State of the touch panel finger data</summary>
	public enum TouchStatus : uint
	{
		/// <summary>Not pressed</summary>
		None, /* 0 */
		/// <summary>Pressed</summary>
		Down, /* 1 */
		/// <summary>Released</summary>
		Up, /* 2 */
		/// <summary>Moved</summary>
		Move, /* 3 */
		/// <summary>Canceled</summary>
		Canceled /* 4 */
	}
}
