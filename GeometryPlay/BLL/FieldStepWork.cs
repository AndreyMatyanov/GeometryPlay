using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.BLL
{
    class FieldStepWork : IFieldStepWork
    {
        public bool HavePlaceBool(Field field)
        {
            bool result = false;

            for (var j = 0; j <= field.FieldArray[0].Length - field.PlayerTurn.RollWidth; j++)
            {
                for (var i = 0; i <= field.FieldArray.Length - field.PlayerTurn.RollHeight; i++)
                {
                    if (field.FieldArray[i][j] == '-')
                    {
                        result = IsFillPlaceBool(j, i, field);
                    }

                    if (result)
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        private bool IsFillPlaceBool(int coordinateWidth, int coordinateHight, Field field)
        {
            int extremeRightPosition = coordinateWidth + field.PlayerTurn.RollWidth;
            int extremeDownPosition = coordinateHight + field.PlayerTurn.RollHeight;

            for (var i = coordinateWidth; i < extremeRightPosition; i++)
            {
                for (var j = coordinateHight; j < extremeDownPosition; j++)
                {
                    if (field.FieldArray[j][i] != '-')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void FillStepOfPlayer(int coordinateHeight, int coordinateWidth, Field field)
        {
            int extremeRightPosition = coordinateHeight + field.PlayerTurn.RollHeight;
            int extremeDownPosition = coordinateWidth + field.PlayerTurn.RollWidth;
            
            if (!IsFillPlaceBool(coordinateWidth, coordinateHeight, field))
            {
                throw new ArgumentException("Позиция занята.");
            }

            for (var i = coordinateHeight; i < extremeRightPosition; i++)
            {
                for (var j = coordinateWidth; j < extremeDownPosition; j++)
                {
                    field.FieldArray[i][j] = field.PlayerTurn.Symbol;
                }
            }

            field.PlayerTurn.Record += field.PlayerTurn.RollWidth * field.PlayerTurn.RollHeight;
            field.CountOfSteps--;
        }

        public bool IsFullField(Field field)
        {
            for (int i = 0; i < field.FieldArray.Length; i++)
            {
                for (int j = 0; j < field.FieldArray[0].Length; j++)
                {
                    if (field.FieldArray[i][j] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
