using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using FlexEnum.DataTypes;
using FlexEnum.DataTypes.Enums;

namespace FlexEnum.Util
{
  internal static class FlexEnumCache<TEnum>
    where TEnum : BaseEnum0
  {
    private static TEnum[] _fields;
    private static SortedList<int, TEnum> _parseValues;

    public static ReadonlyArray<TEnum> Fields => _fields;

    private static void EnsureCreate()
    {
      if(_parseValues != null)
        return;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string value, out TEnum val)
    {
      EnsureCreate();
      return _parseValues.TryGetValue((value ?? string.Empty).GetHashCode(), out val);
    }
  }
}