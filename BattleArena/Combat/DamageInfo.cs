using BattleArena.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena.Combat
{
    public struct DamageInfo
    {
        public int TotalAmountDamage { get; private set; }
        public int ActualAmountDamage { get; private set; }
        public string AttackType { get; private set; }
        public bool IsCritical { get; private set; }
        public Warrior From { get; private set; }

        public DamageInfo(
            int actualAmountDamage,
            string attackType,
            bool isCritical,
            Warrior from)
        {
            ActualAmountDamage = actualAmountDamage;
            AttackType = attackType;
            IsCritical = isCritical;
            TotalAmountDamage = isCritical ? actualAmountDamage * 2 : actualAmountDamage;
            From = from;
        }
    }
}
