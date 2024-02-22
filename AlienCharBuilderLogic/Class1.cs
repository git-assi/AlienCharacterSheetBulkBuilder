using iTextSharp.text.pdf;
using System.Data;

namespace AlienCharBuilderLogic
{
    public class Class1
    {
        public void narf()
        {
            var x = new Models.Character();
            x.Name = "Rogers";
            x.Armor = new Models.Armor();
            x.Armor.Name = "Flakvest";
            x.Armor.Rating = 5000;
            x.TinyItems.AddItem("Foto");
            x.TinyItems.AddItem("Zigarette");
            x.TinyItems.AddItem("Zigarette");
            x.TinyItems.AddItem("Zigarette");
            x.TinyItems.AddItem("Zigarette");
            var y = new Factory.CharacterSheet();
            var data = new Dictionary<string, string>();
            y.ReadCharacter(x, data);


            int xx = 1;
        }

    }

      
}