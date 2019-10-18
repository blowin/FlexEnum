using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FlexEnum.DataTypes.Enums
{
#pragma warning disable 660,661, 659
  public abstract class BaseEnum<T> : BaseEnum0
#pragma warning restore 660,661, 659
  {
    public T Value { get; }

    protected BaseEnum(T val)
    {
      Value = val;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T(BaseEnum<T> v)
      => v.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(BaseEnum<T> lft, BaseEnum<T> rgt)
      => lft?.Equals(rgt) ?? false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(BaseEnum<T> lft, BaseEnum<T> rgt) 
      => !(lft == rgt);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(BaseEnum0 other)
      => ReferenceEquals(this, other) || (IsSameType(other) && EqualityComparer<T>.Default.Equals(((BaseEnum<T>)other).Value, Value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#pragma warning disable 659
    public override bool Equals(object obj)
#pragma warning restore 659
      => obj is BaseEnum<T> @enum && Equals(@enum);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
      => EqualityComparer<T>.Default.GetHashCode(Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int CompareTo(BaseEnum0 other)
      => IsSameType(other) ? 
        Comparer<T>.Default.Compare(Value, ((BaseEnum<T>) other).Value) : 
        1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
      => Value?.ToString();
  }
}