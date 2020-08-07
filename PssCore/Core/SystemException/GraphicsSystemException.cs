using System;

namespace Sce.PlayStation.Core
{
    public class GraphicsSystemException : Exception
    {
		public GraphicsSystemException() { }
		public GraphicsSystemException(string message) : base(message) { }
		public GraphicsSystemException(string message, Exception inner) : base(message, inner) { }
	}
}
