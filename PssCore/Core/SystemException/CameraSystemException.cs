using System;

namespace Sce.PlayStation.Core
{
    public class CameraSystemException : Exception
    {
		public CameraSystemException() { }
		public CameraSystemException(string message) : base(message) { }
		public CameraSystemException(string message, Exception inner) : base(message, inner) { }
	}
}
