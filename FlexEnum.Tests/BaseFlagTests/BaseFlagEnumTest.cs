using FlexEnum.DataTypes.Enums;
using Xunit;

namespace FlexEnum.Tests.BaseFlagTests
{
  public partial class BaseFlagEnumTest
  {
    public sealed class Brace : BaseFlagEnum<string>
    {
      public static readonly Brace Start = new Brace(1, "{");
      public static readonly Brace End = new Brace(2, "}");
      public static readonly Brace StartEnd = new Brace(Start | End, "{}");
      public static readonly Brace None = new Brace(int.MinValue, string.Empty);
      
      private Brace(int i, string val) : base(i, val)
      {
      }
    }

    [Theory]
    [ClassData(typeof(EqClass))]
    public void Eq(Brace lft, Brace rgt)
    {
      Assert.Equal(lft, rgt);
    }
    
    [Theory]
    [ClassData(typeof(EqClass))]
    public void EqOperator(Brace lft, Brace rgt)
    {
      Assert.True(lft == rgt);
    }
    
    [Theory]
    [ClassData(typeof(NotEqClass))]
    public void NotEq(Brace lft, Brace rgt)
    {
      Assert.NotEqual(lft, rgt);
    }
    
    [Theory]
    [ClassData(typeof(NotEqClass))]
    public void NotEqOperator(Brace lft, Brace rgt)
    {
      Assert.True(lft != rgt);
    }
    
    [Theory]
    [ClassData(typeof(ToStringClass))]
    public void ToStringTest(Brace lft, string data)
    {
      Assert.Equal(data, lft.ToString());
    }
    
    [Fact]
    public void OperatorAmpersand()
    {
      var val = Brace.Start | Brace.End;
      
      Assert.True((val & Brace.End) == Brace.End);
    }
    
    [Theory]
    [ClassData(typeof(HasFlagClass))]
    public void HasFlag(Brace container, Brace hasFlag, bool res)
    {
      Assert.Equal(res, container.HasFlag(hasFlag));
    }
    
    [Theory]
    [ClassData(typeof(StepGenerator1Class))]
    public void StepGenerator1Test(int value, StepGenerator1 generator)
    {
      Assert.Equal(value, generator.Value);
    }
    
    [Theory]
    [ClassData(typeof(StepGenerator2Class))]
    public void StepGenerator2Test(int value, StepGenerator2 generator)
    {
      Assert.Equal(value, generator.Value);
    }
  }
}