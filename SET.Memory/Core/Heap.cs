using System;
using System.Runtime.InteropServices;

namespace SET.Memory.Core
{
	public static class Heap
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr HeapCreate(HeapFlags flOptions, uint dwInitialsize, uint dwMaximumSize);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr HeapAlloc(IntPtr hHeap, HeapFlags dwFlags, uint dwSize);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool HeapDestroy(IntPtr hHeap);

		[Flags()]
		public enum HeapFlags
		{

			HEAP_NO_SERIALIZE = 0x1,
			HEAP_GENERATE_EXCEPTIONS = 0x4,
			HEAP_ZERO_MEMORY = 0x8
		}
	}
}
