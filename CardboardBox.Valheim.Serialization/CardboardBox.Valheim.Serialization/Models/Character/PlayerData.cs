using System;

namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// Represents details about the players
	/// This is provided by fukcye#1272 on discord via: https://gist.github.com/balu92/ce1ce7ea70a0a29e0f146596a1dff3f7
	/// </summary>
	public class PlayerData
	{
		/// <summary>
		/// The version of player data
		/// </summary>
		[Index(0)]
		public int Version { get; set; }

		/// <summary>
		/// The player's max health
		/// </summary>
		[Index(1)]
		public float MaxHealth { get; set; }

		/// <summary>
		/// The player's current health
		/// </summary>
		[Index(2)]
		public float Health { get; set; }

		/// <summary>
		/// The player's current stamina
		/// </summary>
		[Index(3)]
		public float Stamina { get; set; }

		/// <summary>
		/// Whether this will be the player's first spawn in the world or not
		/// </summary>
		[Index(4)]
		public bool FirstSpawn { get; set; }

		/// <summary>
		/// The timestamp offset since the players last death in the world
		/// </summary>
		[Index(5)]
		public float TimeSinceDeath { get; set; }

		/// <summary>
		/// The guardian power the character has equipped
		/// </summary>
		[Index(6)]
		public string GuardianPower { get; set; }

		/// <summary>
		/// The cooldown until the guardian power is available for use
		/// </summary>
		[Index(7)]
		public float GuardianCooldown { get; set; }

		/// <summary>
		/// The version of the inventory data
		/// </summary>
		[Index(8)]
		public int InventoryVersion { get; set; }
	}
}
