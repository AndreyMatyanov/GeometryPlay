using GeometryPlay.Models;

namespace GeometryPlay.Controllers.Interface
{
    interface IFieldCreater
    {
        Field CreateField(int width, int height);
        void FillEmptyArray(Field field);
    }
}
