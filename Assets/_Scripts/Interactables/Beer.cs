using System.Linq;
using GJ25.Debuff;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Beer : InteractableObjectBase
    {
        [SerializeField] private float duration = 5f;
        [SerializeField] private GameObject modelObject;
        private PlayerBase otherPlayer;

        private void Start()
        {
            if (modelObject == null)
            {
                modelObject = transform.GetChild(0).gameObject;
            }
        }

        public override void ExtendedInteraction(PlayerBase player)
        {
            otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != player);

            if (otherPlayer != null)
            {
                EffectBase flip = new EffectFlip(duration, otherPlayer);
                otherPlayer.AddDebuff(flip);
                modelObject.SetActive(false);
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != player);
            
            if (otherPlayer == null) return false;
            if (otherPlayer.HasForDebuff(BuffNames.FLIP)) return false;
            if (player.HasForDebuff(BuffNames.BAT)) return false;

            return true;
        }
    }
}