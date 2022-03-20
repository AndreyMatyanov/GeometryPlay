using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;
using System;


namespace GeometryPlay.BLL
{
    class PlayerRoll : IPlayerRoll
    {
        public void RollDice(Player player)
        {
            Random rollRandom = new Random();
            player.RollHeight = rollRandom.Next(1, 7);
            player.RollWidth = rollRandom.Next(1, 7);
        }

        public void SetPlayerTurn(Field field, Player playerOne, Player playerTwo)
        {
            if (field.CountOfSteps % 2 == 0)
            {
                playerOne.CountOfSteps--;
                field.PlayerTurn = playerOne;
            }
            else
            {
                playerTwo.CountOfSteps--;
                field.PlayerTurn = playerTwo;
            }
        }
    }
}
