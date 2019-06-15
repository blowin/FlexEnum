using System.Collections.Generic;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public class EqClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(Brace.Start, Brace.Start);
        yield return Param(Brace.End, Brace.End);
        yield return Param(Brace.StartEnd, Brace.StartEnd);
        yield return Param(Brace.None, Brace.None);
      }
    }
  }
}