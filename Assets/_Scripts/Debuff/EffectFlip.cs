using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectFlip : EffectBase
    {
        public EffectFlip(float duration, PlayerBase player) 
            : base(BuffNames.FLIP, duration, player)
        {
            UnityEngine.Debug.Log($"flip{player.name},{duration}");
        }

        public override void ApplyEffect()
        {
            UnityEngine.Debug.Log($"apply flip {player.name}");
            player.Controls.FlipControls(true);
        }

        public override void OnExpire()
        {
            UnityEngine.Debug.Log($"Remove flip {player.name}");
            player.Controls.FlipControls(false);
        }
    }
}