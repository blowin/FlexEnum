using System;
using System.Collections.Generic;
using System.Reflection;
using FlexEnum.DataTypes;
using FlexEnum.DataTypes.Enums;

namespace FlexEnum.Util
{
  internal static class FlexEnumCache<TEnum>
    where TEnum : BaseEnum0
  {
    private static readonly TEnum[] _fields;
    private static readonly SortedList<int, TEnum> _parseValues;

    public static ReadonlyArray<TEnum> Fields => _fields;
    
    static FlexEnumCache()
    {
      var type = typeof(TEnum);

      var staticFields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
      
      _parseValues = new SortedList<int, TEnum>(staticFields.Length);
      if (staticFields.Length == 0)
      {
        _fields = Array.Empty<TEnum>();
      }
      else
      {
        _fields = new TEnum[staticFields.Length];
        for (var index = 0; index < staticFields.Length; index++)
        {
          var item = (TEnum)staticFields[index].GetValue(null);
          _fields[index] = item;
          _parseValues.Add(item.ToString().GetHashCode(), item);
        }
        
        Array.Sort(_fields);
      }
    }
    
    public static bool TryParse(string value, out TEnum val)
    {
      return _parseValues.TryGetValue((value ?? string.Empty).GetHashCode(), out val);
    }
  }
}