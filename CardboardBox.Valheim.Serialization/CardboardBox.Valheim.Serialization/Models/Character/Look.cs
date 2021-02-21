namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	public class Look
	{
		/// <summary>
		/// The beard the character is using
		/// </summary>
		[Index(0)]
		public string BeardModel { get; set; }

		/// <summary>
		/// The hair the character is using
		/// </summary>
		[Index(1)]
		public string HairModel { get; set; }

		/// <summary>
		/// The color of the character's skin
		/// </summary>
		[Index(2)]
		public FColor Skin { get; set; }

		/// <summary>
		/// The color of the character's hair
		/// </summary>
		[Index(3)]
		public FColor Hair { get; set; }

		/// <summary>
		/// The index of the character's model
		/// </summary>
		[Index(4)]
		public int ModelIndex { get; set; }
	}
}
