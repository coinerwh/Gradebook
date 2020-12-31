using System;
using System.Collections.Generic;

namespace GradeBook 
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade)
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

        public override event GradeAddedDelegate GradeAdded;
        public List<double> GetGrades()
        {
            return grades;
        }

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            stats.ComputeAverage(grades);
            return stats;
        }

        private List<double> grades;
    }
}