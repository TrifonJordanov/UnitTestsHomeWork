using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void ValidateConstructor()
        {
            Person person = new Person(123, "Trifon");
            Database database = new Database(new[]
            {
                new Person(123, "Trifon"),
                new Person(321, "Tozi")
            });

            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void ValidateConstructorWithInvalidCount()
        {
            Assert.Throws<ArgumentException>(() => new Database(new[]
            {
                new Person(123, "Trifon"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
                new Person(321, "Tozi"),
            }));
        }
        [Test]
        public void ValidateAddMethod_AddCorrectly()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database(new[]
            {
                new Person(123, "Trifon"),
                new Person(321, "Tozi")
            });
            databases.Add(new Person(222, "Onzi"));
            Assert.AreEqual(3, databases.Count);
        }

        [Test]
        public void ValidateAddMethod_ThrowsExceptionWithNotEnoughCapacity()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database(new[]
            {
                new Person(3211, "Tozi1"),
                new Person(3212, "Tozi2"),
                new Person(3213, "Tozi3"),
                new Person(3214, "Tozi4"),
                new Person(3215, "Tozi5"),
                new Person(3216, "Tozi6"),
                new Person(3217, "Tozi7"),
                new Person(3218, "Tozi8"),
                new Person(3219, "Tozi9"),
                new Person(3210, "Tozi0"),
                new Person(32111, "Tozi10"),
                new Person(32112, "Tozi11"),
                new Person(32113, "Tozi12"),
                new Person(32114, "Tozi13"),
                new Person(32115, "Tozi14"),
                new Person(32116, "Tozi15"),
            });

            Assert.Throws<InvalidOperationException>((() => databases.Add(new Person(222, "Onzi"))));
        }

        [Test]
        public void ValidateAddMethod_ThrowsExceptionWithSameIdOfPerson()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database(new[]
            {
                new Person(3211, "Tozi1"),
                new Person(3212, "Tozi2"),
            });

            Assert.Throws<InvalidOperationException>((() => databases.Add(new Person(3211, "Onzi"))));
        }

        [Test]
        public void ValidateAddMethod_ThrowsExceptionWithSameNameOfPerson()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database(new[]
            {
                new Person(3211, "Tozi1"),
                new Person(3212, "Tozi2"),
            });

            Assert.Throws<InvalidOperationException>((() => databases.Add(new Person(3222211, "Tozi1"))));
        }

        [Test]
        public void ValidateRemoveMethod_ThrowsExceptionWithZeroCount()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            Assert.Throws<InvalidOperationException>((() => databases.Remove()));
        }

        [Test]
        public void ValidateRemoveMethod_RemoveCorrectly()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            databases.Add(person);
            databases.Remove();
            Assert.AreEqual(0, databases.Count);
        }

        [Test]
        public void ValidateFindByName_ReturnCorrectlyData()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            databases.Add(person);
            var personToFind = databases.FindByUsername("Trifon");
            Assert.AreSame(person, personToFind);
        }


        [Test]
        public void ValidateFindByNameMethodThrowsExceptionWithNullUsername()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            databases.Add(person);
            Assert.Throws<ArgumentNullException>(()=> databases.FindByUsername(null));
        }

        [Test]
        public void ValidateFindByNameMethodThrowsExceptionWithNonExistingUser()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            databases.Add(person);
            Assert.Throws<InvalidOperationException>(() => databases.FindByUsername("Tozi"));
        }

        [Test]
        public void ValidateFindByIdMethodThrowsExceptionWithNonExistingUser()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            databases.Add(person);
            Assert.Throws<InvalidOperationException>(() => databases.FindById(321));
        }

        [Test]
        public void ValidateFindByIdMethodThrowsExceptionWithNegativeNumber()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            databases.Add(person);
            Assert.Throws<ArgumentOutOfRangeException>(() => databases.FindById(-1));
        }


        [Test]
        public void ValidateFindByIdMethodReturnCorrectlyData()
        {
            Person person = new Person(123, "Trifon");
            Database databases = new Database();
            databases.Add(person);
            var personToFind = databases.FindById(123);
            Assert.AreSame(person, personToFind);
        }
    }
}