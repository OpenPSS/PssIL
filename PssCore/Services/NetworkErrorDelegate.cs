using System;

namespace Sce.PlayStation.Core.Services
{
	internal delegate bool NetworkErrorDelegate(IAsyncResult asynchronousResult, Exception e, object state);
}
