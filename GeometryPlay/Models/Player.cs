using System;

namespace GeometryPlay.Models
{
    class Player
    {
        private string nickname;
        private readonly char symbol;
        private int rollHeight;
        private int rollWidth;
        readonly Random rollRandom = new Random();

        public Player(char symbol)
        {
            this.symbol = symbol;
        }

        public int CountOfSteps { get; set; }

        public bool IsPlayerTurn { get; set; }

        public bool IsRerolling { get; set; }

        public string Nickname
        {
            get 
            { 
                return nickname; 
            }
            set 
            { 
                if(value == String.Empty)
                {
                    throw new ArgumentException("Введена пустая строка. Введите nickname!");
                }
                else
                {
                    nickname = value;
                }
            }
        }

        public int RollWidth => rollHeight;

        public int RollHeight => rollWidth;

        public int Record { get; set; }

        public char Symbol => symbol;

        public void RollDice()
        {
            rollHeight = rollRandom.Next(1, 7);
            rollWidth = rollRandom.Next(1, 7);
        }
    }
}
