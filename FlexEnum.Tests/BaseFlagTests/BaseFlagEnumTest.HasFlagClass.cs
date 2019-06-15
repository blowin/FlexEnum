using System.Collections.Generic;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public class HasFlagClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        var arr = new[]
        {
          Brace.Start, 
          Brace.End, 
          Brace.None
        };

        for (var i = 0; i < arr.Length; ++i)
        {
          var lft = arr[i];
          for (var j = 0; j < arr.Length; ++j)
          {
            if (i == j)
            {
              yield return Param(lft, lft, true);
            }
            else
            {
              yield return Param(lft, arr[j], false);
            }
          }
        }

        yield return Param(Brace.StartEnd, Brace.Start, true);
        yield return Param(Brace.StartEnd, Brace.End, true);
      }
    }
  }
}