using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FlexEnum.Util;

namespace FlexEnum.DataTypes.Enums
{
  public abstract class BaseEnum<T, T2> : BaseEnum<T>
  {
    public T2 Value2 { get; }

    protected BaseEnum(T val, T2 val2) : base(val)
    {
      Value2 = val2;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T2(BaseEnum<T, T2> v)
      => v.Value2;

    public override int CompareTo(BaseEnum0 other)
    {
      if (!IsSameType(other))
        return 1;

      var o = (BaseEnum<T, T2>) other;
      var c = Comparer<T>.Default.Compare(Value, o.Value);
      if (c != 0)
        return c;

      return Comparer<T2>.Default.Compare(Value2, o.Value2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(BaseEnum0 other)
    {
      if (!IsSameType(other))
        return false;

      var o = (BaseEnum<T, T2>)other;
      return EqualityComparer<T>.Default.Equals(Value, o.Value) &&
             EqualityComparer<T2>.Default.Equals(Value2, o.Value2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
      return HashCodeUtility.Combine(
        EqualityComparer<T>.Default.GetHashCode(Value),
        EqualityComparer<T2>.Default.GetHashCode(Value2)
      );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
      => $"[{Value?.ToString()}, {Value2?.ToString()}]";
  }
}