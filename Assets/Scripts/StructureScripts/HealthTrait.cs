
public class HealthTrait : Trait
{
    public readonly int fullHP;
    private int hp;

    public float GetHP() => hp;

    public override void Tick()
    {
        UnityEngine.Debug.Log("HP: " + hp);
        DealDamage(1);
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

    public HealthTrait(TraitData _data, Structure _structure) : base(_data, _structure)
    {
        fullHP = ((HealthData)_data).HP;
        hp = fullHP;
    }
}
