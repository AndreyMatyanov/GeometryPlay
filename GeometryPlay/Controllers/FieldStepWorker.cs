using GeometryPlay.Controllers.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.Controllers
{
    class FieldStepWorker : IFieldStepWorker
    {
        public bool HavePlaceBool(Field field)
        {
            bool result = false;
            for (var j = 0; j <= field.FieldArray.GetLength(1) - field.PlayerTurn.RollWidth; j++)
            {
                for (var i = 0; i <= field.FieldArray.GetLength(0) - field.PlayerTurn.RollHeight; i++)
                {
                    if (field.FieldArray[i, j] == '-')
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
                    if (field.FieldArray[j, i] != '-')
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
                    field.FieldArray[i, j] = field.PlayerTurn.Symbol;
                }
            }

            field.PlayerTurn.Record += field.PlayerTurn.RollWidth * field.PlayerTurn.RollHeight;
            field.CountOfSteps--;
        }
    }
}
