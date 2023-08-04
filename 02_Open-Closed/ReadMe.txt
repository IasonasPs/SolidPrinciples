IEnumerable:
The IEnumerable interface is the base for all the non-generic collections that can be enumerated.

It exposes a single method GetEnumerator(). This method returns a reference to yet another interface System.Collections.IEnumerator.

The IEnumerator interface in turn provides the ability to iterate through a collection by using the methods MoveNext() and Reset(), and the property Current.

*Here we explore the open-closed principle, by following two different implementations.
*One that violates the principle and one that follows it.
*The Violation occured in the ProductFilter class when we needed to add new functionality such as double filtering for both size and color.
*and we had to directly modificate the class itself.
*
*
*
*
*
*
*
*
*
*
*