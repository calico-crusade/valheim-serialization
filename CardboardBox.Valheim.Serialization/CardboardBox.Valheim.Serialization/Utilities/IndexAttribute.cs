using System;

namespace CardboardBox.Valheim.Serialization.Utilities
{
	[AttributeUsage(AttributeTargets.Property)]
	public class IndexAttribute : Attribute
	{
		public int Index { get; private set; }
		public int Version { get; set; }
		public bool HasCondition { get; set; }

		public IndexAttribute(int index, int version = -1, bool hasCondition = false)
		{
			Index = index;
			Version = version == -1 ? ComplexSerializer.DefaultWorldVersion : version;
			HasCondition = hasCondition;
		}
	}
}
