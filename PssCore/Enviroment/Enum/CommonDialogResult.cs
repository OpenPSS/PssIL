using System;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Operational result of the Common Dialog</summary>
	public enum CommonDialogResult : uint
	{
		/// <summary>Successful</summary>
		OK, /* 0 */
		/// <summary>Canceled by the user</summary>
		Canceled, /* 1 */
		/// <summary>Aborted by the program</summary>
		Aborted, /* 2 */
		/// <summary>Error occurred</summary>
		Error /* 3 */
	}
}
