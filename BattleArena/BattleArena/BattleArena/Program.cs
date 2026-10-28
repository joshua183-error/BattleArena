using BattleArena.Enums;
using BattleArena.Warriors.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Mark = new Mark(100, 30, 25, 10, TeamType.A);
            var Mabel = new Mabel ( 200, 15, 10, 30, TeamType.B);
            var Denia = new Denia(150, 20, 15, 10, TeamType.A);

            BattleArena.AddWarrior(Mark);
            BattleArena.AddWarrior(Mabel);
            BattleArena.AddWarrior(Denia);

            BattleArena.StartBattle();
        }
    }
}
