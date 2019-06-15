using System.Collections.Generic;
using System.Reflection;

namespace FlexEnum.Tests.BaseEnumTests
{
  public partial class BaseEnum1Test
  {
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
  }
}