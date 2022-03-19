using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryPlay.View.Interface
{
    interface IView
    {
        void NotificationEnteringFieldHeight();

        void NotificationEnteringFieldHWidth();

        void NotificationEnteringCoorditaneOfStepWidth();

        void NotificationEnteringCoorditaneOfStepHight();

        void NotificationEnteringCountOfSteps(int minCountOfSteps);

        void NotificationEnteringFirstPlayerNickname();

        void NotificationEnteringSecondPlayerNickname();

        void NotificationEnterintCoordinateOfStepWidth();

        void NotificationEnterintCoordinateOfStepHeight();

        void NotificationMadeStep();

        void NotificationNoPlace(bool isRerolled);

        void NotificationRestartGame();

        void SayHello();

        void ShowErrorMessage(string message);

        void ShowField(char[,] field);

        void ShowRoll(int height, int width);

        void ShowRecord(string name, int record);

        void ShowRules();

        void ShowPlayerTurn(string name);

        void ShowDeadHeat();

        void ShowWinner(string name);

    }
}
