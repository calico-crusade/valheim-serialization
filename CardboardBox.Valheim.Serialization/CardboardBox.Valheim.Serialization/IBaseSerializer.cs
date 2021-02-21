using System.IO;

namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	public interface IBaseSerializer 
	{ 
		string Extension { get; }
	}

	public abstract class BaseSerializer<T> : IBaseSerializer
	{
		public abstract string Extension { get; }

		public abstract T Read(BinaryReader reader);

		public virtual T Read(Stream stream)
		{
			var data = TypeSerializer.ReadBytes(stream);

			using var ms = new MemoryStream(data);
			using var br = new BinaryReader(ms);

			return Read(br);
		}

		public virtual T Read(string filepath)
		{
			if (!File.Exists(filepath))
				return default;

			using var io = File.OpenRead(filepath);
			return Read(io);
		}

		public abstract void Write(BinaryWriter writer, T input);

		public virtual void Write(Stream output, T input)
		{
			byte[] data = null;
			using (var ms = new MemoryStream())
			{
				using var bw = new BinaryWriter(ms);
				Write(bw, input);
				data = ms.ToArray();
			}

			TypeSerializer.WriteBytes(output, data);
		}

		public virtual void Write(string filepath, T input)
		{
			using var io = File.Create(filepath);
			Write(io, input);
		}
	}
}
