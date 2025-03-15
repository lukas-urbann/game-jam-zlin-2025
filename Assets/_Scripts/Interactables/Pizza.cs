using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Pizza : InteractableObjectBase
    {
        [SerializeField] private float duration = 10f;
        [SerializeField] private float multiplier = 3f;
            
        public override void ExtendedInteraction(PlayerBase player)
        {
            if (player == null) return;
            
            Debug.Log($"Applying PC speed effect to {player.name}");
            EffectBase speed = new EffectComputerSpeed(duration, multiplier, player);

            if (player.computer.malfunctionActive)
            {
                player.computer.ResetMalfunction();
            }
            else
            {
                player.computer.AddDebuff(speed);

            }
        }
    }
}

