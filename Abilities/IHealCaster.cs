using BattleArena.Enums;
using BattleArena.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena.Abilities
{
    public interface IHealCaster
    {
        TeamType TeamType { get; }

        void HealTeamMates(List<Warrior> teamMates);
    }
}
