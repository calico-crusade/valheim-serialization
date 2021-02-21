using System.IO;

namespace CardboardBox.Valheim.Serialization.Tests
{
	public static class TestExtensions
	{
		public const string TEST_FILES_DIR = "TestFiles";

		public static string GetTestFile(this string filename)
		{
			return Path.Combine(TEST_FILES_DIR, filename);
		}
	}
}
