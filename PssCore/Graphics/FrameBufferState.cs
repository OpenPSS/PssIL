using System;

namespace Sce.PlayStation.Core.Graphics
{
	internal class FrameBufferState
	{
		public RenderTarget colorTarget;
		public RenderTarget depthTarget;
		public bool status;
		public int width;
		public int height;
		public PixelFormat colorFormat;
		public PixelFormat depthFormat;
		public MultiSampleMode multiSampleMode;
		
		public void Update()
		{
			this.colorFormat = (this.depthFormat = PixelFormat.None);
			this.width = (this.height = 0);
			if (this.depthTarget.Buffer != null)
			{
				this.depthFormat = this.depthTarget.Buffer.Format;
				this.width = this.depthTarget.Buffer.GetMipmapWidth(this.depthTarget.Level);
				this.height = this.depthTarget.Buffer.GetMipmapHeight(this.depthTarget.Level);
			}
			if (this.colorTarget.Buffer != null)
			{
				this.colorFormat = this.colorTarget.Buffer.Format;
				this.width = this.colorTarget.Buffer.GetMipmapWidth(this.colorTarget.Level);
				this.height = this.colorTarget.Buffer.GetMipmapHeight(this.colorTarget.Level);
			}
		}
	}
}
