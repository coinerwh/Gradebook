using System;
using System.Collections.Generic;

namespace GradeBook 
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)}"); 
            }
        }

        public void AddGrade(char letter)
        {
            Dictionary<char, double> letterGrade = new Dictionary<char, double>
            {
                ['A'] = 100,
                ['B'] = 89,
                ['C'] = 79,
                ['D'] = 69,
                ['F'] = 59
            };
            grades.Add(letterGrade[letter]);
        }

        public event GradeAddedDelegate GradeAdded;
        public List<double> GetGrades()
        {
            return grades;
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

            switch(stats.average)
            {
                case double d when d >= 90.0:
                    stats.Letter = 'A';
                    break;
                case double d when d >= 80.0:
                    stats.Letter = 'B';
                    break;
                case double d when d >= 70.0:
                    stats.Letter = 'C';
                    break;
                case double d when d >= 60.0:
                    stats.Letter = 'D';
                    break;
                default:
                    stats.Letter = 'F';
                    break;
                
            }
            return stats;
        }

        private List<double> grades;

        private string name;
        readonly string category = "Science";
    }
}