using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    internal class GroundVehicleFactory
    {
        private static Dictionary<string, GroundVehicle> _allGroundVehicles = new Dictionary<string, GroundVehicle>();
        public static Dictionary<string, GroundVehicle> AllGroundVehicles
        {
            get
            {
                if (_allGroundVehicles.Count == 0)
                {
                    _allGroundVehicles = CreateAirVehicles();
                }
                return _allGroundVehicles;
            }
        }

        private static Dictionary<string, GroundVehicle> CreateAirVehicles()
        {

            var result = new Dictionary<string, GroundVehicle>
            {
                { Constants.GroundVehicle.TYPE.M577_APC, new GroundVehicle() { Name = Constants.GroundVehicle.TYPE.M577_APC, Geschwindigkeit = 13, Manoevrierbarkeit = "+1", Panzerung = 3, Passagiere = 8, Rumpf = 8 } },                
            };

            return result;
        }
    }
}
