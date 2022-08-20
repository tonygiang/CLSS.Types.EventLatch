// A part of the C# Language Syntactic Sugar suite.

using System;

namespace CLSS
{
  /// <summary>
  /// Base class of all event latch classes.
  /// </summary>
  public abstract class BaseEventLatch
  {
    /// <summary>
    /// The current count number of the latch.
    /// </summary>
    public virtual int CurrentCount { get; set; }

    /// <summary>
    /// The count number the latch starts at.
    /// </summary>
    public virtual int StartingCount { get; set; }

    /// <summary>
    /// The range for count number within which the latch's condition is met and
    /// will execute the encapsulated event.
    /// </summary>
    public ValueRange<int> ConditionRange = new ValueRange<int>(0, 0);

    public BaseEventLatch(int startingCount) { Reset(startingCount); }

    public BaseEventLatch(int startingCount, ValueRange<int> conditionRange)
    { ConditionRange = conditionRange; Reset(startingCount); }

    /// <summary>
    /// Sets the current count number to the number it initially started at.
    /// </summary>
    public virtual void Reset() { CurrentCount = StartingCount; }

    /// <summary>
    /// Changes the starting count number to the specified number and sets the
    /// current count number to the new starting count.
    /// </summary>
    /// <param name="newStartingCount"></param>
    public virtual void Reset(int newStartingCount)
    { StartingCount = newStartingCount; Reset(); }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action OnConditionMet
      = NoOp.Method;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal()
    {
      --CurrentCount;
      TryCondition();
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition()
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet();
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1> OnConditionMet
      = NoOp.Method<T1>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1)
    {
      --CurrentCount;
      TryCondition(arg1);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2> OnConditionMet
      = NoOp.Method<T1, T2>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3> OnConditionMet
      = NoOp.Method<T1, T2, T3>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9,
        arg10);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9,
          arg10);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9,
        arg10,
        arg11);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9,
          arg10,
          arg11);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9,
        arg10,
        arg11,
        arg12);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9,
          arg10,
          arg11,
          arg12);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9,
        arg10,
        arg11,
        arg12,
        arg13);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9,
          arg10,
          arg11,
          arg12,
          arg13);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13,
      T14 arg14)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9,
        arg10,
        arg11,
        arg12,
        arg13,
        arg14);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13,
      T14 arg14)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9,
          arg10,
          arg11,
          arg12,
          arg13,
          arg14);
    }
  }

  /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : BaseEventLatch
  {
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.OnConditionMet"/>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>;

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int)"/>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"/>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.Signal(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13,
      T14 arg14,
      T15 arg15)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9,
        arg10,
        arg11,
        arg12,
        arg13,
        arg14,
        arg15);
    }

    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.TryCondition(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)"/>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13,
      T14 arg14,
      T15 arg15)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9,
          arg10,
          arg11,
          arg12,
          arg13,
          arg14,
          arg15);
    }
  }

  /// <summary>
  /// A conditional object to aid single-threaded asynchronous code paths in
  /// waiting until multiple operations have completed to execute the next step.
  /// </summary>
  /// <typeparam name="T1">The type of the 1st argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T2">The type of the 2nd argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T3">The type of the 3rd argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T4">The type of the 4th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T5">The type of the 4th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T6">The type of the 6th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T7">The type of the 7th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T8">The type of the 8th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T9">The type of the 9th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T10">The type of the 10th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T11">The type of the 11th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T12">The type of the 12th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T13">The type of the 13th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T14">The type of the 14th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T15">The type of the 15th argument of the event that will
  /// be executed on condition met.</typeparam>
  /// <typeparam name="T16">The type of the 16th argument of the event that will
  /// be executed on condition met.</typeparam>
  public class EventLatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : BaseEventLatch
  {
    /// <summary>
    /// The event that will be executed upon calling Signal and the current
    /// count enters the condition range.
    /// </summary>
    public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> OnConditionMet
      = NoOp.Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>;

    /// <summary>
    /// Initializes a new event latch using the specified starting count number
    /// and default condition range of (0, 0).
    /// </summary>
    /// <param name="startingCount">
    /// <inheritdoc cref="EventLatch{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}.EventLatch(int, ValueRange{int})"
    /// path="/param[@name='startingCount']"/>
    /// </param>
    public EventLatch(int startingCount) : base(startingCount) { }

    /// <summary>
    /// Initializes a new event latch using the specified starting count number
    /// and specified condition range.
    /// </summary>
    /// <param name="startingCount">The starting count of the event latch.
    /// </param>
    /// <param name="conditionRange">The condition range of the event latch.
    /// </param>
    public EventLatch(int startingCount, ValueRange<int> conditionRange)
      : base(startingCount, conditionRange) { }

    /// <summary>
    /// Decrements the current count of the latch by 1. If the current count
    /// afterward is within the latch's condition range, invokes the
    /// OnConditionMet event.
    /// </summary>
    /// <param name="arg1">The 1st argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg2">The 2nd argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg3">The 3rd argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg4">The 4th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg5">The 5th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg6">The 6th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg7">The 7th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg8">The 8th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg9">The 9th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg10">The 10th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg11">The 11th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg12">The 12th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg13">The 13th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg14">The 14th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg15">The 15th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    /// <param name="arg16">The 16th argument for the event that will be invoked
    /// if current count is within condition range after decrement.</param>
    public virtual void Signal(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13,
      T14 arg14,
      T15 arg15,
      T16 arg16)
    {
      --CurrentCount;
      TryCondition(arg1,
        arg2,
        arg3,
        arg4,
        arg5,
        arg6,
        arg7,
        arg8,
        arg9,
        arg10,
        arg11,
        arg12,
        arg13,
        arg14,
        arg15,
        arg16);
    }

    /// <summary>
    /// If the current count
    /// is within the latch's condition range, invokes the
    /// OnConditionMet event.
    /// </summary>
    /// <param name="arg1">The 1st argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg2">The 2nd argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg3">The 3rd argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg4">The 4th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg5">The 5th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg6">The 6th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg7">The 7th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg8">The 8th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg9">The 9th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg10">The 10th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg11">The 11th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg12">The 12th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg13">The 13th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg14">The 14th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg15">The 15th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    /// <param name="arg16">The 16th argument for the event that will be invoked
    /// if current count is within condition range.</param>
    public virtual void TryCondition(T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      T11 arg11,
      T12 arg12,
      T13 arg13,
      T14 arg14,
      T15 arg15,
      T16 arg16)
    {
      if (CurrentCount <= ConditionRange.Max && CurrentCount >= ConditionRange.Min)
        OnConditionMet(arg1,
          arg2,
          arg3,
          arg4,
          arg5,
          arg6,
          arg7,
          arg8,
          arg9,
          arg10,
          arg11,
          arg12,
          arg13,
          arg14,
          arg15,
          arg16);
    }
  }
}
