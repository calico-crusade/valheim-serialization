using System.IO;

namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	/// <summary>
	/// Represents a serializer for FWL world files
	/// </summary>
	public class WorldSerializer : BaseSerializer<World>
	{
		public override string Extension => "fwl";

		/// <summary>
		/// Deserilaize the world for the contexted binary reader
		/// </summary>
		/// <param name="reader">The binary reader to read from</param>
		/// <returns>The deserialized world</returns>
		public override World Read(BinaryReader reader)
		{
			return ComplexSerializer.Read<World>(reader);
		}
				
		/// <summary>
		/// Writes the given world to the contextual binary writer
		/// </summary>
		/// <param name="writer">The writer to serialize to</param>
		/// <param name="world">The world to serialize</param>
		public override void Write(BinaryWriter writer, World world)
		{
			ComplexSerializer.Write(writer, world);
		}
	}
}
