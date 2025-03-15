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
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                Debug.Log($"Applying SlowDebuff");
                EffectBase slow = new EffectSpeed(duration, multiplier, otherPlayer);
                otherPlayer.AddDebuff(slow);
            }
        }
    }
}

