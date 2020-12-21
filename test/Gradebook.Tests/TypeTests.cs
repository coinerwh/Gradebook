using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            //string is immutable

            string name = "Scott";
            MakeUppercase(name);

            Assert.Equal(name, "Scott");
        }

        public void MakeUppercase(string parameter)
        {
            parameter.ToUpper();
        }

        [Fact]
        public void ValueType()
        {
            int x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int num)
        {
            num = 5;
        }

        public int GetInt()
        {
            return 3;
        }

        [Fact]
        public void PassByReference()
        {
           Book book1 = GetBook("Book 1");
           GetBookSetName(ref book1, "New name");

           Assert.Equal("New name", book1.Name);
        }

        public void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void PassByValue()
        {
           Book book1 = GetBook("Book 1");
           GetBookSetName(book1, "New name");

           Assert.Equal("Book 1", book1.Name);
        }

        public void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
           Book book1 = GetBook("Book 1");
           setName(book1, "New name");

           Assert.Equal("New name", book1.Name);
        }

        public void setName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void UniqueObject()
        {
           Book book1 = GetBook("Book 1");
           Book book2 = GetBook("Book 2");

           Assert.Equal("Book 1", book1.Name);
           Assert.Equal("Book 2", book2.Name);
           Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesSameObject()
        {
           Book book1 = GetBook("Book 1");
           Book book2 = book1;

           Assert.Same(book1, book2);
           Assert.True(Object.ReferenceEquals(book1, book2));
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
