using GeometryPlay.Models;

namespace GeometryPlay.BLL.Interface
{
    internal interface IPlayersRecords
    {
        string GetWinner(Player playerOne, Player playerTwo);
    }
}
