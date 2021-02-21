namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// Represents the data in the FWL file
	/// </summary>
	public class World
	{
		/// <summary>
		/// The version of the game the world was last opened on
		/// </summary>
		[Index(0)]
		public int WorldVersion { get; set; } = 26;

		/// <summary>
		/// The name of the world
		/// </summary>
		[Index(1)]
		public string Name { get; set; }

		/// <summary>
		/// The seed of the world
		/// </summary>
		[Index(2)]
		public string Seed { get; set; }

		/// <summary>
		/// The numeric version of the seed
		/// </summary>
		[Index(3)]
		public int NumericSeed { get; set; }

		/// <summary>
		/// The UID field from the file
		/// </summary>
		[Index(4)]
		public long WorldId { get; set; }


		/// <summary>
		/// The version of world generation it's using (either 1 or 0 for now)
		/// </summary>
		[Index(5)]
		public int WorldGenVersion { get; set; } = 1;

		public override string ToString()
		{
			return $"[{WorldId}]::{Name} - {Seed} ({NumericSeed}) - v{WorldVersion}-{WorldGenVersion}";
		}
	}
}
