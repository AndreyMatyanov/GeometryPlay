using GeometryPlay.Models;

namespace GeometryPlay.Controllers.Interface
{
    interface IFieldStepWorker
    {
        bool HavePlaceBool(Field field);

        void FillStepOfPlayer(int coordinateHeight, int coordinateWidth, Field field);
    }
}
