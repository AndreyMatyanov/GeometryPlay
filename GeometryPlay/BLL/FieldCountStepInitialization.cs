using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.BLL
{
    class FieldCountStepInitialization : IFieldCountStepInitialization
    {
        public void SetStartCountOfSteps(int count, Field field)
        {
            int minCountOfSteps = GetMinCountOfSteps(field);

            if (count >= minCountOfSteps)
            {
                field.CountOfSteps = count;
            }
            else
            {
                throw new ArgumentException($"Количество шагов не может быть меньше {minCountOfSteps}");
            }
        }

        public int GetMinCountOfSteps(int width, int height)
        {
            const int minSteps = 20;
            return minSteps * width * height / 600;
        }

        public int GetMinCountOfSteps(Field field)
        {
            const int minSteps = 20;
            return minSteps * field.FieldArray.Length * field.FieldArray[0].Length / 600;
        }
    }
}
