using System;
using System.Threading;

namespace BattleArena.Warriors
{
    public class Marksman : Warrior
    {
        public int ArrowDamage { get; private set; } 
        public Marksman(string name, int health, int attackPower, int arrowDamage)
            : base(name, health, attackPower)
        {
            ArrowDamage = arrowDamage;
            attackPower += arrowDamage;
        }

        public Marksman(string name, int health, int attackPower) 
            : base(name, health, attackPower)
        {

        }

        public override void Attack(Warrior target)
        {
            var totalDamage = target.AttackPower + ArrowDamage;
            TakeDamage(totalDamage);
            Console.WriteLine($"\t-> {Name}: Ano ka Boi! {target.Name}!");
            Thread.Sleep(1000);

            Console.WriteLine($"\t-> {target.Name}: Takas kapa!");
            Thread.Sleep(1000);

            if (target.IsAlive)
            Console.WriteLine($"\t-> {target.Name}: Punit ako! {target.Name}");
            Thread.Sleep(1000);

            Console.WriteLine($"\t------ {target.Name} --------");
            Console.WriteLine($"\t  *Damage Taken: {totalDamage} *");
            Console.WriteLine($"\t  *Health Remaining: {target.Health} *");
           


        }
    }
}
