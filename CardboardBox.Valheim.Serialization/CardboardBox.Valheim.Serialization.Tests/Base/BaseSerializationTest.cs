using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CardboardBox.Valheim.Serialization.Tests
{
	using Utilities;

	public abstract class BaseSerializationTest<T>
	{
		public abstract string TestFile { get; }
		public abstract IBaseSerializer<T> Serializer { get; }

		public virtual string FullTestFilePath => TestFile.GetTestFile();

		public virtual T Read() => Serializer.Read(FullTestFilePath);

		[TestMethod]
		public virtual void Deserialization()
		{
			var test = Read();
			Assert.IsNotNull(test, "Null check");
		}

		[TestMethod]
		public virtual void Serialization()
		{
			var beforeHash = File.ReadAllBytes(FullTestFilePath).Sha512HashString();

			var test = Read();

			using var ms = new MemoryStream();
			Serializer.Write(ms, test);

			var afterHash = ms.ToArray().Sha512HashString();

			Assert.AreEqual(beforeHash, afterHash, "File Hash test");
		}
	}
}
