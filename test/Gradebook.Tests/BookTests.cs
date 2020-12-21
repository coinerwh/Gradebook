using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            //arrange
            Book book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(78.4);
            book.AddGrade(67.5);

            // act
            Statistics stats = book.Statistics();

            // assert
            Assert.Equal(89.1, stats.high);
            Assert.Equal('C', stats.Letter);
        }

        [Fact]
        public void CheckAddGrade()
        {
            Book book = new Book("test");
            book.AddGrade(100.5);
            Assert.Equal(0, book.GetGrades().Count);
        }

        [Fact]
        public void CheckLetterGrade()
        {
            Book book = new Book("");
            book.AddGrade('A');
            Assert.Equal(100, book.GetGrades()[0]);
        }
    }
}
