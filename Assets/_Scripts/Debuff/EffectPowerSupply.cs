using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectPowerSupply : EffectBase
    {
        private float speedMultiplier;

        public EffectPowerSupply(float duration, float speedAmount, PlayerBase player) 
            : base(BuffNames.POWERSUPPLY, duration, player)
        {
            speedMultiplier = speedAmount;
            base.TrackEffect();
        }

        public override void ApplyEffect()
        {
            player.computer.SetSpeed(speedMultiplier);
        }

        public override void OnExpire()
        {
            player.computer.SetSpeed(1);
        }
    }
}