namespace recipeapp_backend.Models
{
    public class Instruction
    {
        public int Id { get; set; }
        public string InstructionStep { get; set; }
        public Recipe Recipes { get; set; }
    }
}