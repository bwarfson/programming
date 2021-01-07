# 1. The Basics

> Collaborating classes should rely on infrastructure to provide necessary services

**Program to an interface, not an implementation**
- Loose coupling makes code extensible
- Extensibility makes it maintainable

> **DI is nothing more than a technique that enables loose coupling**

**Object Composition**
> To harvest the benefits of extensibility, late binding, and parallel development, you must be able to compose classes into applications. This means that you’ll want to create an application out of individual classes by putting them together, much like plugging electrical appliances together. And, as with electrical appliances, you’ll want to easily
rearrange those classes when new requirements are introduced, ideally, without having to make changes to existing classes. 

> Object Composition is often the primary motivation for introducing DI into an
application. In fact, initially, DI was synonymous with Object Composition

**Interception**
> When we delegate control over Dependencies to a third party, we also
provide the power to modify them before we pass them on to the classes consuming them.

> Interception is an application of the Decorator design pattern

### Summary

- Dependency Injection is a set of software design principles and patterns that enables you to develop loosely coupled code. Loose coupling makes code more maintainable.
- When you have a loosely coupled infrastructure in place, it can be used by anyone and adapted to changing needs and unanticipated requirements without having to make large changes to the application’s code base and its infrastructure.
- Troubleshooting tends to become less taxing because the scope of likely culprits narrows.
- DI enables late binding, which is the ability to replace classes or modules with different ones without the need for the original code to be recompiled.
- DI makes it easier for code to be extended and reused in ways not explicitly planned for, similar to the way you have flexibility when working with electrical plugs and sockets.

# 2. Tightly Coupled

> Every time you add a reference, though, you take on a Dependency.

- To understand how the modules in an application relate to each other, we can draw a graph of the dependencies.

# 3. Loosely Coupled

> When we write software, we prefer to start in the most significant place — the part that has most visibility to our stakeholders. As in Mary’s e-commerce application, this is often the UI. From there, we work our way in, adding more functionality until one feature is done; then we move on to the next. This outside-in technique helps us to focus on
the requested functionality without overengineering the solution.

> The outside-in technique is closely related to the YAGNI principle — “You Aren’t Gonna Need It.” This principle emphasizes that only required features should be implemented, and that the implementation should be as simple as possible.

> Because we practice Test-Driven Development (TDD), we start by writing unit tests as soon as our outside-in approach prompts us to create a new class.

