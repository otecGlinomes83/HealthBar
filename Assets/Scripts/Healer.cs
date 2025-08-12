public class Healer : HealthInteractor
{
    protected override void InteractHealth() =>
        _health.Heal(_value);
}
