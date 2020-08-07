using System;
using System.Security;

namespace Sce.PlayStation.Core.Graphics
{
	/// <summary>Class representing a shader program</summary>
	public class ShaderProgram : IDisposable, IShallowCloneable
	{
		/*
		 *	Global Variables
		 */
		internal int handle;
		internal ShaderProgramState state;
		
		/// <summary>Creates a shader program (from a file)</summary>
		/// <param name="fileName">Shader filename</param>
		/// <remarks>Creates a shader program from a specified file. The usable file format is CGX.</remarks>
		public ShaderProgram(string fileName) : this(fileName, null, null) { }

		/// <summary>Creates a shader program (from a file)</summary>
		/// <param name="vpFileName">Vertex shader filename</param>
		/// <param name="fpFileName">Fragment shader filename</param>
		/// <remarks>Creates a shader program from a specified file. The usable file format is CGX.</remarks>
		public ShaderProgram(string vpFileName, string fpFileName) : this(vpFileName, fpFileName, null) { }

		/// <summary>Creates a shader program (from a file, with options)</summary>
		/// <param name="fileName">Shader filename</param>
		/// <param name="option">Shader program creation option</param>
		/// <remarks>Creates a shader program from a specified file. The usable file format is CGX.</remarks>
		public ShaderProgram(string fileName, ShaderProgramOption option) : this(fileName, null, option) {}

		/// <summary>Creates a shader program (from a file, with options)</summary>
		/// <param name="vpFileName">Vertex shader filename</param>
		/// <param name="fpFileName">Fragment shader filename</param>
		/// <param name="option">Shader program creation option</param>
		/// <remarks>Creates a shader program from a specified file. The usable file format is CGX.</remarks>
		[SecuritySafeCritical]
		public ShaderProgram(string vpFileName, string fpFileName, ShaderProgramOption option)
		{
			string[] constKeys = ShaderProgram.GetConstKeys(option);
			int[] constVals = ShaderProgram.GetConstVals(option);
			int errorCode = PsmShaderProgram.FromFile(vpFileName, fpFileName, constKeys, constVals, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.state = new ShaderProgramState(this.handle);
		}

		/// <summary>Creates a shader program (from a file image)</summary>
		/// <param name="fileImage">Shader file image</param>
		/// <remarks>Creates a shader program from a specified file image. The usable file format is CGX.</remarks>
		public ShaderProgram(byte[] fileImage) : this(fileImage, null, null) { }

		/// <summary>Creates a shader program (from a file image)</summary>
		/// <param name="vpFileImage">Vertex shader file image</param>
		/// <param name="fpFileImage">Fragment shader file image</param>
		/// <remarks>Creates a shader program from a specified file image. The usable file format is CGX.</remarks>
		public ShaderProgram(byte[] vpFileImage, byte[] fpFileImage) : this(vpFileImage, fpFileImage, null) { }

		/// <summary>Creates a shader program (from a file image, with options)</summary>
		/// <param name="fileImage">Shader file image</param>
		/// <remarks>Creates a shader program from a specified file image. The usable file format is CGX.</remarks>
		public ShaderProgram(byte[] fileImage, ShaderProgramOption option) : this(fileImage, null, option) { }

		/// <summary>Creates a shader program (from a file image, with options)</summary>
		/// <param name="vpFileImage">Vertex shader file image</param>
		/// <param name="fpFileImage">Fragment shader file image</param>
		/// <remarks>Creates a shader program from a specified file image. The usable file format is CGX.</remarks>
		[SecuritySafeCritical]
		public ShaderProgram(byte[] vpFileImage, byte[] fpFileImage, ShaderProgramOption option)
		{
			string[] constKeys = ShaderProgram.GetConstKeys(option);
			int[] constVals = ShaderProgram.GetConstVals(option);
			int errorCode = PsmShaderProgram.FromImage(vpFileImage, fpFileImage, constKeys, constVals, out this.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.state = new ShaderProgramState(this.handle);
		}

		/// <summary>Creates a copy of the shader program</summary>
		/// <returns>Clones a shader program</returns>
		/// <remarks>Creates a copy of the shader program. The 2 shader programs will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		[SecuritySafeCritical]
		protected ShaderProgram(ShaderProgram program)
		{
			int errorCode = PsmShaderProgram.AddRef(program.handle);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			this.handle = program.handle;
			this.state = program.state;
		}

		/// <summary>Creates a copy of the shader program</summary>
		/// <returns>Copy of the shader program</returns>
		/// <remarks>Creates a copy of the shader program. The 2 shader programs will then share unmanaged resources. When Dispose() is called for all copies, the shared unmanaged resources will be freed.</remarks>
		public virtual object ShallowClone()
		{
			return new ShaderProgram(this);
		}

		/// <summary>Deletes a shader program</summary>
		~ShaderProgram()
		{
			this.Dispose(false);
		}

		/// <summary>Frees the unmanaged resources of the shader program</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.state = null;
			}
			PsmShaderProgram.Delete(this.handle);
			this.handle = 0;
		}

