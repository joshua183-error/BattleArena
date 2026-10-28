using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Reimu : Warrior
    {
        public int ShotDamage { get; private set; }

        public Reimu(int health, int attackPower, int speed, int shotDamage, TeamType teamType)
            : base("Reimu", health, attackPower, speed, WarriorType.Marksman, teamType)
        {
            ShotDamage = shotDamage;
            attackPower += ShotDamage;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Fantasy Seal!", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Seal of Heaven, Annihilates {target.Name}!" );

            Thread.Sleep(1000);
            Console.WriteLine($"->{target.Name}: Fortune is my enemy!");

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: Lucky that I am still alive, {target.Name}.");
        }
    }
}