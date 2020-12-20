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

            Statistics stats = book.Statistics();

            Console.WriteLine($"The average grade is {stats.average}. The highest grade is {stats.high}. The lowest grade is {stats.low}");
        }
    }
}