		/// <summary>Number of uniform variables</summary>
		public int UniformCount
		{
			get
			{
				return this.state.uniformCount;
			}
		}

		/// <summary>Number of attribute variables</summary>
		public int AttributeCount
		{
			get
			{
				return this.state.attributeCount;
			}
		}

		/// <summary>Enables search by specifying the uniform variable name</summary>
		/// <param name="name">Name of the uniform variable</param>
		/// <returns>Number of the uniform variable (failure if -1)</returns>
		/// <remarks>Enables search by specifying the uniform variable name. -1 will be returned if the specified variable is not found.</remarks>
		[SecuritySafeCritical]
		public int FindUniform(string name)
		{
			int uniform;
			int errorCode = PsmShaderProgram.FindUniform(this.handle, name, out uniform);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return uniform;
		}

		/// <summary>Enables search by specifying the attribute variable name</summary>
		/// <param name="name">Name of the attribute variable</param>
		/// <returns>Number of the attribute variable (failure if -1)</returns>
		/// <remarks>Enables search by specifying the attribute variable name. -1 will be returned if the specified variable is not found.</remarks>
		[SecuritySafeCritical]
		public int FindAttribute(string name)
		{
			int attribute;
			int errorCode = PsmShaderProgram.FindAttribute(this.handle, name, out attribute);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return attribute;
		}

		/// <summary>Obtains the uniform variable binding</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <returns>Name of the uniform variable (default when null)</returns>
		[SecuritySafeCritical]
		public string GetUniformBinding(int index)
		{
			string uniformBinding;
			int errorCode = PsmShaderProgram.GetUniformBinding(this.handle, index, out uniformBinding);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			return uniformBinding;
		}

		/// <summary>Sets the uniform variable binding</summary>
		/// <param name="index">Number of the uniform variable</param>
		/// <param name="name">Name of the uniform variable (default when null)</param>
		/// <remarks>Links the uniform variable to a specific number. The old binding of the specified variable will be freed. Variables that do not have a binding are assigned an unused number.</remarks>
		/// \image html image/graphics_uniform_binding.png
		/// <remarks>It is also possible to specify a number that is equal to or greater than UniformCount to index. In such cases, an empty variable is inserted and the UniformCount value increases.</remarks>
		/// \image html image/graphics_uniform_binding2.png
		[SecuritySafeCritical]
		public void SetUniformBinding(int index, string name)
		{
			int errorCode = PsmShaderProgram.SetUniformBinding(this.handle, index, name);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			PsmShaderProgram.GetUniformCount(this.handle, out this.state.uniformCount);
		}

		/// <summary>Obtains the attribute variable binding</summary>
		/// <param name="index">Number of the attribute variable (0 to AttributeCount-1)</param>
		/// <returns>Name of the attribute variable (default when null)</returns>
		[SecuritySafeCritical]
		public string GetAttributeBinding(int index)
		{
			string result;
			int attributeBinding = PsmShaderProgram.GetAttributeBinding(this.handle, index, out result);
			if (attributeBinding != 0)
			{
				Error.ThrowNativeException(attributeBinding);
			}
			return result;
		}

