using UnityEngine;

public class DebuffCutProgress : DebuffBase
{
    [SerializeField] private float cutAmount = 0.1f;
    private PlayerProgress _targetProgress;
    
    protected override void OnDebuffApplied()
    {
        if (!targetPlayer.TryGetComponent(out _targetProgress))
        {
            enabled = false;
            return;
        }
        _targetProgress.RemoveProgress(cutAmount);
        enabled = false;
    }

    protected override void OnDebuffRemoved()
    {
        _targetProgress = null;
    }
}
