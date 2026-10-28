using BattleArena.Enums;
using BattleArena.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena.Abilities
{
    public interface IHealable
    {
        TeamType TeamType { get; }

        void ReceiveHealing(int amount, Warrior healer);
    }
}
