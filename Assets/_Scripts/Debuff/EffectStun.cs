using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectStun : EffectBase
    {
        public EffectStun(float duration, PlayerBase player) 
            : base(BuffNames.STUN, duration, player)
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