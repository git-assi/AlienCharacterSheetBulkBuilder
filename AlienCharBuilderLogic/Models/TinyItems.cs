using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class TinyItem
    {
        public string Name { get; set; } = string.Empty;
        public int count { get; set; } = 0;
    }


    public class TinyItems
    {
        public static TinyItem NewTinyItem(string name)
        {

            return new TinyItem() { Name = name, count = 1 };

        }


        [SheetnameAttribute(Sheetname = "Tiny items")]
        public string Items
        {
            get
            {
                string result = "";
                foreach (var item in _items)
                {
                    int anzahl = item.count;

                    result += item.Name + (anzahl > 1 ? " x " + anzahl.ToString() : "") + Environment.NewLine;
                }

                return result;
            }
        }

        private List<TinyItem> _items { get; set; } = new List<TinyItem>();

        public void AddItem(string name)
        {
            var item = TinyItems.NewTinyItem(name);
            if (!_items.Any(i => i.Name == item.Name))
            {
                _items.Add(item);
            }
            else
            {
                _items.First(i => i.Name == name).count++;
            }

        }
    }
}
