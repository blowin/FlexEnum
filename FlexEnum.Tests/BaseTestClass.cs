using System.Collections;
using System.Collections.Generic;

namespace FlexEnum.Tests
{
  public abstract class BaseTestClass : IEnumerable<object[]>
  {
    public abstract IEnumerator<object[]> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    protected static object[] Param(params object[] param)
    {
      return param;
    }
  }
}