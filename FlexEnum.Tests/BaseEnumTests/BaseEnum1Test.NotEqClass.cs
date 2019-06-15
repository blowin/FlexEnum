using System.Collections.Generic;

namespace FlexEnum.Tests.BaseEnumTests
{
  public partial class BaseEnum1Test
  {
    public class NotEqClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        var arr = new[]
        {
          Month.December, 
          Month.September, 
          Month.October, 
          Month.November
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