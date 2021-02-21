using System;
using System.Collections.Generic;
using System.IO;

namespace CardboardBox.Valheim.Serialization.Utilities
{
	public class TypeSerializer
	{
		public static Dictionary<Type, TypeSerializer> TypeSerializers = new Dictionary<Type, TypeSerializer>
		{
			[typeof(int)] = new TypeSerializer((r) => r.ReadInt32(), (w, i) => w.Write((int)i)),
			[typeof(float)] = new TypeSerializer((r) => r.ReadSingle(), (w, i) => w.Write((float)i)),
			[typeof(string)] = new TypeSerializer((r) => r.ReadString(), (w, i) => w.Write((string)i)),
			[typeof(long)] = new TypeSerializer((r) => r.ReadInt64(), (w, i) => w.Write((long)i)),
			[typeof(bool)] = new TypeSerializer((r) => r.ReadBoolean(), (w, i) => w.Write((bool)i)),
			[typeof(Vector)] = new TypeSerializer((r) => ReadVector(r), (w, i) => WriteVector(w, (Vector)i)),
			[typeof(FColor)] = new TypeSerializer((r) => ReadColor(r), (w, i) => WriteColor(w, (FColor)i)),
			[typeof(byte[])] = new TypeSerializer((r) => ReadBytes(r), (w, i) => WriteBytes(w, (byte[])i))
		};

		public Func<BinaryReader, object> Reader { get; }

		public Action<BinaryWriter, object> Writer { get; }

		public TypeSerializer(Func<BinaryReader, object> reader, Action<BinaryWriter, object> writer)
		{
			Reader = reader;
			Writer = writer;
		}

		#region Read-Write Generics
		public static void Write(Stream stream, object output)
		{
			using var wr = new BinaryWriter(stream);
			Write(wr, output);
		}

		public static void Write(BinaryWriter writer, object output)
		{
			var type = output.GetType();
			if (TypeSerializers.ContainsKey(type))
			{
				TypeSerializers[type].Writer(writer, output);
				return;
			}

			throw new NotImplementedException($"{type.Name} does not have a type serializer registered! Are you missing a type definition?");
		}

		public static object Read(Stream stream, Type type)
		{
			using var re = new BinaryReader(stream);
			return Read(re, type);
		}

		public static object Read(BinaryReader reader, Type type)
		{
			try
			{
				if (TypeSerializers.ContainsKey(type))
					return TypeSerializers[type].Reader(reader);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error Handling Deserialize of type: {type.Name}. {ex.Message}", ex);
			}

			throw new NotImplementedException($"{type.Name} does not have a type serializer registered! Are you missing a type definition?");
		}

		public static T Read<T>(Stream stream)
		{
			using var re = new BinaryReader(stream);
			return Read<T>(re);
		}

		public static T Read<T>(BinaryReader reader)
		{
			return (T)Read(reader, typeof(T));
		}
		#endregion

		#region Read-Write Bytes
		public static byte[] ReadBytes(Stream stream)
		{
			using var re = new BinaryReader(stream);
			return ReadBytes(re);
		}

		public static byte[] ReadBytes(BinaryReader reader)
		{
			int length = reader.ReadInt32();
			return reader.ReadBytes(length);
		}

		public static void WriteBytes(Stream stream, byte[] bytes)
		{
			using var bw = new BinaryWriter(stream);
			WriteBytes(bw, bytes);
		}

		public static void WriteBytes(BinaryWriter writer, byte[] bytes)
		{
			int length = bytes.Length;
			writer.Write(length);
			writer.Write(bytes);
		}
		#endregion

		#region Read-Write Vectors
		public static Vector ReadVector(Stream stream)
		{
			using var re = new BinaryReader(stream);
			return ReadVector(re);
		}

		public static Vector ReadVector(BinaryReader reader)
		{
			return new Vector
			{
				X = reader.ReadSingle(),
				Y = reader.ReadSingle(),
				Z = reader.ReadSingle()
			};
		}

		public static void WriteVector(Stream stream, Vector vector)
		{
			using var wr = new BinaryWriter(stream);
			WriteVector(wr, vector);
		}

		public static void WriteVector(BinaryWriter writer, Vector vector)
		{
			writer.Write(vector.X);
			writer.Write(vector.Y);
			writer.Write(vector.Z);
		}
		#endregion

		#region Read-Write Colors

		public static FColor ReadColor(BinaryReader reader)
		{
			return ComplexSerializer.Read<FColor>(reader);
		}

		public static void WriteColor(BinaryWriter writer, FColor color)
		{
			ComplexSerializer.Write(writer, color);
		}

		#endregion
	}
}
