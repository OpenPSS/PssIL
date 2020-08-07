using System;
using System.Runtime.CompilerServices;
using System.Security;
using Sce.PlayStation.Core.Environment;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Common dialog class to take a photograph</summary>
	public class CameraImportDialog : ICommonDialog, IDisposable
	{
		/// <summary>Obtains the file path of the content stored in the local area</summary>
		public string Filename { get; private set; }
		
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewNative(int type, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ReleaseNative(int type, int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int OpenNative(int type, int handle, ref CameraImportDialog.DialogArguments dialogArguments);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int AbortNative(int type, int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetState(int type, int handle, out CommonDialogState commonDialogState);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetResult(int type, int handle, out CommonDialogResult commonDialogResult, out CameraImportDialog.DialogResults dialogResults);
		
		/*
		 * Global Variables
		 */
		
		private static readonly int DialogType = 513;

		private int m_Handle;

		/// <summary>Parameters that can be specified when opening the common dialog for taking a photograph</summary>
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
		public CameraImportDialog()
		{
			int nativeResult = CameraImportDialog.NewNative(CameraImportDialog.DialogType, out this.m_Handle);
			CameraImportDialog.CheckNativeResult(nativeResult);
		}

		/// <summary>Destructor</summary>
		~CameraImportDialog()
		{
			this.Dispose(false);
		}

		/// <summary>Destroys the common dialog object for taking a photograph</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Destroys the common dialog object for taking a photograph</summary>
		/// <param name="disposing">Whether an object is being destroyed or not</param>
		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (0 != this.m_Handle)
			{
				CameraImportDialog.ReleaseNative(CameraImportDialog.DialogType, this.m_Handle);
				this.m_Handle = 0;
			}
		}

		/// <summary>Opens the common dialog for taking a photograph</summary>
		public void Open()
		{
			this.Open(default(CameraImportDialog.DialogArguments));
		}

		/// <summary>Opens the common dialog for taking a photograph</summary>
		/// <param name="args">Parameters of the common dialog for taking a photograph</param>
		[SecuritySafeCritical]
		private void Open(CameraImportDialog.DialogArguments args)
		{
			int nativeResult = CameraImportDialog.OpenNative(CameraImportDialog.DialogType, this.m_Handle, ref args);
			CameraImportDialog.CheckNativeResult(nativeResult);
		}

		/// <summary>Aborts the common dialog for taking a photograph</summary>
		[SecuritySafeCritical]
		public void Abort()
		{
			int nativeResult = CameraImportDialog.AbortNative(CameraImportDialog.DialogType, this.m_Handle);
			CameraImportDialog.CheckNativeResult(nativeResult);
		}

		/// <summary>Obtains the state of the common dialog for taking a photograph</summary>
		public CommonDialogState State
		{
			[SecuritySafeCritical]
			get
			{
				CommonDialogState result = CommonDialogState.None;
				int state = CameraImportDialog.GetState(CameraImportDialog.DialogType, this.m_Handle, out result);
				CameraImportDialog.CheckNativeResult(state);
				return result;
			}
		}

		/// <summary>Obtains the result of the common dialog for taking a photograph</summary>
		public CommonDialogResult Result
		{
			[SecuritySafeCritical]
			get
			{
				CommonDialogResult commonDialogResult = CommonDialogResult.OK;
				CameraImportDialog.DialogResults dialogResults = default(CameraImportDialog.DialogResults);
				int result = CameraImportDialog.GetResult(CameraImportDialog.DialogType, this.m_Handle, out commonDialogResult, out dialogResults);
				CameraImportDialog.CheckNativeResult(result);
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
