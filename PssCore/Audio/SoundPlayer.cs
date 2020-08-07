using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace Sce.PlayStation.Core.Audio
{
	/// <summary>Class providing sound effect playback features</summary>
	public class SoundPlayer : IDisposable
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void ReleaseNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int PlayNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int StopNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetStatusNative(int handle, out SoundStatus status);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetVolumeNative(int handle, float volume);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetVolumeNative(int handle, out float volume);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetPanNative(int handle, float pan);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPanNative(int handle, out float pan);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetLoopNative(int handle, bool pan);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetLoopNative(int handle, [MarshalAs(4)] out bool pan);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetPlaybackRateNative(int handle, float rate);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPlaybackRateNative(int handle, out float rate);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetPosition(int handle, ulong millisecond);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPosition(int handle, out ulong millisecond);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetLength(int handle, out ulong millisecond);
		
		/*
		 *	IL Code.
		 */
		private int handle = 0;
		
		internal SoundPlayer(int handle)
		{
			this.handle = handle;
		}

		/// <summary>SoundPlayer finalizer</summary>
		~SoundPlayer()
		{
			this.Dispose(false);
		}

		/// <summary>Frees unmanaged resources of SoundPlayer</summary>
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
				SoundPlayer.ReleaseNative(this.handle);
				this.handle = 0;
			}
		}

		/// <summary>Plays back sound effects</summary>
		[SecuritySafeCritical]
		public void Play()
		{
			int num = SoundPlayer.PlayNative(this.handle);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
			}
		}

		/// <summary>Stops sound effects</summary>
		[SecuritySafeCritical]
		public void Stop()
		{
			int num = SoundPlayer.StopNative(this.handle);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
			}
		}

		/// <summary>States of sound effects</summary>
		public SoundStatus Status
		{
			[SecuritySafeCritical]
			get
			{
				SoundStatus result;
				int statusNative = SoundPlayer.GetStatusNative(this.handle, out result);
				if (statusNative != 0)
				{
					Error.ThrowNativeException(statusNative);
				}
				return result;
			}
		}

		/// <summary>Volume (0.0-1.0)</summary>
		public float Volume
		{
			[SecuritySafeCritical]
			get
			{
				float result;
				int volumeNative = SoundPlayer.GetVolumeNative(this.handle, out result);
				if (volumeNative != 0)
				{
					Error.ThrowNativeException(volumeNative);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int num = SoundPlayer.SetVolumeNative(this.handle, value);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
				}
			}
		}

		/// <summary>Left/right voice position (-1.0-1.0)</summary>
		public float Pan
		{
			[SecuritySafeCritical]
			get
			{
				float result;
				int panNative = SoundPlayer.GetPanNative(this.handle, out result);
				if (panNative != 0)
				{
					Error.ThrowNativeException(panNative);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int num = SoundPlayer.SetPanNative(this.handle, value);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
				}
			}
		}

		/// <summary>Loop playback</summary>
		public bool Loop
		{
			[SecuritySafeCritical]
			get
			{
				bool result = false;
				int loopNative = SoundPlayer.GetLoopNative(this.handle, out result);
				if (loopNative != 0)
				{
					Error.ThrowNativeException(loopNative);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int num = SoundPlayer.SetLoopNative(this.handle, value);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
				}
			}
		}

		/// <summary>Playback speed and pitch (0.25-4.0)</summary>
		public float PlaybackRate
		{
			[SecuritySafeCritical]
			get
			{
				float result = 0f;
				int playbackRateNative = SoundPlayer.GetPlaybackRateNative(this.handle, out result);
				if (playbackRateNative != 0)
				{
					Error.ThrowNativeException(playbackRateNative);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int num = SoundPlayer.SetPlaybackRateNative(this.handle, value);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
				}
			}
		}

		/// <summary>Playback time (seconds)</summary>
		public double Time
		{
			[SecuritySafeCritical]
			get
			{
				ulong num = 0UL;
				int position = SoundPlayer.GetPosition(this.handle, out num);
				if (position != 0)
				{
					Error.ThrowNativeException(position);
				}
				return num * 0.001;
			}
			[SecuritySafeCritical]
			set
			{
				ulong millisecond = (ulong)(value * 1000.0);
				int num = SoundPlayer.SetPosition(this.handle, millisecond);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
				}
			}
		}

		/// <summary>Playback duration (seconds)</summary>
		public double Duration
		{
			[SecuritySafeCritical]
			get
			{
				ulong num = 0UL;
				int length = SoundPlayer.GetLength(this.handle, out num);
				if (length != 0)
				{
					Error.ThrowNativeException(length);
				}
				return num * 0.001;
			}
		}

		[Obsolete("Use Time")]
		public ulong Position
		{
			[SecuritySafeCritical]
			get
			{
				ulong result = 0UL;
				int position = SoundPlayer.GetPosition(this.handle, out result);
				if (position != 0)
				{
					Error.ThrowNativeException(position);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int num = SoundPlayer.SetPosition(this.handle, value);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
				}
			}
		}

		[Obsolete("Use Duration")]
		public ulong Length
		{
			[SecuritySafeCritical]
			get
			{
				ulong result = 0UL;
				int length = SoundPlayer.GetLength(this.handle, out result);
				if (length != 0)
				{
					Error.ThrowNativeException(length);
				}
				return result;
			}
		}
	}
}
