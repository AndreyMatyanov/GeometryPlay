using GeometryPlay.Controllers.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.Controllers
{
    class FieldStepController : IFieldStepController
    {
        public void SetStartCountOfSteps(int count, Field field)
        {
            int minCountOfSteps = GetMinCountOfSteps(field);

            if (count < minCountOfSteps)
            {
                throw new ArgumentException($"Количество шагов не может быть меньше {minCountOfSteps}");
            }
            else
            {
                field.CountOfSteps = count;
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
            return minSteps * field.FieldArray.GetLength(0) * field.FieldArray.GetLength(1) / 600;
        }
    }
}
