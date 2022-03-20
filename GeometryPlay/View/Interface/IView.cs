using GeometryPlay.Models;

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

        void NotificationNoPlace();

        void NotificationRestartGame();

        void SayHello();

        void ShowErrorMessage(string message);

        void ShowField(char[][] field);

        void ShowRoll(int height, int width);

        void ShowRecord(Player playerOne, Player playerTwo);

        void ShowRules();

        void ShowPlayerTurn(string name);

        void ShowDeadHeat();

        void ShowWinner(string name);

    }
}
