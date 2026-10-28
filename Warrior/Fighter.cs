using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleArena.Warriors
{
    public class Fighter : Warrior
    {
        public int SwordDamage { get; private set; }
        public Fighter(string name, int health, int attackPower, int swordDamage)
            : base(name, health, attackPower)
        {
            SwordDamage = swordDamage;
            attackPower += swordDamage;
        }

        public Fighter(string name, int health, int attackPower) 
            : base(name, health, attackPower)
        {
            SwordDamage = SwordDamage;
        }

        public override void Attack(Warrior target)
        {
            var totalDamage = target.AttackPower + SwordDamage; 
            TakeDamage(totalDamage);
            Console.WriteLine($"\t-> {Name}: Ano na Boi kapa! {target.Name}!");
            Thread.Sleep(1000);

            Console.WriteLine($"\t-> {target.Name}: Napinsala ako!");   
            Console.WriteLine($"\t-------- {target.Name} --------");
            Thread.Sleep(1000);

            if (target.IsAlive)
                Console.WriteLine($"\t-> {target.Name}: Patay ka ngayon! {target.Name}");

            Thread.Sleep(1000);
            Console.WriteLine($"\t------ {target.Name} --------");
            Console.WriteLine($"\t  *Damage Taken: {totalDamage} *");
            Console.WriteLine($"\t  *Remaining Health: {target.Health} *");
            



        }
    }
}
