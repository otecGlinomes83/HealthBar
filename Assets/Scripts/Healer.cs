using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private float _heal = 5;

    public void Heal()
    {
        _health.Heal(_heal);
    }
}
