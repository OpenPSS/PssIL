using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Audio
{
	/// <summary>Sound effects data</summary>
	/// <remarks>wav files can be used as sound effects data.</remarks>
	public class Sound : IDisposable
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
		
		private int handle = 0;
		
		/// <summary>Sound constructor (from the filename)</summary>
		/// <param name="filename">Sound effect filename</param>
		[SecuritySafeCritical]
		public Sound(string filename)
		{
			int errorCode = Sound.NewFromFilename(filename, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sound constructor (from the file image)</summary>
		/// <param name="fileImage">Sound effect file image</param>
		[SecuritySafeCritical]
		public Sound(byte[] fileImage)
		{
			int errorCode = Sound.NewFromFileImage(fileImage, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sound finalizer</summary>
		~Sound()
		{
			this.Dispose(false);
		}

		/// <summary>Frees unmanaged resources of Sound</summary>
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
				Sound.ReleaseNative(this.handle);
				this.handle = 0;
			}
		}

		/// <summary>Creates a SoundPlayer object to play back this sound effect</summary>
		/// <returns>SoundPlayer object linked to the sound effect data</returns>
		[SecuritySafeCritical]
		public SoundPlayer CreatePlayer()
		{
			int sndPlayerId;
			int errorCode = Sound.CreatePlayerNative(this.handle, out sndPlayerId);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return new SoundPlayer(sndPlayerId);
		}
	}
}
