public class Healer : HealthModifier
{
    public override void ApplyModifier() =>
        _health.Heal(_value);
}
