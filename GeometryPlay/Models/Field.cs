namespace GeometryPlay.Models
{
    class Field
    {
        public int CountOfSteps { get; set; }
        public char[][] FieldArray { get; set; }
        public Player PlayerTurn { get; set; }
    }
}
