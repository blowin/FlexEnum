using System;
using System.Collections.Generic;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public class ToStringClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        var makeParam = new Func<Brace, object[]>(b => Param(b, $"[{b.Value}, {b.Value2}]"));
        
        yield return makeParam(Brace.Start);
        yield return makeParam(Brace.End);
        yield return makeParam(Brace.StartEnd);
        yield return makeParam(Brace.None);
      }
    }
  }
}