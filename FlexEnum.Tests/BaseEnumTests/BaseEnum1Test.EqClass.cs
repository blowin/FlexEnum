using System.Collections.Generic;

namespace FlexEnum.Tests.BaseEnumTests
{
  public partial class BaseEnum1Test
  {
    public class EqClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(Month.December, Month.December);
        yield return Param(Month.September, Month.September);
        yield return Param(Month.October, Month.October);
        yield return Param(Month.November, Month.November);
      }
    }
  }
}