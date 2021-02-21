namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	public class Food
	{
		/// <summary>
		/// The name of the food item
		/// </summary>
		[Index(0)]
		public string Name { get; set; }

		/// <summary>
		/// How much HP it would regen (per tick?)
		/// </summary>
		[Index(1)]
		public float Hp { get; set; }

		/// <summary>
		/// How much stamina it would regen (per tick?)
		/// </summary>
		[Index(2)]
		public float Stamina { get; set; }
	}
}
