using GJ25.Debuff;
using GJ25.Player;

namespace GJ25.Interactables
{
    public class Toilet : InteractableObjectBase
    {
        public override void ExtendedInteraction(PlayerBase player)
        {
            if (player == null) return;
            bool isPlayer1 = player.name.Contains("Red"); 

            TypingTest.Instance.StartTypingChallenge(isPlayer1, () => {
                player.RemoveDebuff(BuffNames.LAXNESS);
            });
            
        }

        public override bool ExtendedCondition(PlayerBase player)
        {
            if (player.HasForDebuff(BuffNames.BAT)) return false;

            
            return true;
        }
    }
}

