using System.Collections.Generic;

namespace FlexEnum.Tests.BaseEnumTests
{
  public partial class BaseEnum1Test
  {
    public class TryParseClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(false, "INVALIDSTRING");
        yield return Param(true, Month.December.Value);
        yield return Param(true, Month.October.Value);
        yield return Param(false, "Winter");
        yield return Param(false, "Wint");
      }
    }
  }
}