using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    public event Action Dead;

    public bool IsAlive => CurrentHealth.Value > 0;

    public ReactiveFloat CurrentHealth { get; private set; } = new ReactiveFloat(default);
    public ReactiveFloat MaxHealth { get; private set; } = new ReactiveFloat(default);

    private void Awake()
    {
        MaxHealth.Value = _maxHealth;
        CurrentHealth.Value = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        if (CurrentHealth.Value < damage)
        {
            CurrentHealth.Value = 0f;
        }
        else
        {
            CurrentHealth.Value -= damage;
        }

        if (IsAlive == false)
        {
            Dead?.Invoke();
            CurrentHealth.Value = _maxHealth;
        }
    }

    public void Heal(float health)
    {
        if (health + CurrentHealth.Value > _maxHealth)
        {
            CurrentHealth.Value = _maxHealth;
        }
        else
        {
            CurrentHealth.Value += health;
        }
    }
}