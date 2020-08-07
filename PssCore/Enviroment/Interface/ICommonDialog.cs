using System;

namespace Sce.PlayStation.Core.Environment
{
	/// <summary>Interface common to the Common Dialog</summary>
	public interface ICommonDialog
	{
		/// <summary>Opens the Common Dialog</summary>
		/// <remarks>Calling only in the main thread is possible.</remarks>
		void Open();

		/// <summary>Aborts the Common Dialog</summary>
		/// <remarks>Calling only in the main thread is possible.</remarks>
		void Abort();

		/// <summary>Common Dialog state</summary>
		/// <remarks>Obtaining only in the main thread is possible.</remarks>
		CommonDialogState State { get; }

		/// <summary>Operational result of the Common Dialog</summary>
		/// <remarks>Obtaining only in the main thread is possible.</remarks>
		CommonDialogResult Result { get; }
	}
}
