# Creator
Factory for creating types with public constructors.

Factory is configurable via T4 template, with an arbitrary number of arguments.
Every type contains a cache for a constructor lambda to speed up construction.

Contains 2 types of creators:
- Creator.Create<T,>(object a, object b, ...)
- Creator.Create<T,A,B>(A a, B b)

Inspired by:

https://rogerjohansson.blog/2008/02/28/linq-expressions-creating-objects/
