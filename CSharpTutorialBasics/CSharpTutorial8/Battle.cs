using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial8
{
    class Battle
    {
        // StartFight
        // Warrior 1, Warrior 2
        // Loop given each warrior a change to attack and block each turn until one dies
        public static void StartFight(Warrior warrior1, Warrior warrior2)
        {
            bool gameOver = false;
            bool firstWarriorTurn = true;
            while (!gameOver)
            {
                if (firstWarriorTurn)
                {
                    gameOver = GetAttackResult(warrior1, warrior2);
                }
                else
                {
                    gameOver = GetAttackResult(warrior2, warrior1);
                }
                firstWarriorTurn = !firstWarriorTurn;
            }
            Console.WriteLine("Game Over");
        }

        // GetAttckResult
        // WarriorA, WarriorB

        // Calculates 1 warriors attack and the others block
        // Subtract block from attack
        // If there was damage sybtract that from health

        // print out info on who attacked who and for how much damage

        // provide output on the change in health

        // check if the warriors health fell below 0, if so print a message and then send a response that will end the loop
        private static bool GetAttackResult(Warrior warrior1, Warrior warrior2)
        {
            int firstWarriorAttack = warrior1.Attack();
            int secondWarriorBlock = warrior2.Block();

            int damage = firstWarriorAttack - secondWarriorBlock;

            if (damage > 0)
            {
                Console.WriteLine($"{warrior1.Name} Attacks {warrior2.Name} and Deals {damage} Damage");

                warrior2.Health -= damage;

                Console.WriteLine($"{warrior2.Name} Has {warrior2.Health} Health \n");

                if (warrior2.Health <= 0)
                {
                    Console.WriteLine($"{warrior2.Name} has Died and {warrior1.Name} is Victorious! \n");
                    return true;
                }
            }

            return false;
        }
        
    }
}
