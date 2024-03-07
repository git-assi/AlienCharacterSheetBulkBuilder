using AlienCharBuilderLogic.Models;
using System;
using System.Collections.Generic;
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
                    newCharacter.Attributes.Strength.CloseCombat += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Strength.Stamina += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Agility.RangedCombat += RandomGen.Next(2, 4);
                    break;

                case Constants.Career.PILOT:
                    newCharacter.Attributes.Agility.Piloting += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Wits.Comtech += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Agility.RangedCombat += RandomGen.Next(2, 4);
                    break;

                case Constants.Career.HEAVY_GUNNER:
                    newCharacter.Attributes.Agility.Mobilty += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Strength.Stamina += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Agility.RangedCombat += RandomGen.Next(2, 4);
                    break;

                case Constants.Career.TECH:
                    newCharacter.Attributes.Wits.Comtech += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Strength.HeavyMachinery += RandomGen.Next(2, 4);
                    newCharacter.Attributes.Agility.RangedCombat += RandomGen.Next(2, 4);
                    break;
            }
        }
    }
}
