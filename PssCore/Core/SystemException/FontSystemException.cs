using System;

namespace Sce.PlayStation.Core
{
    public class FontSystemException : Exception
    {
		public FontSystemException() { }
		public FontSystemException(string message) : base(message) { }
		public FontSystemException(string message, Exception inner) : base(message, inner) { }
	}
}
