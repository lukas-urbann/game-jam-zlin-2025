using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Laxative : InteractableObjectBase
    {
        [SerializeField] private float duration = 999999f;
        [SerializeField] private float multiplier = 0.5f;
        private PlayerBase otherPlayer;
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            otherPlayer = PlayerQuery.instance.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                EffectBase lax = new EffectLaxative(duration, multiplier, otherPlayer);
                otherPlayer.AddDebuff(lax);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            otherPlayer = PlayerQuery.instance.players.FirstOrDefault(p => p != player);

            if (otherPlayer.HasForDebuff(BuffNames.SLOWNESS)) return false;

            if (player.HasForDebuff(BuffNames.BAT)) return false;
            
            return true;
        }
    }
}

