using AlienCharBuilderLogic.Models;
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

            x.Weapons.Add(WeaonFactory.CreateAssaultRifle());

            x.TinyItems.AddItem("Foto");
            x.TinyItems.AddItem("Zigarette");
            x.TinyItems.AddItem("Zigarette");
            x.TinyItems.AddItem("Zigarette");
            x.TinyItems.AddItem("Zigarette");

            x.Attributes.Wits.Value = 2;
            x.Attributes.Wits.Survival = 1;

            x.Attributes.Agility.Value = 2;
            x.Attributes.Agility.Piloting = 1;

            x.Attributes.Strength.Value = 2;
            x.Attributes.Strength.HeavyMachinery = 1;

            x.Attributes.Empathy.Value = 2;
            x.Attributes.Empathy.Manipulation = 1;

            var y = new Factory.CharacterSheet();
            var data = new Dictionary<string, string>();
            y.ReadCharacter(x, data);


            int xx = 1;
        }

    }

      
}