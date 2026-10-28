using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Yuuki : Warrior
    {
        public int SlashDamage { get; private set; }

        public Yuuki(int health, int attackPower, int speed, int slashDamage, TeamType teamType)
            : base("Yuuki", health, attackPower, speed, WarriorType.Fighter, teamType)
        {
            SlashDamage = slashDamage;
            attackPower += SlashDamage;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Void Serpent", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Destroy {target.Name} and done!" );

            Thread.Sleep(1000);
            Console.WriteLine($"->{target.Name}: Hmph!");

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: I am still alive, foolish {target.Name}.");
        }
    }
}