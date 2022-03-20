namespace GeometryPlay.Models
{
    class Field
    {
        public int CountOfSteps { get; set; }
        public char[][] FieldArray { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Player PlayerTurn { get; set; }
    }
}