		/// <summary>Sets the attribute variable binding</summary>
		/// <param name="index">Number of the attribute variable</param>
		/// <param name="name">Name of the attribute variable (default when null)</param>
		/// <remarks>Links the attribute variable to a specific number. The old binding of the specified variable will be freed. Variables that do not have a binding are assigned an unused number.</remarks>
		/// \image html image/graphics_attribute_binding.png
		/// <remarks>It is also possible to specify a number that is equal to or greater than AttributeCount to index. In such cases, an empty variable is inserted and the AttributeCount value increases.</remarks>
		/// \image html image/graphics_attribute_binding2.png
		[SecuritySafeCritical]
		public void SetAttributeBinding(int index, string name)
		{
			int errorCode = PsmShaderProgram.SetAttributeBinding(this.handle, index, name);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			PsmShaderProgram.GetAttributeCount(this.handle, out this.state.attributeCount);
			GraphicsContext.NotifyUpdate(GraphicsUpdate.VertexBuffer);
		}

		/// <summary>Obtains the uniform variable type</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <returns>Uniform variable type</returns>
		[SecuritySafeCritical]
		public ShaderUniformType GetUniformType(int index)
		{
			ShaderUniformType result;
			int uniformType = PsmShaderProgram.GetUniformType(this.handle, index, out result);
			if (uniformType != 0)
			{
				Error.ThrowNativeException(uniformType);
			}
			return result;
		}

		/// <summary>Obtains the attribute variable type</summary>
		/// <param name="index">Number of the attribute variable (0 to AttributeCount-1)</param>
		/// <returns>Attribute variable type</returns>
		[SecuritySafeCritical]
		public ShaderAttributeType GetAttributeType(int index)
		{
			ShaderAttributeType result;
			int attributeType = PsmShaderProgram.GetAttributeType(this.handle, index, out result);
			if (attributeType != 0)
			{
				Error.ThrowNativeException(attributeType);
			}
			return result;
		}

		/// <summary>Obtains the uniform variable name</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <returns>Name of the uniform variable</returns>
		[SecuritySafeCritical]
		public string GetUniformName(int index)
		{
			string result;
			int uniformName = PsmShaderProgram.GetUniformName(this.handle, index, out result);
			if (uniformName != 0)
			{
				Error.ThrowNativeException(uniformName);
			}
			return result;
		}

		/// <summary>Obtains the attribute variable name</summary>
		/// <param name="index">Number of the attribute variable (0 to AttributeCount-1)</param>
		/// <returns>Name of the attribute variable</returns>
		[SecuritySafeCritical]
		public string GetAttributeName(int index)
		{
			string result;
			int attributeName = PsmShaderProgram.GetAttributeName(this.handle, index, out result);
			if (attributeName != 0)
			{
				Error.ThrowNativeException(attributeName);
			}
			return result;
		}

		/// <summary>Obtains the array size of the uniform variable</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <returns>Obtains the array size of the uniform variable</returns>
		[SecuritySafeCritical]
		public int GetUniformSize(int index)
		{
			int result;
			int uniformSize = PsmShaderProgram.GetUniformSize(this.handle, index, out result);
			if (uniformSize != 0)
			{
				Error.ThrowNativeException(uniformSize);
			}
			return result;
		}

