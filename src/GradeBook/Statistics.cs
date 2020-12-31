using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            average = 0.0;
            low = double.MaxValue;
            high = double.MinValue;
        }

        public void ComputeAverage(List<double> grades)
        {
            foreach(double grade in grades)
            {
                average += grade;
                low = Math.Min(low, grade);
                high = Math.Max(high, grade);
            }
            average = average / grades.Count;
            LetterGrade();
        }

        public void LetterGrade()
        {
            switch(average)
            {
                case double d when d >= 90.0:
                    Letter = 'A';
                    break;
                case double d when d >= 80.0:
                    Letter = 'B';
                    break;
                case double d when d >= 70.0:
                    Letter = 'C';
                    break;
                case double d when d >= 60.0:
                    Letter = 'D';
                    break;
                default:
                    Letter = 'F';
                    break;
                
            }
        }
        public double average;
        public double high;
        public double low;
        public char Letter;
    }
}