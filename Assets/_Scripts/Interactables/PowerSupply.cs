using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class PowerSupply : InteractableObjectBase
    {
        [SerializeField] private float duration = 999999f;
        [SerializeField] private float multiplier = 0f;
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                EffectBase ps = new EffectPowerSupply(duration, multiplier, otherPlayer);
                otherPlayer.computer.AddDebuff(ps);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            if (player.HasForDebuff(BuffNames.BAT)) return false;
            
            return true;
        }
    }
}
