using BattleArena.Abilities;
using BattleArena.Combat;
using BattleArena.Enums;
using System;

namespace BattleArena.Warriors
{
    public abstract class Warrior : IHealable
    {
        private bool _isAlive;
        private bool _hasCriticalChance;

        protected DamageInfo _damageTaken;
        protected Random _random = new Random();

        public string Name { get; private set; }
        public int Health { get; private set; }
        public int AttackPower { get; private set; }
        public int Speed { get; private set; }

        public WarriorType WarriorType { get; private set; }
        public TeamType TeamType { get; private set; }


        public bool IsAlive
        {
            get
            {
                _isAlive = Health > 0;
                return _isAlive;
            }
            private set { _isAlive = value; }
        }

        public bool HasCriticalChance
        {
            get
            {
                var chance = _random.Next(0, 100);
                _hasCriticalChance = chance < 30;
                return _hasCriticalChance;
            }
            private set { _hasCriticalChance = value; }
        }

        public Warrior(string name, int health, int attackPower, int speed, WarriorType warriorType, TeamType teamType)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Speed = speed;
            WarriorType = warriorType;
            TeamType = teamType;
        }

        protected virtual void TakeDamage(DamageInfo damage)
        {
            _damageTaken = damage;
            Health -= damage.TotalAmountDamage;
            if (Health < 0) Health = 0;
        }

        public virtual void DisplayStatus()
        {
            Console.WriteLine($"---== {Name} ==---");

            if (_damageTaken.IsCritical)
                Console.WriteLine($"---- Critical Hit ----");

            Console.WriteLine($"[*] Health: {Health}");
            Console.WriteLine($"[*] Attack Power: {AttackPower}");
            Console.WriteLine($"[*] Damage Taken: {_damageTaken.TotalAmountDamage}");
        }

        public abstract void Attack(Warrior target);

        public void ReceiveHealing(int amount, Warrior healer)
        {
            if ( healer.TeamType == TeamType )
            {
                Health += amount;
                Console.WriteLine($"->{Name}: Received healing from {healer.Name}! Health is now {Health}");
            }
        }
    }
}
