# CLSS.Types.EventLatch

### Problem

Multi-threading environments are not the only places where the need to synchronise actions emerge. Even within single-threaded code, there can be unpredictable runtime conditions that lead to code paths executing in unpredictable order, such as users interacting with the GUI, network requests being received out-of-order or running a spin loop similar to JavaScript's event loop.

In such situations, the parallelization tools in the .NET Base Class Library does not provide a solution, as locking in the same thread will only prevent all other code paths in the same thread from running. In order to ensure some actions will only execute upon the completion of multiple actions executing in unpredictable order, you can typically keep track of some variables paths and manually set and check their values at each of said unpredictable code paths. This approach however can be verbose, requires hard-coding and scales up badly as more conditions emerges.

```
/// Fields accessible from all 3 code paths
public bool Path1Completed = false;
public bool Path2Completed = false;
public bool Path3Completed = false;

void Path1()
{
  // ...
  Path1Completed = true;
  if (Path2Completed && Path3Completed) SubsequentAction();
}

void Path2()
{
  // ...
  Path2Completed = true;
  if (Path1Completed && Path3Completed) SubsequentAction();
}

void Path3()
{
  // ...
  Path3Completed = true;
  if (Path1Completed && Path2Completed) SubsequentAction();
}

void SubsequentAction() { }
```

### Solution

Inspired by Java's [`CountDownLatch`](https://docs.oracle.com/javase/7/docs/api/java/util/concurrent/CountDownLatch.html) class, this package provides the `EventLatch` type that abstracts away the synchronisation logic so that synchronisation logic becomes shorter to write and more expressive to read.

```
using CLSS;

/// Field accessible from all 3 code paths
public EventLatch OnAll3PathsCompleted = new EventLatch(3);

/// Register subsequent action
OnAll3PathsCompleted.OnConditionMet += SubsequentAction;

void Path1()
{
  // ...
  OnAll3PathsCompleted.Signal();
}

void Path2()
{
  // ...
  OnAll3PathsCompleted.Signal();
}

void Path3()
{
  // ...
  OnAll3PathsCompleted.Signal();
}
```

`EventLatch` is constructed using a starting countdown number, which is used to initialized its `CurrentCount` and `StartingCount` properties. By default, the `Signal` method will decrement a latch's `CurrentCount` by 1, then execute its `OnConditionMet` event if `CurrentCount` is 0 afterward. This event is publicly exposed so that you can register/deregister actions to it. The 2 properties `CurrentCount` and `StartingCount` are also publicly exposed to manipulate at will.

`EventLatch` does not automatically reset count when it reaches 0 count or lower. You have to manually call the `Reset` method from a latch to do set the `CurrentCount` property to the same value as the `StartingCount` property. The decision to do this or not is left up to you.

```
using CLSS;

// This enables auto-resetting
OnAll3PathsCompleted.OnConditionMet += OnAll3PathsCompleted.Reset;
// This disables auto-resetting
OnAll3PathsCompleted.OnConditionMet -= OnAll3PathsCompleted.Reset;
```

`OnConditionMet` is initialized to a no-op method as defined in the [`CLSS.Constants.NoOp`](https://www.nuget.org/packages/CLSS.Constants.NoOp) package by default. You will not have to initialize this field yourself or null-check it.

An overload of the `Reset` method takes in a new starting count number, which will set both `CurrentCount` and `StartingCount` to that argument.

```
using CLSS;

OnAll3PathsCompleted.Reset(newStartingCount);
// The above line does the same thing as the following 2 lines
OnAll3PathsCompleted.StartingCount = newStartingCount;
OnAll3PathsCompleted.Reset();
```

You can try to invoke the `OnConditionMet` event with the same condition as `Signal` (current count number must be 0 by default) without decrementing `CurrentCount`.

```
using CLSS;

OnAll3PathsCompleted.CurrentCount = 1;
OnAll3PathsCompleted.TryCondition(); // This line will not invoke OnConditionMet
OnAll3PathsCompleted.CurrentCount = -1;
OnAll3PathsCompleted.TryCondition(); // This line will not either
OnAll3PathsCompleted.CurrentCount = 0;
OnAll3PathsCompleted.TryCondition(); // This line will invoke OnConditionMet
```

EventLatch can be initialized with type parameters. They determine the types of arguments to be passed on to the `OnConditionMet` event upon calling `Signal` or `TryCondition`. The actual values that `OnConditionMet` will receive will be the values passed to the last signal call that moves `CurrentCount` to 0.

#### Advanced Usage

By default, `OnConditionMet` is called by a signal if `CurrentCount` is 0, but this behavior can be changed too. `CurrentCount` will actually be checked against a range of value defined by the `ConditionRange` field of a latch. This field is initialized to (0, 0) by default, but because it is also publicly exposed, you can manipulate its min and max boundary values.

`ConditionRange` is a `ValueRange<int>` - [a CLSS type](https://www.nuget.org/packages/CLSS.Types.ValueRange) that this package depends on.

```
using CLSS;

// This lets the latch continue to execute OnConditionMet on a signal call past 0 count
OnAll3PathsCompleted.ConditionRange = new ValueRange<int>(int.MinValue, 0);
```

`ConditionRange` can also be initialized upon construction as the second optional argument.

```
using CLSS;

// Execute everytime new person joins, starting from the 5th person
EventLatch OnEnoughPeopleJoined = new EventLatch(5, new ValueRange<int>(int.MinValue, 0));
```


**Note**: Unlike most CLSS packages which target minimum .NET Standard 1.0, this package targets minimum .NET Standard 2.0.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).