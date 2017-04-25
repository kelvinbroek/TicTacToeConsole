using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2;
using ConsoleApp2.Enums;

namespace Main
{
    class Program
    {
        private TicTacToeEngine t;
        public Program()
        {
            t = new TicTacToeEngine();
        }

        public void Choose(string place)
        {
            if ((!(t.Status == GameStatus.PlayerOPlays) && !(t.Status == GameStatus.PlayerXPlays)) || place.Equals("new"))
            {
                t.Reset();
            }
            else if (place.Equals("quit"))
            {
                Environment.Exit(0);
            }

            bool result = t.ChooseCell(place);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.t.Board());
            while (!Environment.HasShutdownStarted)
            {
                string choice = Console.ReadLine(); 
                program.Choose(choice);
                Console.Write(program.t.Board());
            }
            
            Console.ReadKey();
        }
    }
}
