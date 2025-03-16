using System.Collections.Generic;
using GJ25.Debuff;
using GJ25.Interactables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace GJ25.Player
{
    public class PlayerComputer : InteractableObjectBase
    {
        public PlayerBase playerOwner;
        [SerializeField] private float currentHealth = 0;
        [SerializeField] private Image healthBarFill;
        
        private const float WinningHealth = 120;
        private const float StartHealth = 0;
        
        private float _currentSpeed;
        private float _initialSpeed = 1;

        public GameObject malfunction;
        protected bool HasMalfunction = false;
        public bool malfunctionActive => HasMalfunction;
        
        public float InitialSpeed => _initialSpeed;
        private List<EffectBase> activeEffects = new List<EffectBase>();
        
        public UnityEvent<PlayerBase> onPlayerWin = new();

        public void OnEnable()
        {
            if (playerOwner.TryGetComponent(out PlayerBase player))
            {
                player.computer = this;
            }
        }

        public override void ExtendedInteraction(PlayerBase player)
        {
            if (player != playerOwner) return;

            if (HasMalfunction)
            {
                bool isPlayer1 = player.name.Contains("Red"); // my beloved (sam), ja bych tohle nenapsal dekuju
                
                //tvl
                playerOwner.pcLock = true;
                
                TypingTest.Instance.StartTypingChallenge(isPlayer1, () => {
                    ResetMalfunction();
                    playerOwner.pcLock = false;
                });
            }
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            return true;
        }

        public void ResetMalfunction()
        {
            activeEffects.Clear();
            SetSpeed(_initialSpeed);
            ToggleMalfunction(false);
        }

        private void Start()
        {
            ToggleMalfunction(false);
            currentHealth = StartHealth;
            _currentSpeed = _initialSpeed;
        }
        
        public void RemoveDebuff(string debuffName)
        {
            for (int i = activeEffects.Count - 1; i >= 0; i--)
            {
                if (activeEffects[i].Name == debuffName)
                {
                    activeEffects[i].OnExpire();
                    activeEffects.RemoveAt(i);
                }
            }
        }

        private void Update()
        {
            healthBarFill.fillAmount = GetPercentage();
            currentHealth += _currentSpeed * Time.deltaTime;
            healthBarFill.fillAmount = GetPercentage();

            if (currentHealth >= WinningHealth)
            {
                onPlayerWin?.Invoke(playerOwner);
            }
            
            CheckEffects();
        }

        public void AddValue(float val)
        {
            currentHealth += val;

            if (currentHealth >= WinningHealth)
            {
                onPlayerWin?.Invoke(playerOwner);
            }

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }
        
        private float GetPercentage()
        {
            return currentHealth / WinningHealth;
        }
        
        public void SetSpeed(float multiplier)
        {
            _currentSpeed = _initialSpeed * multiplier;
        }
        
        public void AddDebuff(EffectBase effect)
        {
            switch (effect.Name)
            {
                case BuffNames.POWERSUPPLY:
                    ToggleMalfunction(true);
                    break;
            }
            
            effect.ApplyEffect();
            activeEffects.Add(effect);
        }

        public void ToggleMalfunction(bool toggle)
        {
            HasMalfunction = toggle;
            malfunction.SetActive(toggle);
        }

        private void CheckEffects()
        {
            for (int i = activeEffects.Count - 1; i >= 0; i--)
            {
                if (activeEffects[i].UpdateDebuff(Time.deltaTime))
                {
                    activeEffects.RemoveAt(i);
                }
            }
        }
    }
}

