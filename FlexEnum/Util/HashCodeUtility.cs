using System.Runtime.CompilerServices;

namespace FlexEnum.Util
{
  internal static class HashCodeUtility
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Combine(int h1, int h2)
      => (((h1 << 5) + h1) ^ h2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Combine(int h1, int h2, int h3)
      => Combine(Combine(h1, h2), h3);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Combine(int h1, int h2, int h3, int h4)
      => Combine(Combine(Combine(h1, h2), h3), h4);
  }
}
