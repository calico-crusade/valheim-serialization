namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// Represents an item in a players inventory
	/// </summary>
	public class Item
	{
		/// <summary>
		/// The name of the item
		/// </summary>
		[Index(0)]
		public string Name { get; set; }

		/// <summary>
		/// The count of how many of these items
		/// </summary>
		[Index(1)]
		public int Count { get; set; }

		/// <summary>
		/// How much durability remains for this item
		/// </summary>
		[Index(2)]
		public float Durability { get; set; }

		/// <summary>
		/// The column this item is in
		/// </summary>
		[Index(3)]
		public int Column { get; set; }

		/// <summary>
		/// The row this item is in
		/// </summary>
		[Index(4)]
		public int Row { get; set; }

		/// <summary>
		/// Whether or not the item is currently equipped
		/// </summary>
		[Index(5)]
		public bool Equipped { get; set; }

		/// <summary>
		/// The quality of the item
		/// </summary>
		[Index(6)]
		public int Quality { get; set; }

		/// <summary>
		/// The variant of the item
		/// </summary>
		[Index(7)]
		public int Variant { get; set; }

		/// <summary>
		/// The ID of the player who crafted the item
		/// </summary>
		[Index(8)]
		public long CrafterId { get; set; }

		/// <summary>
		/// The name of the player who crafted the item
		/// </summary>
		[Index(9)]
		public string Crafter { get; set; }
	}
}
