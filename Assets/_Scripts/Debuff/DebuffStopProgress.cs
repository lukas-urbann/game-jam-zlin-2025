using UnityEngine;
using GJ25.Player;

public class DebuffStopProgress : DebuffBase
{
    private PlayerProgress _targetProgress;
    
    protected override void OnDebuffApplied()
    {
        if (!targetPlayer.TryGetComponent(out _targetProgress))
        {
            enabled = false;
            return;
        }
        _targetProgress.StopProgress();
    }

    protected override void OnDebuffRemoved()
    {
        if (_targetProgress != null)
        {
            _targetProgress.ResumeProgress();
            _targetProgress = null;
        }
    }
}
