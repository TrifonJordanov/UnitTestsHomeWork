using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void ValidateConstructor()
        {
            Database dataBase = new Database(new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
            });
            Assert.AreEqual(16, dataBase.Count);
        }

        [Test]
        public void ValidateAddMethodAddCorrectly()
        {
            Database dataBase = new Database(new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
            });
            dataBase.Add(15);
            Assert.AreEqual(15, dataBase.Count);
        }

        [Test]
        public void ValidateAddMethodThrowsExceptionWithMoreThan16Digits()
        {
            Database dataBase = new Database(new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
            });

            Assert.Throws<InvalidOperationException>(() => dataBase.Add(17));
        }

        [Test]
        public void ValidateRemoveMethodRemoveCorrectly()
        {
            Database dataBase = new Database(new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
            });

            dataBase.Remove();
            Assert.AreEqual(15, dataBase.Count);
        }


        [Test]
        public void ValidateRemoveMethodThrowsException()
        {
            Database dataBase = new Database(new int[]
            {

            });


            Assert.Throws<InvalidOperationException>(() => dataBase.Remove(), "The collection is empty!");
        }

        [Test]
        public void ValidateFetchMethodReturnCorrectly()
        {
            Database dataBase = new Database(new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
            });

            var array = dataBase.Fetch();
            Assert.AreEqual(dataBase.Count, array.Length);
        }
    }
}
