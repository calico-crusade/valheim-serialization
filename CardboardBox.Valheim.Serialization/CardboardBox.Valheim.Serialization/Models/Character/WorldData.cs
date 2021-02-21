using System.Collections.Generic;

namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// Represents a world's data for a specific character
	/// </summary>
	public class WorldData
	{
		/// <summary>
		/// The ID of the world
		/// </summary>
		[Index(0)]
		public long WorldId { get; set; }

		/// <summary>
		/// Whether or not the player has a spawn point
		/// </summary>
		[Index(1)]
		public bool HasSpawnPoint { get; set; }

		/// <summary>
		/// The player's spawn point in the world
		/// </summary>
		[Index(2)]
		public Vector SpawnPoint { get; set; }

		/// <summary>
		/// Whether or not the player has a logout point
		/// </summary>
		[Index(3)]
		public bool HasLogoutPoint { get; set; }

		/// <summary>
		/// The player's logout point from the world
		/// </summary>
		[Index(4)]
		public Vector LogoutPoint { get; set; }

		/// <summary>
		/// Whether or not the player has a death point
		/// </summary>
		[Index(5)]
		public bool HasDeathPoint { get; set; }

		/// <summary>
		/// The player's last death point in the world
		/// </summary>
		[Index(6)]
		public Vector DeathPoint { get; set; }

		/// <summary>
		/// The player's home point in the world
		/// </summary>
		[Index(7)]
		public Vector HomePoint { get; set; }

		/// <summary>
		/// The version of map data
		/// </summary>
		public int MapVersion { get; set; }

		/// <summary>
		/// The data from the players map in the world.
		/// </summary>
		[Index(8, hasCondition: true)]
		public byte[] MapData { get; set; }

		/// <summary>
		/// Two dimensional array of whether each location has been explored or not
		/// </summary>
		public bool[,] Explored { get; set; }

		/// <summary>
		/// Any of the user's pins from their map
		/// </summary>
		public List<Pin> Pins { get; set; }
	}
}
