namespace CardboardBox.Valheim.Serialization
{ 
	using Utilities;

	public class Skill
	{
		/// <summary>
		/// The id of the skill
		/// </summary>
		[Index(0)]
		public int Id { get; set; }

		/// <summary>
		/// The current players level
		/// </summary>
		[Index(1)]
		public float Level { get; set; }

		/// <summary>
		/// The modifyer for damage or speed of the skill
		/// </summary>
		[Index(2)]
		public float Accumulator { get; set; }
	}
}
