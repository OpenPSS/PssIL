using System;
using System.Runtime.CompilerServices;
using System.Security;
using Sce.PlayStation.Core.Environment;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Common dialog class to select a photograph</summary>
	public class PhotoImportDialog : ICommonDialog, IDisposable
	{
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewNative(int type, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ReleaseNative(int type, int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int OpenNative(int type, int handle, ref PhotoImportDialog.DialogArguments dialogArguments);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int AbortNative(int type, int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetState(int type, int handle, out CommonDialogState commonDialogState);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetResult(int type, int handle, out CommonDialogResult commonDialogResult, out PhotoImportDialog.DialogResults dialogResults);
		
		/*
		 * Global Variables 
		 */
		
		/// <summary>Obtains the file path of the content stored in the local area</summary>
		public string Filename { get; private set; }
		
		private static readonly int DialogType = 769;
		
		private int m_Handle;

		/// <summary>Parameters that can be specified when opening the common dialog for selecting a photograph</summary>
		private struct DialogArguments { }

		/// <summary>Result of storing a photograph</summary>
		private struct DialogResults
		{
			/// <summary>File path of the content stored in the local area</summary>
			public string Filename;
		}
		
		/*
		 *	IL Code.
		 */
		
		/// <summary>Constructor</summary>
		[SecuritySafeCritical]
		public PhotoImportDialog()
		{
			int nativeResult = PhotoImportDialog.NewNative(PhotoImportDialog.DialogType, out this.m_Handle);
			PhotoImportDialog.CheckNativeResult(nativeResult);
		}

		/// <summary>Destructor</summary>
		~PhotoImportDialog()
		{
			this.Dispose(false);
		}

		/// <summary>Destroys the common dialog object for selecting a photograph</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Destroys the common dialog object for selecting a photograph</summary>
		/// <param name="disposing">Whether an object is being destroyed or not</param>
		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (0 != this.m_Handle)
			{
				PhotoImportDialog.ReleaseNative(PhotoImportDialog.DialogType, this.m_Handle);
				this.m_Handle = 0;
			}
		}

		/// <summary>Opens the common dialog for selecting a photograph</summary>
		public void Open()
		{
			this.Open(default(PhotoImportDialog.DialogArguments));
		}

		/// <summary>Opens the common dialog for selecting a photograph</summary>
		/// <param name="args">Parameters of the common dialog for selecting a photograph</param>
		[SecuritySafeCritical]
		private void Open(PhotoImportDialog.DialogArguments args)
		{
			int nativeResult = PhotoImportDialog.OpenNative(PhotoImportDialog.DialogType, this.m_Handle, ref args);
			PhotoImportDialog.CheckNativeResult(nativeResult);
		}

		/// <summary>Aborts the common dialog for selecting a photograph</summary>
		[SecuritySafeCritical]
		public void Abort()
		{
			int nativeResult = PhotoImportDialog.AbortNative(PhotoImportDialog.DialogType, this.m_Handle);
			PhotoImportDialog.CheckNativeResult(nativeResult);
		}

		/// <summary>Obtains the state of the common dialog for selecting a photograph</summary>
		public CommonDialogState State
		{
			[SecuritySafeCritical]
			get
			{
				CommonDialogState result = CommonDialogState.None;
				int state = PhotoImportDialog.GetState(PhotoImportDialog.DialogType, this.m_Handle, out result);
				PhotoImportDialog.CheckNativeResult(state);
				return result;
			}
		}

		/// <summary>Obtains the result of the common dialog for selecting a photograph</summary>
		public CommonDialogResult Result
		{
			[SecuritySafeCritical]
			get
			{
				CommonDialogResult commonDialogResult = CommonDialogResult.OK;
				PhotoImportDialog.DialogResults dialogResults = default(PhotoImportDialog.DialogResults);
				int result = PhotoImportDialog.GetResult(PhotoImportDialog.DialogType, this.m_Handle, out commonDialogResult, out dialogResults);
				PhotoImportDialog.CheckNativeResult(result);
				if (CommonDialogResult.OK == commonDialogResult)
				{
					this.Filename = dialogResults.Filename;
				}
				return commonDialogResult;
			}
		}

		private static void CheckNativeResult(int nativeResult)
		{
			if (0 != nativeResult)
			{
				Error.ThrowNativeException(nativeResult);
			}
		}
	}
}
