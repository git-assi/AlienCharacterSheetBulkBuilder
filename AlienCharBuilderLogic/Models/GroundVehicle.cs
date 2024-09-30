
namespace AlienCharBuilderLogic.Models
{
    public class GroundVehicle : Vehicle
    {
        
    }
    public class GroundVehicleFactory
    {
        public List<Vehicle> CreateVehicles()
        {
            var result = new List<Vehicle>();
            result.Add(new GroundVehicle() { Name = "M577 Gepanzerter Mannschaftstransporter", Geschwindigkeit = 13, Manoevrierbarkeit = "+1", Panzerung = 3, Passagiere = 8, Rumpf = 8 });
            return result;
        }
    }
}
