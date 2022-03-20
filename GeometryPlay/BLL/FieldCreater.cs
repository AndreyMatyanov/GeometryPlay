using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.BLL
{
    internal class FieldCreater : IFieldCreater
    {
        public Field CreateField(int width, int height)
        {
            if (width >= 20 && height >= 30)
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
            for (var i = 0; i < field.FieldArray.Length; i++)
            {
                for (var j = 0; j < field.FieldArray[0].Length; j++)
                {
                    field.FieldArray[i][j] = '-';
                }
            }
        }
    }
}
