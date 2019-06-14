using System;
using FlexEnum.DataTypes;

namespace FlexEnum.Util
{
  public static class FlexEnum
  {
    public static ReadonlyArray<TEnum> GetFields<TEnum>()
      where TEnum : BaseEnum0 => FlexEnumCache<TEnum>.Fields;

    public static bool IsDefined<TEnum>(object hasVal) 
      where TEnum : BaseEnum0
    {
      if (hasVal == null)
        return false;

      if (hasVal.GetType() != typeof(TEnum))
        return false;
      
      var fields = GetFields<TEnum>();
      
      return fields.BinarySearch((TEnum)hasVal) >= 0;
    }
    
    public static bool TryParse<TEnum>(string value, out TEnum val)
      where TEnum : BaseEnum0
    {
      return FlexEnumCache<TEnum>.TryParse(value, out val);
    }
    
    public static TEnum Parse<TEnum>(string value)
      where TEnum : BaseEnum0
    {
      TEnum val;
      FlexEnumCache<TEnum>.TryParse(value, out val);
      return val;
    }
  }
}