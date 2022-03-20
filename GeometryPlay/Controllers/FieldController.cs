using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.Controllers
{
    class FieldController
    {
        public FieldController(IFieldCreater fieldCreater, IFieldStepWorker worker, IFieldCountStepInitialization stepController)
        {
            FieldCreater = fieldCreater;
            StepWorker = worker;
            StepController = stepController;
        }

        public Field Field { get; set; }
        public IFieldCreater FieldCreater { get; set; }
        public IFieldStepWorker StepWorker { get; set; }
        public IFieldCountStepInitialization StepController { get; set; }

        public void SetSetings(int width, int height, int countOfSteps)
        {
            Field = FieldCreater.CreateField(width, height);
            StepController.SetStartCountOfSteps(countOfSteps, Field);
        }

        public void SetStep(int coordinateHeight, int coordinateWidth)
        {
            if (coordinateHeight > Field.FieldArray.Length || coordinateWidth > Field.FieldArray[0].Length || coordinateWidth < 0 || coordinateHeight < 0)
            {
                throw new ArgumentException("Введены некорректные координаты.");
            }

            StepWorker.FillStepOfPlayer(coordinateHeight - 1, coordinateWidth - 1, Field);
        }

        public void SetCountOfSteps(int count)
        {
            StepController.SetStartCountOfSteps(count, Field);
        }

        public Player GetPlayerTurn()
        {
            return Field.PlayerTurn;
        }
    }
}
