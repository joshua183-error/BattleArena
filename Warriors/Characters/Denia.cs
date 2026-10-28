using BattleArena.Abilities;
using BattleArena.Combat;
using BattleArena.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleArena.Warriors.Characters
{
    public class Denia : Warrior, IHealCaster
    {
        public int HealingAmount { get; set; }
        public Denia(int health, int attackPower, int speed, int healingAmount, TeamType teamType)
            : base("Denia", health, attackPower, speed, WarriorType.Magery, teamType)
        {
            HealingAmount = healingAmount;
        }

        public override void Attack(Warrior target)
        {
            var dmginfo = new DamageInfo(AttackPower, "Angelic Heal!", HasCriticalChance, this);
            TakeDamage(dmginfo);

            Console.WriteLine($"->{Name}: Don't die yet, {target.Name}.");

            Thread.Sleep(1000);
            if (target.IsAlive)
                Console.WriteLine($"->{target.Name}: I am still alive? {Name}");
        }

        public void HealTeamMates( List<Warrior> teamMates)
        {
            foreach (var warrior in teamMates)
            {
                if (warrior.IsAlive && warrior.TeamType == TeamType)
                {
                    Console.WriteLine($"->{Name}: I'll heal the brave warrior, {warrior.Name}!");
                    warrior.ReceiveHealing(HealingAmount, this);
                }
                else
                    Console.WriteLine($"->{Name}: Rest in peace, {warrior.Name}. " +
                        $"I'll pray you after this mess.");
            }
        }
    }
}
