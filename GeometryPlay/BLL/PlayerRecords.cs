using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;

namespace GeometryPlay.BLL
{
    class PlayerRecords : IPlayersRecords
    {
        public string GetWinner(Player playerOne, Player playerTwo)
        {

            if (playerOne.Record > playerTwo.Record)
            {
                return playerOne.Nickname;
            }
            else if (playerOne.Record < playerTwo.Record)
            {
                return playerTwo.Nickname;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
