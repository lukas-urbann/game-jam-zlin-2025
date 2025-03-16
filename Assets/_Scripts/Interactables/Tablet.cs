using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Tablet : InteractableObjectBase
    {
        [SerializeField] private float buff = 8f;
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            if (player != null)
            {
                player.computer.AddValue(buff);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            if (player.HasForDebuff(BuffNames.BAT)) return false;
            
            return true;
        }
    }
}

