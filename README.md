# FlexEnum

#### BaseEnum
```c#
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
```c#
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

#### FlexEnum

##### IsDefune
```c#
Assert.Equal(false, Util.FlexEnum.IsDefined<Brace>(null));
Assert.Equal(true, Util.FlexEnum.IsDefined<Brace>(Brace.Start));

var ctor = typeof(Month).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new []{typeof(string)}, null);
var anotherObj = (Month)ctor.Invoke(new []{"NOT ENUM VALUE"});
Assert.Equal(false, Util.FlexEnum.IsDefined<Brace>(anotherObj));
```

##### TryParseTest
```c#
Brace parseVal;
Assert.Equal(false, Util.FlexEnum.TryParse("NOTCONTAIN", out parseVal));
Assert.Equal(true, Util.FlexEnum.TryParse("[1, {]", out parseVal));
```

##### ParseTest
```c#
Assert.Equal(null, Util.FlexEnum.Parse<Brace>("NOTCONTAIN"));
Assert.Equal(Brace.Start, Util.FlexEnum.Parse<Brace>("[1, {]"));
```
#### Flag auto generate value
```c#
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

Assert.Equal(5, StepGenerator1.Step1.Value);
Assert.Equal(6, StepGenerator1.Step2.Value);
Assert.Equal(7, StepGenerator1.Step3.Value);
```

#### Flag value generator value
```c#
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

Assert.Equal(1, StepGenerator2.Step1.Value);
Assert.Equal(2, StepGenerator2.Step2.Value);
Assert.Equal(4, StepGenerator2.Step3.Value);
```
