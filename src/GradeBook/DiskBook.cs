using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            List<double> grades = CreateGradeList();
            stats.ComputeAverage(grades);
            
            return stats;
        }

        public List<double> CreateGradeList()
        {
            var gradeFile = File.ReadAllLines($"{Name}.txt");
            List<double> grades = new List<double>();
            foreach(string sGrade in gradeFile)
            {
                double grade = double.Parse(sGrade);
                grades.Add(grade);
            }
            return grades;
        }

        public override void AddGrade(double grade)
        {
            using (StreamWriter w = File.AppendText($"{Name}.txt"))
            {
                w.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
    }
}