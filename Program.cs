using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// Main class.
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// The array of running times.
        /// </summary>
        static double[] eff = new double[6];
        /// <summary>
        /// the array of memory usages
        /// </summary>
        static long[] mem = new long[6];

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            // User enter the length of the array.
            Console.Write("Eneter the length of the array: ");
            // Converts the input into an integer.
            int length = Convert.ToInt32(Console.ReadLine());

            Random rand = new Random();
            // New array of length entered by the user.
            int[] a = new int[length];

            // Genereates the array with random numbers between -1000 and 1000.
            for (int i = 0; i < length; i++)
            {
                a[i] = rand.Next(-1000, 1000);
            }

            // Prints the generated array.
            Console.WriteLine("\nGiven Array");
            printArray(a);

            // The id guide of the sorting algorithms from 1-5 and 6 as "all".
            Console.WriteLine("\nSelect the sorting algorithm you want to use: " + 
"\n1 - BubbleSort \n2 - InsertionSort \n3 - QuickSort \n4 - HeapSort \n5 - MergeSort \n6 - All");
            Console.WriteLine();

            // User enters the command of the sorting algorithms he/she wants to run.
            // The input is stored as a String.
            String input = Console.ReadLine();

            // Another array is declared to act as a container for a copy of the original one.
            int[] b = new int[length];

            // The input 6 is replaced with 1-5 to run all the cases.
            if (input == "6") input = "1-5";

            if(input.Contains("-")) 
            {
                // All the spaces are deleted.
                input = input.Replace(" ", String.Empty);

                //The starting point and the ending point are determined.
                int s1 = Convert.ToInt32(input[0]) - 48;
                int s2 = Convert.ToInt32(input[2]) - 48;

                // Iterates over the indices of wanter algorithms.
                for (int i = s1; i <= s2; i++)
                {
                    // Copies the original array into the container array.
                    for (int j = 0; j < length; j++)
                    {
                        b[j] = a[j];
                    }

                    // Sorts the container array with the algotithm that has index i.
                    sort(b, i);
                }
            } else if(input.Contains(","))
            {
                // Deletes all the spaces and commas.
                input = input.Replace(" ", String.Empty);
                input = input.Replace(",", String.Empty);

                // Measures the size of the imput and iterates over its elements. 
                int k = input.Length;
                for (int i = 0; i < k; i++)
                {
                    // Copies the original array into the container array.
                    for (int f = 0; f < length; f++)
                    {
                        b[f] = a[f];
                    }

                    // Converts the element into an integer.
                    int j = Convert.ToInt32(input[i]) - 48;

                    // Sorts the container array with the algorithm of index j.
                    sort(b, j);
                }
            } else // This is the case when jus an integer is entered.
            {
                // Gets the integer value of the inputed String.
                int j = Convert.ToInt32(input);

                // Sorts the container array with the algorithm of index j.
                sort(a, j);
            }

            // Prints the results.
            printResults();

        }


        /// <summary>
        /// Sort the specified array with the algorithm of index i.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="a">The array of integers.</param>
        /// <param name="i">The index of the algorithm.</param>
        static void sort(int[] a, int i)
        {
            switch (i)
            {
                // Bubble Sort.
                case 1:
                    // Stores the memory allocated at the moment.
                    var mem1 = GC.GetTotalMemory(false);

                    // Starts a new stopwatch.
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    // Calls the Bubble Sort algorithm.
                    BubbleSort.sort(a);

                    // Stops the stopwatch.
                    watch.Stop();

                    // Gets the memory allocated at the moment and sumtracts the 
                    // older one to get the memory used in the intermediate process.
                    var mem2 = GC.GetTotalMemory(false) - mem1;

                    // Writes the memory usage in the index of its algorithm in the memory array.
                    MainClass.mem[i] = mem2;

                    // Gets the value of the stopwatch and stores itin the running time array.
                    double time = watch.ElapsedTicks; 
                    MainClass.eff[i] = time;
                    break;

                    // Similarly the other cases.
                case 2:
                    mem1 = GC.GetTotalMemory(false);
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    InsertSort.sort(a);
                    watch.Stop();
                    mem2 = GC.GetTotalMemory(false) - mem1;
                    MainClass.mem[i] = mem2;
                    time = watch.ElapsedTicks;
                    MainClass.eff[i] = time;
                    break;
                case 3:
                    mem1 = GC.GetTotalMemory(false);
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    QuickSort.sort(a);
                    watch.Stop();
                    mem2 = GC.GetTotalMemory(false) - mem1;
                    MainClass.mem[i] = mem2;
                    time = watch.ElapsedTicks;
                    MainClass.eff[i] = time;
                    break;
                case 4:
                    mem1 = GC.GetTotalMemory(false);
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    HeapSort.sort(a);
                    watch.Stop();
                    mem2 = GC.GetTotalMemory(false) - mem1;
                    MainClass.mem[i] = mem2;
                    time = watch.ElapsedTicks;
                    MainClass.eff[i] = time;
                    break;
                case 5:
                    mem1 = GC.GetTotalMemory(false);
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    MergeSort.sort(a);
                    watch.Stop();
                    mem2 = GC.GetTotalMemory(false) - mem1;
                    MainClass.mem[i] = mem2;
                    time = watch.ElapsedTicks;
                    MainClass.eff[i] = time;
                    break;
            }

        }

        /// <summary>
        /// Prints the array given as an input.
        /// </summary>
        /// <param name="a">The array.</param>
        static void printArray(int[] a)
        {
            int n = a.Length;

            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
            
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the results.
        /// </summary>
        static void printResults() 
        {
            double min = 100000000;

            // Finds the minimal running time and puts it in a variable named min.
            for (int i = 1; i < 6; i++)
            {
                var time = MainClass.eff[i];
                if (time != 0 && min > time) 
                {
                    min = time;
                }

            }

            // Puts the text color in console green and prints the properties 
            // of the algorithm that was under the index of min.
            Console.ForegroundColor = ConsoleColor.Green;
            printAlgoProps(Array.IndexOf(eff, min));

            // Puts the text color in console back to black and prints the properties 
            // of the rest of the algorithms.
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 1; i < 6; i++)
            {
                var time = MainClass.eff[i];
                if (time > min) printAlgoProps(i);;
            }
        }

        /// <summary>
        /// Prints the algorithm properties.
        /// </summary>
        /// <param name="i">The index of the algorithm.</param>
        static void printAlgoProps(int i) 
        {
            switch(i)
            {
                case 1:
                    // The name of the algorithm.
                    Console.WriteLine("\nBubble Sort\n");

                    // Calls the function that writes.
                    write(i);
                    break;

                    // Similarly the other cases.
                case 2:
                    Console.WriteLine("\nInsertion Sort\n");
                    write(i);
                    break;
                case 3:
                    Console.WriteLine("\nQuick Sort\n");
                    write(i);
                    break;
                case 4:
                    Console.WriteLine("\nHeap Sort\n");
                    write(i);
                    break;
                case 5:
                    Console.WriteLine("\nMerge Sort\n");
                    write(i);
                    break;
            }
        }

        /// <summary>
        /// Write the properties of the specified algorithm with index i.
        /// </summary>
        /// <returns>The written properties.</returns>
        /// <param name="i">The index of the algorithm.</param>
        static void write(int i)
        {
            // The running time.
            Console.WriteLine("Running Time:" + eff[i] + "\n");
            //The Memory usage.
            Console.WriteLine("Memory Usage:" + mem[i] + "\n");
        }
    }
}

