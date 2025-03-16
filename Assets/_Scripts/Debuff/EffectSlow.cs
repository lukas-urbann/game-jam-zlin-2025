using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectSlow : EffectBase
    {
        private float speedMultiplier;

        public EffectSlow(float duration, float speedAmount, PlayerBase player) 
            : base(BuffNames.SLOWNESS, duration, player)
        {
            speedMultiplier = speedAmount;
        }

        public override void ApplyEffect()
        {
            player.SetSpeed(speedMultiplier);
        }

        public override void OnExpire()
        {
            player.SetSpeed(1);
        }
    }
}