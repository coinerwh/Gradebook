using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Wil's Gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.89);

            double average = book.AverageGrade();
            double high = book.HighGrade();
            double low = book.LowestGrade();

            Console.WriteLine($"The average grade is {average}. The highest grade is {high}. The lowest grade is {low}");
        }
    }
}
