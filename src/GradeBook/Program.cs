using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Wil's Gradebook");

            while(true)
            {
                System.Console.WriteLine("Please enter a grade or input 'q' to quit: ");
                string input = Console.ReadLine();
                if(input == "q")
                {
                    break;
                }
                try
                {
                    double grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }

            Statistics stats = book.Statistics();

            Console.WriteLine($"The average grade is {stats.average}. The highest grade is {stats.high}. The lowest grade is {stats.low}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
