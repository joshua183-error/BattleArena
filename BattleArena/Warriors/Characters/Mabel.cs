using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Mabel : Warrior
    {
        public int ArrowDamage { get; private set; }

        public Mabel(int health, int attackPower, int speed, int arrowDamage, TeamType teamType)
            : base("Mabel", health, attackPower, speed, WarriorType.Marksman, teamType)
        {
            ArrowDamage = arrowDamage;
            attackPower += ArrowDamage;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Eldritch Arrows", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Perish, {target.Name}." );

            Thread.Sleep(1000);
            Console.WriteLine($"->{target.Name}: Ouch!");

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: Fool! {target.Name}");
        }
    }
}