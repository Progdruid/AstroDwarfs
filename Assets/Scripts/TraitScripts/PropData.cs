
public class PropData : TraitData
{
    public readonly float Range;

    public PropData(float _range)
    {
        Range = _range;
    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new PropTrait(this, _structure);
    }
}
