using BattleArena.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena.Combat
{
    public class TurnEntry
    {
        public Warrior Warrior { get; set; }
        public int Initiative { get; set; }
        public bool IsAttacked { get; set; }
        public bool IsTurnDone { get; set; }

        public TurnEntry(Warrior warrior, int initiative)
        {
            Warrior = warrior;
            Initiative = initiative;
            IsAttacked = false;
            IsTurnDone = false;
        }
    }
}
