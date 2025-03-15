using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Chair : InteractableObjectBase
    {
        public void TestChair()
        {
            Debug.Log("Testing Chair");
        }
        
        public void TestChair(PlayerBase playerBase)
        {
            Debug.Log("Testing .." + playerBase.name);
        }
    }
}