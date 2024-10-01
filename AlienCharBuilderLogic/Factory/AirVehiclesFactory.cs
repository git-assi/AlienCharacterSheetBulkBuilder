using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    internal class AirVehiclesFactory
    {
        private static Dictionary<string, AirVehicle> _allAirVehicles = new Dictionary<string, AirVehicle>();
        public static Dictionary<string, AirVehicle> AllAirVehicles
        {
            get
            {
                if (_allAirVehicles.Count == 0)
                {
                    _allAirVehicles = CreateAirVehicles();
                }
                return _allAirVehicles;
            }
        }

        private static Dictionary<string, AirVehicle> CreateAirVehicles()
        {

            var result = new Dictionary<string, AirVehicle>
            {
                { Constants.AirVehicles.TYPE.CHEYENNE, new AirVehicle() { Name = Constants.AirVehicles.TYPE.CHEYENNE, Geschwindigkeit = 15, Manoevrierbarkeit = "+2", Panzerung = 4, Passagiere = 10, Rumpf = 7 } },
                { Constants.AirVehicles.TYPE.ATLAS, new AirVehicle() { Name = Constants.AirVehicles.TYPE.ATLAS, Geschwindigkeit = 8, Manoevrierbarkeit = "-", Panzerung = 1, Passagiere = 4, Rumpf = 10 } },
                { Constants.AirVehicles.TYPE.BLACKFLY, new AirVehicle() { Name = Constants.AirVehicles.TYPE.BLACKFLY, Geschwindigkeit = 19, Manoevrierbarkeit = "+1", Panzerung = 2, Passagiere = 8, Rumpf = 5, Special = { Constants.AirVehicles.SPEZIAL.STEALTH } } }
                
            };
            
            return result;
        }

    }
}
