using System.Linq;
using FlexEnum.DataTypes.Enums;
using Xunit;

namespace FlexEnum.Tests.BaseEnumTests
{
  public partial class BaseEnum1Test
  {
    public sealed class Month : BaseEnum<string>
    {
      public static readonly Month September = new Month("Sept");
      public static readonly Month December = new Month("Dec");
      public static readonly Month October = new Month("Octob");
      public static readonly Month November = new Month("Novemb");
      
      private Month(string val) : base(val)
      {
      }
    }

    [Theory]
    [ClassData(typeof(EqClass))]
    public void Eq(Month lft, Month rgt)
    {
      Assert.Equal(lft, rgt);
    }
    
    [Theory]
    [ClassData(typeof(EqClass))]
    public void EqOperator(Month lft, Month rgt)
    {
      Assert.True(lft == rgt);
    }
    
    [Theory]
    [ClassData(typeof(NotEqClass))]
    public void NotEq(Month lft, Month rgt)
    {
      Assert.NotEqual(lft, rgt);
    }
    
    [Theory]
    [ClassData(typeof(NotEqClass))]
    public void NotEqOperator(Month lft, Month rgt)
    {
      Assert.True(lft != rgt);
    }
    
    [Theory]
    [ClassData(typeof(ToStringClass))]
    public void ToStringTest(Month lft, string data)
    {
      Assert.Equal(data, lft.ToString());
    }
    
    [Fact]
    public void GetFieldsTest()
    {
      var arr = new[]
      {
        Month.December, 
        Month.September, 
        Month.October, 
        Month.November
      }.OrderBy(month => month.Value).ToArray();

      var items = Util.FlexEnum.GetFields<Month>().OrderBy(month => month.Value).ToArray();
      
      Assert.Equal(arr, items);
    }
    
    [Theory]
    [ClassData(typeof(IsDefineClass))]
    public void IsDefineTest(bool expect, object has)
    {
      Assert.Equal(expect, Util.FlexEnum.IsDefined<Month>(has));
    }
    
    [Theory]
    [ClassData(typeof(TryParseClass))]
    public void TryParseTest(bool expect, string value)
    {
      Assert.Equal(expect, Util.FlexEnum.TryParse(value, out Month _));
    }
    
    [Theory]
    [ClassData(typeof(ParseClass))]
    public void ParseTest(Month expect, string value)
    {
      Assert.Equal(expect, Util.FlexEnum.Parse<Month>(value));
    }
  }
}