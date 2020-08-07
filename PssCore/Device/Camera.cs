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
		 *	IL Code.
		 */
		
		/// <summary>Event that occurs when the stream image frame has changed<br />
		/// Occurs asynchronously in a thread separate from the thread that called the Start method</summary>
		public event EventHandler<Camera.FrameChangedEventArgs> FrameChanged;

		/// <summary>Event that occurs when the picture state has changed<br />
		/// Occurs asynchronously in a thread separate from the thread that called the TakePicture method</summary>
		public event EventHandler<Camera.PictureStateChangedEventArgs> PictureStateChanged;

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
			int num = Camera.NewFromIndex(cameraId, out this._handle);
			if (num < 0 || this._handle == 0)
			{
				Error.ThrowNativeException(num);
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

		// Token: 0x06000753 RID: 1875 RVA: 0x0001828C File Offset: 0x0001648C
		private void _worker_DoWork(object sender, DoWorkEventArgs e)
		{
			Camera.DoWork(e.Argument);
		}

		/// <summary>Destructor to destroy the camera instance</summary>
		// Token: 0x06000754 RID: 1876 RVA: 0x0001829C File Offset: 0x0001649C
		~Camera()
		{
			this.Dispose(false);
		}

		/// <summary>Destroy the camera instance</summary>
		// Token: 0x06000755 RID: 1877 RVA: 0x000182D0 File Offset: 0x000164D0
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Destroy the camera instance</summary>
		/// <param name="disposing">Whether an instance is being destroyed or not</param>
		// Token: 0x06000756 RID: 1878 RVA: 0x000182E4 File Offset: 0x000164E4
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
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00018334 File Offset: 0x00016534
		public CameraState CameraState
		{
			[SecuritySafeCritical]
			get
			{
				if (this._handle == 0)
				{
					Error.ThrowNativeException(-2141716475);
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
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0001838C File Offset: 0x0001658C
		public PictureState PictureState
		{
			[SecuritySafeCritical]
			get
			{
				if (this._handle == 0)
				{
					Error.ThrowNativeException(-2141716475);
				}
				PictureState pictureState;
				int num = Camera.HasTakenPictureNative(this._handle, out pictureState);
				PictureState result;
				if (num < 0)
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
		// Token: 0x06000759 RID: 1881 RVA: 0x000183E4 File Offset: 0x000165E4
		public void Open()
		{
			this.Open(0);
		}

		/// <summary>Open the stream with the specified resolution</summary>
		/// <param name="sizeId">Number of the resolution for an image to be used in a stream</param>
		// Token: 0x0600075A RID: 1882 RVA: 0x000183F0 File Offset: 0x000165F0
		[SecuritySafeCritical]
		public void Open(int sizeId)
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(-2141716475);
			}
			if (sizeId < 0 || this._cameraInfo.SupportedPreviewSizes.Count < sizeId)
			{
				Error.ThrowNativeException(-2141716477);
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
		// Token: 0x0600075B RID: 1883 RVA: 0x000184D0 File Offset: 0x000166D0
		[SecuritySafeCritical]
		public void Close()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(0x80580005);
			}
			int errorCode = Camera.CloseNative(this._handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Obtains the currently set stream image's resolution</summary>
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x00018518 File Offset: 0x00016718
		public CameraSize CurrentPreviewSize
		{
			get
			{
				return this._currentPreviewSize;
			}
		}

		/// <summary>Obtains the currently set stream data format</summary>
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x00018530 File Offset: 0x00016730
		public CameraImageFormat CurrentPreviewImageFormat
		{
			get
			{
				return this._currentPreviewImageFormat;
			}
		}

		/// <summary>Starts image streaming<br />
		/// Reads data asynchronously to the buffer when the FrameChanged event is set</summary>
		// Token: 0x0600075E RID: 1886 RVA: 0x00018548 File Offset: 0x00016748
		[SecuritySafeCritical]
		public void Start()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(-2141716475);
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
		// Token: 0x0600075F RID: 1887 RVA: 0x000185C4 File Offset: 0x000167C4
		[SecuritySafeCritical]
		public void Stop()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(-2141716475);
			}
			CameraState cameraState = this.CameraState;
			if (cameraState == CameraState.TakingPicture)
			{
				this.Close();
			}
			else if (cameraState == CameraState.Running)
			{
				this._cancel = true;
				bool flag = true;
				while (flag)
				{
					if (Camera._worker.IsBusy)
					{
						Thread.Sleep(100);
					}
					else
					{
						flag = false;
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
		// Token: 0x06000760 RID: 1888 RVA: 0x0001866C File Offset: 0x0001686C
		[SecuritySafeCritical]
		private static void DoWork(object obj)
		{
			Camera camera = obj as Camera;
			if (camera._handle == 0)
			{
				Error.ThrowNativeException(0x80580005);
			}
			int multiplier = 2;
			if (camera._currentPreviewImageFormat == CameraImageFormat.Rgba8888)
			{
				multiplier = 4;
			}
			int totalFrameSize = camera._currentPreviewSize.Width * camera._currentPreviewSize.Height * multiplier;
			byte[] frameBuffer = new byte[totalFrameSize];
			long frameframeData = 0L;
			long lastFrame = 0L;
			long lastPictureData = 0L;
			long ticks = DateTime.Now.Ticks;
			while (!camera._cancel)
			{
				lock (Camera.syncObject)
				{
					if (camera._isTakingPicture)
					{
						lastPictureData = frameData;
						if (camera.PictureState == PictureState.Finishied || camera.PictureState == PictureState.Failed)
						{
							camera._isTakingPicture = false;
							camera._pictureStateChangedCallback(camera.PictureState);
						}
					}
					else
					{
						int errorCode = Camera.ReadNative(camera._handle, frameBuffer, totalFrameSize, out frameData);
						if (errorCode != 0 && lastPictureData != frameData)
						{
							Camera.CloseNative(camera._handle);
							break;
						}
						if (errorCode == 0 && lastFrame != frameData)
						{
							lastFrame = frameData;
							camera._frameChangedCallback(frameBuffer, frameData);
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
		// Token: 0x06000761 RID: 1889 RVA: 0x00018850 File Offset: 0x00016A50
		[SecuritySafeCritical]
		public void Read()
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(-2141716475);
			}
			CameraState cameraState = this.CameraState;
			int num = 2;
			if (this._currentPreviewImageFormat == CameraImageFormat.Rgba8888)
			{
				num = 4;
			}
			int num2 = this._currentPreviewSize.Width * this._currentPreviewSize.Height * num;
			byte[] frameBuffer = new byte[num2];
			long num4;
			int num3 = Camera.ReadNative(this._handle, frameBuffer, num2, out num4);
			if (num3 < 0)
			{
				this.Close();
			}
		}

		/// <summary>Takes a photograph<br />
		/// The format of the taken photograph is JPEG<br />
		/// The taken photograph will be stored in a file<br />
		/// This method can only be called while an image is being streamed</summary>
		/// <param name="sizeId">Number of the resolution for an image to be used in taking a photograph</param>
		// Token: 0x06000762 RID: 1890 RVA: 0x000188E8 File Offset: 0x00016AE8
		[SecuritySafeCritical]
		public void TakePicture(int sizeId)
		{
			if (this._handle == 0)
			{
				Error.ThrowNativeException(-2141716475);
			}
			int num = 0;
			lock (Camera.syncObject)
			{
				this._isTakingPicture = true;
				num = Camera.TakePictureNative(this._handle, this._cameraInfo.SupportedPictureSizes[sizeId]);
			}
			if (num < 0)
			{
				this._isTakingPicture = false;
				this.Close();
			}
		}

		/// <summary>Obtains the file path of the taken photograph</summary>
		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0001898C File Offset: 0x00016B8C
		public string PictureFilename
		{
			[SecuritySafeCritical]
			get
			{
				if (this._handle == 0)
				{
					Error.ThrowNativeException(-2141716475);
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

		/// <summary>Error code when the method cannot be called</summary>
		// Token: 0x040000CD RID: 205
		private const int InvalidOperaion = -2141716476;

		/// <summary>Error code when the object is already deleted</summary>
		// Token: 0x040000CE RID: 206
		private const int ObjectDisposed = -2141716475;

		/// <summary>Error code when outside of the array range was specified</summary>
		// Token: 0x040000CF RID: 207
		private const int ArgumentOutOfRange = -2141716477;

		// Token: 0x040000D2 RID: 210
		private Camera.FrameChangedCallback _frameChangedCallback;

		// Token: 0x040000D3 RID: 211
		private Camera.PictureStateChangedCallback _pictureStateChangedCallback;

		// Token: 0x040000D4 RID: 212
		private int _handle = 0;

		// Token: 0x040000D5 RID: 213
		private Thread _thread = null;

		// Token: 0x040000D6 RID: 214
		private bool _cancel = false;

		// Token: 0x040000D7 RID: 215
		private bool _disposed = false;

		// Token: 0x040000D8 RID: 216
		private CameraInfo _cameraInfo;

		// Token: 0x040000D9 RID: 217
		private CameraSize _currentPreviewSize;

		// Token: 0x040000DA RID: 218
		private CameraImageFormat _currentPreviewImageFormat;

		// Token: 0x040000DB RID: 219
		private static int _numberOfCameras = -1;

		// Token: 0x040000DC RID: 220
		private static CameraInfo[] _cameraInfos = null;

		// Token: 0x040000DD RID: 221
		private bool _isTakingPicture = false;

		// Token: 0x040000DE RID: 222
		private static BackgroundWorker _worker = null;

		// Token: 0x040000DF RID: 223
		private static object syncObject = new object();

		/// <summary>Callback method called when the stream image frame has changed</summary>
		/// <param name="frameBuffer">Frame buffer where the image was stored</param>
		/// <param name="frameCount">Image frame number</param>
		// Token: 0x02000044 RID: 68
		// (Invoke) Token: 0x06000768 RID: 1896
		private delegate void FrameChangedCallback(byte[] frameBuffer, long frameCount);

		/// <summary>Argument class passed with the event that occurs when the stream image frame has changed</summary>
		// Token: 0x02000045 RID: 69
		public class FrameChangedEventArgs : EventArgs
		{
			/// <summary>Constructor</summary>
			/// <param name="frameBuffer">Buffer where the frame data was stored</param>
			/// <param name="frameCount">Frame number when streaming started</param>
			// Token: 0x0600076B RID: 1899 RVA: 0x00018A80 File Offset: 0x00016C80
			internal FrameChangedEventArgs(byte[] frameBuffer, long frameCount)
			{
				this.FrameBuffer = frameBuffer;
				this.FrameCount = frameCount;
			}

			/// <summary>Buffer where the frame data was stored</summary>
			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x0600076C RID: 1900 RVA: 0x00018A9C File Offset: 0x00016C9C
			// (set) Token: 0x0600076D RID: 1901 RVA: 0x00018AB4 File Offset: 0x00016CB4
			public byte[] FrameBuffer { get; private set; }

			/// <summary>Frame number when streaming started</summary>
			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x0600076E RID: 1902 RVA: 0x00018AC0 File Offset: 0x00016CC0
			// (set) Token: 0x0600076F RID: 1903 RVA: 0x00018AD8 File Offset: 0x00016CD8
			public long FrameCount { get; private set; }
		}

		/// <summary>Callback method called when the picture state has changed</summary>
		/// <param name="taken">Picture state</param>
		// Token: 0x02000046 RID: 70
		// (Invoke) Token: 0x06000771 RID: 1905
		private delegate void PictureStateChangedCallback(PictureState taken);

		/// <summary>Argument class passed with the event that occurs when the picture state has changed</summary>
		// Token: 0x02000047 RID: 71
		public class PictureStateChangedEventArgs : EventArgs
		{
			/// <summary>Constructor</summary>
			/// <param name="taken">Picture state</param>
			// Token: 0x06000774 RID: 1908 RVA: 0x00018AE4 File Offset: 0x00016CE4
			internal PictureStateChangedEventArgs(PictureState state)
			{
				this.PictureState = state;
			}

			/// <summary>Picture state</summary>
			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x06000775 RID: 1909 RVA: 0x00018AF8 File Offset: 0x00016CF8
			// (set) Token: 0x06000776 RID: 1910 RVA: 0x00018B10 File Offset: 0x00016D10
			public PictureState PictureState { get; private set; }
		}
	}
}
