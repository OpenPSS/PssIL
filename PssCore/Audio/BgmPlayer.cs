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
		 *  Implemented by PSM Runtime.
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
			int num = BgmPlayer.PlayNative(this.handle);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
			}
		}

		/// <summary>Stops music</summary>
		[SecuritySafeCritical]
		public void Stop()
		{
			int num = BgmPlayer.StopNative(this.handle);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
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
			int num = BgmPlayer.PauseNative(this.handle);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
			}
		}

		/// <summary>Cancels the pause of the music player</summary>
		[SecuritySafeCritical]
		public void Resume()
		{
			int num = BgmPlayer.ResumeNative(this.handle);
			if (num != 0)
			{
				Error.ThrowNativeException(num);
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
				int num = BgmPlayer.SetVolumeNative(this.handle, value);
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
				int loopNative = BgmPlayer.GetLoopNative(this.handle, out result);
				if (loopNative != 0)
				{
					Error.ThrowNativeException(loopNative);
				}
				return result;
			}
			[SecuritySafeCritical]
			set
			{
				int num = BgmPlayer.SetLoopNative(this.handle, value);
				if (num != 0)
				{
					Error.ThrowNativeException(num);
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
				int num = BgmPlayer.SetPlaybackRateNative(this.handle, value);
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
				int position = BgmPlayer.GetPosition(this.handle, out num);
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
				int num = BgmPlayer.SetPosition(this.handle, millisecond);
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
				int length = BgmPlayer.GetLength(this.handle, out num);
				if (length != 0)
				{
					Error.ThrowNativeException(length);
				}
				return num * 0.001;
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
				ulong num;
				ulong num2;
				int loopPosition = BgmPlayer.GetLoopPosition(this.handle, out num, out num2);
				if (loopPosition != 0)
				{
					Error.ThrowNativeException(loopPosition);
				}
				double duration = this.Duration;
				this.loopStart = Math.Min(num * 0.001, duration);
				this.loopEnd = Math.Min(num2 * 0.001, duration);
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
			ulong num = (ulong)(start * 1000.0);
			ulong num2 = (ulong)(end * 1000.0);
			if (num > num2)
			{
				num = num2;
			}
			int num3 = BgmPlayer.SetLoopPosition(this.handle, num, num2);
			if (num3 != 0)
			{
				Error.ThrowNativeException(num3);
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
				ulong num = 0UL;
				int position = BgmPlayer.GetPosition(this.handle, out num);
				if (position != 0)
				{
					Error.ThrowNativeException(position);
				}
				return new TimeSpan((long)(num * 10000UL));
			}
			[SecuritySafeCritical]
			set
			{
				ulong millisecond = (ulong)value.TotalMilliseconds;
				int num = BgmPlayer.SetPosition(this.handle, millisecond);
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
				int length = BgmPlayer.GetLength(this.handle, out result);
				if (length != 0)
				{
					Error.ThrowNativeException(length);
				}
				return result;
			}
		}
	}
}
