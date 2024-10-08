namespace AlienCharBuilderLogic.Models
{
    public class Platoon
    {
     
        public string Name { get; set; } = string.Empty;
        public required NPC Lieutenant { get; set; }
        public required NPC SecondInCommand { get; set; }
        public required Section SectionA { get; set; }
        public required Section SectionB { get; set; }
    }

    public class Section
    {
        public required AirVehicle Dropship { get; set; }
        public required FlightCrew Wing { get; set; }
        public required GroundVehicle APC { get; set; }
        public required Character VehicleDriver { get; set; }
        public required Squad FirstSquad { get; set; }
        public required Squad SecondSquad { get; set; }
    }

    public class FlightCrew
    {
        public required Character Pilot { get; set; }
        public required Character WeaponOfficer { get; set; }

    }

    public class Squad
    {
        public required Team FirstTeam { get; set; }
        public required Team SecondTeam { get; set; }

    }

    public class Team
    {
        public required Character Marine1 { get; set; }
        public required Character Marine2 { get; set; }
    }


}
