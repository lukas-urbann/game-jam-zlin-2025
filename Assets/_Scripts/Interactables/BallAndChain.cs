using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class BallAndChain : InteractableObjectBase
    {
        [SerializeField] private float duration = 8f;
        [SerializeField] private float multiplier = 0.3f;
        private PlayerBase otherPlayer;
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            otherPlayer = PlayerQuery.instance.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                EffectBase slow = new EffectSlow(duration, multiplier, otherPlayer);
                otherPlayer.AddDebuff(slow);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            otherPlayer = PlayerQuery.instance.players.FirstOrDefault(p => p != player);

            if (otherPlayer.HasForDebuff(BuffNames.LAXNESS)) return false;
            if (player.HasForDebuff(BuffNames.BAT)) return false;
            return true;
        }
    }
}
