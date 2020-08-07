using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Imaging
{
	/// <summary>Image</summary>
	public class Image : IDisposable, IShallowCloneable
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
		private static extern int NewFromModeSizeColor(ImageMode mode, ref ImageSize size, ref ImageColor color, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int NewFromModeSizeBuffer(ImageMode mode, ref ImageSize size, byte[] buffer, out int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void AddRefNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern void ReleaseNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetSize(int handle, out ImageSize size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SetDecodeSize(int handle, ref ImageSize size);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int DecodeNative(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPixelData(int handle, byte[] buffer, uint bufferSize);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetPixelDataSize(int handle, out uint bufferSize);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ResizeNative(int handle, ref ImageSize size, out int resizedImageHandle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int CropNative(int handle, ref ImageRect rect, out int croppedImageHandle);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int DrawImageNative(int handle, int source_handle, ref ImagePosition position);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int DrawRectangleNative(int handle, ref ImageColor color, ref ImageRect rect);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int DrawTextNative(int handle, string text, int offset, int len, ref ImageColor color, int font_handle, ref ImagePosition position);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int ExportNative(int handle, string albumname, string filename);
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int SaveAsNative(int handle, string filename);
		
		/*
		 *	IL Code.
		 */
		
		/// <summary>Image constructor (from filename)</summary>
		/// <param name="filename">Image filename</param>
		/// <remarks>The image is not actually decoded immediately after Image is created from an image file. To decode the image, Decode() must be called. However, even if the image has not been decoded, it is still possible to obtain Size, for example.</remarks>
		/// <remarks>The currently supported image file formats are PNG, BMP, JPG, and GIF.</remarks>
		[SecuritySafeCritical]
		public Image(string filename)
		{
			int errorCode = Image.NewFromFilename(filename, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Image constructor (from the file image)</summary>
		/// <param name="fileImage">Image file image</param>
		/// <remarks>The image is not actually decoded immediately after Image is created from an image file. To decode the image, Decode() must be called. However, even if the image has not been decoded, it is still possible to obtain Size, for example.</remarks>
		/// <remarks>The currently supported image file formats are PNG, BMP, JPG, and GIF.</remarks>
		[SecuritySafeCritical]
		public Image(byte[] fileImage)
		{
			int errorCode = Image.NewFromFileImage(fileImage, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Image constructor (from the image mode, size, and color)</summary>
		/// <param name="mode">Image mode</param>
		/// <param name="size">Image size</param>
		/// <param name="color">Color</param>
		/// <remarks>The width and height given to the argument size must each be between 0 and 4096.</remarks>
		[SecuritySafeCritical]
		public Image(ImageMode mode, ImageSize size, ImageColor color)
		{
			int errorCode = Image.NewFromModeSizeColor(mode, ref size, ref color, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Image constructor (from the image mode, size, and buffer)</summary>
		/// <param name="mode">Image mode</param>
		/// <param name="size">Image size</param>
		/// <param name="buffer">Color</param>
		/// <remarks>The width and height given to the argument size must each be between 0 and 4096.</remarks>
		[SecuritySafeCritical]
		public Image(ImageMode mode, ImageSize size, byte[] buffer)
		{
			int errorCode = Image.NewFromModeSizeBuffer(mode, ref size, buffer, out this.handle);
			if (errorCode < 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Image constructor (copied from another Image object)</summary>
		/// <param name="image">Copy source Image object</param>
		/// <remarks>A separate Image object is copied to create a new Image object. However, the actual body of the Image is not copied and one unmanaged resource will be shared. To free an unmanaged resource of an Image, Dispose() must be called for all the copied Image objects.</remarks>
		[SecuritySafeCritical]
		protected Image(Image image)
		{
			this.handle = image.handle;
			Image.AddRefNative(this.handle);
		}

		private Image(int handle)
		{
			this.handle = handle;
		}

		/// <summary>Image finalizer</summary>
		~Image()
		{
			this.Dispose(false);
		}

		/// <summary>Copies Image object</summary>
		/// <remarks>A separate Image object is copied to create a new Image object. However, the actual body of the Image is not copied and one unmanaged resource will be shared. To free an unmanaged resource of an Image, Dispose() must be called for all the copied Image objects.</remarks>
		public virtual object ShallowClone()
		{
			return new Image(this);
		}

		/// <summary>Frees unmanaged resources of Image</summary>
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
				Image.ReleaseNative(this.handle);
				this.handle = 0;
			}
		}

		/// <summary>Image size</summary>
		public ImageSize Size
		{
			[SecuritySafeCritical]
			get
			{
				ImageSize result;
				int size = Image.GetSize(this.handle, out result);
				if (size != 0)
				{
					Error.ThrowNativeException(size);
				}
				return result;
			}
		}

		/// <summary>Image size upon decoding</summary>
		/// <remarks>By setting DecodeSize before calling Decode(), decoding can be performed while enlarging/reducing the image.</remarks>
		public ImageSize DecodeSize
		{
			[SecuritySafeCritical]
			set
			{
				int errorCode = Image.SetDecodeSize(this.handle, ref value);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
			}
		}

		/// <summary>Decodes image</summary>
		[SecuritySafeCritical]
		public void Decode()
		{
			int errorCode = Image.DecodeNative(this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Obtains the memory image of the image</summary>
		/// <returns>Memory image of the image</returns>
		[SecuritySafeCritical]
		public byte[] ToBuffer()
		{
			uint pixelDataSize;
			int errorCode = Image.GetPixelDataSize(this.handle, out pixelDataSize);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			byte[] array = new byte[pixelDataSize];
			errorCode = Image.GetPixelData(this.handle, array, pixelDataSize);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return array;
		}

		/// <summary>Reads the memory image of the image in the provided buffer</summary>
		/// <param name="buffer">Buffer of read destination</param>
		[SecuritySafeCritical]
		public void ReadBuffer(byte[] buffer)
		{
			int pixelData = Image.GetPixelData(this.handle, buffer, (uint)buffer.Length);
			if (pixelData != 0)
			{
				Error.ThrowNativeException(pixelData);
			}
		}

		/// <summary>Creates a new image object after scaling</summary>
		/// <param name="size">Size of the image after scaling</param>
		/// <returns>Scaled image</returns>
		[SecuritySafeCritical]
		public Image Resize(ImageSize size)
		{
			int resizedImageId;
			int errorCode = Image.ResizeNative(this.handle, ref size, out resizedImageId);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return new Image(resizedImageId);
		}

		/// <summary>Creates a new Image object by cutting out a part of an already-existing image</summary>
		/// <param name="rect">Rectangular area to be cut</param>
		/// <returns>Cut image</returns>
		[SecuritySafeCritical]
		public Image Crop(ImageRect rect)
		{
			int croppedImageId;
			int errorCode = Image.CropNative(this.handle, ref rect, out croppedImageId);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return new Image(croppedImageId);
		}

		/// <summary>Pastes a different image within the image</summary>
		/// <param name="source">Image to be pasted</param>
		/// <param name="position">Coordinate of the paste position (upper left)</param>
		[SecuritySafeCritical]
		public void DrawImage(Image source, ImagePosition position)
		{
			int errorCode = Image.DrawImageNative(this.handle, source.handle, ref position);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Renders a single-colored rectangle within the image</summary>
		/// <param name="color">Rectangle color</param>
		/// <param name="rect">Rectangle</param>
		[SecuritySafeCritical]
		public void DrawRectangle(ImageColor color, ImageRect rect)
		{
			int errorCode = Image.DrawRectangleNative(this.handle, ref color, ref rect);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Renders text within the image (all of the character string)</summary>
		/// <param name="text">Character string</param>
		/// <param name="color">Font color</param>
		/// <param name="font">Font</param>
		/// <param name="position">Coordinate within the image (upper left of the text)</param>
		/// <remarks>DrawText is the action of rendering text on a transparent image. The RGB value is overwritten with the color provided by the color argument, and the Alpha value is blended.</remarks>
		/// <remarks>When DrawText is called for an opaque image, the expected effect cannot be obtained.</remarks>
		public void DrawText(string text, ImageColor color, Font font, ImagePosition position)
		{
			this.DrawText(text, 0, text.Length, color, font, position);
		}

		/// <summary>Renders text within the image (part of the character string)</summary>
		/// <param name="text">Character string</param>
		/// <param name="offset">Offset of the position to be used to render in the string</param>
		/// <param name="len">Length to use for the render in the string</param>
		/// <param name="color">Font color</param>
		/// <param name="font">Font</param>
		/// <param name="position">Coordinate within the image (upper left of the text)</param>
		/// <remarks>DrawText is the action of rendering text on a transparent image. The RGB value is overwritten with the color provided by the color argument, and the Alpha value is blended.</remarks>
		/// <remarks>When DrawText is called for an opaque image, the expected effect cannot be obtained.</remarks>
		[SecuritySafeCritical]
		public void DrawText(string text, int offset, int len, ImageColor color, Font font, ImagePosition position)
		{
			int errorCode = Image.DrawTextNative(this.handle, text, offset, len, ref color, font.Handle, ref position);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		[SecuritySafeCritical]
		public void Export(string albumname, string filename)
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			int errorCode = Image.ExportNative(this.handle, albumname, filename);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		[SecuritySafeCritical]
		public void SaveAs(string path)
		{
			string fullPath = Path.GetFullPath(path);
			string directoryName = Path.GetDirectoryName(fullPath);
			if (string.IsNullOrEmpty(directoryName) || string.Equals("/", directoryName))
			{
				throw new DirectoryNotFoundException();
			}
			if (!Directory.Exists(directoryName))
			{
				throw new DirectoryNotFoundException();
			}
			FileAttributes attributes = File.GetAttributes(directoryName);
			bool canAccess = FileAttributes.ReadOnly == (attributes & FileAttributes.ReadOnly);
			if (canAccess)
			{
				string text = string.Format("Access to the path '{0}' is denied.", path);
				throw new UnauthorizedAccessException(text);
			}
			if (FileAttributes.Directory != (attributes & FileAttributes.Directory))
			{
				string text = string.Format("Access to the path '{0}' is denied.", path);
				throw new UnauthorizedAccessException(text);
			}
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			int errorCode = Image.SaveAsNative(this.handle, fullPath);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		private int handle = 0;
	}
}
