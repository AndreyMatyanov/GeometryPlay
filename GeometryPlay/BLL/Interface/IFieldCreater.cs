using GeometryPlay.Models;

namespace GeometryPlay.BLL.Interface
{
    interface IFieldCreater
    {
        Field CreateField(int width, int height, int counfOfSteps);
        Field ResizeField(int countOfSteps);
    }
}
