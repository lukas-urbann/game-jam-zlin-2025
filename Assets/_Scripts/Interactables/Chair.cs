using System.Linq;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Chair : InteractableObjectBase
    {
        public void TestChair(PlayerBase playerBase)
        {
            PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != playerBase);
            if(otherPlayer != null) Debug.Log($"Applying debuff from {playerBase.name} to: {otherPlayer.name}");
        }
    }
}