using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ValidateConstructor()
        {
            Arena arena = new Arena();
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void ValidateEnrollMethod_AddCorrectlyToWarriors()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Trifon", 120, 120);
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void ValidateEnrollMethod_ThrowsExceptionWithEnrolledWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Trifon", 120, 120);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void ValidateWarriorsReadOnlyCollection()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Trifon", 120, 120);
            Warrior warrior1 = new Warrior("Tozi", 120, 120);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            Assert.AreEqual(arena.Count, arena.Warriors.Count);
        }

        [Test]
        public void ValidateFightMethod_ReturnCorrectlyData()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Trifon", 119, 120);
            Warrior warrior1 = new Warrior("Tozi", 60, 120);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            arena.Fight("Trifon", "Tozi");
            Assert.AreEqual(1, warrior1.HP);
        }

        [Test]
        public void ValidateFightMethod_ThrowExceptionWithNullAttacker()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Trifon", 119, 120);
            Warrior warrior1 = new Warrior("Tozi", 60, 120);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Trifonov", "Tozi"));
        }

        [Test]
        public void ValidateFightMethod_ThrowExceptionWithNullDefender()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Trifon", 119, 120);
            Warrior warrior1 = new Warrior("Tozi", 60, 120);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Trifon", "Todorov"));
        }
    }
}
