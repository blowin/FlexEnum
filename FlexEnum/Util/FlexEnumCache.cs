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
    private static ReadonlyArray<TEnum> _fields;
    private static SortedList<int, TEnum> _parseValues;

    public static ReadonlyArray<TEnum> Fields
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get
      {
        EnsureCreate();
        return _fields;
      }
    }

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
        var fields = new TEnum[staticFields.Length];
        int idx = 0;
        for (var index = 0; index < staticFields.Length; index++)
        {
          var notCastItem = staticFields[index].GetValue(null);
          if (notCastItem is TEnum)
          {
            var item = (TEnum)notCastItem;
            fields[idx] = item;
            _parseValues.Add(item.ToString().GetHashCode(), item);

            idx += 1;
          }

          if (staticFields.Length != idx)
          {
            Array.Resize(ref fields, idx + 1);
          }
        }
        
        Array.Sort(fields);
        _fields = fields;
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