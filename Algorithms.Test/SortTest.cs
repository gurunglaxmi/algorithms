using Xunit;

namespace Algorithms.Test
{
    public class SortTest
    {
        [Fact]
        public void Sorting_5_Elements_Is_Sorted_AscendingOrder()
        {
            // Arrange
            int[] testArray = new [] { 4, 8, 8, 9, 6, 2 };

            // Act
            testArray.QuickSort();

            //Assert
            Assert.Equal(6, testArray.Length);
            Assert.Equal(2, testArray[0]);
        }

        [Fact]
        public void Sorting_Collection_By_Heights_ASC()
        {
            //Arrage
            var testData = new[] {new MyObject("James", 18, 6.11), new MyObject("Susan", 25, 5.11), new MyObject("Jake", 35, 4.11),
                new MyObject("Jill", 28, 2.11), new MyObject("Kat", 21, 5.11)};

            // Act
            testData.QuickSort((a, b) => {
                var result = a.Height.CompareTo(b.Height);
                if (result == 0)
                {
                    return a.Name.CompareTo(b.Name);
                }
                return result;                
            });

            // Assert
            Assert.Equal(5, testData.Length);
            Assert.Equal("Susan", testData[3].Name);
        }

        [Fact]
        public void Sorting_Collection_By_Heights_DESC()
        {
            //Arrage
            var testData = new[] {new MyObject("James", 18, 6.11), new MyObject("Susan", 25, 5.11), new MyObject("Jake", 35, 4.11),
                new MyObject("Jill", 28, 2.11), new MyObject("Kat", 21, 5.11)};

            // Act
            testData.QuickSort((a, b) => {
                var result = b.Height.CompareTo(a.Height);
                if (result == 0)
                {
                    return a.Name.CompareTo(b.Name);
                }
                return result;
            });

            // Assert
            Assert.Equal(5, testData.Length);
            Assert.Equal("Kat", testData[1].Name);
        }

        [Fact]
        public void Sorting_Already_Sorted_List_Does_Not_Change_Sorting_Order()
        {
            // Arrage
            int[] testData = new[] { 2, 5, 6, 9, 10, 15 };

            // Act
            testData.QuickSort();

            // Assert
            Assert.Equal(10, testData[4]);
        }

        private class MyObject
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public double Height { get; set; }

            public MyObject(string name, int age, double height)
            {
                Name = name;
                Age = age;
                Height = height;
            }
        }
    }    
}
