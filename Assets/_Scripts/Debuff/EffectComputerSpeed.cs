using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectComputerSpeed : EffectBase
    {
        private float speedMultiplier;

        public EffectComputerSpeed(float duration, float speedAmount, PlayerBase player) 
            : base("Speed", duration, player)
        {
            speedMultiplier = speedAmount;
        }

        public override void ApplyEffect()
        {
            player.computer.SetSpeed(speedMultiplier);
        }

        protected override void OnExpire()
        {
            player.computer.SetSpeed(1);
        }
    }
}