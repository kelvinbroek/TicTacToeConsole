using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Enums;

namespace ConsoleApp2
{
    class TicTacToeEngine
    {
        public GameStatus Status { get; private set; }

        public IList<string> cells = new List<string>();

        public TicTacToeEngine()
        {
            Status = GameStatus.PlayerOPlays;
            cells.Add("0"); cells.Add("1"); cells.Add("2"); cells.Add("3"); cells.Add("4");
            cells.Add("5"); cells.Add("6"); cells.Add("7"); cells.Add("8");
        }

        public string Board()
        {
            String waarde = "Type a number from 1-9, new or quit\nStatus: " + Status + "\n";
            waarde = waarde + "----------------\n";

            for (int i = 0; i < cells.Count; i += 3)
            {
                waarde = waarde + String.Format("- {0} - {1} - {2} -\n", cells[i], cells[i + 1], cells[i + 2]);
            }

            waarde = waarde + "---------------\n";
            return waarde;
        }

        public Boolean ChooseCell(string choice)
        {
            try
            {
                int index = int.Parse(choice);

                if (!cells[index].Equals("O") && !cells[index].Equals("X"))
                {
                    if (Status == GameStatus.PlayerOPlays)
                    {
                        cells[index] = "O";
                        Status = GameStatus.PlayerXPlays;
                    }
                    else if (Status == GameStatus.PlayerXPlays)
                    {
                        cells[index] = "X";
                        Status = GameStatus.PlayerOPlays;
                    }
                    GetWinner(cells[0], cells[1], cells[2]); GetWinner(cells[3], cells[4], cells[5]); GetWinner(cells[6], cells[7], cells[8]);
                    GetWinner(cells[0], cells[4], cells[8]); GetWinner(cells[2], cells[4], cells[6]); GetWinner(cells[0], cells[3], cells[6]);
                    GetWinner(cells[1], cells[4], cells[7]); GetWinner(cells[2], cells[5], cells[8]);

                    switch (Status)
                    {
                        case GameStatus.PlayerOWins:
                            Console.WriteLine("");
                            break;
                        case GameStatus.PlayerXWins:
                            Console.WriteLine("");
                            break;
                        case GameStatus.Equal:
                            Console.WriteLine("");
                            break;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid choice");
                return false;
            }

            return false;
        }

        public void Reset()
        {
            cells[0] = "0"; cells[1] = "1"; cells[2] = "2"; cells[3] = "3"; cells[4] = "4";
            cells[5] = "5"; cells[6] = "6"; cells[7] = "7"; cells[8] = "8";

            Status = GameStatus.PlayerOPlays;
        }

        public Boolean GetWinner(string a, string b, string c)
        {
            Boolean value = false;
            int beurt = 0;

            if (a.Equals("O") && b.Equals("O") && c.Equals("O"))
            {
                Status = GameStatus.PlayerOWins;
                value = true;
            }
            else if (a.Equals("X") && b.Equals("X") && c.Equals("X"))
            {
                Status = GameStatus.PlayerXWins;
                value = true;
            }

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Equals("O") || cells[i].Equals("X"))
                {
                    beurt++;
                }
            }
            if (beurt == 9)
            {
                Status = GameStatus.Equal;
                value = true;
            }

            return value;
        }
    }
}
