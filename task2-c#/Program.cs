using System;
using System.Collections.Generic;
using System.Drawing;

namespace task2_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char option;
            int number, range,temp,maxNum,minNum,count=0;
            double average = 0;
            List<int> numbers = new List<int>();
            
            Console.WriteLine("Please choose one option\nP- print numbers \nA- Add a number\nD-Display the numbers sorted\nF- Find a specific number");
            Console.WriteLine("M- Display mean of the numbers\nS- Display the smallest number\nL- Display the largest number\nC- Clear the list\nQ- Quit");
            option = char.Parse(Console.ReadLine().ToLower());
            
            do {
                List<int> Sortednumbers = new List<int>();
                Sortednumbers = new List<int>(numbers);
                if (option == 'p')
                {
                    if (numbers.Count() == 0)
                        Console.WriteLine(" []-List is empty");
                    else
                    {
                        Console.Write("the numbers are: [");
                        for (int i = 0; i < numbers.Count(); i++)
                        {
                            Console.Write($" {numbers[i]} ");
                        }
                        Console.WriteLine("]");

                    }
                    Console.WriteLine("===========================================");

                }
                else if (option == 'd')
                {
                    if (Sortednumbers.Count() == 0)
                        Console.WriteLine(" []-List is empty");
                    else
                    {
                        for (int i = 0; i < Sortednumbers.Count() - 1; i++)
                        {
                            for (int j = 0; j < Sortednumbers.Count() - 1; j++)
                            {
                                if (Sortednumbers[j] > Sortednumbers[j + 1])
                                {
                                    temp = Sortednumbers[j + 1];
                                    Sortednumbers[j + 1] = Sortednumbers[j];
                                    Sortednumbers[j] = temp;
                                }
                            }
                        }
                        Console.Write("the Sorted numbers are: [");
                        for (int i = 0; i < Sortednumbers.Count(); i++)
                        {
                            Console.Write($" {Sortednumbers[i]} ");
                        }
                        Console.WriteLine("]");

                       
                    }
                    Console.WriteLine("===========================================");

                }
                else if (option == 'a')
                {
                 
                    Console.WriteLine("How many numbers do you need to add ?");
                    range = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Please add {range} numbers");
                    for (int i = 0; i < range; i++)
                    {
                        number = int.Parse(Console.ReadLine());
                        numbers.Add(number);
                        
                    }

                    for (int i = 0; i < range; i++)
                    {

                        Console.Write($" {numbers[i]} ");
                    }
                    Console.WriteLine(" added");
                    Console.WriteLine("===========================================");
                }
                else if (option == 'm')
                {
                    if (numbers.Count() == 0)
                        Console.WriteLine("Unable to calculate the mean - no data");
                    else
                    {
                        double sum = 0;
                        for (int i = 0; i < numbers.Count(); i++)
                        {
                            sum += numbers[i];
                        }
                        average = sum / numbers.Count();
                        Console.WriteLine($"The average of the elements : {average}");
                        Console.WriteLine("===========================================");

                    }

                }
                else if (option == 's')
                {
                    if (numbers.Count() == 0)
                        Console.WriteLine("Unable to determine the smallest number - List is empty");
                    else
                    {
                        minNum = numbers[0];
                        for (int i = 0; i < numbers.Count(); i++)
                        {
                            if (numbers[i] < minNum)
                                minNum = numbers[i];

                        }
                        Console.WriteLine($"The smallest value is: {minNum}");
                        Console.WriteLine("===========================================");
                    }
                    
                }
                else if (option == 'l')
                {
                    if (numbers.Count() == 0)
                        Console.WriteLine("Unable to determine the smallest number - List is empty");
                    else
                    {
                        maxNum = numbers[0];
                        for (int i = 0; i < numbers.Count(); i++)
                        {
                            if (numbers[i] > maxNum)
                                maxNum = numbers[i];

                        }
                        Console.WriteLine($"The largest value is: {maxNum}");
                        Console.WriteLine("===========================================");
                    }
                    
                }
                else if (option == 'f')
                {
                    if (numbers.Count() == 0)
                        Console.WriteLine(" []-List is empty -no data");
                    else
                    {
                        Console.Write("Search for a specific number: ");
                        number = int.Parse(Console.ReadLine());
                        for (int i = 0; i < numbers.Count(); i++)
                        {
                            if (numbers[i] == number)
                            {
                                Console.WriteLine($"Number found at index {i}");
                                count++;
                                
                            }

                        }
                        if(count==0)
                            Console.WriteLine("Number couldnot found");


                        Console.WriteLine("===========================================");
                    }


                }
                else if (option == 'c')
                {
                    numbers.Clear();
                    Console.WriteLine("All elements are cleared - List is empty");
                    Console.WriteLine("===========================================");

                }
                else if (option == 'q')
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
                else
                {
                    Console.WriteLine("unknown selection , please try again later");
                    Console.WriteLine("===========================================");
                }

                Console.WriteLine("Please choose one option");
                Console.WriteLine("===========================================");
                Console.WriteLine("P- print numbers \nA- Add a number \nD-Display the numbers sorted \nF- Find a specific number");
                Console.WriteLine("M- Display mean of the numbers\nS- Display the smallest number\nL- Display the largest number\nC- Clear the list\nQ- Quit");
                option = char.Parse(Console.ReadLine().ToLower());

            } while (true);
        }
    }
}
