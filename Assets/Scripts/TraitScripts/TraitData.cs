
public abstract class TraitData
{
    public readonly string Name;

    public abstract Trait CreateThisTrait(Structure _structure);

    public TraitData (string _name)
    {
        Name = _name;
    }
}
