using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Models
{
    class Field
    {
        private Player playerTurn;
        private int countOfSteps;
        private char[,] fieldArray;
        private int width;
        private int height;

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
        public char[,] FieldArray
        {
            get 
            { 
                return fieldArray; 
            }
            set 
            { 
                fieldArray = value; 
            }
        }

        public int Height
        {
            get 
            {
                return width; 
            }
            set 
            {
                if (value < 10)
                {
                    throw new ArgumentException("Ширина не может быть меньше 20.");
                }
                else
                {
                    width = value;
                }
            }
        }

        public int Width
        {
            get 
            {
                return height; 
            }
            set 
            { 
                if(value < 20)
                {
                    throw new ArgumentException("Высота не может быть меньше 30.");
                }
                else
                {
                    height = value;
                }
            }
        }

        public Player PlayerTurn
        {
            get 
            { 
                return playerTurn; 
            }
            set
            {
                playerTurn = value;
            }
        }

        public void FillEmptyArray()
        {
            for (int i = 0; i < fieldArray.GetLength(0); i++)
            {
                for (int j = 0; j < fieldArray.GetLength(1); j++)
                {
                    fieldArray[i, j] = '-';
                }
            }
        }

        public int GetCountOfChars(char symbol)
        {
            int count = 0;
            for (int i = 0; i<width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if (fieldArray[j, i] == symbol)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        public int GetMinCountOfSteps()
        {
            const int minSteps = 20;
            return minSteps * width * height / 600;
        }

        public void SetArraySize()
        {
            fieldArray = new char[height, Height];
        }

        public void EnterStartCountOfSteps(int count)
        {
            if (count < GetMinCountOfSteps())
            {
                throw new ArgumentException($"Количество шагов не может быть меньше {GetMinCountOfSteps()}");
            }
            else
            {
                countOfSteps = count;
            }
        }

        public void FillStepOfPlayer()
        {
            int extremeRightPosition = playerTurn.CoordinateWidth + playerTurn.RollWidth;
            int extremeDownPosition = playerTurn.CoordinateHight + playerTurn.RollHight;

            if (extremeRightPosition > width || extremeDownPosition > height)
            {
                throw new ArgumentOutOfRangeException("Фигура вышла за поле игры.");
            }

            char[,] temp = CopyArray();
            for (int i = playerTurn.CoordinateWidth; i < extremeRightPosition; i++)
            {
                for (int j = playerTurn.CoordinateHight; j < extremeDownPosition; j++)
                {
                    if (temp[j, i] != '-')
                    {
                        throw new ArgumentException("Позиция занята.");
                    }
                    else
                    {
                        temp[j, i] = playerTurn.Symbol;
                    }
                }
            }
            countOfSteps--;
            fieldArray = temp;
        }

        public char[,] CopyArray()
        {
            char[,] copyArray = new char[height, width];
            for (int i = 0; i < fieldArray.GetLength(0); i++)
                for (int j = 0; j < fieldArray.GetLength(1); j++)
                    copyArray[i, j] = fieldArray[i, j];
            return copyArray;
        }

        public bool IsTherePlaceInField()
        {
            bool result = false;
            for (int j = 0; j <= width - playerTurn.RollWidth; j++)
            {
                for (int i = 0; i <= height - playerTurn.RollHight; i++)
                {
                    if(fieldArray[i,j] == '-')
                    {
                        result = IsFillStepOfPlayer(j, i);
                    }

                    if (result == true)
                    {
                        return true;
                    }
                }
            }

            return result;
        }
        public bool IsFillStepOfPlayer(int coordinateWidth, int coordinateHight)
        {
            int extremeRightPosition = coordinateWidth + playerTurn.RollWidth;
            int extremeDownPosition = coordinateHight + playerTurn.RollHight;

            char[,] temp = FieldArray;
            for (int i = coordinateWidth; i < extremeRightPosition; i++)
            {
                for (int j = coordinateHight; j < extremeDownPosition; j++)
                {
                    if (temp[j,i] != '-')
                    {
                         return false;
                    }
                }
            }

            return true;
        }
    }
}
