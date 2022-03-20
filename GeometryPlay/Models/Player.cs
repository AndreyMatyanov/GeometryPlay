using System;

namespace GeometryPlay.Models
{
    class Player
    {
        public int CountOfSteps { get; set; }
        public bool IsPlayerTurn { get; set; }
        public bool IsRerolling { get; set; }
        public string Nickname { get; set; }
        public int RollWidth { get; set; }
        public int RollHeight { get; set; }
        public int Record { get; set; }
        public char Symbol { get; set; }
    }
}
