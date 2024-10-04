using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class TinyItem
    {
        public string Name { get; set; } = string.Empty;
        public int Anzahl { get; set; } = 0;
    }


    public class TinyItems
    {      
        [SheetnameAttribute(Sheetname = "Tiny items")]
        public string Items
        {
            get
            {
                string result = "";
                foreach (var item in _items)
                {
                    int anzahl = item.Anzahl;

                    result += item.Name + (anzahl > 1 ? " x " + anzahl.ToString() : "") + Environment.NewLine;
                }

                return result;
            }
        }

        private List<TinyItem> _items { get; set; } = new List<TinyItem>();

        public void AddItem(string name)
        {            
            if (!_items.Any(i => i.Name == name))
            {                
                _items.Add(new TinyItem() { Name = name, Anzahl = 1 });
            }
            else
            {
                _items.First(i => i.Name == name).Anzahl++;
            }

        }
    }
}
