using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectSpeed : EffectBase
    {
        private float speedMultiplier;

        public EffectSpeed(float duration, float speedAmount, PlayerBase player) 
            : base("Speed", duration, player)
        {
            speedMultiplier = speedAmount;
        }

        public override void ApplyEffect()
        {
            player.SetSpeed(speedMultiplier);
        }

        protected override void OnExpire()
        {
            player.SetSpeed(1);
        }
    }
}