﻿
namespace AlienCharBuilderLogic.Models
{
    public abstract class Vehicle
    {
        public string Name { get; set; } = string.Empty;
        public int Passagiere { get; set; } = 0;
        public string Manoevrierbarkeit { get; set; } = string.Empty;
        public int Geschwindigkeit { get; set; } = 0;
        public int Rumpf {  get; set; } = 0;    
        public int Panzerung { get; set; } = 0;

        public List<string> Special { get; set; } = new List<string>() { string.Empty };
    }
}
