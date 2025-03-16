using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class BaseballBat : InteractableObjectBase
    {
        [SerializeField] private float duration = 999999;
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            if (player == null) return;
            
            EffectBase bat = new EffectBat(duration, player);
            player.AddDebuff(bat);
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            if (player.HasForDebuff(BuffNames.BAT)) return false;
            
            return true;
        }
    }
}

