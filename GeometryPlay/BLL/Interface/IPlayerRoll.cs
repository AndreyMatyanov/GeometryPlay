using GeometryPlay.Models;

namespace GeometryPlay.BLL.Interface
{
    internal interface IPlayerRoll
    {
        void RollDice(Player player);

        void SetPlayerTurn(Field field, Player playerOne, Player playerTwo);
    }
}
