using System;

namespace FlexEnum
{
  public abstract class BaseEnum<T, T2> : BaseEnum<T>
  {
    public T2 Value2 { get; }
    protected BaseEnum(T val, T2 val2) : base(val)
    {
      if(val2 == null)
        throw new ArgumentNullException(nameof(val2));
      
      Value2 = val2;
    }
    
    public static implicit operator T2(BaseEnum<T, T2> v)
      => v.Value2;

    public override string ToString()
    {
      return $"[{Value.ToString()}, {Value2.ToString()}]";
    }
  }
}