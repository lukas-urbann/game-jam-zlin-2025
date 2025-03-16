using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectBat : EffectBase
    {
        public EffectBat(float duration, PlayerBase player) 
            : base(BuffNames.BAT, duration, player)
        {
            base.TrackEffect();
        }

        public override void ApplyEffect()
        {
        }

        public override void OnExpire()
        {
        }
    }
}