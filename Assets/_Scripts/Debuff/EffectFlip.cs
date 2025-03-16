using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectFlip : EffectBase
    {
        public EffectFlip(float duration, PlayerBase player) 
            : base(BuffNames.FLIP, duration, player)
        {
            base.TrackEffect();
        }

        public override void ApplyEffect()
        {
            player.Controls.FlipControls(true);
        }

        public override void OnExpire()
        {
            player.Controls.FlipControls(false);
        }
    }
}