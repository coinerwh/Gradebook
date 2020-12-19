using System;
using System.Collections.Generic;

namespace GradeBook 
{
    public class Book {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double num)
        {
            this.grades.Add(num);
        }

        public double AverageGrade()
        {
            double sum = 0;
            foreach(double grade in this.grades)
            {
                sum += grade;
            }
            return sum / this.grades.Count;
        }

        public double LowestGrade()
        {
            double low = double.MaxValue;
            foreach(double grade in this.grades)
            {
                low = Math.Min(low, grade);
            }
            return low;
        }

        public double HighGrade() 
        {
            double high = double.MinValue;
            foreach(double grade in this.grades)
            {
                high = Math.Max(high, grade);
            }
            return high;
        }

        private List<double> grades;
        private string name;
    }
}