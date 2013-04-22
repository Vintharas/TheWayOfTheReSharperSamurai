using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Katas.Tests
{
    [TestFixture]
    public class Class1Tests
    {

        [Test]
        public void CalculateDamage_WhenTheDieRollIs0_ShouldNotDoAnyDamage()
        {
            // Arrange
            var sword = new Weapon{Damage = 100};
            IEnumerable<Armor> armor = new List<Armor>{new Armor { Defence = 10}};
            var die = new Mock<IDie>();
            die.Setup(d => d.Roll()).Returns(0);
            var damageCalculator = GetDamageCalculator(die.Object);
            // Act
            var damage = damageCalculator.CalculateDamage(sword, armor);
            // Assert
            Assert.That(damage, Is.EqualTo(0));
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(24)]
        public void CalculateDamage_WhenTheDieRollIsBelow25_ShouldCalculateTheDamageForAPenalizedAttack(int dieRoll)
        {
            // Arrange
            var sword = new Weapon {Name = "Sword of Might", Damage = 100};
            var helmet = new Armor {Name = "Bronze Helmet", Defence = 10};
            var breastplate = new Armor {Name = "Bronze Breastplate", Defence = 20};
            var armor = new List<Armor>{helmet, breastplate};
            var die = new Mock<IDie>();
            die.Setup(d => d.Roll()).Returns(dieRoll);
            var damageCalculator = GetDamageCalculator(die.Object);
            // Act
            var damage = damageCalculator.CalculateDamage(sword, armor);
            // Assert
            Assert.That(damage, Is.EqualTo(20));
        }

        [TestCase(25)]
        [TestCase(50)]
        [TestCase(74)]
        public void CalculateDamage_WhenTheDieRollIsBetween25and75_ShouldCalculateTheDamageForANormalAttack(int dieRoll)
        {
            // Arrange
            var sword = new Weapon { Name = "Sword of Might", Damage = 100 };
            var helmet = new Armor { Name = "Bronze Helmet", Defence = 10 };
            var breastplate = new Armor { Name = "Bronze Breastplate", Defence = 20 };
            var armor = new List<Armor> { helmet, breastplate };
            var die = new Mock<IDie>();
            die.Setup(d => d.Roll()).Returns(dieRoll);
            var damageCalculator = GetDamageCalculator(die.Object);
            // Act
            var damage = damageCalculator.CalculateDamage(sword, armor);
            // Assert
            Assert.That(damage, Is.EqualTo(70));
        }

        [TestCase(75)]
        [TestCase(80)]
        [TestCase(99)]
        public void CalculateDamage_WhenTheDieRollIsBetween75and100_ShouldCalculateTheDamageForAnExtraordinaryAttack(int dieRoll)
        {
            // Arrange
            var sword = new Weapon { Name = "Sword of Might", Damage = 100 };
            var helmet = new Armor { Name = "Bronze Helmet", Defence = 10 };
            var breastplate = new Armor { Name = "Bronze Breastplate", Defence = 20 };
            var armor = new List<Armor> { helmet, breastplate };
            var die = new Mock<IDie>();
            die.Setup(d => d.Roll()).Returns(dieRoll);
            var damageCalculator = GetDamageCalculator(die.Object);
            // Act
            var damage = damageCalculator.CalculateDamage(sword, armor);
            // Assert
            Assert.That(damage, Is.EqualTo(120));
        }

        [Test]
        public void CalculateDamage_WhenTheDieRollIs100_ShouldCalculateTheDamageForACriticalAttack()
        {
            // Arrange
            var sword = new Weapon { Name = "Sword of Might", Damage = 100 };
            var helmet = new Armor { Name = "Bronze Helmet", Defence = 10 };
            var breastplate = new Armor { Name = "Bronze Breastplate", Defence = 20 };
            var armor = new List<Armor> { helmet, breastplate };
            var die = new Mock<IDie>();
            die.Setup(d => d.Roll()).Returns(100);
            var damageCalculator = GetDamageCalculator(die.Object);
            // Act
            var damage = damageCalculator.CalculateDamage(sword, armor);
            // Assert
            Assert.That(damage, Is.EqualTo(170));
        }

        #region Helpers

        private Class1 GetDamageCalculator(IDie die)
        {
            return new Class1(die);
        }

        #endregion

    }
}
