using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public float Progress { get; private set; }
    [SerializeField] private float progressSpeed = 0.5f;
    private bool _isStopped;

    public event System.Action<float> OnProgressChanged;

    private void SetProgress(float value)
    {
        if (value < 0f)
            value = 0f;
        else if (value > 1f)
            value = 1f;

        Progress = value;
        OnProgressChanged?.Invoke(Progress);
    }

    public void AddProgress(float amount) => SetProgress(Progress + amount);
    public void RemoveProgress(float amount) => SetProgress(Progress - amount);

    public void StopProgress() => _isStopped = true;
    public void ResumeProgress() => _isStopped = false;
    
}