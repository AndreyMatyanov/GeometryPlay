using GeometryPlay.Models;

namespace GeometryPlay.BLL.Interface
{
    interface IFieldStepWork
    {
        bool HavePlaceBool(Field field);
        void FillStepOfPlayer(int coordinateHeight, int coordinateWidth, Field field);
        bool IsFullField(Field field);
    }
}
