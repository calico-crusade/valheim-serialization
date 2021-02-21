using System.IO;

namespace CardboardBox.Valheim.Serialization.ExampleCli
{
	class Program
	{
		public static void Main()
		{
			var worldPath = GetPath("World-Metadata.fwl");

			//Deserialize the FWL file (This contains world meta-data)
			var world = Serializer.Worlds.Read(worldPath);
			//Serialize the FWL file
			Serializer.Worlds.Write("test.fwl", world);

			var characterPath = GetPath("Character-Save.fch");

			//Deserialize the FCH file (This contains the character profile)
			var character = Serializer.Characters.Read(characterPath);
			//Serialize the FCH file
			Serializer.Characters.Write("test.fch", character);
		}

		public static string GetPath(string filename)
		{
			return Path.Combine("TestFiles", filename);
		}
	}
}
