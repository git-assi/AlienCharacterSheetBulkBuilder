
namespace AlienCharBuilderLogic.Factory
{
    internal class CareerAttributeFactory
    {
        public CareerAttributeFactory(string career)
        {
            switch(career)
            {
                case Constants.Career.DRIVER:
                    Agility = true;
                    Piloting = true;
                    HeavyMachinery = true;
                    Observation = true;
                    break;
                case Constants.Career.MARINE:
                    Strength = true;
                    CloseCombat = true;
                    RangedCombat = true;
                    Stamina = true;
                    break;
                case Constants.Career.PILOT:
                    Agility = true;
                    Piloting = true;
                    RangedCombat = true;
                    Comtech = true;
                    break;
                case Constants.Career.HEAVY_GUNNER:
                    Strength = true;
                    HeavyMachinery = true;
                    RangedCombat = true;
                    Stamina = true;
                    break;
                case Constants.Career.MEDIC:
                    Empathy = true;
                    Observation = true;
                    MedicalAid = true;
                    Mobilty = true;
                    break;
                case Constants.Career.TECH:
                    Wits = true;
                    Comtech = true;
                    HeavyMachinery = true;
                    Observation = true;
                    break;
                case Constants.Career.WEAPONS_OFFICER:
                    Agility = true;
                    HeavyMachinery = true;
                    RangedCombat = true;
                    Observation = true;
                    break;
                case Constants.Career.OFFICER:
                    Empathy = true;
                    Command = true;
                    Manipulation = true;
                    RangedCombat = true;
                    break;
                case Constants.Career.SERGANT:
                    Strength = true;
                    Command = true;
                    Observation = true;
                    RangedCombat = true;
                    break;

                default:
                    return;
            }
        }

        public bool Wits { get; set; } = false;
        public bool Survival { get; set; } = false;
        public bool Comtech { get; set; } = false;
        public bool Observation { get; set; } = false;

        public bool Agility { get; set; } = false;
        public bool Piloting { get; set; } = false;
        public bool RangedCombat { get; set; } = false;
        public bool Mobilty { get; set; } = false;

        public bool Strength { get; set; } = false;
        public bool HeavyMachinery { get; set; } = false;
        public bool Stamina { get; set; } = false;
        public bool CloseCombat { get; set; } = false;

        public bool Empathy { get; set; } = false;
        public bool Manipulation { get; set; } = false;
        public bool MedicalAid { get; set; } = false;
        public bool Command { get; set; } = false;
    }
}
