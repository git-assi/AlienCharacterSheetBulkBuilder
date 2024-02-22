using AlienCharBuilderLogic.Factory;
using AlienCharBuilderLogic.InGameResources.Models;
using AlienCharBuilderLogic.Models;
using iTextSharp.text.pdf;
using System.Data;

namespace AlienCharBuilderLogic
{
    public class Class1
    {
        public static void Narf()
        {

            var fac = new CharacterFactory();
            fac.platoon = "first";

            var plt = new InGameResources.Models.Platoon()
            {
                Lieutenant = new NPC(),
                SecondInCommand = new NPC(),

                SectionA = new Section()
                {
                    APC = new GroundVehicle(),
                    VehicleDriver = fac.CreateCharacter("Driver"),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = fac.CreateCharacter("Pilot"), WeaponOfficer = fac.CreateCharacter("WeaponsOfficer"), },

                    FirstSquad = new Squad() 
                    { 
                        FirstTeam = new Team() {Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Marine") },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Heavy Gunner") }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Marine") },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Medic") }
                    }
                },

                SectionB = new Section()
                {
                    APC = new GroundVehicle(),
                    VehicleDriver = fac.CreateCharacter("Driver"),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = fac.CreateCharacter("Pilot"), WeaponOfficer = fac.CreateCharacter("WeaponsOfficer"), },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Marine") },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Heavy Gunner") }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Marine") },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter("Marine"), Marine2 = fac.CreateCharacter("Tech") }
                    }
                },
            };



            /*var data = new Dictionary<string, string>();
            fac.ReadObjectProperties(newChar, data);
            */
            int xx = 1;
        }

    }


}