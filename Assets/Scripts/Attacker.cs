using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;

    [SerializeField] private Health _target;


    public void Attack()
    {
        _target.TakeDamage(_damage);
    }
}
