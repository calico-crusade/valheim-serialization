using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	public class CharacterSerializer : BaseSerializer<Character>
	{
		public override string Extension => "fch";

		public void ReadPlayerData(Character character, byte[] data)
		{
			using var ms = new MemoryStream(data);
			using var br = new BinaryReader(ms);

			character.PlayerData = ComplexSerializer.Read<PlayerData>(br);

			character.Inventory = ComplexSerializer
				.ReadCollection<Item>(br)
				.ToList();

			character.KnownRecipes = ComplexSerializer
				.ReadCollection<IndexedTuple<string>>(br)
				.Select(t => t.Item1)
				.ToList();

			character.KnownStations = ComplexSerializer
				.ReadCollection<IndexedTuple<string, int>>(br)
				.Select(t => (t.Item1, t.Item2))
				.ToList();

			character.KnownMaterials = ComplexSerializer
				.ReadCollection<IndexedTuple<string>>(br)
				.Select(t => t.Item1)
				.ToList();

			character.KnownTutorials = ComplexSerializer
				.ReadCollection<IndexedTuple<string>>(br)
				.Select(t => t.Item1)
				.ToList();

			character.Uniques = ComplexSerializer
				.ReadCollection<IndexedTuple<string>>(br)
				.Select(t => t.Item1)
				.ToList();

			character.Trophies = ComplexSerializer
				.ReadCollection<IndexedTuple<string>>(br)
				.Select(t => t.Item1)
				.ToList();

			character.KnownBiomes = ComplexSerializer
				.ReadCollection<IndexedTuple<int>>(br)
				.Select(t => (Biome)t.Item1)
				.ToList();

			character.KnownTexts = ComplexSerializer
				.ReadCollection<IndexedTuple<string, string>>(br)
				.Select(t => (t.Item1, t.Item2))
				.ToList();

			character.Model = ComplexSerializer.Read<Look>(br);

			character.Food = ComplexSerializer
				.ReadCollection<Food>(br)
				.ToList();

			character.SkillVersion = br.ReadInt32();
			character.Skills = ComplexSerializer
				.ReadCollection<Skill>(br)
				.ToList();
		}

		public void ReadMapData(WorldData world, byte[] data)
		{
			using var ms = new MemoryStream(data);
			using var br = new BinaryReader(ms);

			world.MapVersion = br.ReadInt32();
			var size = br.ReadInt32();

			world.Explored = new bool[size, size];

			for(var x = 0; x < size; x++)
				for(var y = 0; y < size; y++)
					world.Explored[x, y] = br.ReadBoolean();

			world.Pins = ComplexSerializer
				.ReadCollection<Pin>(br)
				.ToList();
		}

		public override Character Read(BinaryReader reader)
		{
			var stats = ComplexSerializer.Read<Statistics>(reader);
			var worlds = new Dictionary<long, WorldData>();

			foreach (var world in ComplexSerializer.ReadCollection<WorldData>(reader))
			{
				if (world.MapData != null &&
					world.MapData.Length > 0)
					ReadMapData(world, world.MapData);

				world.MapData = null;
				worlds.Add(world.WorldId, world);
			}

			var character = ComplexSerializer.Read<Character>(reader);

			var hasPlayerData = TypeSerializer.Read<bool>(reader);
			if (hasPlayerData)
			{
				var pd = TypeSerializer.ReadBytes(reader);
				ReadPlayerData(character, pd);
			}

			character.Statistics = stats;
			character.WorldData = worlds;

			return character;
		}

		public override void Write(BinaryWriter writer, Character input)
		{
			ComplexSerializer.Write(writer, input.Statistics);
			var worlds = input.WorldData.Values;
			ComplexSerializer.WriteCollection(writer, worlds);
			ComplexSerializer.Write(writer, input);
		}

		public override void Write(Stream output, Character input)
		{
			byte[] data = null;
			using (var ms = new MemoryStream())
			{
				using var bw = new BinaryWriter(ms);
				Write(bw, input);
				data = ms.ToArray();
			}

			byte[] hash = GenerateHash(data);
			using var io = new BinaryWriter(output);
			TypeSerializer.WriteBytes(io, data);
			TypeSerializer.WriteBytes(io, hash);
		}

		public byte[] GenerateHash(byte[] data)
		{
			using var sha = SHA512.Create();
			return sha.ComputeHash(data);
		}
	}
}
