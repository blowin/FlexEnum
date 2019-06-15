using System.Collections.Generic;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public class StepGenerator1Class : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(5, StepGenerator1.Step1);
        yield return Param(6, StepGenerator1.Step2);
        yield return Param(7, StepGenerator1.Step3);
      }
    }
  }
}