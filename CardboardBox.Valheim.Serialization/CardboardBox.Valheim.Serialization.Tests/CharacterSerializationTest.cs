using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardboardBox.Valheim.Serialization.Tests
{
	[TestClass]
	public class CharacterSerializationTest : BaseSerializationTest<Character>
	{
		public override string TestFile => "Character-Save.fch";

		public override IBaseSerializer<Character> Serializer => new CharacterSerializer();

		[TestMethod]
		public override void Deserialization()
		{
			var character = Read();

			Assert.AreEqual("Cardboard", character.Name, "Name test");
			Assert.AreEqual(2, character.SkillVersion, "Skill Version Test");
			Assert.AreEqual(3, character.Food.Count, "Food Count Check");
			Assert.AreEqual(30, character.Inventory.Count, "Inventory Count Check");
			Assert.AreEqual(9, character.KnownBiomes.Count, "Known Biomes Count Check");
			Assert.AreEqual(165, character.KnownMaterials.Count, "Known Materials Count Check");
			Assert.AreEqual(15, character.Skills.Count, "Skills Count Check");
		}
	}
}
