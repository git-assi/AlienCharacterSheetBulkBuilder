namespace AlienCharBuilderLogic.Models
{
    public class Career
    {
        public Career(string name)
        {
            Name = name;
        }
    
        public string Name { get; private set; } = string.Empty;
    }
}
