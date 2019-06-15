using System.Collections.Generic;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public class NotEqClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        var arr = new[]
        {
          Brace.Start, 
          Brace.End, 
          Brace.StartEnd,
          Brace.None
        };

        for (var i = 0; i < arr.Length; ++i)
        {
          var lft = arr[i];
          for (var j = 0; j < arr.Length; ++j)
          {
            if(i == j)
              continue;

            yield return Param(lft, arr[j]);
          }
        }
      }
    }
  }
}