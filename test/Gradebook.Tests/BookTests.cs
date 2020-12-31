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
            InMemoryBook book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(78.4);
            book.AddGrade(67.5);

            // act
            Statistics stats = book.GetStatistics();

            // assert
            Assert.Equal(89.1, stats.high);
            Assert.Equal('C', stats.Letter);
        }

        [Fact]
        public void CheckAddGrade()
        {
            InMemoryBook book = new InMemoryBook("test");
            book.AddGrade(98.5);
            Assert.Equal(1, book.GetGrades().Count);
        }

        [Fact]
        public void CheckLetterGrade()
        {
            InMemoryBook book = new InMemoryBook("");
            book.AddGrade('A');
            Assert.Equal(100, book.GetGrades()[0]);
        }
    }
}
