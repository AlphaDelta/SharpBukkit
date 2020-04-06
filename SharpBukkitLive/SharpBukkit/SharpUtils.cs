using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBukkitLive.SharpBukkit
{
    public class SharpUtils
    {
        public static void ArrayFill<T>(T[] a, int from, int to, T val)
        {
            for (int i = from; i < to; i++)
                a[i] = val;
        }
    }

	public static class Base36
	{
		private static readonly char[] CharList = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();

		public static String Encode(long input)
		{
			if (input < 0)
				throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");
			char[] clistarr = CharList;
			var result = new List<char>();
			while (input != 0)
			{
				result.Add(clistarr[input % 36]);
				input /= 36;
			}

			var len = result.Count;
			for (var i = 0; i < (3 - len); i++)
			{
				result.Insert(0, '0');
			}

			return new string(result.ToArray());
		}

		/// <summary>
		/// Decode the Base36 Encoded string into a number
		/// </summary>
		/// <param name = "input"></param>
		/// <returns></returns>
		public static Int64 Decode(string input)
		{
			var reversed = Reverse(input);
			long result = 0;
			int pos = 0;
			foreach (char c in reversed)
			{
				result += Array.IndexOf(CharList, c) * (long)Math.Pow(36, pos);
				pos++;
			}
			return result;
		}

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
