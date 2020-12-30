using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Wil's Gradebook");
            book.GradeAdded += OnGradeAdded;

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
                    // ...
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

            System.Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.average}. The highest grade is {stats.high}. The lowest grade is {stats.low}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}
