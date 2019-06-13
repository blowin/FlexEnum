using System;
using System.Collections.Generic;
using Xunit;

namespace FlexEnum.Tests
{
  public class BaseFlagEnumTest
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

    public class NotEqClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        var arr = new[]
        {
          Brace.Start, 
          Brace.End, 
          Brace.StartEnd,
          Brace.None
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
        yield return Param(Brace.Start, Brace.Start);
        yield return Param(Brace.End, Brace.End);
        yield return Param(Brace.StartEnd, Brace.StartEnd);
        yield return Param(Brace.None, Brace.None);
      }
    }
    
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
    
    public class HasFlagClass : BaseTestClass
    {
      public override IEnumerator<object[]> GetEnumerator()
      {
        var arr = new[]
        {
          Brace.Start, 
          Brace.End, 
          Brace.None
        };

        for (var i = 0; i < arr.Length; ++i)
        {
          var lft = arr[i];
          for (var j = 0; j < arr.Length; ++j)
          {
            if (i == j)
            {
              yield return Param(lft, lft, true);
            }
            else
            {
              yield return Param(lft, arr[j], false);
            }
          }
        }

        yield return Param(Brace.StartEnd, Brace.Start, true);
        yield return Param(Brace.StartEnd, Brace.End, true);
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
  }
}