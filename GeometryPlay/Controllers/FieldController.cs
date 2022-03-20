using GeometryPlay.Controllers.Interface;
using GeometryPlay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryPlay.Controllers
{
    class FieldController
    {
        public FieldController(IFieldCreater fieldCreater, IFieldStepWorker worker, IFieldStepController stepController)
        {
            FieldCreater = fieldCreater;
            StepWorker = worker;
            StepController = stepController;
        }

        public Field Field { get; set; }
        public IFieldCreater FieldCreater { get; set; }
        public IFieldStepWorker StepWorker { get; set; }
        public IFieldStepController StepController { get; set; }

        public void SetSetings(int width, int height, int countOfSteps)
        {
            Field = FieldCreater.CreateField(width, height);
            StepController.SetStartCountOfSteps(countOfSteps, Field);
        }

        public void SetStep(int coordinateHeight, int coordinateWidth)
        {
            if (coordinateHeight > Field.FieldArray.GetLength(0) || coordinateWidth > Field.FieldArray.GetLength(1) || coordinateWidth < 0 || coordinateHeight < 0)
            {
                throw new ArgumentException("Введены некорректные координаты.");
            }
            StepWorker.FillStepOfPlayer(coordinateHeight - 1, coordinateWidth - 1, Field);
        }

        public void SetCountOfSteps(int count)
        {
            StepController.SetStartCountOfSteps(count, Field);
        }
    }
}
