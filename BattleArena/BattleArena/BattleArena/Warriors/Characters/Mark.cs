using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Mark : Warrior
    {
        public int DuraDamage { get; private set; }
        public Mark(int health, int attackPower, int speed, int duraDamage, TeamType teamType) 
            : base("Mark", health, attackPower, speed, WarriorType.Marksman, teamType)
        {
            DuraDamage = duraDamage;
            attackPower += DuraDamage; 
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Fool's Gambit.", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Destroy the path, {target.Name}.");

            Thread.Sleep(1000);
            Console.WriteLine($"->{target.Name}: Reviving from Abyss, isn't my style.");

            Thread.Sleep(1000);
            if (target.IsAlive)
                 Console.WriteLine($"->{target.Name}: Foolish {target.Name}, your enemy are still alive and breathing.");
        }
    }

}




