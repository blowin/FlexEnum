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

    protected object[] Param(params object[] param)
    {
      return param;
    }
  }
}