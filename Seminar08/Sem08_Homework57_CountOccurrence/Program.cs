﻿// Task: Create a program which counts how many times each element of 2D array occurs in this array.

int m = Convert.ToInt32(new Random().Next(2, 11)); // Randomly select how many rows will be in array within specified range
int n = Convert.ToInt32(new Random().Next(2, 11)); //Randomly select how many columns will be in array within specified range
Console.WriteLine();

int[,] array = new int[m, n];

void FillPrint2DArray(int[,] arr, int randomMin, int randomMax) // Randomly fill out 2D array with integers and print it to the terminal
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new Random().Next(randomMin, randomMax);
            Console.Write("{0,4}", arr[i, j]);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    Console.WriteLine();
}

void CountOccurrence(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++) // Going through array to perform needed work
    {
        for (int j = 0; j < arr.GetLength(1);)
        {
            int repeat = arr[i, j];
            int count = 0;

            for (int i1 = 0; i1 < arr.GetLength(0); i1++) // Comparing current element with previous elements to check if it repeats
            {
                for (int j1 = 0; j1 < arr.GetLength(1); j1++)
                {
                    // If numbers match before index i, j equals to i1, j1. I.e. NOT the first appearance.
                    // Then skip further checks and counting - counting for this number was already done before.
                    if ((arr[i1, j1] == repeat) && (((i1 != i) || (j1 != j)) || ((i1 != i) && (j1 != j))))
                    {
                        goto Skip;
                    }
                    // If numbers match only when index i, j equals to i1, j1. I.e. IS the first appearance.
                    // Then need to count how many times this number appears in the array.
                    else if ((arr[i1, j1] == repeat) && ((i1 == i) && (j1 == j)))
                    {
                        for (int i2 = 0; i2 < arr.GetLength(0); i2++) // Counting how many times a number repeats in the array
                        {
                            for (int j2 = 0; j2 < arr.GetLength(1); j2++)
                            {
                                if (arr[i2, j2] == repeat)
                                {
                                    count++;
                                }
                            }
                        }
                        Console.WriteLine($"Number {arr[i, j]} appears {count} times in this array.");
                    }
                }
            }
        Skip: //Skip to comparison and counting of next element of the array
            j++;
        }
    }
    Console.WriteLine();
}

FillPrint2DArray(array, randomMin: 1, randomMax: 5); // Array will be filled up with numbers from 1 to 4
CountOccurrence(array);

