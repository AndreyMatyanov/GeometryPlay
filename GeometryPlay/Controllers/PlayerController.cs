using GeometryPlay.BLL.Interface;
using GeometryPlay.Controllers.Interface;
using GeometryPlay.Models;

namespace GeometryPlay.Controllers
{
    class PlayerController : IPlayerController
    {
        public PlayerController(IPlayerCreate playerCreater, IPlayerRoll playerRoll, IPlayersRecords playersRecords)
        {
            PlayerCreater = playerCreater;
            PlayerRoll = playerRoll;
            PlayerRecords = playersRecords;
        }

        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public IPlayerCreate PlayerCreater { get; set; }
        public IPlayerRoll PlayerRoll { get; set; }
        public IPlayersRecords PlayerRecords { get; set; }

        public void SetNickname(string firstPlayerNickname, string secondPlayerNickname)
        {
            PlayerOne = PlayerCreater.CreatePlayer(firstPlayerNickname, 'X');
            PlayerTwo = PlayerCreater.CreatePlayer(secondPlayerNickname, 'O');
        }

        public void SetRoll(Player player)
        {
            PlayerRoll.RollDice(player);
        }
    }
}
