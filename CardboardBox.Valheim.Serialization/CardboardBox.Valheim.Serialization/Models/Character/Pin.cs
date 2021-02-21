namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// A pin on the players mini-map
	/// </summary>
	public class Pin
	{
		/// <summary>
		/// The name of the pin
		/// </summary>
		[Index(0)]
		public string Name { get; set; }

		/// <summary>
		/// The position of the pin on the mini-map
		/// </summary>
		[Index(1)]
		public Vector Position { get; set; }

		/// <summary>
		/// The type of pin
		/// </summary>
		[Index(2)]
		public int NumericPinType { get; set; }

		/// <summary>
		/// Whether or not the user has an X over it.
		/// </summary>
		[Index(3)]
		public bool Checked { get; set; }

		/// <summary>
		/// The type of pin
		/// </summary>
		public PinType Type
		{
			get => (PinType)NumericPinType;
			set => NumericPinType = (int)value;
		}
	}
}
