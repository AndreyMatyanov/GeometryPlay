using GeometryPlay.Models;

namespace GeometryPlay.BLL.Interface
{
    internal interface IPlayerCreate
    {
        Player CreatePlayer(string nickname, char symbol);
    }
}
