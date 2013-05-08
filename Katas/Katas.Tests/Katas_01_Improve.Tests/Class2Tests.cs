using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Katas.Tests
{
    [TestFixture]
    public class Class2Tests
    {
         [Test]
         public void Attack_WhenGivenADamageCalculatorAndAFoe_ShouldAttackFoeAndReduceHisHitpointsBasedOnTheCalculatedDamage()
         {
             // Arrange
             var mightyKatana = new Weapon();
             var conan = new Class2 {name = "Miyamoto Musashi", rightHandWeapon = mightyKatana};

             var majesticRobes = new Armor();
             var evilWizard = new Class2 {name = "Shadow Ninja", currentHitPoints = 100d, torso = majesticRobes};
             var evilWizardsArmor = new List<Armor>{ majesticRobes };

             var damageCalculator = new Mock<IDamageCalculator>();
             damageCalculator.Setup(dc => dc.CalculateDamage(mightyKatana, evilWizardsArmor)).Returns(50d);
             // Act
             conan.Attack(evilWizard, damageCalculator.Object);
             // Assert
             Assert.That(evilWizard.currentHitPoints, Is.EqualTo(50d));
         }
    }
}