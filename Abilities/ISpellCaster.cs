using BattleArena.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena.Abilities
{
    public interface ISpellCaster
    {
        void CastSpell(Warrior target);
    }
}
