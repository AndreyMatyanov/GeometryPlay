using GeometryPlay.BLL;
using GeometryPlay.Models;
using GeometryPlay.View;
using GeometryPlay.View.Controllers;
using GeometryPlay.View.Interface;
using System;

namespace GeometryPlay.Controllers
{
    public class Controller : IController
    {
        private readonly IView view = new ConsoleView();
        private readonly Player playerOne = new Player();
        private readonly Player playerTwo = new Player();
        private FieldController fieldController;
        private PlayerController playerController;

        public void Run()
        {
            view.SayHello();

            view.ShowRules();

            fieldController = new FieldController(new FieldCreater(), new FieldStepWorker(), new FieldCountStepInitialization());
            playerController = new PlayerController(new PlayerCreater(), new PlayerRoll(), new PlayerRecords());

            Console.Clear();

            EnterGameSetting();

            EnterNickName();

            StartGame();

            GameRecord();

            RestartGame();
        }

        public void EnterGameSetting()
        {
            try
            {
                view.NotificationEnteringFieldHWidth();
                int width = Convert.ToInt32(Console.ReadLine());

                view.NotificationEnteringFieldHeight();
                int height = Convert.ToInt32(Console.ReadLine());

                view.NotificationEnteringCountOfSteps(fieldController.StepController.GetMinCountOfSteps(width, height));
                int countOfSteps = Convert.ToInt32(Console.ReadLine());
                playerOne.CountOfSteps = countOfSteps / 2;
                playerTwo.CountOfSteps = countOfSteps / 2;

                fieldController.SetSetings(width, height, countOfSteps);
            }
            catch (ArgumentException ex)
            {
                view.ShowErrorMessage(ex.Message);

                EnterGameSetting();
            }
        }

        public void EnterNickName()
        {
            try
            {
                view.NotificationEnteringFirstPlayerNickname();
                string firstPlayerNickname = Console.ReadLine();

                view.NotificationEnteringSecondPlayerNickname();
                string secondPlayerNickname = Console.ReadLine();
                playerController.SetNickname(firstPlayerNickname, secondPlayerNickname);
            }
            catch (ArgumentException ex)
            {
                view.ShowErrorMessage(ex.Message);
                EnterNickName();
            }

        }

        public void StartGame()
        {
            while(fieldController.Field.CountOfSteps != 0)
            {
                Console.Clear();
                view.ShowField(fieldController.Field.FieldArray);
                SetPlayerTurn();

                bool isSkipStep = Rolling(false);
                if (!isSkipStep)
                {
                    EnterPlayerStep();
                    view.NotificationMadeStep();
                }
                else if (fieldController.StepWorker.IsFullField(fieldController.Field))
                {
                    view.NotificationNoPlace();
                    break;
                }
                else
                {
                    fieldController.Field.CountOfSteps--;
                }

                Console.ReadKey();
            }
        }

        private void SetPlayerTurn()
        {
            playerController.PlayerRoll.SetPlayerTurn(fieldController.Field, playerController.PlayerOne, playerController.PlayerTwo);

            view.ShowPlayerTurn(fieldController.GetPlayerTurn().Nickname);
        }


        private bool Rolling(bool reroll)
        {
            playerController.SetRoll(fieldController.GetPlayerTurn());

            view.ShowRoll(fieldController.GetPlayerTurn().RollWidth, fieldController.GetPlayerTurn().RollHeight);

            if (!fieldController.StepWorker.HavePlaceBool(fieldController.Field) && !reroll)
            {
                view.NotificationNoPlace(reroll);
                return Rolling(true);
            }
            else if (!fieldController.StepWorker.HavePlaceBool(fieldController.Field) && reroll)
            {
                view.NotificationNoPlace(reroll);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EnterPlayerStep()
        {
            try
            {
                view.NotificationEnterintCoordinateOfStepWidth();
                int coordinateWidth = Convert.ToInt32(Console.ReadLine());

                view.NotificationEnterintCoordinateOfStepHeight();
                int coordinateHeight = Convert.ToInt32(Console.ReadLine());

                fieldController.SetStep(coordinateHeight, coordinateWidth);
            }
            catch (ArgumentOutOfRangeException)
            {
                view.ShowErrorMessage("Ваш ход вышел за рамки поля.");
                EnterPlayerStep();
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);

                EnterPlayerStep();
            }
        }

        public void GameRecord()
        {
            view.ShowRecord(playerController.PlayerOne, playerController.PlayerTwo);
            string winner = playerController.PlayerRecords.GetWinner(playerController.PlayerOne, playerController.PlayerTwo);
            if (winner != string.Empty)
            {
                view.ShowWinner(winner);
            }
            else
            {
                view.ShowDeadHeat();
            }
        }

        public void RestartGame()
        {
            view.NotificationRestartGame();

            ConsoleKeyInfo button = Console.ReadKey();
            if (button.Key == ConsoleKey.NumPad1 || button.KeyChar == '1')
            {
                Run();
            }
            else if (button.Key == ConsoleKey.NumPad2 || button.KeyChar == '2')
            {
                Environment.Exit(0);
            }
            else
            {
                view.ShowErrorMessage("Такой кнопки нет.");
                RestartGame();
            }
        }
    }
}
