using System;
using System.Runtime.CompilerServices;

namespace FlexEnum.DataTypes.Enums
{
  public abstract class BaseEnum0 : IComparable<BaseEnum0>, IEquatable<BaseEnum0>
  {
    public abstract int CompareTo(BaseEnum0 other);
    public abstract bool Equals(BaseEnum0 other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected bool IsSameType<T>(T enumVal)
      where T : BaseEnum0
      => GetType() == enumVal?.GetType();

    public static ReadonlyArray<TEnum> GetFields<TEnum>()
      where TEnum : BaseEnum0 => Util.FlexEnum.GetFields<TEnum>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDefined<TEnum>(object hasVal)
      where TEnum : BaseEnum0 => Util.FlexEnum.IsDefined<TEnum>(hasVal);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse<TEnum>(string value, out TEnum val)
      where TEnum : BaseEnum0 => Util.FlexEnum.TryParse<TEnum>(value, out val);

    public static TEnum Parse<TEnum>(string value)
      where TEnum : BaseEnum0 => Util.FlexEnum.Parse<TEnum>(value);
  }
}