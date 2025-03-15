using GJ25.Player;
using UnityEngine;

namespace GJ25.Debuff
{
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

        public virtual void ApplyEffect() { }

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

        protected virtual void OnExpire()
        {
        }
    }
}