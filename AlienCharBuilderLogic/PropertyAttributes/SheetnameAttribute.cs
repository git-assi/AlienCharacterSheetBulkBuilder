namespace AlienCharBuilderLogic.PropertyAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SheetnameAttribute : Attribute
    {
        public string Sheetname { get; set; } = string.Empty;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MinMaxAttribute : Attribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ComplexDataAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class CountableAttribute : Attribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
