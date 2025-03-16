using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Virus : InteractableObjectBase
    {
        [SerializeField] private float duration = 10f;
        [SerializeField] private float debuff = -15f;
            
        public override void ExtendedInteraction(PlayerBase player)
        {
            PlayerBase otherPlayer = PlayerQuery.instance.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                otherPlayer.computer.AddValue(debuff);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            if (player.HasForDebuff(BuffNames.BAT)) return false;
            
            return true;
        }
    }
}

