using BattleArena.Abilities;
using BattleArena.Combat;
using BattleArena.Enums;
using BattleArena.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    public static class BattleArena
    {
        private static readonly Random _random = new Random();
        static List<Warriors.Warrior> _warriors = new List<Warriors.Warrior>();
        static List<TurnEntry> _entries = new List<TurnEntry>();
        static List<TurnEntry> _teamA;
        static List<TurnEntry> _teamB;

        public static void StartBattle()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("       Battle Arena");
            Console.WriteLine("=============================");
            Console.WriteLine();
            InitializeTeams();
            DisplayWarriors();

            Console.WriteLine("---------Battle Start-------");

            int round = 1;

            while (CountAlive() >1)
            {
                Console.WriteLine($"\n++++++++++++++ Round {round} ++++++++++++++");

                Console.WriteLine("--------------  Team A:  --------------\n");
                foreach (var entry in _teamA)
                {
                    if(entry.Warrior.IsAlive)
                        entry.Warrior.DisplayStatus();
                }

                Console.WriteLine("--------------  Team B:  --------------\n");
                foreach (var entry in _teamB)
                {
                    if (entry.Warrior.IsAlive)
                        entry.Warrior.DisplayStatus();
                }
                Console.WriteLine("-----------------------------------------");

                RunRound();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                round++;
            }

            DisplayWinner();
            Console.WriteLine("\n---------Battle Ended-------");
        }

        public static void AddWarrior(Warrior warrior)
        {
            _warriors.Add(warrior);
        }

        private static void InitializeTeams()
        {
            _teamA = _warriors.Where(w => w.TeamType == TeamType.A)
                .Select(w => new TurnEntry(w, 0)).ToList();
            _teamB = _warriors.Where(w => w.TeamType == TeamType.B)
                .Select(w => new TurnEntry(w, 0)).ToList();
        }

        private static void DisplayWarriors()
        {
            Console.WriteLine("==========  Team A:  ==========\n");
            foreach (var turnEntry in _teamA)
                Console.WriteLine($"\t---++++ {turnEntry.Warrior.Name} ++++--_" +
                    $"\n\t [*] Health: {turnEntry.Warrior.Health}," +
                    $"\n\t [*] Attack Power: {turnEntry.Warrior.AttackPower}, " +
                    $"\n\t [*] Speed: {turnEntry.Warrior.Speed}) \n");

            Console.WriteLine("==========  Team B:  ==========\n");
            foreach (var turnEntry in _teamB)
                Console.WriteLine($"\t---++++ {turnEntry.Warrior.Name} ++++--_" +
                    $"\n\t [*] Health: {turnEntry.Warrior.Health}," +
                    $"\n\t [*] Attack Power: {turnEntry.Warrior.AttackPower}, " +
                    $"\n\t [*] Speed: {turnEntry.Warrior.Speed}) \n");
        }

        private static void DisplayWinner()
        {
            var winningTeam = _teamA.Any(w => w.Warrior.IsAlive) ? "Team A" : "Team B";
            Console.WriteLine($"\nCongratulations! {winningTeam} wins the battle!");
        }

        private static void RunRound()
        {
            var turnOrder = CreateTurnOrder();


            foreach (var entry  in turnOrder)
            {
                var attacker = entry.Warrior;
                if (!attacker.IsAlive) continue;

                var target = FindOpponent(attacker);
                if (target == null) continue;

                if (attacker is IHealCaster)
                {
                    var healer = (IHealCaster)attacker;
                    var teamMates = attacker.TeamType == TeamType.A ? _teamA : _teamB;
                    healer.HealTeamMates(teamMates.Select(t => t.Warrior).ToList());
                }

                attacker.Attack(target);
            }
        }

        private static List<TurnEntry> CreateTurnOrder()
        {
            var turnOrder = new List<TurnEntry>();

            foreach (var warrior  in _warriors)
            {
                if (!warrior.IsAlive) continue;

                int random = _random.Next(1, 21);
                int initiative = warrior.Speed + random;
                turnOrder.Add(new TurnEntry(warrior, initiative));
            }

            return turnOrder.OrderBy(t => t.Initiative).ToList();
        }


        private static Warrior FindOpponent(Warrior attacker)
        {
            var opponentTeam = attacker.TeamType == TeamType.A ? _teamB : _teamA;
            var validOpponents = opponentTeam.Where(t => t.Warrior.IsAlive).ToList();
            if (validOpponents.Count == 0) return null;

            int index = _random.Next(validOpponents.Count);
            return validOpponents[index].Warrior;
        }


        private static int CountAlive()
        {
            int cnt = 0;

            foreach (var warrior in _warriors)
                if (warrior.IsAlive) cnt++;
            return cnt;
        }
    }
}
