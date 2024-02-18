using System;
using System.Linq;

namespace Lab2CSharp {
    internal class Program {
        static void Main(string[] args) {
            int number = 1;

            while (number != 0) {
                Console.Write("Input task number [1-4], [0] to exit: ");

                try {
                    string? input = Console.ReadLine();

                    if (input != null) {
                        number = int.Parse(input);

                        switch (number) {
                            case 0:
                                return;

                            case 1:
                                task1(); // Testing task 1
                                break;

                            case 2:
                                task2(); // Testing task 2
                                break;

                            case 3:
                                task3(); // Testing task 3
                                break;

                            case 4:
                                task4(); // Testing task 4
                                break;

                            default:
                                break;
                        }
                    } else {
                        Console.WriteLine("Nothing provided. Exiting...");
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }

                Console.WriteLine();
            }
        }

        static void task1() {
            Console.WriteLine("|===~        Testing task 1.1        ~===|");
            try {
                int xSize = 0;
                int ySize = 0;
                // Array dimension
                Console.Write("Input array size X: ");
                string? input = Console.ReadLine();
                if (input != null) {
                    xSize = int.Parse(input);
                }

                Console.Write("Input array size Y: ");
                input = Console.ReadLine();
                if (input != null) {
                    ySize = int.Parse(input);
                }

                // Array initialization
                int[,] array = new int[ySize, xSize];


                // Array input
                for (int y = 0; y < ySize; y++) {
                    for (int x = 0; x < xSize; x++) {
                        Console.Write($"Input value [{y}][{x}] ");
                        input = Console.ReadLine();
                        if (input != null) {
                            array[y, x] = int.Parse(input);
                        }
                    }
                }

                // Threshold
                Console.Write("Input threshold number: ");
                int threshold = 0;
                input = Console.ReadLine();
                if (input != null) {
                    threshold = int.Parse(input);



                    for (int y = 0; y < ySize; y++) {
                        for (int x = 0; x < xSize; x++) {
                            if (array[y, x] < threshold) {
                                array[y, x] = threshold;
                            }
                        }
                    }
                }


                // Output 
                Console.WriteLine("Modified array:");
                for (int y = 0; y < ySize; y++) {
                    for (int x = 0; x < xSize; x++) {
                        Console.Write(array[y, x] + " ");
                    }
                    Console.WriteLine();
                }
            } catch (Exception e) {
                Console.WriteLine($"{e.Message}");
            }
        }

        static void task2() {
            Console.WriteLine("|===~        Testing task 2.1        ~===|");
            try {
                int xSize = 0;
                int ySize = 1;
                // Array dimension
                Console.Write("Input array size n: ");
                string? input = Console.ReadLine();
                if (input != null) {
                    xSize = int.Parse(input);
                }

                // Array initialization
                int[,] array = new int[ySize, xSize];

                // Array input
                for (int y = 0; y < ySize; y++) {
                    for (int x = 0; x < xSize; x++) {
                        Console.Write($"Input value [{x}] ");
                        input = Console.ReadLine();
                        if (input != null) {
                            array[y, x] = int.Parse(input);
                        }
                    }
                }

                // Min value
                int minValue = array[0, 0];
                for (int y = 0; y < ySize; y++) {
                    for (int x = 0; x < xSize; x++) {
                        if (array[y, x] < minValue) minValue = array[y, x];
                    }
                }
                Console.WriteLine("Minimum value: " + minValue);

                // Output 
                Console.WriteLine("Modified array:");
                for (int y = 0; y < ySize; y++) {
                    for (int x = 0; x < xSize; x++) {
                        if (array[y, x] == minValue) Console.WriteLine($"ID [{x}]: " + array[y, x]);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine($"{e.Message}");
            }
        }

        static void task3() {
            Console.WriteLine("|===~        Testing task 3.1        ~===|");
            try {
                int xSize = 0;
                // Array dimension
                Console.Write("Input array size n: ");
                string? input = Console.ReadLine();
                if (input != null) {
                    xSize = int.Parse(input);
                }

                // Array initialization
                int[,] array = new int[xSize, xSize];

                // Array input
                for (int y = 0; y < xSize; y++) {
                    for (int x = 0; x < xSize; x++) {
                        Console.Write($"Input value [{y},{x}]: ");
                        input = Console.ReadLine();
                        if (input != null) {
                            array[y, x] = int.Parse(input);
                        }
                    }
                }

                // Output 
                Console.WriteLine("Primary array:");
                for (int y = 0; y < xSize; y++) {
                    for (int x = 0; x < xSize; x++) {
                        Console.Write(array[y, x] + " ");
                    }
                    Console.WriteLine();
                }


                // Calculate sum and count of even elements below the main diagonal
                int sum = 0;
                int count = 0;
                int checkValue = xSize + xSize;
                if (xSize == 2) {
                    count = 1;
                    sum = array[1, 1];
                } else {
                    int correction = xSize % 2 == 0 ? 0 : 1;

                    for (int y = 0; y < xSize; y++) {
                        for (int x = 0; x < xSize; x++) {
                            if (x > y) {
                                sum += array[xSize - 1 - y, x];
                                count++;
                            }
                        }
                    }
                }

                // Calculate the arithmetic mean
                double average = count == 0 ? 0 : (double)sum / (double)count;

                // Output result
                Console.WriteLine("Arithmetic mean of even elements below the main diagonal: " + average);
            } catch (Exception e) {
                Console.WriteLine($"{e.Message}");
            }
        }

        static void task4() {
            Console.WriteLine("|===~        Testing task 4.1        ~===|");
            try {
                int xSize = 0;
                // Array dimension
                Console.Write("Input array size n: ");
                string? input = Console.ReadLine();
                if (input != null) {
                    xSize = int.Parse(input);
                }

                // array initialization
                int[][] jaggedArray = new int[xSize][];

                for (int i = 0; i < xSize; i++) {
                    jaggedArray[i] = new int[i + 1];
                }

                // Input
                for (int y = 0; y < xSize; y++) {
                    for (int x = 0; x < jaggedArray[y].Length; x++) {
                        Console.Write($"Input element [{y}][{x}]: ");
                        jaggedArray[y][x] = int.Parse(Console.ReadLine());
                    }
                }

                // Output 
                Console.WriteLine("Primary array:");
                for (int y = 0; y < xSize; y++) {
                    for (int x = 0; x < jaggedArray[y].Length; x++) {
                        Console.Write($"{jaggedArray[y][x]} ");
                    }
                    Console.WriteLine();
                }


                int[] minColumnValues = new int[xSize];
                for(int x = 0; x < xSize; x++) {
                    minColumnValues[x] = jaggedArray[x][x];
                }

                // Calculation 
                for (int y = 0; y < xSize; y++) {
                    for (int x = 0; x < jaggedArray[y].Length; x++) {
                        if (jaggedArray[y][x] < minColumnValues[x]) {
                            minColumnValues[x] = jaggedArray[y][x];
                        }
                    }
                }

                // Output
                Console.WriteLine("Min element in columns:");
                for (int x = 0; x < xSize; x++) {
                    Console.Write($"[{x}]: {minColumnValues[x]} ");
                }
                Console.WriteLine();


            } catch (Exception e) {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
