using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core
{
	internal class Error 
	{
		/*
		 * This class handles exceptions thrown from native runtime code 
		 * and passing them to the IL application.
		 */

		/*
		 *   Native Error Codes
		 */
		private const uint SCE_PSM_ERROR_BASE = 0x80580000;
		private const uint SCE_PSM_ERROR_COMMON_ARGUMENT = 0x80580001;
		private const uint SCE_PSM_ERROR_COMMON_ARGUMENT_NULL = 0x80580002;
		private const uint SCE_PSM_ERROR_COMMON_ARGUMENT_OUT_OF_RANGE = 0x80580003;
		private const uint SCE_PSM_ERROR_COMMON_INVALID_OPERATION = 0x80580004;
		private const uint SCE_PSM_ERROR_COMMON_OBJECT_DISPOSED = 0x80580005;
		private const uint SCE_PSM_ERROR_COMMON_NOT_SUPPORTED = 0x80580006;
		private const uint SCE_PSM_ERROR_COMMON_INVALID_FORMAT = 0x80580007;
		private const uint SCE_PSM_ERROR_COMMON_INSUFFICIENT_MEMORY = 0x80580008;
		private const uint SCE_PSM_ERROR_COMMON_IO = 0x80580010;
		private const uint SCE_PSM_ERROR_COMMON_FILE_NOT_FOUND = 0x80580011;
		private const uint SCE_PSM_ERROR_COMMON_FILE_LOAD = 0x80580012;
		private const uint SCE_PSM_ERROR_COMMON_OUT_OF_MEMORY = 0x80580013;

		private const uint SCE_PSM_ERROR_GRAPHICS_SYSTEM = 0x80580021;
		private const uint SCE_PSM_ERROR_AUDIO_SYSTEM = 0x80580022;
		private const uint SCE_PSM_ERROR_IMAGE_SYSTEM = 0x80580023;
		private const uint SCE_PSM_ERROR_FONT_SYSTEM = 0x80580024;
		private const uint SCE_PSM_ERROR_INPUT_SYSTEM = 0x80580025;
		private const uint SCE_PSM_ERROR_CAMERA_SYSTEM = 0x80580026;
		private const uint SCE_PSM_ERROR_LOCATION_SYSTEM = 0x80580028;

		/*
		 *  Implemented by PSM Runtime.
		 */
		[SecurityCritical]
		[MethodImpl(4096)]
		private static extern int GetExceptionInfoNative(out string message, out string param); 

		[SecuritySafeCritical]
		internal static void ThrowNativeException(int error)
		{
			string message;
			string param;
			Error.GetExceptionInfoNative(out message, out param);
			if (message == null)
			{
				message = "native function returned error.";
			}
			switch ((uint)error)
			{
				case SCE_PSM_ERROR_COMMON_ARGUMENT: // Base exceptions
					throw new ArgumentException(message, param);
				case SCE_PSM_ERROR_COMMON_ARGUMENT_NULL:
					throw new ArgumentNullException(param, message);
				case SCE_PSM_ERROR_COMMON_ARGUMENT_OUT_OF_RANGE:
					throw new ArgumentOutOfRangeException(param, message);
				case SCE_PSM_ERROR_COMMON_INVALID_OPERATION:
					throw new InvalidOperationException(message);
				case SCE_PSM_ERROR_COMMON_OBJECT_DISPOSED:
					throw new ObjectDisposedException(param, message);
				case SCE_PSM_ERROR_COMMON_NOT_SUPPORTED:
					throw new NotSupportedException(message);
				case SCE_PSM_ERROR_COMMON_INVALID_FORMAT:
					throw new FormatException(message);
				case SCE_PSM_ERROR_COMMON_INSUFFICIENT_MEMORY:
					throw new InsufficientMemoryException(message);
				case SCE_PSM_ERROR_COMMON_IO:
					throw new IOException(message);
				case SCE_PSM_ERROR_COMMON_FILE_NOT_FOUND:
					throw new FileNotFoundException(message, param);
				case SCE_PSM_ERROR_COMMON_FILE_LOAD:
					throw new FileLoadException(message, param);
				case SCE_PSM_ERROR_COMMON_OUT_OF_MEMORY:
					throw new OutOfMemoryException(message);

				case SCE_PSM_ERROR_GRAPHICS_SYSTEM: // Custom Exceptions
					throw new GraphicsSystemException(message);
				case SCE_PSM_ERROR_AUDIO_SYSTEM:
					throw new AudioSystemException(message);
				case SCE_PSM_ERROR_IMAGE_SYSTEM:
					throw new ImageSystemException(message);
				case SCE_PSM_ERROR_FONT_SYSTEM:
					throw new FontSystemException(message);
				case SCE_PSM_ERROR_INPUT_SYSTEM:
					throw new InputSystemException(message);
				case SCE_PSM_ERROR_CAMERA_SYSTEM:
					throw new CameraSystemException(message);
				case SCE_PSM_ERROR_LOCATION_SYSTEM:
					throw new LocationSystemException(message);
				case 0x80580009: // Name unknown..
				case 0x8058000A:
				case 0x8058000B:
				case 0x8058000C:
				case 0x8058000D:
				case 0x8058000E:
				case 0x8058000F:
				default:
					break;
			}
			throw new Exception("unknown error number: 0x" + error.ToString("x8"));
		}
	}
}
