using System.Collections.Generic;

namespace Katas
{

    /* 
     * Kata 01. Improve
     * *********************
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
     * 
     * Tip: 
     * - Download and print ReSharper keymap from http://www.jetbrains.com/resharper/documentation/index.jsp
     * - Try not to use the mouse and rely solely on the keyboard
     */

    public class Class1
    {
        private readonly IDie die;

        public Class1(IDie die)
        {
            this.die = die;
        }

        public double CalculateDamage(Weapon weapon, IEnumerable<Armor> armor)
        {
            var dieRoll = die.Roll();
            var temp = 0d;
            if (dieRoll == 0) // Utmost failure
            {
                temp = 0;
            }
            else if (dieRoll > 0 && dieRoll < 25) // Penalized Attack
            {
                var totalDefence = 0d;
                foreach (var pieceOfArmor in armor)
                    totalDefence += pieceOfArmor.Defence;
                temp = 0.5*weapon.Damage - totalDefence;
            }
            else if (dieRoll >= 25 && dieRoll < 75) // Normal Attack
            {
                var totalDefence = 0d;
                foreach (var pieceOfArmor in armor)
                    totalDefence += pieceOfArmor.Defence;
                temp = weapon.Damage - totalDefence;
            }
            else if (dieRoll >= 75 && dieRoll < 100) // Extraordinary Attack
            {
                var totalDefence = 0d;
                foreach (var pieceOfArmor in armor)
                    totalDefence += pieceOfArmor.Defence;
                temp = 1.5*weapon.Damage - totalDefence;
            }
            else if (dieRoll == 100) // Critical attack
            {
                var totalDefence = 0d;
                foreach (var pieceOfArmor in armor)
                    totalDefence += pieceOfArmor.Defence;
                temp = 2*weapon.Damage - totalDefence;
            }
            return temp;
        }

    }

    public interface IDie
    {
        int Roll();
    }

    public class Armor
    {
        public string Name { get; set; }
        public double Defence { get; set; }
         
    }

    public class Weapon
    {
        public string Name { get; set; }
        public double Damage { get; set; }
    }
}
