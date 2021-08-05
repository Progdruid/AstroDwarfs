
public class HealthTrait : Trait
{
    public readonly int fullHP;
    private int hp;

    public float GetHP() => hp;

    public override void Tick()
    {

    }

    public void DealDamage (int _dmg)
    {
        hp -= _dmg;
        if (hp <= 0f)
            Str.Kill();
    }

    public void Heal (int _value)
    {
        if (hp == fullHP)
            return;

        hp += _value;
        if (hp >= fullHP)
            hp = fullHP;
    }

    public HealthTrait(HealthData _data, Structure _structure) : base(_structure)
    {
        fullHP = _data.HP;
        hp = fullHP;
    }
}
