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
             var swordOfCrom = new Weapon();
             var conan = new Class2 {name = "Conan", rightHandWeapon = swordOfCrom};

             var majesticRobes = new Armor();
             var evilWizard = new Class2 {name = "evilWizard", currentHitPoints = 100d, torso = majesticRobes};
             var evilWizardsArmor = new List<Armor>{ majesticRobes };

             var damageCalculator = new Mock<IDamageCalculator>();
             damageCalculator.Setup(dc => dc.CalculateDamage(swordOfCrom, evilWizardsArmor)).Returns(50d);
             // Act
             conan.Attack(evilWizard, damageCalculator.Object);
             // Assert
             Assert.That(evilWizard.currentHitPoints, Is.EqualTo(50d));
         }
    }
}