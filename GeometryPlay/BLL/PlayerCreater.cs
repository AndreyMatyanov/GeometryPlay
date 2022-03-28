using GeometryPlay.BLL.Interface;
using GeometryPlay.Models;
using System;

namespace GeometryPlay.BLL
{
    class PlayerCreater : IPlayerCreate
    {
        public Player CreatePlayer(string nickname, char symbol)
        {
            if (nickname != string.Empty)
            {
                return new Player()
                {
                    Nickname = nickname,
                    Symbol = symbol
                };
            }
            else
            {
                throw new ArgumentException("Введена пустая строка. Введите nickname!");
            }
        }
    }
}
