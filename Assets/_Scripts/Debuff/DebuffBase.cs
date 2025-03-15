using GJ25.Player;
using UnityEngine;

public abstract class DebuffBase : MonoBehaviour
{
    [SerializeField] protected float duration = 3f;
    [SerializeField] protected float cooldown = 10f;
    [SerializeField] protected bool isActive;
    protected PlayerBase targetPlayer;
    protected bool isOnCooldown;
    
    public virtual void ApplyDebuff(PlayerBase target)
    {
        targetPlayer = target;
        isActive = true;
        CancelInvoke(nameof(RemoveDebuff));
        CancelInvoke(nameof(ResetCooldown));
        Invoke(nameof(RemoveDebuff), duration);
        Invoke(nameof(ResetCooldown), cooldown);
        
        OnDebuffApplied();
        Debug.Log($"{target.name}, {GetType().Name}, {duration}");
    }

    protected virtual void RemoveDebuff()
    {
        OnDebuffRemoved();
        isActive = false;
        targetPlayer = null;
        isOnCooldown = true;
    }

    private void ResetCooldown()
    {
        isOnCooldown = false;
    }

    protected abstract void OnDebuffApplied();
    protected abstract void OnDebuffRemoved();
    
}