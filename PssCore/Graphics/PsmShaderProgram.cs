using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	internal static class PsmShaderProgram
	{
		/*
		 *  Implemented by PSM Runtime.
		 */
		
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int FromFile(string vpFileName, string fpFileName, string[] constKeys, int[] constVals, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int FromImage(byte[] vpFileImage, byte[] fpFileImage, string[] constKeys, int[] constVals, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int Delete(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int AddRef(int handle);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetUniformCount(int handle, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetAttributeCount(int handle, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int FindUniform(int handle, string name, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int FindAttribute(int handle, string name, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetUniformBinding(int handle, int index, out string result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformBinding(int handle, int index, string name);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetAttributeBinding(int handle, int index, out string result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetAttributeBinding(int handle, int index, string name);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetUniformType(int handle, int index, out ShaderUniformType result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetAttributeType(int handle, int index, out ShaderAttributeType result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetUniformName(int handle, int index, out string result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetAttributeName(int handle, int index, out string result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetUniformSize(int handle, int index, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetAttributeSize(int handle, int index, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue(int handle, int index, int offset, ref Matrix4 value, ShaderUniformType type);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue(int handle, int index, int offset, ref Vector4 value, ShaderUniformType type);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue(int handle, int index, int offset, ref Vector3 value, ShaderUniformType type);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue(int handle, int index, int offset, ref Vector2 value, ShaderUniformType type);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue(int handle, int index, int offset, ref float value, ShaderUniformType type);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue(int handle, int index, int offset, ref int value, ShaderUniformType type);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue2(int handle, int index, Matrix4[] value, ShaderUniformType type, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue2(int handle, int index, Vector4[] value, ShaderUniformType type, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue2(int handle, int index, Vector3[] value, ShaderUniformType type, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue2(int handle, int index, Vector2[] value, ShaderUniformType type, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue2(int handle, int index, float[] value, ShaderUniformType type, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetUniformValue2(int handle, int index, int[] value, ShaderUniformType type, int to, int from, int count);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetAttributeValue2(int handle, int index, float[] value);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetUniformTexture(int handle, int index, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int GetAttributeStream(int handle, int index, out int result);
		[SecurityCritical]
		[MethodImpl(4096)]
		public static extern int SetAttributeStream(int handle, int index, int stream);
	}
}
