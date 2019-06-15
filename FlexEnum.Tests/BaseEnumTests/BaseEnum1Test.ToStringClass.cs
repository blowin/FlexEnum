using System.Collections.Generic;

namespace FlexEnum.Tests.BaseEnumTests
{
  public partial class BaseEnum1Test
  {
    public class ToStringClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(Month.December, Month.December.Value);
        yield return Param(Month.September, Month.September.Value);
        yield return Param(Month.October, Month.October.Value);
        yield return Param(Month.November, Month.November.Value);
      }
    }
  }
}