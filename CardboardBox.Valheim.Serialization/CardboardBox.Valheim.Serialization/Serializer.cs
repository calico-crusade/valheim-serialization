using System.IO;

namespace CardboardBox.Valheim.Serialization
{
	public static class Serializer
	{
		public static IBaseSerializer<World> Worlds => new WorldSerializer();

		public static IBaseSerializer<Character> Characters => new CharacterSerializer();
	}
}
