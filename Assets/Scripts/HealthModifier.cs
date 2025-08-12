using UnityEngine;

public abstract class HealthModifier : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected float _value;

    public abstract void ApplyModifier();
}
