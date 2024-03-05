
using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.InGameResources
{
    public class GameResources
    {
        public required List<Talent> Talents { get; set; }

        public required List<Gear> Gear { get; set; }

        public required List<Weapon> Weapons { get; set; }

        public required List<TinyItem> TinyItems { get; set; }
    }
}