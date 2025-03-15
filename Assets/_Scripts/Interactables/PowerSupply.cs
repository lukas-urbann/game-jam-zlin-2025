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
                Debug.Log($"Applying pc speed from {player.name} to: {otherPlayer.name}");
                EffectBase slow = new EffectComputerSpeed(duration, multiplier, otherPlayer);
                otherPlayer.computer.AddDebuff(slow);
                otherPlayer.computer.ToggleMalfunction(true);
            }
        }
    }
}
