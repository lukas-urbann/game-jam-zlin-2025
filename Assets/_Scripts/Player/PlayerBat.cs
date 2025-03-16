using GJ25.Audio;
using GJ25.Debuff;
using UnityEngine;

namespace GJ25.Player
{
    public class PlayerBat : MonoBehaviour
    {
        public PlayerBase player;
        public Animator anim;
        public BoxCollider hitBox;
        public AudioCall audioCall;

        private void OnEnable()
        {
            player.onInteractPerformed?.AddListener(Swing);
        }

        private void OnDisable()
        {
            player.onInteractPerformed?.RemoveListener(Swing);
        }

        private void Swing()
        {
            anim.SetBool("hit", true);
            hitBox.enabled = true;
            audioCall.PlaySound("batSwing");
        }

        public void StopSwing()
        {
            anim.SetBool("hit", false);
            hitBox.enabled = false;
            
            player.RemoveDebuff(BuffNames.BAT);
        }
    }
}

