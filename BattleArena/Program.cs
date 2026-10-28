﻿﻿    using BattleArena.Warriors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace BattleArena
    {

        internal class Program
        {
            static void Main(string[] args)
            {
                int round = 1;
                var Denia = new Marksman("Denia", 100, 30);
                var Mabel = new Fighter("Mabel", 200, 15);
                var Yuuki = new Tank("Yuuki", 150, 30);

                Denia.DisplayStats();
                Mabel.DisplayStats();
                Yuuki.DisplayStats();
             
                while(Denia.IsAlive && Mabel.IsAlive && Yuuki.IsAlive)
                {
                
                    Denia.Attack(Mabel);
                    Console.WriteLine("----------------------------------------------");
                    Cods.Attack(Denia);
                    Console.WriteLine("----------------------------------------------");
                    round++;
                }

                Console.ReadKey();
            }
        } 
    }
