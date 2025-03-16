using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectLaxative : EffectBase
    {
        private float speedMultiplier;

        public EffectLaxative(float duration, float speedAmount, PlayerBase player) 
            : base(BuffNames.LAXNESS, duration, player)
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