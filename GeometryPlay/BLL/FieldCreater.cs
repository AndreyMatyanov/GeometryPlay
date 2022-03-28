using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.BLL
{
    internal class FieldCreater : IFieldCreater
    {
        public Field CreateField(int width, 
            int height, 
            int counfOfSteps)
        {
            char[][] field = new char[height][];

            for (var i = 0; i < field.Length; i++)
            {
                field[i] = new char[width];

                for (var j = 0; j < field[i].Length; j++)
                {
                    field[i][j] = '-';
                }
            }

            return new Field()
            {
                FieldArray = field,
                CountOfSteps = counfOfSteps
            };
        }

        public Field ResizeField(int countOfSteps)
        {
            const int minHeight = 20;
            const int minWidth = 30;
            const int minCountOfSteps = 20;

            double percentOfCountUpper = (double)countOfSteps / (double)minCountOfSteps;

            if (percentOfCountUpper <= 2.3)
            {
                return CreateField((int)(percentOfCountUpper * minWidth), (int)(percentOfCountUpper * minHeight), countOfSteps);
            }

            else
            {
                throw new ArgumentException($"Слишком большая ширина. Максимальная ширина ввиду размеров консоли: {minWidth * 2.3}");
            }
        }
    }
}
