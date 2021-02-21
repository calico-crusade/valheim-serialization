using System;
using System.Collections.Generic;

namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// Represents a character object from the FCH files
	/// </summary>
	public class Character
	{
		/// <summary>
		/// The name of the character
		/// </summary>
		[Index(0)]
		public string Name { get; set; }

		/// <summary>
		/// The character's ID
		/// </summary>
		[Index(1)]
		public long PlayerId { get; set; }

		/// <summary>
		/// The seed for the start menu render
		/// </summary>
		[Index(2)]
		public string StartSeed { get; set; }

		/// <summary>
		/// The version of the skill data
		/// </summary>
		public int SkillVersion { get; set; }

		/// <summary>
		/// All of the recipes the player knows
		/// </summary>
		public List<string> KnownRecipes { get; set; }

		/// <summary>
		/// The name and level of all crafting stations the character knows
		/// </summary>
		public List<(string, int)> KnownStations { get; set; }

		/// <summary>
		/// All of the materials the character knows
		/// </summary>
		public List<string> KnownMaterials { get; set; }

		/// <summary>
		/// All of the tutorials the character knows (Hugin Messages)
		/// </summary>
		public List<string> KnownTutorials { get; set; }

		/// <summary>
		/// Not exactly sure what this is yet...
		/// </summary>
		public List<string> Uniques { get; set; }

		/// <summary>
		/// All of the trophies the player has encountered
		/// </summary>
		public List<string> Trophies { get; set; }

		/// <summary>
		/// All of the biomes the character has visited
		/// </summary>
		public List<Biome> KnownBiomes { get; set; }

		/// <summary>
		/// A list of all the text / runes the player has read
		/// </summary>
		public List<(string, string)> KnownTexts { get; set; }

		/// <summary>
		/// The food the player has eaten
		/// </summary>
		public List<Food> Food { get; set; }

		/// <summary>
		/// The players levels of each of their skills
		/// </summary>
		public List<Skill> Skills { get; set; }

		/// <summary>
		/// The player's inventory
		/// </summary>
		public List<Item> Inventory { get; set; }

		/// <summary>
		/// Data about the player
		/// </summary>
		public PlayerData PlayerData { get; set; }

		/// <summary>
		/// Details about the player's model
		/// </summary>
		public Look Model { get; set; }

		/// <summary>
		/// The player's statistics
		/// </summary>
		public Statistics Statistics { get; set; }

		/// <summary>
		/// The player's world data
		/// </summary>
		public Dictionary<long, WorldData> WorldData { get; set; }
	}
}
