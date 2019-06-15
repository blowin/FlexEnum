using System.Collections.Generic;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public class StepGenerator2Class : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(1, StepGenerator2.Step1);
        yield return Param(2, StepGenerator2.Step2);
        yield return Param(4, StepGenerator2.Step3);
      }
    }
  }
}