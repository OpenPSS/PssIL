using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Audio
{
	/// <summary>Music data</summary>
	/// <remarks>mp3 files can be used as music data.</remarks>
	public class Bgm : IDisposable
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewFromFilename(string filename, out int handle);

		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewFromFileImage(byte[] fileImage, out int handle);

		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void ReleaseNative(int handle);

		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int CreatePlayerNative(int handle, out int playerHandle);
		
		/*
		 *	IL Code.
		 */
		
		internal int handle = 0;
		/// <summary>Bgm constructor (from the filename)</summary>
		/// <param name="filename">Music data filename</param>
		[SecuritySafeCritical]
		public Bgm(string filename)
		{
			int errorCode = Bgm.NewFromFilename(filename, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Bgm constructor (from the file image)</summary>
		/// <param name="fileImage">Music data file image</param>
		[SecuritySafeCritical]
		public Bgm(byte[] fileImage)
		{
			int errorCode = Bgm.NewFromFileImage(fileImage, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Bgm finalizer</summary>
		~Bgm()
		{
			this.Dispose(false);
		}

		/// <summary>Frees unmanaged resources of the Bgm</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (this.handle != 0)
			{
				Bgm.ReleaseNative(this.handle);
				this.handle = 0;
			}
		}

		/// <summary>Creates a BgmPlayer object to play this Bgm</summary>
		/// <returns>BgmPlayer object linked to the music data</returns>
		[SecuritySafeCritical]
		public BgmPlayer CreatePlayer()
		{
			int bgmPlayerId;
			int errorCode = Bgm.CreatePlayerNative(this.handle, out bgmPlayerId);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return new BgmPlayer(bgmPlayerId);
		}
	}
}
