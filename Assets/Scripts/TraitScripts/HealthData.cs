
public class HealthData : TraitData
{
    public readonly int HP;

    public HealthData(int _health)
    {
        HP = _health;
    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new HealthTrait(this, _structure);
    }
}
