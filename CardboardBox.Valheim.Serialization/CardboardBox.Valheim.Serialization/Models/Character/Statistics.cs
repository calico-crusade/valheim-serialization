namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// Represents character data from the FCH files
	/// </summary>
	public class Statistics
	{
		/// <summary>
		/// The version of the game the player was last loaded on
		/// </summary>
		[Index(0)]
		public int Version { get; set; }

		/// <summary>
		/// How many kills this character has gotten
		/// </summary>
		[Index(1)]
		public int Kills { get; set; }

		/// <summary>
		/// How many deaths this character has had
		/// </summary>
		[Index(2)]
		public int Deaths { get; set; }

		/// <summary>
		/// How many items this character has crafted (Unsure)
		/// </summary>
		[Index(3)]
		public int Crafts { get; set; }

		/// <summary>
		/// How many blocks this character has placed (Unsure)
		/// </summary>
		[Index(4)]
		public int Builds { get; set; }
	}
}
