using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace Sce.PlayStation.Core.Audio
{
	/// <summary>Class providing music playback features</summary>
	// Token: 0x02000038 RID: 56
	public class BgmPlayer : IDisposable
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
		private static extern int GetStatusNative(int handle, out BgmStatus status);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int PauseNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ResumeNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetVolumeNative(int handle, float volume);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetVolumeNative(int handle, out float volume);
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
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetLoopPosition(int handle, ulong msStart, ulong msEnd);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetLoopPosition(int handle, out ulong msStart, out ulong msEnd);
		
		/*
		 *	IL Code.
		 */
		
		private int handle = 0;
		private double loopStart = -1.0;
		private double loopEnd = -1.0;
		
		internal BgmPlayer(int handle)
		{
			this.handle = handle;
		}

		/// <summary>BgmPlayer finalizer</summary>
		~BgmPlayer()
		{
			this.Dispose(false);
		}

		/// <summary>Frees unmanaged resources of the BgmPlayer</summary>
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
				BgmPlayer.ReleaseNative(this.handle);
				this.handle = 0;
			}
		}

		/// <summary>Plays music</summary>
		[SecuritySafeCritical]
		public void Play()
		{
			int errorCode = BgmPlayer.PlayNative(this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Stops music</summary>
		[SecuritySafeCritical]
		public void Stop()
		{
			int errorCode = BgmPlayer.StopNative(this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>State of the music player</summary>
		public BgmStatus Status
		{
			[SecuritySafeCritical]
			get
			{
				BgmStatus result;
				int statusNative = BgmPlayer.GetStatusNative(this.handle, out result);
				if (statusNative != 0)
				{
					Error.ThrowNativeException(statusNative);
				}
				return result;
			}
		}

		/// <summary>Pauses the music player</summary>
		[SecuritySafeCritical]
		public void Pause()
		{
			int errorCode = BgmPlayer.PauseNative(this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Cancels the pause of the music player</summary>
		[SecuritySafeCritical]
		public void Resume()
		{
			int errorCode = BgmPlayer.ResumeNative(this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Volume (0.0-1.0)</summary>
		public float Volume
		{
			[SecuritySafeCritical]
			get
			{
				float result;
				int volumeNative = BgmPlayer.GetVolumeNative(this.handle, out result);
				if (volumeNative != 0)
				{
					Error.ThrowNativeException(volumeNative);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int errorCode = BgmPlayer.SetVolumeNative(this.handle, value);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
			}
		}

		/// <summary>Loop playback</summary>
		public bool Loop
		{
			[SecuritySafeCritical]
			get
			{
				bool isLooping = false;
				int errorCode = BgmPlayer.GetLoopNative(this.handle, out isLooping);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return isLooping;
			}
			[SecuritySafeCritical]
			set
			{
				int errorCode = BgmPlayer.SetLoopNative(this.handle, value);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
			}
		}

		/// <summary>Playback speed ratio and pitch (0.25-4.0)</summary>
		public float PlaybackRate
		{
			[SecuritySafeCritical]
			get
			{
				float result = 0f;
				int playbackRateNative = BgmPlayer.GetPlaybackRateNative(this.handle, out result);
				if (playbackRateNative != 0)
				{
					Error.ThrowNativeException(playbackRateNative);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int errorCode = BgmPlayer.SetPlaybackRateNative(this.handle, value);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
			}
		}

		/// <summary>Playback time (seconds)</summary>
		public double Time
		{
			[SecuritySafeCritical]
			get
			{
				ulong position = 0UL;
				int errorCode = BgmPlayer.GetPosition(this.handle, out position);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return position * 0.001;
			}
			[SecuritySafeCritical]
			set
			{
				ulong millisecond = (ulong)(value * 1000.0);
				int errorCode = BgmPlayer.SetPosition(this.handle, millisecond);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
			}
		}

		/// <summary>Playback duration (seconds)</summary>
		public double Duration
		{
			[SecuritySafeCritical]
			get
			{
				ulong length = 0UL;
				int errorCode = BgmPlayer.GetLength(this.handle, out length);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return length * 0.001;
			}
		}

		/// <summary>Loop start time (seconds)</summary>
		public double LoopStart
		{
			get
			{
				this.GetLoopPosition();
				return this.loopStart;
			}
			set
			{
				this.SetLoopPosition(value, this.LoopEnd);
			}
		}

		/// <summary>Loop end time (seconds)</summary>
		public double LoopEnd
		{
			get
			{
				this.GetLoopPosition();
				return this.loopEnd;
			}
			set
			{
				this.SetLoopPosition(this.LoopStart, value);
			}
		}

		[SecuritySafeCritical]
		private void GetLoopPosition()
		{
			if (this.loopStart < 0.0)
			{
				ulong start;
				ulong end;
				int loopPosition = BgmPlayer.GetLoopPosition(this.handle, out start, out end);
				if (loopPosition != 0)
				{
					Error.ThrowNativeException(loopPosition);
				}
				double duration = this.Duration;
				this.loopStart = Math.Min(start * 0.001, duration);
				this.loopEnd = Math.Min(end * 0.001, duration);
			}
		}

		[SecuritySafeCritical]
		private void SetLoopPosition(double start, double end)
		{
			double duration = this.Duration;
			if (start < 0.0 || start > duration || end < 0.0 || end > duration)
			{
				throw new ArgumentOutOfRangeException();
			}
			ulong startRes = (ulong)(start * 1000.0);
			ulong endRes = (ulong)(end * 1000.0);
			if (startRes > endRes)
			{
				startRes = endRes;
			}
			int errorCode = BgmPlayer.SetLoopPosition(this.handle, startRes, endRes);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.loopStart = start;
			this.loopEnd = end;
		}

		[Obsolete("Use Time")]
		public TimeSpan Position
		{
			[SecuritySafeCritical]
			get
			{
				ulong position = 0UL;
				int errorCode = BgmPlayer.GetPosition(this.handle, out position);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return new TimeSpan((long)(position * 10000UL));
			}
			[SecuritySafeCritical]
			set
			{
				ulong millisecond = (ulong)value.TotalMilliseconds;
				int errorCode = BgmPlayer.SetPosition(this.handle, millisecond);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
			}
		}

		[Obsolete("Use Duration")]
		public ulong Length
		{
			[SecuritySafeCritical]
			get
			{
				ulong length = 0UL;
				int errorCode = BgmPlayer.GetLength(this.handle, out length);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				return length;
			}
		}
	}
}
