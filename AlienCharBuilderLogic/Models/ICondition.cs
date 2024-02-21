namespace AlienCharBuilderLogic.Models
{
    public interface ICondition
    {
        public string Name { get; set; }
        public string Sheetname { get; set; }
        public int Value { get; set; }
    }

    public class ValueCondition : ICondition
    {
        public string Name { get; set; } = string.Empty;
        public string Sheetname { get; set; } = string.Empty;
        public int Value { get; set; }
    }
    public class BoolCondition : ICondition
    {
        public string Name { get; set; } = string.Empty;
        public string Sheetname { get; set; } = string.Empty;
        public bool Value { get; set; }
        int ICondition.Value
        {
            get { return (Value ? 1 : 0); }
            set { Value = value > 0; }
        }
    }
}
