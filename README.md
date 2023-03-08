# Sundew.Base

Sundew.Base is a collection of smaller NuGet packages that work on various .NETStandard targets:

## Collections
Contains various Linq style extension methods for collection types suchs IEnumerable, IReadOnlyList etc.
* For, ForEach, ForReverse, IndexOf, ToReadOnly.
* AllOrFailed extension allows seemless conversion from IEnumerable<TItem?> to IEnumerable\<TItem\>.
* ByCardinality extension allows checking whether an IEnumerable\<TItem\> is empty, has a single element or multiple elements.
* Value-Array, List and Dictionary* wrappers for Immutable collections with value semantics. (* Not on NETStandard1.2)

## Disposal
* DisposeAction for wrapping an Action in an IDisposable.
* Disposer provides disposal of a fixed set of IDisposables.
* DisposableState provides an easy way to implement the Dispose(bool) pattern.
* DisposingDictionary allows building a list of IDisposables that supports disposal by a key and otherwise supports disposal in the same order.
* DisposingList allows building a list of IDisposables for disposal in the same order.

IAsyncDisposable is only supported on .NETStandard2.1
## Equality
* ReferenceEqualityComparer compares objects by reference.
* TargetEqualityWeakReference is a weak reference that implements equality based on target equality.

## Initialization
* IInitializable for implementing async initialization logic.
* InitializeAction for wrapping an Action in an IInitializable.
* Initializer provides initialization of IInitializables.
* InitializeFlag for keeping tracking whether initialization is completed.

## Memory
* Buffer allows building arrays
* Split extensions allows Linq style splitting memory in to segments.

## Primitives
* Interval represents an interval of two values.
* Percentage as a value type.
* DateTime provider.
* Result type (R) and Option type (O).

## Text
* AlignedString and AlignAndLimitFormatProvider providers aligning and length limiting string formatting.
* NamedFormatString allows to define a string format using names rather than indices.
* NaturalTextComparer does logical text comparison for all platforms with performance similar to the Windows specific StrCmpLogicalW.
* AppendItems allows joining items into a StringBuilder.

## Threading and Threading.Jobs
* AsyncLazy provides a cancellable async lazy implementation
* AsyncLock provides async locking.
* Flag is an Interlocked.Exchanged based flag.
* CancellableJob is implmentation of a cancellable task.
* ContinusJob is implmentation of a cancellable task that keeps running.

## Timers
* Timer is an easy to use and modify timer.