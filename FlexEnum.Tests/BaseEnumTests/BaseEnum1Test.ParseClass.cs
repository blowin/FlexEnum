using System.Collections.Generic;

namespace FlexEnum.Tests.BaseEnumTests
{
  public partial class BaseEnum1Test
  {
    public class ParseClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(null, "INVALIDSTRING");
        yield return Param(Month.December, Month.December.Value);
        yield return Param(Month.October, Month.October.Value);
        yield return Param(null, "Winter");
        yield return Param(null, "Wint");
      }
    }
  }
}