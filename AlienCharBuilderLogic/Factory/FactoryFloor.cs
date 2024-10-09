using AlienCharBuilderLogic.InGameResources;

namespace AlienCharBuilderLogic.Factory
{
    internal class FactoryFloor
    {
        public static CareerResources Careers { get; } = new CareerResources();
        public static ArmourFactory Armours { get; } = new ArmourFactory();
        public static GearResourcesFactory Gears { get; } = new GearResourcesFactory();
        public static NamesFactory Names { get; } = new NamesFactory();
        public static TinyItemsFactory TinyItems { get; } = new TinyItemsFactory();
        
        public static GenericTalentFactory GenericTalents { get; } = new GenericTalentFactory();
        

    }
}
