using BattleArena.Abilities;
using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Rim : Warrior, IDefender
    {
        public int Shield { get; private set; }

        public Rim(int health, int attackPower, int speed, int shield, TeamType teamType)
            : base("Rim", health, attackPower, speed, WarriorType.Tank, teamType)
        {
            Shield = shield;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Devour", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Try to defend this, {target.Name}!" );

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: Your defense is quite easy to break!");
        }

        protected override void TakeDamage(DamageInfo damage)
        {
            var newActualDamage = damage.TotalAmountDamage - Shield;
            if (newActualDamage < 0) newActualDamage = 0;

            _damageTaken = damage;
            base.TakeDamage(new DamageInfo(newActualDamage, damage.AttackType, damage.IsCritical, damage.From));
        }

        public void Block()
        {
            Console.WriteLine($"Hahaha! Blocked {_damageTaken.TotalAmountDamage} damage from {_damageTaken.From.Name}!");
        }
    }
}