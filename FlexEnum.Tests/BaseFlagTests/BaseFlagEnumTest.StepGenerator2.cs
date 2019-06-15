using FlexEnum.DataTypes.Enums;
using FlexEnum.Interfaces;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public sealed class StepGenerator2 : BaseFlagEnum<string>
    {
      public static StepGenerator2 Step1;
      public static StepGenerator2 Step2;
      public static StepGenerator2 Step3;

      static StepGenerator2()
      {
        StartValue = 0;
        var gen = new Generator();
        Step1 = new StepGenerator2(string.Empty, gen);
        Step2 = new StepGenerator2(string.Empty, gen);
        Step3 = new StepGenerator2(string.Empty, gen);
      }
      
      private StepGenerator2(string val2, IEnumStepGenerator enumStepGenerator) 
        : base(val2, enumStepGenerator)
      {
      }
      
      private sealed class Generator : IEnumStepGenerator
      {
        public int NextStep(int curVal)
        {
          return 1 << curVal;
        }
      }
    }
  }
}