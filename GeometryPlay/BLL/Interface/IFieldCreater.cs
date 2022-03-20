using GeometryPlay.Models;

namespace GeometryPlay.BLL.Interface
{
    interface IFieldCreater
    {
        Field CreateField(int width, int height);
        void FillEmptyArray(Field field);
    }
}
