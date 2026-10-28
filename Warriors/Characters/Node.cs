using BattleArena.Abilities;
using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BattleArena.Warriors.Characters
{
    public class Node : Warrior, IHealCaster
    {
        public int HealingAmount { get; set; }

        public Node(int health, int attackPower, int speed, int healingAmount, TeamType teamType)
            : base("Node", health, attackPower, speed, WarriorType.Magery, teamType)
        {
            HealingAmount = healingAmount;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Time Reversal", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Assassinate, {target.Name}." );

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: Time is at my side.");
        }

        public void HealTeamMates(List<Warrior> teamMates)
        {
            foreach (var warrior in teamMates)
            {
                if (warrior.IsAlive && warrior.TeamType == TeamType)
                {
                    Console.WriteLine($"->{Name}: I'll help you, {warrior.Name}!");
                    warrior.ReceiveHealing(HealingAmount, this);
                }
            }
        }
    }
}