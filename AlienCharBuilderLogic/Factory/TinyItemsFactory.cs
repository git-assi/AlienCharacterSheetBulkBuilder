
using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    public class TinyItemsFactory
    {
        public static TinyItems CreateRandomTinyItems(int anzahl)
        {
            var result = new TinyItems();

            result.AddItem("Foto");
            result.AddItem("Zigarette");
            result.AddItem("Zigarette");
            result.AddItem("Zigarette");
            result.AddItem("Zigarette");

            return result;

        }
    }
}
