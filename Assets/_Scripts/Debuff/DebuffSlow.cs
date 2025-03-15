using UnityEngine;

public class DebuffSlow : DebuffBase
{
    [SerializeField] private float slowMultiplier = 0.5f;

    protected override void OnDebuffApplied()
    {
        targetPlayer.SetSpeed(slowMultiplier);
    }

    protected override void OnDebuffRemoved()
    {
        targetPlayer.SetSpeed(targetPlayer.InitialSpeed);
    }
}