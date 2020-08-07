using System;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Common Dialog state</summary>
	public enum CommonDialogState : uint
	{
		/// <summary>Not used</summary>
		None, /* 0 */
		/// <summary>Running</summary>
		Running, /* 1 */
		/// <summary>Terminated</summary>
		Finished /* 2 */
	}
}
