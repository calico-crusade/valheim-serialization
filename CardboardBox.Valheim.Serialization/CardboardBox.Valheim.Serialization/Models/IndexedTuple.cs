namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	public class IndexedTuple<T>
	{
		[Index(0)]
		public T Item1 { get; set; }

		public void Deconstruct(out T item1)
		{
			item1 = Item1;
		}
	}

	public class IndexedTuple<T1, T2> : IndexedTuple<T1>
	{
		[Index(1)]
		public T2 Item2 { get; set; }

		public void Deconstruct(out T1 item1, out T2 item2)
		{
			item1 = Item1;
			item2 = Item2;
		}
	}

	public class IndexedTuple<T1, T2, T3> : IndexedTuple<T1, T2>
	{
		[Index(2)]
		public T3 Item3 { get; set; }

		public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
		{
			item1 = Item1;
			item2 = Item2;
			item3 = Item3;
		}
	}
}
