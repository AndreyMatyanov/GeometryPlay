using GeometryPlay.Controllers.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.Controllers
{
    internal class FieldCreater : IFieldCreater
    {
        public Field CreateField(int width, int height)
        {
            if (width >= 20 && height >= 30)
            {
                char[,] field = new char[height, width];
                for (var i = 0; i < field.GetLength(0); i++)
                {
                    for (var j = 0; j < field.GetLength(1); j++)
                    {
                        field[i, j] = '-';
                    }
                }

                return new Field()
                {
                    FieldArray = field
                };
            }
            else
            {
                throw new ArgumentException("Неверные данные о ширине и/или высоте. Минимальная ширина: 20. Максимальная высота: 30.");
            }
        }

        public void FillEmptyArray(Field field)
        {
            for (var i = 0; i < field.FieldArray.GetLength(0); i++)
            {
                for (var j = 0; j < field.FieldArray.GetLength(1); j++)
                {
                    field.FieldArray[i, j] = '-';
                }
            }
        }
    }
}
