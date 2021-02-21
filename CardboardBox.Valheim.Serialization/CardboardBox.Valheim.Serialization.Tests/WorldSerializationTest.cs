using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardboardBox.Valheim.Serialization.Tests
{
	[TestClass]
	public class WorldSerializationTest : BaseSerializationTest<World>
	{
		public override string TestFile => "World-Metadata.fwl";
		public override IBaseSerializer<World> Serializer => new WorldSerializer();

		[TestMethod]
		public override void Deserialization()
		{
			var world = Read();
			Assert.IsNotNull(world, "Null check");

			Assert.AreEqual(2420125204, world.WorldId, "World ID");
			Assert.AreEqual("MapTest", world.Name, "World Name");
			Assert.AreEqual("test", world.Seed, "World Seed");
			Assert.AreEqual(-871206010, world.NumericSeed, "World Seed (number)");
			Assert.AreEqual(26, world.WorldVersion, "World Version");
			Assert.AreEqual(1, world.WorldGenVersion, "World Gen Version");
		}
	}
}
