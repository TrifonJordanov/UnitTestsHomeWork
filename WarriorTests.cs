using System;
using System.Security.Cryptography;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ValidateConstructor()
        {
            Warrior warrior = new Warrior("Trifon", 120, 120);
            Assert.AreEqual("Trifon", warrior.Name);
            Assert.AreEqual(120, warrior.Damage);
            Assert.AreEqual(120, warrior.HP);
        }

        [Test]
        public void ValidateNameProperty_ThrowExceptionWithNullValue()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 120, 120));
        }

        [Test]
        public void ValidateNameProperty_ThrowExceptionWithWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 120, 120));
        }

        [Test]
        public void ValidateDamageProperty_ThrowExceptionWithDmgEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Trifon", 0, 120));
        }


        [Test]
        public void ValidateDamageProperty_ThrowExceptionWithDmgBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Trifon", -1, 120));
        }

        [Test]
        public void ValidateHpProperty_SetCorrectlyHpValue()
        {
            Warrior warrior = new Warrior("Trifon", 120, 120);
            Assert.AreEqual(120, warrior.HP);
        }

        [Test]
        public void ValidateHpProperty_ThrowExceptionWithHpBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Trifon", 1, -1));
        }

        [Test]
        public void ValidateAttackMethod_ThrowsExceptionWithNotEnoughHpToAttack()
        {
            Warrior warrior = new Warrior("Trifon", 120, 29);
            Warrior warriorToAtack = new Warrior("Tozi", 120, 120);
            Assert.Throws<InvalidOperationException>((() => warrior.Attack(warriorToAtack)));
        }

        [Test]
        public void ValidateAttackMethod_ThrowsExceptionWithHpEqualToConst()
        {
            Warrior warrior = new Warrior("Trifon", 120, 30);
            Warrior warriorToAtack = new Warrior("Tozi", 120, 120);
            Assert.Throws<InvalidOperationException>((() => warrior.Attack(warriorToAtack)));
        }

        [Test]
        public void ValidateAttackMethod_ThrowsExceptionWithHpEqualToConstOfAttackedWarrior()
        {
            Warrior warrior = new Warrior("Trifon", 120, 120);
            Warrior warriorToAtack = new Warrior("Tozi", 120, 30);
            Assert.Throws<InvalidOperationException>((() => warrior.Attack(warriorToAtack)));
        }

        [Test]
        public void ValidateAttackMethod_ThrowsExceptionWithNotEnoughHpOfAttackedWarrior()
        {
            Warrior warrior = new Warrior("Trifon", 120, 120);
            Warrior warriorToAtack = new Warrior("Tozi", 120, 29);
            Assert.Throws<InvalidOperationException>((() => warrior.Attack(warriorToAtack)));
        }

        [Test]
        public void ValidateAttackMethod_WithHpBellowAttackedWarriorDmg()
        {
            Warrior warrior = new Warrior("Trifon", 120, 120);
            Warrior warriorToAtack = new Warrior("Tozi", 121, 120);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warriorToAtack));
        }

        [Test]
        public void ValidateAttackMethod_ReturnCorrectlyWarriorHp()
        {
            Warrior warrior = new Warrior("Trifon", 120, 120);
            Warrior warriorToAtack = new Warrior("Tozi", 60, 120);
            warrior.Attack(warriorToAtack);
            Assert.AreEqual(60, warrior.HP);
        }

        [Test]
        public void ValidateAttackMethod_ReturnCorrectlyAttackedWarriorHpWithDmgMoreThanHp()
        {
            Warrior warrior = new Warrior("Trifon", 121, 120);
            Warrior warriorToAtack = new Warrior("Tozi", 60, 120);
            warrior.Attack(warriorToAtack);
            Assert.AreEqual(0, warriorToAtack.HP);
        }

        [Test]
        public void ValidateAttackMethod_ReturnCorrectlyAttackedWarriorHpWithDmgSmallerThanHp()
        {
            Warrior warrior = new Warrior("Trifon", 119, 120);
            Warrior warriorToAtack = new Warrior("Tozi", 60, 120);
            warrior.Attack(warriorToAtack);
            Assert.AreEqual(1, warriorToAtack.HP);
        }
    }
}