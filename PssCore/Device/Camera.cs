using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;

namespace Sce.PlayStation.Core.Device
{
	/// <summary>Class representing a camera</summary>
	public class Camera : IDisposable
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetNumberOfCamerasNative();
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetCameraFacingNative(int cameraId, out CameraFacing info);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetSupportedPreviewSizeCountNative(int cameraId);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetSupportedPreviewSizeNative(int cameraId, int sizeId, out CameraSize size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetSupportedPictureSizeCountNative(int cameraId);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetSupportedPictureSizeNative(int cameraId, int sizeId, out CameraSize size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewFromIndex(int cameraId, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ReleaseNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetCameraStateNative(int handle, out CameraState state);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int HasTakenPictureNative(int handle, out PictureState taken);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int OpenNative(int handle, CameraSize size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int CloseNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPreviewSizeNative(int handle, out CameraSize size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPreviewImageFormatNative(int handle, out CameraImageFormat format);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int StartNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int StopNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ReadNative(int handle, byte[] frameBuffer, int bufferSize, out long frameCount);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int TakePictureNative(int handle, CameraSize size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPictureFilenameNative(int handle, out string filename);
		

		/*
		 * Global Variables
		 */
		/// <summary>Error code when the method cannot be called</summary>
		private const int InvalidOperaion = unchecked((int)0x80580004);

		/// <summary>Error code when the object is already deleted</summary>
		private const int ObjectDisposed = unchecked((int)0x80580005);

		/// <summary>Error code when outside of the array range was specified</summary>
		private const int ArgumentOutOfRange = unchecked((int)0x80580003);
		
		/// <summary>Event that occurs when the stream image frame has changed<br />
		/// Occurs asynchronously in a thread separate from the thread that called the Start method</summary>
		public event EventHandler<Camera.FrameChangedEventArgs> FrameChanged;

		/// <summary>Event that occurs when the picture state has changed<br />
		/// Occurs asynchronously in a thread separate from the thread that called the TakePicture method</summary>
		public event EventHandler<Camera.PictureStateChangedEventArgs> PictureStateChanged;
			
		private Camera.FrameChangedCallback _frameChangedCallback;
		private Camera.PictureStateChangedCallback _pictureStateChangedCallback;
		private int _handle = 0;
		private Thread _thread = null;
		private bool _cancel = false;
		private bool _disposed = false;
		private CameraInfo _cameraInfo;
		private CameraSize _currentPreviewSize;
		private CameraImageFormat _currentPreviewImageFormat;
		private static int _numberOfCameras = -1;
		private static CameraInfo[] _cameraInfos = null;
		private bool _isTakingPicture = false;
		private static BackgroundWorker _worker = null;
		private static object syncObject = new object();
		
		/*
		 *	IL Code.
		 */
		
		/// <summary>Obtain the number of cameras</summary>
		/// <returns>Number of cameras</returns>
		[SecuritySafeCritical]
		public static int GetNumberOfCameras()
		{
			if (Camera._numberOfCameras < 0)
			{
				Camera._numberOfCameras = Camera.GetNumberOfCamerasNative();
				if (Camera._numberOfCameras > 0)
				{
					Camera._cameraInfos = new CameraInfo[Camera._numberOfCameras];
					for (int i = 0; i < Camera._numberOfCameras; i++)
					{
						Camera._cameraInfos[i].SupportedPreviewSizes = new List<CameraSize>();
						Camera._cameraInfos[i].SupportedPictureSizes = new List<CameraSize>();
					}
				}
			}
			return Camera._numberOfCameras;
		}

		/// <summary>Obtain detailed information of the camera</summary>
		/// <param name="cameraId">Camera number</param>
		/// <returns>Detailed information of the camera</returns>
		[SecuritySafeCritical]
		public static CameraInfo GetCameraInfo(int cameraId)
		{
			if (Camera._cameraInfos == null)
			{
				Camera.GetNumberOfCameras();
			}
			if (Camera._cameraInfos[cameraId].SupportedPreviewSizes.Count == 0)
			{
				CameraFacing facing;
				int camFacing = Camera.GetCameraFacingNative(cameraId, out facing);
				if (camFacing != 0)
				{
					Error.ThrowNativeException(camFacing);
				}
				int supportedPrevSizeCount = Camera.GetSupportedPreviewSizeCountNative(cameraId);
				for (int i = 0; i < supportedPrevSizeCount; i++)
				{
					CameraSize cameraSize;
					int supportedPrevSize = Camera.GetSupportedPreviewSizeNative(cameraId, i, out cameraSize);
					if (supportedPrevSize != 0)
					{
						Error.ThrowNativeException(supportedPrevSize);
					}
					if (cameraSize.Width > 0 && cameraSize.Height > 0 && !Camera._cameraInfos[cameraId].SupportedPreviewSizes.Contains(cameraSize))
					{
						Camera._cameraInfos[cameraId].SupportedPreviewSizes.Add(cameraSize);
					}
				}
				int supportedPictureSizeCount = Camera.GetSupportedPictureSizeCountNative(cameraId);
				for (int i = 0; i < supportedPictureSizeCount; i++)
				{
					CameraSize cameraSize;
					int supportedPictureSize = Camera.GetSupportedPictureSizeNative(cameraId, i, out cameraSize);
					if (supportedPictureSize != 0)
					{
						Error.ThrowNativeException(supportedPictureSize);
					}
					if (!Camera._cameraInfos[cameraId].SupportedPictureSizes.Contains(cameraSize))
					{
						Camera._cameraInfos[cameraId].SupportedPictureSizes.Add(cameraSize);
					}
				}
				Camera._cameraInfos[cameraId].Facing = facing;
			}
			return Camera._cameraInfos[cameraId];
		}

		/// <summary>Constructor that activates a camera and creates an instance<br />
		/// The instance must be destroyed using the Dispose method<br />
		/// Because only one camera can be used, when using a different camera,
		/// a new instance must be created after deleting the current instance.</summary>
		/// <param name="cameraId">Camera number</param>
		[SecuritySafeCritical]
		public Camera(int cameraId)
		{
			int errorCode = Camera.NewFromIndex(cameraId, out this._handle);
			if (errorCode < 0 || this._handle == 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this._cameraInfo = Camera.GetCameraInfo(cameraId);
			this._frameChangedCallback = delegate(byte[] frameBuffer, long frameCount)
			{
				EventHandler<Camera.FrameChangedEventArgs> frameChanged = this.FrameChanged;
				if (frameChanged != null)
				{
					frameChanged.Invoke(this, new Camera.FrameChangedEventArgs(frameBuffer, frameCount));
				}
			};
			this._pictureStateChangedCallback = delegate(PictureState taken)
			{
				EventHandler<Camera.PictureStateChangedEventArgs> pictureStateChanged = this.PictureStateChanged;
				if (pictureStateChanged != null)
				{
					pictureStateChanged.Invoke(this, new Camera.PictureStateChangedEventArgs(taken));
				}
			};
			this._disposed = false;
			this._isTakingPicture = false;
			if (Camera._worker == null)
			{
				Camera._worker = new BackgroundWorker();
				Camera._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
			}
		}

		private void _worker_DoWork(object sender, DoWorkEventArgs e)
		{
			Camera.DoWork(e.Argument);
		}

		/// <summary>Destructor to destroy the camera instance</summary>
		~Camera()
		{
			this.Dispose(false);
		}

		/// <summary>Destroy the camera instance</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Destroy the camera instance</summary>
		/// <param name="disposing">Whether an instance is being destroyed or not</param>
		[SecuritySafeCritical]
		protected void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
				}
				if (this._handle != 0)
				{
					Camera.ReleaseNative(this._handle);
					this._handle = 0;
				}
				this._disposed = true;
			}
		}

		/// <summary>Obtain the operational state of a camera</summary>
		public CameraState CameraState
		{
			[SecuritySafeCritical]
			get
			{
				if (this._handle == 0)
				{
					Error.ThrowNativeException(ObjectDisposed);
				}
				CameraState cameraState;
				int cameraStateNative = Camera.GetCameraStateNative(this._handle, out cameraState);
				CameraState result;
				if (cameraStateNative < 0)
				{
					this.Close();
					result = CameraState.Closed;
				}
				else
				{
					result = cameraState;
				}
				return result;
			}
		}

		/// <summary>Obtain the camera's photo taking state</summary>
		public PictureState PictureState
		{
			[SecuritySafeCritical]
			get
			{
				if (this._handle == 0)
				{
					Error.ThrowNativeException(ObjectDisposed);
				}
				PictureState pictureState;
				int errorCode = Camera.HasTakenPictureNative(this._handle, out pictureState);
				PictureState result;
				if (errorCode < 0)
				{
					this.Close();
					result = PictureState.Failed;
				}
				else
				{
					result = pictureState;
				}
				return result;
			}
		}

		/// <summary>Open the stream with the default resolution</summary>
		public void Open()
		{
			this.Open(0);
		}

		/// <summary>Open the stream with the specified resolution</summary>
		[SecuritySafeCritical]
		public void Open(int sizeId)
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(ObjectDisposed);
			}
			if (sizeId < 0 || this._cameraInfo.SupportedPreviewSizes.Count < sizeId)
			{
				Error.ThrowNativeException(ArgumentOutOfRange);
			}
			int errorCode = Camera.OpenNative(this._handle, this._cameraInfo.SupportedPreviewSizes[sizeId]);
			if (errorCode < 0)
			{
				this.Close();
			}
			else
			{
				CameraSize currentPreviewSize;
				errorCode = Camera.GetPreviewSizeNative(this._handle, out currentPreviewSize);
				if (errorCode < 0)
				{
					this.Close();
				}
				else
				{
					this._currentPreviewSize = currentPreviewSize;
					CameraImageFormat currentPreviewImageFormat;
					errorCode = Camera.GetPreviewImageFormatNative(this._handle, out currentPreviewImageFormat);
					if (errorCode < 0)
					{
						this.Close();
					}
					else
					{
						this._currentPreviewImageFormat = currentPreviewImageFormat;
					}
				}
			}
		}

		/// <summary>Close the stream</summary>
		[SecuritySafeCritical]
		public void Close()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(ObjectDisposed);
			}
			int errorCode = Camera.CloseNative(this._handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Obtains the currently set stream image's resolution</summary>
		public CameraSize CurrentPreviewSize
		{
			get
			{
				return this._currentPreviewSize;
			}
		}

		/// <summary>Obtains the currently set stream data format</summary>
		public CameraImageFormat CurrentPreviewImageFormat
		{
			get
			{
				return this._currentPreviewImageFormat;
			}
		}

		/// <summary>Starts image streaming<br />
		/// Reads data asynchronously to the buffer when the FrameChanged event is set</summary>
		[SecuritySafeCritical]
		public void Start()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(ObjectDisposed);
			}
			int errorCode = Camera.StartNative(this._handle);
			if (errorCode < 0)
			{
				this.Close();
			}
			else if (this.FrameChanged != null && !Camera._worker.IsBusy)
			{
				this._cancel = false;
				Camera._worker.RunWorkerAsync(this);
			}
		}

