public class Attacker : HealthInteractor
{
    protected override void InteractHealth() =>
        _health.TakeDamage(_value);
}
