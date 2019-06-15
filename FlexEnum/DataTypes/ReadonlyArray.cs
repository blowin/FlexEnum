using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FlexEnum.DataTypes
{
  public struct ReadonlyArray<T> : IEquatable<ReadonlyArray<T>>, IEnumerable<T>, IEnumerable
  {
    private readonly T[] _arr;

    public int Length
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get
      {
        return _arr.Length;
      }
    }

    public T this[int idx]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get
      {
        return _arr[idx];
      }
    }

    public ReadonlyArray(T[] arr)
    {
      if(arr == null)
        throw new ArgumentNullException(nameof(arr));
        
      this._arr = arr;
    }
    
    public static implicit operator ReadonlyArray<T>(T[] arr)
      => new ReadonlyArray<T>(arr);

    public bool Equals(ReadonlyArray<T> other)
    {
      var lft = _arr;
      var rgt = other._arr;
      if (lft == null || rgt == null)
        return false;

      var sz = Length;
      if (sz != other.Length)
        return false;

      var comparer = EqualityComparer<T>.Default;
      for (var i = 0; i < sz; ++i)
      {
        if (!comparer.Equals(lft[i], rgt[i]))
          return false;
      }
      
      return true;
    }

    public Enumerator GetEnumerator()
    {
      return new Enumerator(ref this);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return new Enumerator(ref this);
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
    
    public override bool Equals(object obj)
    {
      return obj is ReadonlyArray<T> && Equals((ReadonlyArray<T>)obj);
    }

    public override int GetHashCode()
    {
      return (_arr != null ? _arr.GetHashCode() : 0);
    }

    public override string ToString()
    {
      if (_arr == null)
        return string.Empty;
      
      return "[" + string.Join(", ", _arr) + "]";
    }

    public int BinarySearch(T element)
    {
      return Array.BinarySearch(_arr, element);
    }
    
    public struct Enumerator : IEnumerator<T>
    {
      private int _curPos;
      private T[] _items;

      internal Enumerator(ref ReadonlyArray<T> items)
      {
        _items = items._arr;
        _curPos = -1;
      }
      
      public bool MoveNext()
      {
        return ++_curPos < _items.Length;
      }

      public void Reset()
      {
        _curPos = -1;
      }

      public T Current => _items[_curPos];

      object IEnumerator.Current => Current;

      public void Dispose()
      {
      }
    }
  }
}