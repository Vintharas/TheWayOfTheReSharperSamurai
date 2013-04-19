using System.Collections.Generic;
using System.Linq;

namespace Katas
{

    /* 
     * Kata 01. Improve
     * *********************
     * Use ReSharper "improve" shortcuts to refactor this file
     * 
     * 
     * 
     * Tip: 
     * - Download and print ReSharper keymap from http://www.jetbrains.com/resharper/documentation/index.jsp
     * - Try not to use the mouse and rely solely on the keyboard
     */

    public class DamageCalculator
    {
        public double CalculateDamage(Weapon weapon, IEnumerable<Armor> armor)
        {
            double damage = 0;
            if (IsLesserDamage(weapon))
            {
                var calculateTotalDefenceFromArmor = CalculateTotalDefenceFromArmor(armor);
                damage = weapon.Damage - calculateTotalDefenceFromArmor;
            }
            else if (IsMediumDamage(weapon))
            {
                damage = 2*weapon.Damage - CalculateTotalDefenceFromArmor(armor);
            }
            else if (IsLesserDamage(weapon))
            {
                double temp2 = armor.Sum(armor1 => armor1.Defence);
                damage = 3*weapon.Damage - temp2;
            }
            else
            {
                
                // Critical!!!!!
                double temp2 = 0;
                foreach (var armor1 in armor)
                {
                    temp2 += armor1.Defence;
                }
                damage = 100*weapon.Damage - temp2;
            }
            var ala = new List<int>();
            


            return damage;
        }

        #region lalalala

        /// <summary>
        /// Check if the damage produce by the weapon is medium
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private static bool IsMediumDamage(Weapon weapon)
        {
            return weapon.Damage >= 50 && weapon.Damage < 75;
        }

        private static double CalculateTotalDefenceFromArmor(IEnumerable<Armor> armor)
        {
            double temp2 = 0;
            foreach (var armor1 in armor)
            {
                temp2 += armor1.Defence;
            }
            return temp2;
        }

        private static bool IsLesserDamage()
        {
            return true;
        }

        private static bool IsLesserDamage(Weapon weapon)
        {
            return weapon.Damage < 50;
        }

        #endregion

    }

    public class Armor
    {
        public double Defence { get; set; }
    }

    public class Weapon
    {
        public double Damage { get; set; }
    }
}