		/// <summary>Stops image streaming</summary>
		[SecuritySafeCritical]
		public void Stop()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(ObjectDisposed);
			}
			CameraState cameraState = this.CameraState;
			if (cameraState == CameraState.TakingPicture)
			{
				this.Close();
			}
			else if (cameraState == CameraState.Running)
			{
				this._cancel = true;
				bool running = true;
				while (running)
				{
					if (Camera._worker.IsBusy)
					{
						Thread.Sleep(100);
					}
					else
					{
						running = false;
					}
				}
				int errorCode = Camera.StopNative(this._handle);
				if (errorCode < 0)
				{
					this.Close();
				}
			}
		}

		/// <summary>Reads data of the stream to the buffer using a worker thread</summary>
		/// <param name="obj">Camera instance</param>
		[SecuritySafeCritical]
		private static void DoWork(object obj)
		{
			Camera camera = obj as Camera;
			if (camera._handle == 0)
			{
				Error.ThrowNativeException(ObjectDisposed);
			}
			int multiplier = 2;
			if (camera._currentPreviewImageFormat == CameraImageFormat.Rgba8888)
			{
				multiplier = 4;
			}
			int totalFrameSize = camera._currentPreviewSize.Width * camera._currentPreviewSize.Height * multiplier;
			byte[] frameBuffer = new byte[totalFrameSize];
			long frameCount = 0L;
			long lastFrameCount = 0L;
			long frameCountErrorCheck = 0L;
			long ticks = DateTime.Now.Ticks;
			while (!camera._cancel)
			{
				lock (Camera.syncObject)
				{
					if (camera._isTakingPicture)
					{
						frameCountErrorCheck = frameCount;
						if (camera.PictureState == PictureState.Finishied || camera.PictureState == PictureState.Failed)
						{
							camera._isTakingPicture = false;
							camera._pictureStateChangedCallback(camera.PictureState);
						}
					}
					else
					{
						int errorCode = Camera.ReadNative(camera._handle, frameBuffer, totalFrameSize, out frameCount);
						if (errorCode != 0 && frameCountErrorCheck != frameCount)
						{
							Camera.CloseNative(camera._handle);
							break;
						}
						if (errorCode == 0 && lastFrameCount != frameCount)
						{
							lastFrameCount = frameCount;
							camera._frameChangedCallback(frameBuffer, frameCount);
						}
					}
				}
				long timeTaken = DateTime.Now.Ticks - ticks;
				if (timeTaken < 333333L)
				{
					Thread.Sleep((int)((333333L - timeTaken) / 10000L));
				}
				ticks = DateTime.Now.Ticks;
			}
		}
		/// <summary>Reads data of the stream to the buffer</summary>
		[SecuritySafeCritical]
		public void Read()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(ObjectDisposed);
			}
			CameraState cameraState = this.CameraState;
			int multiplier = 2;
			if (this._currentPreviewImageFormat == CameraImageFormat.Rgba8888)
			{
				multiplier = 4;
			}
			int totalFrameSize = this._currentPreviewSize.Width * this._currentPreviewSize.Height * multiplier;
			byte[] frameBuffer = new byte[totalFrameSize];
			long frameCount;
			int errorCode = Camera.ReadNative(this._handle, frameBuffer, totalFrameSize, out frameCount);
			if (errorCode < 0)
			{
				this.Close();
			}
		}

		/// <summary>Takes a photograph<br />
		/// The format of the taken photograph is JPEG<br />
		/// The taken photograph will be stored in a file<br />
		/// This method can only be called while an image is being streamed</summary>
		/// <param name="sizeId">Number of the resolution for an image to be used in taking a photograph</param>
		[SecuritySafeCritical]
		public void TakePicture(int sizeId)
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(ObjectDisposed);
			}
			int errorCode = 0;
			lock (Camera.syncObject)
			{
				this._isTakingPicture = true;
				errorCode = Camera.TakePictureNative(this._handle, this._cameraInfo.SupportedPictureSizes[sizeId]);
			}
			if (errorCode < 0)
			{
				this._isTakingPicture = false;
				this.Close();
			}
		}

		/// <summary>Obtains the file path of the taken photograph</summary>
		public string PictureFilename
		{
			[SecuritySafeCritical]
			get
			{
				if (this._handle == 0)
				{
					Error.ThrowNativeException(ObjectDisposed);
				}
				string result;
				if (this.PictureState == PictureState.Finishied)
				{
					string text;
					int pictureFilenameNative = Camera.GetPictureFilenameNative(this._handle, out text);
					if (pictureFilenameNative < 0)
					{
						this.Close();
						result = string.Empty;
					}
					else
					{
						result = text;
					}
				}
				else
				{
					result = string.Empty;
				}
				return result;
			}
		}

		/// <summary>Callback method called when the stream image frame has changed</summary>
		/// <param name="frameBuffer">Frame buffer where the image was stored</param>
		/// <param name="frameCount">Image frame number</param>
		private delegate void FrameChangedCallback(byte[] frameBuffer, long frameCount);

		/// <summary>Argument class passed with the event that occurs when the stream image frame has changed</summary>
		public class FrameChangedEventArgs : EventArgs
		{
			/// <summary>Constructor</summary>
			/// <param name="frameBuffer">Buffer where the frame data was stored</param>
			/// <param name="frameCount">Frame number when streaming started</param>
			internal FrameChangedEventArgs(byte[] frameBuffer, long frameCount)
			{
				this.FrameBuffer = frameBuffer;
				this.FrameCount = frameCount;
			}

			/// <summary>Buffer where the frame data was stored</summary>
			public byte[] FrameBuffer { get; private set; }

			/// <summary>Frame number when streaming started</summary>
			public long FrameCount { get; private set; }
		}

		/// <summary>Callback method called when the picture state has changed</summary>
		/// <param name="taken">Picture state</param>
		private delegate void PictureStateChangedCallback(PictureState taken);

		/// <summary>Argument class passed with the event that occurs when the picture state has changed</summary>
		public class PictureStateChangedEventArgs : EventArgs
		{
			/// <summary>Constructor</summary>
			/// <param name="taken">Picture state</param>
			internal PictureStateChangedEventArgs(PictureState state)
			{
				this.PictureState = state;
			}

			/// <summary>Picture state</summary>
			public PictureState PictureState { get; private set; }
		}
	}
}
