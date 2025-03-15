using UnityEngine;
using GJ25.Player;

public class DebuffFlip : DebuffBase
{

    protected override void OnDebuffApplied()
    {
        if (targetPlayer != null && targetPlayer.TryGetComponent(out PlayerControls opponentControls))
        {
            opponentControls.FlipControls(true);
        }
    }

    protected override void OnDebuffRemoved()
    {
        if (targetPlayer != null && targetPlayer.TryGetComponent(out PlayerControls opponentControls))
        {
            opponentControls.FlipControls(false);
        }
    }
}