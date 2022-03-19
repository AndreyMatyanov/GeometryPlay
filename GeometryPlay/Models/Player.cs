using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Models
{
    internal class Player
    {
        private int countOfSteps;
        private string nickname;
        private char symbol;
        private int rollHeight;
        private int rollWidth;
        private int coordinateHeight;
        private int coordinateWidth;
        readonly Random rollRandom = new Random();
        private bool isPlayerTurn;
        private bool isReRolling;

        public Player(char symbol)
        {
            this.symbol = symbol;
        }
        public int CoordinateWidth
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

        public int CoordinateHight
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

        public int CountOfSteps 
        { 
            get 
            { 
                return countOfSteps; 
            }
            set 
            { 
                countOfSteps = value; 
            } 
        }

        public bool IsPlayerTurn
        {
            get 
            { 
                return isPlayerTurn; 
            }
            set 
            { 
                isPlayerTurn = value; 
            }
        }

        public bool IsRerolling
        {
            get
            {
                return isReRolling;
            }
            set
            {
                isReRolling = value;
            }
        }

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

        public int RollWidth
        {
            get { return rollHeight; }
        }

        public int RollHight
        {
            get { return rollWidth; }
        }

        public char Symbol
        {
            get { return symbol; }
        }

        public void RollDice()
        {
            rollHeight = rollRandom.Next(1, 7);
            rollWidth = rollRandom.Next(1, 7);
        }
    }
}