		/// <summary>Obtains the array size of the attribute variable</summary>
		/// <param name="index">Number of the attribute variable (0 to AttributeCount-1)</param>
		/// <returns>Attribute variable array size</returns>
		[SecuritySafeCritical]
		public int GetAttributeSize(int index)
		{
			int result;
			int attributeSize = PsmShaderProgram.GetAttributeSize(this.handle, index, out result);
			if (attributeSize != 0)
			{
				Error.ThrowNativeException(attributeSize);
			}
			return result;
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">4D matrix (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, ref Matrix4 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, 0, ref value, ShaderUniformType.Float4x4);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">4D vector (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, ref Vector4 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, 0, ref value, ShaderUniformType.Float4);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">3D vector (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, ref Vector3 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, 0, ref value, ShaderUniformType.Float3);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">2D vector (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, ref Vector2 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, 0, ref value, ShaderUniformType.Float2);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">Scalar (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, float value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, 0, ref value, ShaderUniformType.Float);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">Scalar (int)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, 0, ref value, ShaderUniformType.Int);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">Array data (float)</param>
		/// <remarks>Sets the uniform variable value. This overload can set a value not only to a float scalar variable, but also to the float vector or matrix variable such as float2,float3,float4... However, the array data size must be a multiple of the vector or matrix size.</remarks>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, float[] value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Float, 0, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">Array data (int)</param>
		/// <remarks>Sets the uniform variable value. This overload can set a value not only to an int scalar variable, but also to the int vector variable such as int2,int3,int4... However, the array data size must be a multiple of the vector size.</remarks>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int[] value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Int, 0, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">4D matrix (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, ref Matrix4 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, offset, ref value, ShaderUniformType.Float4x4);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">4D vector (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, ref Vector4 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, offset, ref value, ShaderUniformType.Float4);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">3D vector (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, ref Vector3 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, offset, ref value, ShaderUniformType.Float3);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">2D vector (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, ref Vector2 value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, offset, ref value, ShaderUniformType.Float2);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">Scalar (float)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, float value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, offset, ref value, ShaderUniformType.Float);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">Scalar (int)</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, int value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue(this.handle, index, offset, ref value, ShaderUniformType.Int);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">Array data (float)</param>
		/// <remarks>Sets the uniform variable value. This overload can set a value not only to a float scalar variable, but also to the float vector or matrix variable such as float2,float3,float4... However, the array data size must be a multiple of the vector or matrix size. Note that the offset arguments are counted in vector or matrix units.</remarks>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, float[] value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Float, offset, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (with offset)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="offset">Offset of array variable</param>
		/// <param name="value">Array data (int)</param>
		/// <remarks>Sets the uniform variable value. This overload can set a value not only to an int scalar variable, but also to the int vector variable such as int2,int3,int4... However, the array data size must be a multiple of the vector size. Note that the offset arguments are counted in vector units.</remarks>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int offset, int[] value)
		{
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Int, offset, 0, -1);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (for array data)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">4D matrix array (float)</param>
		/// <param name="to">Offset of the transfer destination</param>
		/// <param name="from">Offset of the transfer source</param>
		/// <param name="count">Number of data items to be transferred</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, Matrix4[] value, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Float4x4, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (for array data)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">4D vector array (float)</param>
		/// <param name="to">Offset of the transfer destination</param>
		/// <param name="from">Offset of the transfer source</param>
		/// <param name="count">Number of data items to be transferred</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, Vector4[] value, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Float4, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (for array data)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">3D vector array (float)</param>
		/// <param name="to">Offset of the transfer destination</param>
		/// <param name="from">Offset of the transfer source</param>
		/// <param name="count">Number of data items to be transferred</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, Vector3[] value, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Float3, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (for array data)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">2D vector array (float)</param>
		/// <param name="to">Offset of the transfer destination</param>
		/// <param name="from">Offset of the transfer source</param>
		/// <param name="count">Number of data items to be transferred</param>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, Vector2[] value, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Float2, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (for array data)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">Array data (float)</param>
		/// <param name="to">Offset of the transfer destination</param>
		/// <param name="from">Offset of the transfer source</param>
		/// <param name="count">Number of data items to be transferred</param>
		/// <remarks>Sets the uniform variable value. This overload can set a value not only to a float scalar variable, but also to the float vector or matrix variable such as float2,float3,float4... However, note that the offset and count arguments are counted in vector or matrix units.</remarks>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, float[] value, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Float, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the uniform variable value (for array data)</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <param name="value">Array data (int)</param>
		/// <param name="to">Offset of the transfer destination</param>
		/// <param name="from">Offset of the transfer source</param>
		/// <param name="count">Number of data items to be transferred</param>
		/// <remarks>Sets the uniform variable value. This overload can set a value not only to an int scalar variable, but also to the int vector variable such as int2,int3,int4... However, note that the offset and count arguments are counted in vector units.</remarks>
		[SecuritySafeCritical]
		public void SetUniformValue(int index, int[] value, int to, int from, int count)
		{
			if (count < 0)
			{
				count = int.MaxValue;
			}
			int errorCode = PsmShaderProgram.SetUniformValue2(this.handle, index, value, ShaderUniformType.Int, to, from, count);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
		}

