using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Models
{
    class Field
    {
        private int width;
        private int height;

        public int CountOfSteps { get; set; }
        public char[,] FieldArray { get; set; }

        public int Width
        {
            get 
            {
                return width;
            }
            set 
            {
                if (value < 20)
                {
                    throw new ArgumentException("Ширина не может быть меньше 20.");
                }
                else
                {
                    width = value;
                }
            }
        }

        public int Height
        {
            get 
            {
                return height; 
            }
            set 
            { 
                if(value < 30)
                {
                    throw new ArgumentException("Высота не может быть меньше 30.");
                }
                else
                {
                    height = value;
                }
            }
        }

        public Player PlayerTurn { get; set; }

        public void SetArraySize()
        {
            FieldArray = new char[height, Width];
        }

        public void FillEmptyArray()
        {
            for (var i = 0; i < FieldArray.GetLength(0); i++)
            {
                for (var j = 0; j < FieldArray.GetLength(1); j++)
                {
                    FieldArray[i, j] = '-';
                }
            }
        }

        public int GetMinCountOfSteps()
        {
            const int minSteps = 20;
            return minSteps * width * height / 600;
        }


        public void SetStartCountOfSteps(int count)
        {
            if (count < GetMinCountOfSteps())
            {
                throw new ArgumentException($"Количество шагов не может быть меньше {GetMinCountOfSteps()}");
            }
            else
            {
                CountOfSteps = count;
            }
        }

        public char[,] GetArrayCopy()
        {
            char[,] copyArray = new char[height, width];
            for (var i = 0; i < FieldArray.GetLength(0); i++)
            {
                for (var j = 0; j < FieldArray.GetLength(1); j++)
                {
                    copyArray[i, j] = FieldArray[i, j];
                }
            }

            return copyArray;
        }

        public bool HavePlaceBool()
        {
            bool result = false;
            for (var j = 0; j <= width - PlayerTurn.RollWidth; j++)
            {
                for (var i = 0; i <= height - PlayerTurn.RollHight; i++)
                {
                    if (FieldArray[i, j] == '-')
                    {
                        result = IsFillPlaceBool(j, i);
                    }

                    if (result)
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        private bool IsFillPlaceBool(int coordinateWidth, int coordinateHight)
        {
            int extremeRightPosition = coordinateWidth + PlayerTurn.RollWidth;
            int extremeDownPosition = coordinateHight + PlayerTurn.RollHight;

            for (var i = coordinateWidth; i < extremeRightPosition; i++)
            {
                for (var j = coordinateHight; j < extremeDownPosition; j++)
                {
                    if (FieldArray[j, i] != '-')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void FillStepOfPlayer()
        {
            int extremeRightPosition = PlayerTurn.CoordinateHeight + PlayerTurn.RollWidth;
            int extremeDownPosition = PlayerTurn.CoordinateWidth + PlayerTurn.RollHight;

            if (extremeRightPosition > width || extremeDownPosition > height)
            {
                throw new ArgumentOutOfRangeException("Фигура вышла за поле игры.");
            }

            char[,] temp = GetArrayCopy();
            for (var i = PlayerTurn.CoordinateHeight; i < extremeRightPosition; i++)
            {
                for (var j = PlayerTurn.CoordinateWidth; j < extremeDownPosition; j++)
                {
                    if (temp[j, i] != '-')
                    {
                        throw new ArgumentException("Позиция занята.");
                    }
                    else
                    {
                        temp[j, i] = PlayerTurn.Symbol;
                    }
                }
            }

            CountOfSteps--;
            FieldArray = temp;
        }

        public int GetCountOfChars(char symbol)
        {
            int count = 0;
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (FieldArray[j, i] == symbol)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
