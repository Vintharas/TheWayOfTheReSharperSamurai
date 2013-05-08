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
             var miyamotoMusashi = new Class2 {name = "Miyamoto Musashi", rightHandWeapon = mightyKatana};

             var shadowCloak = new Armor();
             var shadowNinja = new Class2 {name = "Shadow Ninja", currentHitPoints = 100d, torso = shadowCloak};
             var shadowNinjasArmor = new List<Armor>{ shadowCloak };

             var damageCalculator = new Mock<IDamageCalculator>();
             damageCalculator.Setup(dc => dc.CalculateDamage(mightyKatana, shadowNinjasArmor)).Returns(50d);
             // Act
             miyamotoMusashi.Attack(shadowNinja, damageCalculator.Object);
             // Assert
             Assert.That(shadowNinja.currentHitPoints, Is.EqualTo(50d));
         }
    }
}