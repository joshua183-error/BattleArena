using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Victoria : Warrior
    {
        public int KickDamage { get; private set; }

        public Victoria(int health, int attackPower, int speed, int kickDamage, TeamType teamType)
            : base("Victoria", health, attackPower, speed, WarriorType.Fighter, teamType)
        {
            KickDamage = kickDamage;
            attackPower += KickDamage;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Let me squish your heart, Death Marrionette.", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Target {target.Name} and kill!" );

            Thread.Sleep(1000);
            Console.WriteLine($"->{target.Name}: How dare you!");

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: Mortals are easy to fool.");
        }
    }
}