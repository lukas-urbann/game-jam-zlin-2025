using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GJ25.Player
{
    public class PlayerComputer : MonoBehaviour
    {
        public PlayerBase playerOwner;
        [SerializeField] private float currentHealth = 0;
        [SerializeField] private Image healthBarFill;
        
        private const float WinningHealth = 70;
        private const float StartHealth = 0;
        
        public UnityEvent<PlayerBase> onPlayerWin = new();

        public void OnEnable()
        {
            if (playerOwner.TryGetComponent(out PlayerBase player))
            {
                player.computer = this;
            }
        }

        private void Start()
        {
            currentHealth = StartHealth;
        }

        private void Update()
        {
            healthBarFill.fillAmount = GetPercentage();
            currentHealth += 1 * Time.deltaTime;
            healthBarFill.fillAmount = GetPercentage();

            if (currentHealth >= WinningHealth)
            {
                onPlayerWin?.Invoke(playerOwner);
            }
        }
        
        private float GetPercentage()
        {
            return currentHealth / WinningHealth;
        }
    }
}

