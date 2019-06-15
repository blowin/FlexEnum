using FlexEnum.DataTypes.Enums;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public sealed class StepGenerator1 : BaseFlagEnum<string>
    {
      public static StepGenerator1 Step1;
      public static StepGenerator1 Step2;
      public static StepGenerator1 Step3;

      static StepGenerator1()
      {
        StartValue = 5;
        
        Step1 = new StepGenerator1(string.Empty);
        Step2 = new StepGenerator1(string.Empty);
        Step3 = new StepGenerator1(string.Empty);
      }
      
      private StepGenerator1(string val2) : base(val2)
      {
      }
    }
  }
}