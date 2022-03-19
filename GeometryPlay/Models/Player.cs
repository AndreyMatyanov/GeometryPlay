using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Models
{
    internal class Player
    {
        private string nickname;
        private readonly char symbol;
        private int rollHeight;
        private int rollWidth;
        private int coordinateHeight;
        private int coordinateWidth;
        readonly Random rollRandom = new Random();

        public Player(char symbol)
        {
            this.symbol = symbol;
        }
        public int CoordinateHeight
        {
            get 
            {
                return coordinateHeight;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть отрицательным.");
                }
                else
                {
                    coordinateHeight = value - 1;
                }
            }
        }

        public int CoordinateWidth
        {
            get
            {
                return coordinateWidth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть отрицательным.");
                }
                else
                {
                    coordinateWidth = value  - 1;
                }
            }
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

        public int RollHight => rollWidth;

        public char Symbol => symbol;

        public void RollDice()
        {
            rollHeight = rollRandom.Next(1, 7);
            rollWidth = rollRandom.Next(1, 7);
        }
    }
}
