public class Attacker : HealthModifier
{
    public override void ApplyModifier() =>
        _health.TakeDamage(_value);
}
