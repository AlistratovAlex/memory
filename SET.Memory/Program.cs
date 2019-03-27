using SET.Memory.Core;
using System;

namespace SET.Memory
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Choose one of options:");
				Console.WriteLine("1 - Get Physically installed system memory");
				Console.WriteLine("2 - Amount of available memory to allocate");
				Console.WriteLine("3 - Max size of single block available in heap to allocate");
				Console.WriteLine("4 - Compare memory");
				Console.WriteLine("5 - Clear screen");
				Console.WriteLine("6 - Close app");
				Console.WriteLine();

				string answer = Console.ReadLine();

				switch (answer)
				{

					case "1":
						long physicallyMemorySize = Core.Memory.GetPhysicallyMemory();
						Console.WriteLine($"Physically installed system memory: { SizeHelper.ToSize(physicallyMemorySize, 2)} \n");
						break;
					case "2":
						long availableMemory = Core.Memory.GetAvailableMemory();
						Console.WriteLine($"Amount of max sizee memory,allocated for the associated process: {SizeHelper.ToSize(availableMemory, 2)}\n");
						break;
					case "3":
						ulong heapMemorySize = Core.Memory.GetHeapMemory();
						Console.WriteLine($"Max size of single block available in heap to allocate: {SizeHelper.ToSize(heapMemorySize)} \n");
						break;
					case "4":
						physicallyMemorySize = Core.Memory.GetPhysicallyMemory();
						availableMemory = Core.Memory.GetAvailableMemory();
						heapMemorySize = Core.Memory.GetHeapMemory();

						Console.WriteLine($"Physically memmory: {SizeHelper.ToSize(physicallyMemorySize)}");
						Console.WriteLine($"Available memmory: {SizeHelper.ToSize(availableMemory)}");
						Console.WriteLine($"Heap memmory: {SizeHelper.ToSize(heapMemorySize)} \n");
						break;
					case "5":
						Console.Clear();
						break;
					case "6":
						Environment.Exit(0);
						break;
					default:
						break;
				}
			}
		}
	}
}
