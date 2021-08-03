
public class PropData : TraitData
{
    public readonly float Range;

    public PropData(string _name, float _range) : base(_name)
    {
        Range = _range;
    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new PropTrait(this, _structure);
    }
}
