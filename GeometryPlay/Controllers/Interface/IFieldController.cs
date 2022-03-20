
namespace GeometryPlay.Controllers.Interface
{
    interface IFieldController
    {
        public void SetSetings(int width, int height, int countOfSteps);
        public void SetStep(int coordinateHeight, int coordinateWidth);
        public void SetCountOfSteps(int count);
    }
}
