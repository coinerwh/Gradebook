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
        }
    }
}
