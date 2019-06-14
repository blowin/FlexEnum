using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; 
using Xunit;

namespace FlexEnum.Tests
{
  public class BaseEnum1Test
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

    public class NotEqClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        var arr = new[]
        {
          Month.December, 
          Month.September, 
          Month.October, 
          Month.November
        };

        for (var i = 0; i < arr.Length; ++i)
        {
          var lft = arr[i];
          for (var j = 0; j < arr.Length; ++j)
          {
            if(i == j)
              continue;

            yield return Param(lft, arr[j]);
          }
        }
      }
    }
    
    public class EqClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(Month.December, Month.December);
        yield return Param(Month.September, Month.September);
        yield return Param(Month.October, Month.October);
        yield return Param(Month.November, Month.November);
      }
    }
    
    public class IsDefineClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(true, Month.December);
        yield return Param(false, new object());
        yield return Param(true, Month.September);
        yield return Param(true, Month.October);
        yield return Param(true, Month.November);

        
        var ctor = typeof(Month).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new []{typeof(string)}, null);
        
        var anotherObj = (Month)ctor.Invoke(new []{"NOT ENUM VALUE"});
        yield return Param(false, anotherObj);
      }
    }
    
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
    
    public class ToStringClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        yield return Param(Month.December, Month.December.Value);
        yield return Param(Month.September, Month.September.Value);
        yield return Param(Month.October, Month.October.Value);
        yield return Param(Month.November, Month.November.Value);
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
      Month parseVal;
      Assert.Equal(expect, Util.FlexEnum.TryParse<Month>(value, out parseVal));
    }
    
    [Theory]
    [ClassData(typeof(ParseClass))]
    public void ParseTest(Month expect, string value)
    {
      Assert.Equal(expect, Util.FlexEnum.Parse<Month>(value));
    }
  }
}