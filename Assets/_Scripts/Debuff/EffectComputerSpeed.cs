using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectComputerSpeed : EffectBase
    {
        private float speedMultiplier;

        public EffectComputerSpeed(float duration, float speedAmount, PlayerBase player) 
            : base(BuffNames.COMPUTERSPEED, duration, player)
        {
            speedMultiplier = speedAmount;
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