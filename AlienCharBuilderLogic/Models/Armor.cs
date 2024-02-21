namespace AlienCharBuilderLogic.Models
{
    public class Armor
    {
        [SheetnameAttribute(Sheetname = "Armor")]
        public string Name { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = "AR")]
        public int Rating { get; set; }
    }
}
