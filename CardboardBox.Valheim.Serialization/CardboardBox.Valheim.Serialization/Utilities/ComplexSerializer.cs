using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CardboardBox.Valheim.Serialization.Utilities
{
	public class ComplexSerializer
	{
		private static Dictionary<Type, IndexedProperty[]> _propertyDataCache = new Dictionary<Type, IndexedProperty[]>();
		public static int DefaultWorldVersion = 26;
		
		public BinaryReader Reader { get; private set; }
		public BinaryWriter Writer { get; private set; }

		#region ctro
		public ComplexSerializer(BinaryReader reader, BinaryWriter writer)
		{
			Reader = reader;
			Writer = writer;
		}

		public ComplexSerializer(BinaryReader reader) : this(reader, null) { }

		public ComplexSerializer(BinaryWriter writer) : this(null, writer) { }
		#endregion

		#region Serialization
		public void Serialize(object instance, int? version = null)
		{
			var type = instance.GetType();
			var props = GetPropertyIndexes(type, version ?? DefaultWorldVersion);

			foreach (var (property, index) in props)
			{
				var value = property.GetValue(instance);
				if (index.HasCondition)
				{
					var condition = value != null;
					TypeSerializer.Write(Writer, condition);

					if (!condition)
						continue;
				}

				TypeSerializer.Write(Writer, value);
			}
		}

		public void SerializeCollection(object[] instances, int? version = null)
		{
			Writer.Write(instances.Length);

			foreach (var item in instances)
				Serialize(item, version);
		}
		#endregion

		#region Deserialization
		public void Deserialize(object instance, int? version = null)
		{
			var type = instance.GetType();
			var props = GetPropertyIndexes(type, version ?? DefaultWorldVersion);

			foreach(var (property, index) in props)
			{
				if (index.HasCondition)
				{
					var condition = TypeSerializer.Read<bool>(Reader);
					if (!condition)
						continue;
				}

				var value = TypeSerializer.Read(Reader, property.PropertyType);
				property.SetValue(instance, value);
			}
		}

		public T Deserialize<T>(int? version = null)
		{
			var instance = Activator.CreateInstance<T>();
			Deserialize(instance, version);
			return instance;
		}

		public IEnumerable<T> DeserializeCollection<T>(int count, int? version = null)
		{
			for (var i = 0; i < count; i++)
				yield return Deserialize<T>(version);
		}

		public IEnumerable<T> DeserializeLengthPrefixCollection<T>(int? version = null)
		{
			int length = Reader.ReadInt32();
			return DeserializeCollection<T>(length, version);
		}
		#endregion

		#region Reflection
		public (PropertyInfo, IndexAttribute)[] GetPropertyIndexes<T>(int version) 
			=> GetPropertyIndexes(typeof(T), version);

		public (PropertyInfo, IndexAttribute)[] GetPropertyIndexes(Type type, int version)
		{
			if (!_propertyDataCache.ContainsKey(type))
			{
				_propertyDataCache.Add(type, 
					type.GetProperties()
					.Select(t => new IndexedProperty(t, t
						.GetCustomAttributes<IndexAttribute>()
						.ToDictionary(a => a.Version, a => a)))
					.Where(t => t.VersionedIndexes.Count > 0)
					.ToArray());
			}

			return _propertyDataCache[type]
				.Select(t => (t.Property, t.VersionedIndexes[version]))
				.Where(t => t.Item2 != null)
				.OrderBy(t => t.Item2.Index)
				.ToArray();
		}
		#endregion

		#region Static impl - Reading
		public static T Read<T>(byte[] data, int? version = null)
		{
			using var ms = new MemoryStream(data);
			return Read<T>(ms, version);
		}

		public static T Read<T>(Stream stream, int? version = null)
		{
			using var br = new BinaryReader(stream);
			return Read<T>(br, version);
		}

		public static T Read<T>(BinaryReader reader, int? version = null)
		{
			return new ComplexSerializer(reader)
				.Deserialize<T>(version);
		}

		public static IEnumerable<T> ReadCollection<T>(byte[] data, int? version = null)
		{
			using var ms = new MemoryStream(data);
			return ReadCollection<T>(ms, version);
		}

		public static IEnumerable<T> ReadCollection<T>(Stream reader, int? version = null)
		{
			using var br = new BinaryReader(reader);
			return ReadCollection<T>(br, version);
		}

		public static IEnumerable<T> ReadCollection<T>(BinaryReader reader, int? version = null)
		{
			return new ComplexSerializer(reader)
				.DeserializeLengthPrefixCollection<T>(version);
		}
		#endregion

		#region Static impl - Writing
		public static void Write<T>(Stream stream, T input, int? version = null)
		{
			using var bw = new BinaryWriter(stream);
			Write(bw, input, version);
		}

		public static void Write<T>(BinaryWriter writer, T input, int? version = null)
		{
			new ComplexSerializer(writer).Serialize(input, version);
		}

		public static void WriteCollection<T>(Stream writer, IEnumerable<T> input, int? version = null)
		{
			using var bw = new BinaryWriter(writer);
			WriteCollection(bw, input, version);
		}

		public static void WriteCollection<T>(BinaryWriter writer, IEnumerable<T> input, int? version = null)
		{
			new ComplexSerializer(writer)
				.SerializeCollection(input.Cast<object>().ToArray(), version);
		}
		#endregion

		public class IndexedProperty
		{
			public PropertyInfo Property { get; set; }

			public Dictionary<int, IndexAttribute> VersionedIndexes { get; set; }

			public IndexedProperty(PropertyInfo property, Dictionary<int, IndexAttribute> versioned)
			{
				Property = property;
				VersionedIndexes = versioned;
			}

			public IndexAttribute this[int version]
			{
				get
				{
					if (VersionedIndexes.ContainsKey(version))
						return VersionedIndexes[version];

					var previous = VersionedIndexes
						.Where(t => t.Key < version)
						.OrderByDescending(t => t.Key)
						.ToArray();

					if (previous.Length <= 0)
						return null;

					return previous[0].Value;
				}
			}

			public void Deconstruct(out PropertyInfo property, out IndexAttribute latest)
			{
				property = Property;
				latest = this[DefaultWorldVersion];
			}
		}
	}
}
