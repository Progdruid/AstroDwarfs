
public class HealthData : TraitData
{
    public readonly int HP;

    public HealthData(string _name, int _health) : base(_name)
    {
        HP = _health;
    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new HealthTrait(this, _structure);
    }
}
