using GJ25.Player;
using UnityEngine;

namespace GJ25.Debuff
{
    public static class BuffNames
    {
        public const string SLOWNESS = "Slow";
        public const string LAXNESS = "Lax";
        public const string POWERSUPPLY = "Ps";
        public const string COMPUTERSPEED = "ComputerSpeed";
        public const string STUN = "Stun";
        public const string BAT = "Bat";
        public const string FLIP = "Flip";
    }
    
    public abstract class EffectBase
    {
        public string Name { get; protected set; }
        public float Duration { get; protected set; }
        protected float elapsedTime = 0f;
        protected PlayerBase player;

        public EffectBase(string name, float duration, PlayerBase player)
        {
            Name = name;
            Duration = duration;
            this.player = player;
        }

        public virtual void ApplyEffect()
        {
        }
        
        public virtual void TrackEffect()
        {
            EffectTracker.Instance.TrackEffect(Name, Duration, player);
        }
        

        public bool UpdateDebuff(float deltaTime)
        {
            elapsedTime += deltaTime;
            if (elapsedTime >= Duration)
            {
                OnExpire();
                return true;
            }
            return false;
        }

        public virtual void OnExpire()
        {
        }
    }
}