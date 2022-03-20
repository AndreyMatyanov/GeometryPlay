using GeometryPlay.Models;

namespace GeometryPlay.BLL.Interface
{
    internal interface IFieldCountStepInitialization
    {
        void SetStartCountOfSteps(int count, Field field);
        int GetMinCountOfSteps(Field field);
        int GetMinCountOfSteps(int width, int height);
    }
}
