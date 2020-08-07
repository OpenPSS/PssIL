using System;

namespace Sce.PlayStation.Core
{
    public class ImageSystemException : Exception
    {
		public ImageSystemException() { }
		public ImageSystemException(string message) : base(message) { }
		public ImageSystemException(string message, Exception inner) : base(message, inner) { }
	}
}
