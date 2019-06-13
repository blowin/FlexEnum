namespace FlexEnum
{
  public abstract class BaseFlagEnum<TVal> : BaseEnum<int, TVal>
  {
    protected BaseFlagEnum(int id, TVal val2) : base(id, val2)
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
      return (this & val) == (int)val;
    }
  }
}