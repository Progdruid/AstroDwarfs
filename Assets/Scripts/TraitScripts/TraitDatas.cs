using UnityEngine;

public class TraitDatas
{
    public abstract class TraitData
    {
        public abstract Trait CreateThisTrait(Structure _structure);
    }

    public class RenderData : TraitDatas.TraitData
    {
        public readonly Sprite[] Sprites;

        public RenderData(Sprite[] _sprites) => Sprites = _sprites;

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new RenderTrait(this, _structure);
        }
    }

    public class TiledRenderData : TraitDatas.RenderData
    {
        public TiledRenderData(Sprite[] _sprites) : base(_sprites) { }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new TiledRenderTrait(this, _structure);
        }
    }

    public class PropData : TraitDatas.TraitData
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

    public class HealthData : TraitDatas.TraitData
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

    public class ExpanderData : TraitDatas.TraitData
    {
        public readonly float Cooldown;

        public ExpanderData(float _cooldown)
        {
            Cooldown = _cooldown;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new ExpanderTrait(this, _structure);
        }
    }

    public class DiggerData : TraitDatas.TraitData
    {
        public readonly string[] AttackTargets;
        public readonly int DiggingSpeed;
        public readonly float Range;

        public DiggerData(string[] _targets, int _diggingSpeed, float _range)
        {
            AttackTargets = _targets;
            DiggingSpeed = _diggingSpeed;
            Range = _range;
        }

        public override Trait CreateThisTrait(Structure _structure)
        {
            return new DiggerTrait(this, _structure);
        }
    }
}