		/// <summary>Sets the default value of the attribute variable.</summary>
		/// <param name="index">Number of the attribute variable (0 to AttributeCount-1)</param>
		/// <param name="value">Array data (float)</param>
		[SecuritySafeCritical]
		public void SetAttributeValue(int index, params float[] value)
		{
			int errorCode = PsmShaderProgram.SetAttributeValue2(this.handle, index, value);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			GraphicsContext.NotifyUpdate(GraphicsUpdate.VertexBuffer);
		}

		/// <summary>Obtains the uniform variable texture number</summary>
		/// <param name="index">Number of the uniform variable (0 to UniformCount-1)</param>
		/// <returns>Texture number of the uniform variable (disabled if -1)</returns>
		/// <remarks>Obtains the uniform variable texture number. -1 will be returned if the specified variable is not a sampler.</remarks>
		[SecuritySafeCritical]
		public int GetUniformTexture(int index)
		{
			int result;
			int uniformTexture = PsmShaderProgram.GetUniformTexture(this.handle, index, out result);
			if (uniformTexture != 0)
			{
				Error.ThrowNativeException(uniformTexture);
			}
			return result;
		}

		/// <summary>Obtains the vertex stream number of the attribute variable</summary>
		/// <param name="index">Number of the attribute variable (0 to AttributeCount-1)</param>
		/// <returns>Vertex stream number (invalid if -1)</returns>
		[SecuritySafeCritical]
		public int GetAttributeStream(int index)
		{
			int result;
			int attributeStream = PsmShaderProgram.GetAttributeStream(this.handle, index, out result);
			if (attributeStream != 0)
			{
				Error.ThrowNativeException(attributeStream);
			}
			return result;
		}

		/// <summary>Sets the vertex stream number of the attribute variable</summary>
		/// <param name="index">Number of the attribute variable (0 to AttributeCount-1)</param>
		/// <param name="stream">Vertex stream number (invalid if -1)</param>
		/// <remarks>Sets the vertex stream number of the attribute variable. The initial value is the number of the attribute variable. With this setting, an arbitrary vertex stream can be forwarded to the specified attribute variable. In addition, specific vertex streams can be disabled and a single vertex stream can be forwarded to multiple attribute variables.</remarks>
		/// \image html image/graphics_attribute_stream.png
		[SecuritySafeCritical]
		public void SetAttributeStream(int index, int stream)
		{
			int errorCode = PsmShaderProgram.SetAttributeStream(this.handle, index, stream);
			if (errorCode != 0)
			{
				Error.ThrowNativeException(errorCode);
			}
			GraphicsContext.NotifyUpdate(GraphicsUpdate.VertexBuffer);
		}

		/// <summary>Changes the shader</summary>
		/// <param name="program">Shader Program</param>
		/// <remarks>Sets the shader of the specified shader program to this shader program. This function is used when switching shaders internally.</remarks>
		[SecuritySafeCritical]
		protected void SwapShader(ShaderProgram program)
		{
			if (program.handle != this.handle)
			{
				int errorCode = PsmShaderProgram.AddRef(program.handle);
				if (errorCode != 0)
				{
					Error.ThrowNativeException(errorCode);
				}
				PsmShaderProgram.Delete(this.handle);
				this.handle = program.handle;
				this.state = program.state;
				GraphicsContext.NotifyUpdate(GraphicsUpdate.ShaderProgram);
			}
		}

		/// <summary>Updates the shader state</summary>
		/// <remarks>A virtual function that is called from the graphics context before primitive rendering. This function is used when a cached state in a class is applied to the shader.</remarks>
		protected internal virtual void UpdateShader() { }

		internal static string[] GetConstKeys(ShaderProgramOption option)
		{
			string[] result;
			if (option == null || option.ConstantValues.Count == 0)
			{
				result = null;
			}
			else
			{
				string[] array = new string[option.ConstantValues.Count];
				option.ConstantValues.Keys.CopyTo(array, 0);
				result = array;
			}
			return result;
		}

		internal static int[] GetConstVals(ShaderProgramOption option)
		{
			int[] result;
			if (option == null || option.ConstantValues.Count == 0)
			{
				result = null;
			}
			else
			{
				int[] array = new int[option.ConstantValues.Count];
				option.ConstantValues.Values.CopyTo(array, 0);
				result = array;
			}
			return result;
		}
	}
}
