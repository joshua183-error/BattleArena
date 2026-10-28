using BattleArena.Abilities;
using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Kirk : Warrior, IDefender
    {
        public int Shield  { get; private set; }

        public Kirk(int health, int attackPower, int speed, int shield, TeamType teamType) 
            : base("Mr.Yang", health, attackPower, speed, WarriorType.Tank, teamType)
        {
            Shield = shield;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Star of Eden!", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Witness the star shattered, {target.Name}.");

            Thread.Sleep(1000);
            Console.WriteLine($"->{target.Name}: Zzzzzz...");

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: This old fellow wouldn't go down easily.");
        }

        protected override void TakeDamage(DamageInfo damage)
        {
            var newActualDamage = damage.TotalAmountDamage - Shield;

            var blockChance = _random.Next(0, 100);
            var isBlocked =  blockChance < 50;
            _damageTaken = damage;

            if (isBlocked) Block();
            else
            {
                var newDmginfo = new DamageInfo(newActualDamage, damage.AttackType, damage.IsCritical, damage.From);
                base.TakeDamage(newDmginfo);
            }
        }
        public void Block()
        {
            Console.WriteLine($"Hahaha! Blocked {_damageTaken.TotalAmountDamage} damage from {_damageTaken.From.Name}! ");
        }
    }

}
