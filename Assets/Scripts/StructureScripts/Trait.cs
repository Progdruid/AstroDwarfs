
public abstract class Trait : ITickable
{
    public readonly Structure Str;

    public virtual void Tick() { }
    public virtual void OnKill() { }


    public Trait (Structure _structure)
    {
        Str = _structure;
    }
}
