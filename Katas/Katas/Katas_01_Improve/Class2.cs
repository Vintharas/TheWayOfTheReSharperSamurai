using System.Collections.Generic;

namespace Katas
{
    /* 
     * Kata 01. Improve. Exercise 02
     * *****************************
     * Use ReSharper "improve" shortcuts to refactor the contents of this file
     * 
     * 
     * Some ReSharper refactoring keys (Visual Studio Key map):
     * Refactor this! => CTRL+SHIFT+R
     * Rename => CTRL+R,R
     * Extract Method => CTRL+R,M
     * Introduce Variable => CTRL+R,V
     * Introduce Field => CTLR+R,F
     * Introduce Parameter => CTRL+R,P
     * Inline Variable, Method or Field => CTRL+R,I
     * Change signature => CTLR+R,S
     * Move type or static member => CTRL+R,O
     * Safe delete => CTRL+R,D or ALT+DEL
     * Quick Fixes, Contextual Actions => ALT+ENTER
     * 
     ** Encapsulate Field => CTRL+R,CTRL+E
     * 
     * 
     * Tip: 
     * - Download and print ReSharper keymap from http://www.jetbrains.com/resharper/documentation/index.jsp
     * - Try not to use the mouse and rely solely on the keyboard
     */

    #region Tip
    /* Rename CTRL+R, R */
    #endregion
    public class Class2
    {
        #region Tip
        /* Encapsulate fields CTRL+R,CTRL+E */
        #endregion
        public string name;
        #region Tip
        /* Rename CTRL+R,R */
        /* Encapsulate fields CTRL+R,CTRL+E */
        #endregion
        public Class @class;

        #region Tip
        /* Extract class  CTRL+SHIFT+R, Extract Class */
        /* Encapsulate fields CTRL+R,CTRL+E */
        #endregion
        public double maxHitPoints;
        public double currentHitPoints;

        #region Tip
        /* Encapsulate fields CTRL+R,CTRL+E */
        #endregion
        public Weapon rightHandWeapon;
        public Weapon leftHandWeapon;
       
        #region Tip
        /* 
         * Extract class CTRL+SHIFT+R, Extract Class
         * Encapsulate fields CTRL+R,CTRL+E
         */
        #endregion
        public Armor head;
        public Armor torso;
        public Armor shoulders;
        public Armor legs;
        public Armor hands;
        public Armor arms;

        public void Attack(Class2 foe, IDamageCalculator damageCalculator)
        {
            /* Exercise !!
             * 1) Refactor
             * 2) Improve to support the use of multiple weapons. E.g. two handed weapons, weapons in both hands, etc
             *    Example:
             *    if (RightHandWeapon)
             *        foe.currentHintPoints -= calculateDamageWithRightHandWeapon()
             *    if (LeftHandWeapon)
             *        foe.currentHitPoints -= calcualteDamageWithLeftHandWeapon() - PenalizationForSecondWeaponUnlessPlayerHasAmbidextrousPerk()
             *    
             */
            var foesArmor = new List<Armor>();
            if (foe.head != null) foesArmor.Add(foe.head);
            if (foe.torso != null) foesArmor.Add(foe.torso);
            if (foe.shoulders != null) foesArmor.Add(foe.legs);
            if (foe.shoulders != null) foesArmor.Add(foe.shoulders);
            if (foe.arms != null) foesArmor.Add(foe.arms);
            if (foe.hands != null) foesArmor.Add(foe.hands);
            
            var damage = damageCalculator.CalculateDamage(rightHandWeapon, foesArmor);
            foe.currentHitPoints -= damage;
        }
    }

    public abstract class Class
    {
        public abstract string Name { get; }
        public abstract IEnumerable<Perk> Perks { get; } 
    }

    public class Barbarian : Class
    {
        public override string Name { get { return "Barbarian"; } }
        public override IEnumerable<Perk> Perks
        {
            get
            {
                return new List<Perk>
                    {
                        new Perk {Name = "Might I"},
                        new Perk {Name = "Intimidate I"}
                    };
            }} 
    }

    public class BladeMaster : Class
    {
        public override string Name { get { return "BladeMaster"; } }
        public override IEnumerable<Perk> Perks
        {
            get
            {
                return new List<Perk>
                    {
                        new Perk {Name = "Ambidextrous"},
                        new Perk {Name = "Cat Reflexes"}
                    };
            }
        }
    }

    public class Perk
    {
        public string Name { get; set; }
    }
}