using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class TinyItems
    {
        [SheetnameAttribute(Sheetname = "Tiny items")]
        public string Items
        {
            get
            {
                string result = "";
                foreach(var item in _items.Keys)
                {
                    int anzahl = _items[item];
                    
                    result += item +( anzahl > 1 ?" x " + anzahl.ToString() : "") + Environment.NewLine;
                }

                return result;
            }
        }

        private Dictionary<string, int> _items { get; set; } = new Dictionary<string, int>();

        public void AddItem(string item)
        {
            if (!_items.ContainsKey(item))
            {
                _items.Add(item, 1);
            }
            else
            {
                _items[item] += 1;
            }

        }
    }
}
