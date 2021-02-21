using System.IO;

namespace CardboardBox.Valheim.Serialization
{
	public static class Serializer
	{
		public static WorldSerializer Worlds => new WorldSerializer();

		public static CharacterSerializer Characters => new CharacterSerializer();
	}
}
