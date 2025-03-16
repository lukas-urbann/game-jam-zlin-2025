using System.Collections.Generic;
using UnityEngine;
using GJ25.Player;

namespace GJ25.Debuff
{
    public class EffectTracker : MonoBehaviour
    {
        private Dictionary<string, (float expireTime, PlayerBase player)> activeEffects = new();
        public static EffectTracker Instance { get; private set; }
        [SerializeField] private GameObject comboPrefab;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        public void TrackEffect(string effectName, float duration, PlayerBase player)
        {
            activeEffects[effectName] = (Time.time + duration, player);
            Debug.Log($"{effectName} to {player.name} for {duration}");
            CheckCombos();
        }

        private void Update()
        {
            var expiredEffects = new List<string>();
            foreach (var effect in activeEffects)
            {
                if (Time.time >= effect.Value.expireTime)
                {
                    expiredEffects.Add(effect.Key);
                }
            }
            foreach (var effect in expiredEffects)
            {
                activeEffects.Remove(effect);
                Debug.Log($"{effect} removed");
            }
        }

        private void CheckCombos()
        {
            if (activeEffects.ContainsKey(BuffNames.LAXNESS) && activeEffects.ContainsKey(BuffNames.SLOWNESS))
            {
                Debug.Log($"Combo: slow and gotta go");
                
            }
            if (activeEffects.ContainsKey(BuffNames.POWERSUPPLY) && activeEffects.ContainsKey(BuffNames.COMPUTERSPEED))
            {
                Debug.Log($"Combo: shutdown");
                
            }
            if (activeEffects.ContainsKey(BuffNames.SLOWNESS) && activeEffects.ContainsKey(BuffNames.STUN))
            {
                Debug.Log($"Combo: slow and smashed");
                
            }
            if (activeEffects.ContainsKey(BuffNames.SLOWNESS) && activeEffects.ContainsKey(BuffNames.FLIP))
            {
                Debug.Log($"Combo: tortoise");
                
            }
        }
    }
}