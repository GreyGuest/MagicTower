using UnityEngine;

public class Cooldown
{
    private readonly float cooldownSeconds;
    private float lastCastTime;

    public Cooldown(float seconds)
    {
        cooldownSeconds = seconds;
        lastCastTime = -cooldownSeconds;
    }

    public bool IsInProgress()
    {
        return Time.time < lastCastTime + cooldownSeconds;
    }

    public void Start()
    {
        lastCastTime = Time.time;
    }
    
    public float GetRemainingValue()
    {
        var remainingCooldown = lastCastTime + cooldownSeconds - Time.time;
        return remainingCooldown > 0 ? remainingCooldown : 0;
    }
}