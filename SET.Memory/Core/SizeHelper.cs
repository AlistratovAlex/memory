using System;

namespace SET.Memory.Core
{
	public static class SizeHelper
	{
		private const int byteInKilobyte = 1024;

		private static readonly string[] suffixes = new[] { "B", " KB", " MB", " GB", " TB", " PB" };

		public static string ToSize(double number, int precision = 2)
		{
			int i = 0;
			while (number > byteInKilobyte)
			{
				number /= byteInKilobyte;
				i++;
			}

			return Math.Round(number, precision) + suffixes[i];
		}
	}
}
