using System;
using System.Collections.Generic;

namespace GradeBook 
{
    public class Book 
    {
        public string Name;
        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        }
        public void AddGrade(double num)
        {
            this.grades.Add(num);
        }

        public Statistics Statistics()
        {
            Statistics stats = new Statistics();
            double sum = 0;
            stats.low = double.MaxValue;
            stats.high = double.MinValue;
            foreach(double grade in this.grades)
            {
                sum += grade;
                stats.low = Math.Min(stats.low, grade);
                stats.high = Math.Max(stats.high, grade);
            }
            stats.average = sum / grades.Count;
            return stats;
        }

        private List<double> grades;
    }
}