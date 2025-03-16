using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Tablet : InteractableObjectBase
    {
        [SerializeField] private float duration = 10f;
        [SerializeField] private float buff = 8f;
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                otherPlayer.computer.AddValue(buff);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            if (player.HasForDebuff(BuffNames.BAT)) return false;
            
            return true;
        }
    }
}

