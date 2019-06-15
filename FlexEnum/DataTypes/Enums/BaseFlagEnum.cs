using FlexEnum.Interfaces;

namespace FlexEnum.DataTypes.Enums
{
  public abstract class BaseFlagEnum<TVal> : BaseEnum<int, TVal>
  {
    protected static int StartValue;
    
    protected BaseFlagEnum(TVal val2, IEnumStepGenerator generator = null) : this(StartValue++, val2, generator)
    {
    }
    
    protected BaseFlagEnum(int id, TVal val2, IEnumStepGenerator generator = null) : base(generator?.NextStep(id) ?? id, val2)
    {
    }

    public static bool operator >(BaseFlagEnum<TVal> lft, BaseFlagEnum<TVal> rgt)
      => lft.Value > rgt.Value;

    public static bool operator <(BaseFlagEnum<TVal> lft, BaseFlagEnum<TVal> rgt)
      => lft.Value > rgt.Value;
    
    public static bool operator >=(BaseFlagEnum<TVal> lft, BaseFlagEnum<TVal> rgt)
      => lft.Value >= rgt.Value;

    public static bool operator <=(BaseFlagEnum<TVal> lft, BaseFlagEnum<TVal> rgt)
      => lft.Value <= rgt.Value;
    
    public static int operator ~(BaseFlagEnum<TVal> lft)
      => ~lft.Value;
    
    public static int operator ^(BaseFlagEnum<TVal> lft, BaseFlagEnum<TVal> rgt)
      => lft.Value ^ rgt.Value;
    
    public static int operator &(BaseFlagEnum<TVal> lft, BaseFlagEnum<TVal> rgt)
      => lft.Value & rgt.Value;
    
    public static int operator |(BaseFlagEnum<TVal> lft, BaseFlagEnum<TVal> rgt)
      => lft.Value | rgt.Value;

    public bool HasFlag(BaseFlagEnum<TVal> val)
    {
      if (val == null)
        return false;
      
      var value = val.Value;
      return (this & value) == value;
    }
  }
}