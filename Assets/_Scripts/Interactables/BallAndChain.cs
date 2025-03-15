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
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                Debug.Log($"Applying SlowDebuff from {player.name} to: {otherPlayer.name}");
                EffectBase slow = new EffectSpeed(duration, multiplier, otherPlayer);
                otherPlayer.AddDebuff(slow);
            }
        }
    }
}
