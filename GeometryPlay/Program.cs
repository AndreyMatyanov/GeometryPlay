using GeometryPlay.Controllers;
using GeometryPlay.View.Controllers;
using System;

namespace GeometryPlay
{
    static class Program
    {
        static void Main(string[] args)
        {
            IController controller = new Controller();
            controller.Run();
        }
    }
}
