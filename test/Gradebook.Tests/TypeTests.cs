using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
   
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        public string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        public string IncrementCount(string message)
        {
            count++;
            return message;
        }

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
           InMemoryBook book1 = GetBook("Book 1");
           GetBookSetName(ref book1, "New name");

           Assert.Equal("New name", book1.Name);
        }

        public void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void PassByValue()
        {
           InMemoryBook book1 = GetBook("Book 1");
           GetBookSetName(book1, "New name");

           Assert.Equal("Book 1", book1.Name);
        }

        public void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
           InMemoryBook book1 = GetBook("Book 1");
           setName(book1, "New name");

           Assert.Equal("New name", book1.Name);
        }

        public void setName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void UniqueObject()
        {
           InMemoryBook book1 = GetBook("Book 1");
           InMemoryBook book2 = GetBook("Book 2");

           Assert.Equal("Book 1", book1.Name);
           Assert.Equal("Book 2", book2.Name);
           Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesSameObject()
        {
           InMemoryBook book1 = GetBook("Book 1");
           InMemoryBook book2 = book1;

           Assert.Same(book1, book2);
           Assert.True(Object.ReferenceEquals(book1, book2));
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
