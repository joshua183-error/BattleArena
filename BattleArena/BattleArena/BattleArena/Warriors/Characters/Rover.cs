using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Rover : Warrior
    {
        public int PunchDamage { get; private set; }
        public Rover(int health, int attackPower, int speed, int punchDamage, TeamType teamType) 
            : base("Rover", health, attackPower, speed, WarriorType.Fighter, teamType)
        {
            PunchDamage = punchDamage;
            attackPower += PunchDamage;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Wind Slash", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Sever the target, {target.Name}.");

            Thread.Sleep(1000);
            Console.WriteLine($"->{target.Name}: Ugh...");

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: Defying fate itself!");
        }
    }

}
