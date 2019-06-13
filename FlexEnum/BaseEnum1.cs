using System;

namespace FlexEnum
{
#pragma warning disable 660,661
  public abstract class BaseEnum<T>
#pragma warning restore 660,661
  {
    public T Value { get; }

    protected BaseEnum(T val)
    {
      if(val == null)
        throw new ArgumentNullException(nameof(val));
      
      Value = val;
    }
    
    public static implicit operator T(BaseEnum<T> v)
      => v.Value;

    public static bool operator ==(BaseEnum<T> lft, BaseEnum<T> rgt)
      => ReferenceEquals(lft, rgt);

    public static bool operator !=(BaseEnum<T> lft, BaseEnum<T> rgt) 
      => !(lft == rgt);

    protected bool Equals(BaseEnum<T> other)
      => Equals((object)other);

#pragma warning disable 659
    public override bool Equals(object obj)
#pragma warning restore 659
    {
      return !ReferenceEquals(null, obj) && ReferenceEquals(this, obj);
    }

    public override string ToString()
    {
      return Value.ToString();
    }
  }
}