using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Font</summary>
	public class Font : IDisposable, IShallowCloneable
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewFromFilenameSizeStyle(string filename, int size, FontStyle style, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewFromAliasSizeStyle(FontAlias alias, int size, FontStyle style, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void AddRefNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void ReleaseNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetName(int handle, out string name);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetSize(int handle, out int size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetStyle(int handle, out FontStyle style);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetMetrics(int handle, out FontMetrics fontMetrics);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetTextWidthNative(int handle, string text, int offset, int len, out int width);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetTextMetricsNative(int handle, string text, int offset, int len, CharMetrics[] charMetrics);
		
		/*
		 *	IL Code.
		 */
		
		private int handle = 0;
		
		/// <summary>Font constructor (from filename, size, and style)</summary>
		/// <param name="filename">Font filename</param>
		/// <param name="size">Size</param>
		/// <param name="style">Style</param>
		/// <remarks>The argument size must be between 1 and 1024. Also, depending on the font, the font may not be generated because its size is too small.</remarks>
		[SecuritySafeCritical]
		public Font(string filename, int size, FontStyle style)
		{
			int errorCode = Font.NewFromFilenameSizeStyle(filename, size, style, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Font constructor (from separate name, size, and style)</summary>
		/// <param name="alias">Font separate name</param>
		/// <param name="size">Size</param>
		/// <param name="style">Style</param>
		/// <remarks>The argument size must be between 1 and 1024. Also, depending on the font, the font may not be generated because its size is too small.</remarks>
		[SecuritySafeCritical]
		public Font(FontAlias alias, int size, FontStyle style)
		{
			int errorCode = Font.NewFromAliasSizeStyle(alias, size, style, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Font constructor (copied from another Font object)</summary>
		/// <param name="font">Copy source Font object</param>
		/// <remarks>A separate Font object is copied to create a new Font object. However, the actual body of the Font is not copied and one unmanaged resource will be shared. To free an unmanaged resource of a Font , Dispose() must be called for all the copied Font objects.</remarks>
		[SecuritySafeCritical]
		protected Font(Font font)
		{
			this.handle = font.handle;
			Font.AddRefNative(this.handle);
		}

		/// <summary>Font constructor (copied from another Font object)</summary>
		/// <param name="font">Copy source Font object</param>
		/// <remarks>A separate Font object is copied to create a new Font object. However, the actual body of the Font is not copied and one unmanaged resource will be shared. To free an unmanaged resource of a Font , Dispose() must be called for all the copied Font objects.</remarks>
		public virtual object ShallowClone()
		{
			return new Font(this);
		}

		/// <summary>Font finalizer</summary>
		~Font()
		{
			this.Dispose(false);
		}

		/// <summary>Frees unmanaged resources of Font</summary>
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
				Font.ReleaseNative(this.handle);
				this.handle = 0;
			}
		}

		internal int Handle
		{
			get
			{
				return this.handle;
			}
		}

		/// <summary>Font name</summary>
		public string Name
		{
			[SecuritySafeCritical]
			get
			{
				string result;
				int name = Font.GetName(this.handle, out result);
				if (name != 0)
				{
					Error.ThrowNativeException(name);
				}
				return result;
			}
		}

		/// <summary>Size</summary>
		public int Size
		{
			[SecuritySafeCritical]
			get
			{
				int result;
				int size = Font.GetSize(this.handle, out result);
				if (size != 0)
				{
					Error.ThrowNativeException(size);
				}
				return result;
			}
		}

		/// <summary>Style</summary>
		public FontStyle Style
		{
			[SecuritySafeCritical]
			get
			{
				FontStyle result;
				int style = Font.GetStyle(this.handle, out result);
				if (style != 0)
				{
					Error.ThrowNativeException(style);
				}
				return result;
			}
		}

		/// <summary>Font metrics</summary>
		public FontMetrics Metrics
		{
			[SecuritySafeCritical]
			get
			{
				FontMetrics result;
				int metrics = Font.GetMetrics(this.handle, out result);
				if (metrics != 0)
				{
					Error.ThrowNativeException(metrics);
				}
				return result;
			}
		}

		/// <summary>Calculates the width required to render the provided character string with this font (entire character string)</summary>
		/// <param name="text">Character string</param>
		/// <returns>Width</returns>
		public int GetTextWidth(string text)
		{
			return this.GetTextWidth(text, 0, text.Length);
		}

		/// <summary>Calculates the width required to render the provided character string (part of a character string)</summary>
		/// <param name="text">All of the character string</param>
		/// <param name="offset">Offset of the section to be used for calculating the character string's width</param>
		/// <param name="len">Length of the section to be used for calculating the character string's width</param>
		/// <returns>Width</returns>
		[SecuritySafeCritical]
		public int GetTextWidth(string text, int offset, int len)
		{
			int result;
			int textWidthNative = Font.GetTextWidthNative(this.handle, text, offset, len, out result);
			if (textWidthNative != 0)
			{
				Error.ThrowNativeException(textWidthNative);
			}
			return result;
		}

		/// <summary>Obtains metrics information of each character in the provided character string (entire character string)</summary>
		/// <param name="text">Character string</param>
		/// <returns>Array of metrics information per character</returns>
		public CharMetrics[] GetTextMetrics(string text)
		{
			return this.GetTextMetrics(text, 0, text.Length);
		}

		/// <summary>Obtains metrics information of each character in the provided character string (part of the character string)</summary>
		/// <param name="text">All of the character string</param>
		/// <param name="offset">Offset of the section to obtain the character string's metrics information</param>
		/// <param name="len">Length of the section to obtain the character string's metrics information</param>
		/// <returns>Array of metrics information per character</returns>
		[SecuritySafeCritical]
		public CharMetrics[] GetTextMetrics(string text, int offset, int len)
		{
			CharMetrics[] array = new CharMetrics[len];
			int textMetricsNative = Font.GetTextMetricsNative(this.handle, text, offset, len, array);
			if (textMetricsNative != 0)
			{
				Error.ThrowNativeException(textMetricsNative);
			}
			return array;
		}
	}
}
