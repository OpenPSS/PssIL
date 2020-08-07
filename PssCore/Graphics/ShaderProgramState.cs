using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	internal class ShaderProgramState
	{
		/*
		 *	Global Variables
		 */
		
		public int uniformCount;
		public int attributeCount;
		
		[SecuritySafeCritical]
		public ShaderProgramState(int handle)
		{
			PsmShaderProgram.GetUniformCount(handle, out this.uniformCount);
			PsmShaderProgram.GetAttributeCount(handle, out this.attributeCount);
		}
	}
}
