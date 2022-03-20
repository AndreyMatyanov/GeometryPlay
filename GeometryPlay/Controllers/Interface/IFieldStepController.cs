using GeometryPlay.Models;

namespace GeometryPlay.Controllers.Interface
{
    internal interface IFieldStepController
    {
        void SetStartCountOfSteps(int count, Field field);
        int GetMinCountOfSteps(Field field);
        int GetMinCountOfSteps(int width, int height);
    }
}
