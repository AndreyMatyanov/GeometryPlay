using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryPlay.View.Controllers
{
    interface IController
    {
        void Run();

        void SetGameSetting();

        void StartGame();

        void RestartGame();
    }
}
