using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            Book book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(78.4);
            book.AddGrade(67.5);

            // act
            double average = book.AverageGrade();
            double  high = book.HighGrade();

            // assert
            Assert.Equal(89.1, high);
        }
    }
}
