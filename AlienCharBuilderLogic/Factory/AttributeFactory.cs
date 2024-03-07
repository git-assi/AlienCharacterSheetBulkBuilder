using AlienCharBuilderLogic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace AlienCharBuilderLogic.Factory
{
    internal static class AttributeFactory
    {
        private static readonly Random RandomGen = new();

        internal static void SetCareerAttributeValues(Character newCharacter)
        {
            switch (newCharacter.Career.Name)
            {
                case Constants.Career.MARINE:
                    int tmp = RandomGen.Next(1, 4);
                    newCharacter.Attributes.Strength.CloseCombat = tmp;                    
                    tmp = RandomGen.Next(1, 4);
                    newCharacter.Attributes.Strength.Stamina = tmp;                    
                    tmp = RandomGen.Next(1, 4);                    
                    Debug.Write($"{newCharacter.Name} RangedCombat: {newCharacter.Attributes.Agility.Value} {newCharacter.Attributes.Agility._rangedCombat} {tmp} = ");
                    newCharacter.Attributes.Agility.RangedCombat = tmp;
                    Debug.WriteLine(newCharacter.Attributes.Agility.RangedCombat);
                    break;

                case Constants.Career.PILOT:
                    newCharacter.Attributes.Agility.Piloting = RandomGen.Next(2, 4);
                    newCharacter.Attributes.Wits.Comtech = RandomGen.Next(2, 4);
                    newCharacter.Attributes.Agility.RangedCombat = RandomGen.Next(2, 4);
                    break;

                case Constants.Career.HEAVY_GUNNER:
                    newCharacter.Attributes.Agility.Mobilty = RandomGen.Next(2, 4);
                    newCharacter.Attributes.Strength.Stamina = RandomGen.Next(2, 4);
                    newCharacter.Attributes.Agility.RangedCombat = RandomGen.Next(2, 4);
                    break;

                case Constants.Career.TECH:
                    newCharacter.Attributes.Wits.Comtech = RandomGen.Next(2, 4);
                    newCharacter.Attributes.Strength.HeavyMachinery = RandomGen.Next(2, 4);
                    newCharacter.Attributes.Agility.RangedCombat = RandomGen.Next(2, 4);
                    break;
            }
        }
    }
}
