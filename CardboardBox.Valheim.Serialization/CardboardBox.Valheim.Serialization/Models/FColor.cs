namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	public class FColor
	{
		[Index(0)]
		public float R { get; set; }

		[Index(1)]
		public float G { get; set; }

		[Index(2)]
		public float B { get; set; }

		public void Deconstruct(out int r, out int g, out int b)
		{
			r = (int)(R * 255);
			g = (int)(G * 255);
			b = (int)(B * 255);
		}
	}
}
