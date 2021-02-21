using System;
using System.IO;

namespace CardboardBox.Valheim.Serialization.ExampleCli
{
	class Program
	{
		public static void Main(string[] args)
		{
			var world = Serializer.Worlds.Read(
				GetPath("World-Metadata.fwl"));
			Console.WriteLine($"{world.Name} - {world.Seed}");

			var character = Serializer.Characters.Read(
				GetPath("Character-Save.fch"));

			Console.WriteLine(character.Name);
		}

		public static string GetPath(string filename)
		{
			return Path.Combine("TestFiles", filename);
		}
	}
}
