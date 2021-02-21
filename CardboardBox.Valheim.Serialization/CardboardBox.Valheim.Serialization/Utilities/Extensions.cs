using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CardboardBox.Valheim.Serialization.Utilities
{
	public static class Extensions
	{
		public static IEnumerable<T> FromIndexed<T>(this IEnumerable<IndexedTuple<T>> data)
		{
			return data.Select(t => t.Item1);
		}

		public static IEnumerable<IndexedTuple<T>> ToIndexed<T>(this IEnumerable<T> data)
		{
			return data.Select(t => new IndexedTuple<T>(t));
		}

		public static IEnumerable<(T1, T2)> FromIndexed<T1, T2>(this IEnumerable<IndexedTuple<T1, T2>> data)
		{
			return data.Select(t => (t.Item1, t.Item2));
		}

		public static IEnumerable<IndexedTuple<T1, T2>> ToIndexed<T1, T2>(this IEnumerable<(T1, T2)> data)
		{
			return data.Select(t => new IndexedTuple<T1, T2>(t.Item1, t.Item2));
		}

		public static IEnumerable<(T1, T2, T3)> FromIndexed<T1, T2, T3>(this IEnumerable<IndexedTuple<T1, T2, T3>> data)
		{
			return data.Select(t => (t.Item1, t.Item2, t.Item3));
		}

		public static IEnumerable<IndexedTuple<T1, T2, T3>> ToIndexed<T1, T2, T3>(this IEnumerable<(T1, T2, T3)> data)
		{
			return data.Select(t => new IndexedTuple<T1, T2, T3>(t.Item1, t.Item2, t.Item3));
		}

		public static byte[] Sha512Hash(this byte[] data)
		{
			using var sha = SHA512.Create();
			return sha.ComputeHash(data);
		}

		public static string Sha512HashString(this byte[] data)
		{
			var hash = data.Sha512Hash();
			return Convert.ToBase64String(hash);
		}
	}
}
