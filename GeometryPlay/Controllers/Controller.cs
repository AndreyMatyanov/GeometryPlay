using Geometry.Models;
using GeometryPlay.View;
using GeometryPlay.View.Controllers;
using GeometryPlay.View.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryPlay.Controllers
{
    public class Controller : IController
    {
        private readonly IView view = new ConsoleView();
        private readonly Player playerOne = new Player('X');
        private readonly Player playerTwo = new Player('O');
        private readonly Field field = new Field();

        public void Run()
        {
            view.SayHello();

            view.ShowRules();

            SetGameSetting();

            StartGame();

            GameRecord();

            RestartGame();
        }

        public void GameRecord()
        {
            int playerOneRecord = field.GetCountOfChars(playerOne.Symbol);
            view.ShowRecord(playerOne.Nickname, playerOneRecord);
            int playerTwoRecord = field.GetCountOfChars(playerTwo.Symbol);
            view.ShowRecord(playerTwo.Nickname, playerTwoRecord);

            if (playerOneRecord == playerTwoRecord)
            {
                view.ShowDeadHeat();
            }

            if (playerOneRecord > playerTwoRecord)
            {
                view.ShowWinner(playerOne.Nickname);
            }
            else
            {
                view.ShowWinner(playerTwo.Nickname);
            }
        }

        public void SetGameSetting()
        {
            view.NotificationEnteringFieldHWidth();
            EnterHeightOfField();

            view.NotificationEnteringFieldHeight();
            EnterWidthOfField();

            field.SetArraySize();
            field.FillEmptyArray();

            view.NotificationEnteringCountOfSteps(field.GetMinCountOfSteps());

            EnterCountOfSteps();

            view.NotificationEnteringFirstPlayerNickname();
            EnterPlayerNickname(playerOne);

            view.NotificationEnteringSecondPlayerNickname();
            EnterPlayerNickname(playerTwo);
        }

        public void StartGame()
        {
            while(field.CountOfSteps != 0)
            {
                Console.Clear();
                view.ShowField(field.FieldArray);
                SetPlayerTurn();

                bool isSkipStep = Rolling(false);
                if (!isSkipStep)
                {
                    SetPlayerStep();
                }
                else
                {
                    field.CountOfSteps--;
                }

                view.NotificationMadeStep();
                Console.ReadKey();
            }
        }

        private void SetPlayerTurn()
        {
            field.PlayerTurn = PlayerTurn();
            view.ShowPlayerTurn(field.PlayerTurn.Nickname);
        }

        private bool Rolling(bool reroll)
        {
            field.PlayerTurn.RollDice();
            view.ShowRoll(field.PlayerTurn.RollWidth, field.PlayerTurn.RollHight);

            if (!field.HavePlaceBool() && !reroll)
            {
                view.NotificationNoPlace(reroll);
                return Rolling(true);
            }
            else if (!field.HavePlaceBool() && reroll)
            {
                view.NotificationNoPlace(reroll);
                return true;
            }
            else
            {
                return false;
            }

        }

        private void SetPlayerStep()
        {
            view.NotificationEnterintCoordinateOfStepWidth();
            EnterCoordinateWidth();

            view.NotificationEnterintCoordinateOfStepHeight();
            EnterCoordinateHight();

            FillStep();
        }

        private void EnterCoordinateWidth()
        {
            try
            {
                field.PlayerTurn.CoordinateHeight = Convert.ToInt32(Console.ReadLine());
            }
            catch (ArgumentOutOfRangeException)
            {
                view.ShowErrorMessage("Ваш ход вышел за рамки поля.");
                EnterCoordinateWidth();
            }
            catch(Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
                EnterCoordinateWidth();
            }
        }

        private void EnterCoordinateHight()
        {
            try
            {
                field.PlayerTurn.CoordinateWidth = Convert.ToInt32(Console.ReadLine());
            }
            catch (ArgumentOutOfRangeException)
            {
                view.ShowErrorMessage("Ваш ход вышел за рамки поля.");
                EnterCoordinateHight();
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
                EnterCoordinateWidth();
            }
        }

        private void FillStep()
        {
            while (true)
            {
                try
                {
                    field.FillStepOfPlayer();
                    break;
                }
                catch (Exception ex)
                {
                    view.ShowErrorMessage(ex.Message);
                    view.NotificationEnterintCoordinateOfStepWidth();
                    EnterCoordinateWidth();
                    view.NotificationEnterintCoordinateOfStepHeight();
                    EnterCoordinateHight();
                }
            }
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

        private Player PlayerTurn()
        {
            if (field.CountOfSteps % 2 == 0)
            {
                playerOne.IsPlayerTurn = true;
                playerTwo.IsPlayerTurn = false;
                playerOne.CountOfSteps--;
                return playerOne;
            }
            else
            {
                playerTwo.IsPlayerTurn = true;
                playerOne.IsPlayerTurn = false;
                playerTwo.CountOfSteps--;
                return playerTwo;
            }
        }

        public void EnterHeightOfField()
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    field.Width = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    view.ShowErrorMessage(ex.Message);
                }
            }
        }

        public void EnterWidthOfField()
        {
            try
            {
                field.Height = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
                EnterWidthOfField();
                
            }
        }

        public void EnterCountOfSteps()
        {
            try
            {
                field.SetStartCountOfSteps(Convert.ToInt32(Console.ReadLine()));
                playerOne.CountOfSteps = field.CountOfSteps / 2;
                playerTwo.CountOfSteps = field.CountOfSteps / 2;
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
                EnterCountOfSteps();
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
