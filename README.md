# FlexEnum

#### BaseEnum
```
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

Assert.Equal(Month.September, Month.September);
Assert.NotEqual(Month.September, Month.October);
Assert.True(Month.September == Month.September);
Assert.True(Month.September != Month.October);
Assert.Equal("Sept", Month.September);
```

#### BaseFlagEnum
```
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

Assert.Equal(Brace.Start, Brace.Start);
Assert.NotEqual(Brace.Start, Brace.End);
Assert.True(Brace.Start == Brace.Start);
Assert.True(Brace.Start != Brace.End);
Assert.Equal("[1, {]", Brace.Start);
Assert.True(((Brace.Start | Brace.End) & Brace.End) == Brace.End);
Assert.True(Brace.StartEnd.HasFlag(Brace.End));
Assert.False(Brace.StartEnd.HasFlag(Brace.None));
```
