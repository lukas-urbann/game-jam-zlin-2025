using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Beer : InteractableObjectBase
    {
        [SerializeField] private float duration = 10f;

        public override void ExtendedInteraction(PlayerBase player)
        {
            PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                EffectBase flip = new EffectFlip(duration, otherPlayer);
                otherPlayer.AddDebuff(flip);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            if (player.HasForDebuff(BuffNames.FLIP)) return false;

            return true;
        }
    }
}