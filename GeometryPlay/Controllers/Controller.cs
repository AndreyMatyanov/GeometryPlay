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
        private readonly Player playerOne = new Player('X');
        private readonly Player playerTwo = new Player('O');
        private FieldController fieldController;

        public void Run()
        {
            view.SayHello();
            view.ShowRules();

            fieldController = new FieldController(new FieldCreater(), new FieldStepWorker(), new FieldStepController());

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
            view.NotificationEnteringFirstPlayerNickname();
            EnterPlayerNickname(playerOne);

            view.NotificationEnteringSecondPlayerNickname();
            EnterPlayerNickname(playerTwo);
        }

        private void EnterPlayerNickname(Player player)
        {
            try
            {
                player.Nickname = Console.ReadLine();
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
                EnterPlayerNickname(player);
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
                }
                else
                {
                    fieldController.Field.CountOfSteps--;
                }

                view.NotificationMadeStep();
                Console.ReadKey();
            }
        }

        private void SetPlayerTurn()
        {
            fieldController.Field.PlayerTurn = PlayerTurn();
            view.ShowPlayerTurn(fieldController.Field.PlayerTurn.Nickname);
        }

        private Player PlayerTurn()
        {
            if (fieldController.Field.CountOfSteps % 2 == 0)
            {
                playerOne.CountOfSteps--;
                return playerOne;
            }
            else
            {
                playerTwo.CountOfSteps--;
                return playerTwo;
            }
        }

        private bool Rolling(bool reroll)
        {
            fieldController.Field.PlayerTurn.RollDice();
            view.ShowRoll(fieldController.Field.PlayerTurn.RollWidth, fieldController.Field.PlayerTurn.RollHeight);

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
            view.ShowRecord(playerOne, playerTwo);
            if (playerOne.Record == playerTwo.Record)
            {
                view.ShowDeadHeat();
            }

            if (playerOne.Record > playerTwo.Record)
            {
                view.ShowWinner(playerOne.Nickname);
            }
            else
            {
                view.ShowWinner(playerTwo.Nickname);
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
            }
        }
    }
}
