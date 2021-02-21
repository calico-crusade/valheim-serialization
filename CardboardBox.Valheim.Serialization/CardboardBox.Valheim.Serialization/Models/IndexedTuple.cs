namespace CardboardBox.Valheim.Serialization
{
	using Utilities;

	public class IndexedTuple<T>
	{
		[Index(0)]
		public T Item1 { get; set; }

		public IndexedTuple() { }

		public IndexedTuple(T t)
		{
			Item1 = t;
		}

		public void Deconstruct(out T item1)
		{
			item1 = Item1;
		}
	}

	public class IndexedTuple<T1, T2> : IndexedTuple<T1>
	{
		[Index(1)]
		public T2 Item2 { get; set; }

		public IndexedTuple() { }

		public IndexedTuple(T1 t1, T2 t2) : base(t1)
		{
			Item2 = t2;
		}

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

		public IndexedTuple() { }

		public IndexedTuple(T1 t1, T2 t2, T3 t3) : base(t1, t2)
		{
			Item3 = t3;
		}

		public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
		{
			item1 = Item1;
			item2 = Item2;
			item3 = Item3;
		}
	}
}
