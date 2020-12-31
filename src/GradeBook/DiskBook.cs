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
            throw new NotImplementedException();
        }

        public override void AddGrade(double grade)
        {
            using (StreamWriter w = File.AppendText($"{Name}.txt"))
            {
                w.WriteLine(grade);
            }
        }

    }

    
}