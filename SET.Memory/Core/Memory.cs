using System;
using System.Runtime.InteropServices;

namespace SET.Memory.Core
{
	public static class Memory
	{
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

		private const int byteInKilobyte = 1024;

		public static long GetPhysicallyMemory()
		{
			GetPhysicallyInstalledSystemMemory(out long memBytes);

			return memBytes * byteInKilobyte;
		}

		public static long GetAvailableMemory()
		{
			int i = 1;
			int size = 100 * byteInKilobyte * byteInKilobyte; // 100 mb

			var td = GC.GetTotalMemory(false);

			try
			{
				while (true)
				{
					var mb = new long[size * i];
					i += 1;
				}
			}
			catch (OutOfMemoryException)
			{
				return GC.GetTotalMemory(false);
			}
		}

		public static ulong GetHeapMemory()
		{
			var hHeap = Heap.HeapCreate(Heap.HeapFlags.HEAP_GENERATE_EXCEPTIONS, 0, 0);

			uint nSize = 100 * byteInKilobyte * byteInKilobyte; // 100 mb
			ulong memorySize = 0;

			try
			{
				for (int i = 0; i < 1000; i++)
				{
					var ptr = Heap.HeapAlloc(hHeap, 0, nSize);

					memorySize += nSize;
				}
			}
			catch (OutOfMemoryException)
			{
				return memorySize;
			}

			Heap.HeapDestroy(hHeap);

			return memorySize;
		}
	}
}
