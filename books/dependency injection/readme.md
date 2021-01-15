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

>  Constructor Injection is the act of statically defining the list of required Dependencies by specifying them as parameters to the class’s constructor. 

> **Composition Root** As we discussed in section 1.4.1, we’d like to be able to compose our classes into applications in a way similar to how we plug electrical appliances together. This level of modularity can be achieved by centralizing the creation of our classes into a single place. We
call this location the Composition Root. The Composition Root is located as close as possible to the application’s entry point. In most .NET Core application types, the entry point is the Main method. Inside the Composition Root, you can decide to compose your application manually—that’s using Pure DI—or to delegate it to a DI Container. We’ll discuss Composition Root in more detail in chapter 4.

> The domain model is a plain, vanilla C# library that we add to the solution. This library will contain POCOs and interfaces.

> The principle of programming to interfaces instead of concrete classes is a cornerstone of DI. It’s this principle that lets you replace one concrete implementation with another

> IProductRepository is the interface to the data access layer, returning “raw” Entities from the persistence store. By contrast, IProductService applies business logic, such as the discount in this case, and converts the Entities to a narrower-focused object. 

> following the outside-in principle, we only define the classes and members needed for the task at hand. It’s easier to add functionality to code than it is to remove anything.

> **Entity** An Entity is a term from Domain-Driven Design that covers a domain object that has a long-term identity unrelated to a particular object instance.7 This may sound abstract and theoretical, but it means that an Entity represents an object that lives beyond arbitrary bits in memory. Any .NET object instance has an in-memory address (identity), but an Entity has an identity that lives across process lifetimes. We often use databases and primary keys to identify Entities and ensure that we can persist and read them even if the host computer reboots. The domain object Product is an
Entity because the concept of a product has a longer lifetime than a single process, and we use a product ID to identify it in IProductRepository

> **Dependency Inversion Principle** Much of what we’re trying to accomplish with DI is related to the Dependency Inversion Principle. This principle states that higher-level modules in our applications shouldn’t depend on lower-level modules; instead, modules of both levels should depend on Abstractions.

### Summary
- Refactoring existing applications towards a more maintainable, loosely coupled design is hard. Big rewrites, on the other hand, are often riskier and expensive.
- The use of view models can simplify the view, because the incoming data is shaped specifically for the view.
- Because views are harder to test, the dumber the view, the better. It also simplifies the work of a UI designer who might work on the view.
- When you limit the amount of Volatile Dependencies within the domain layer, you get a higher degree of decoupling, reuse, and Testability.
- When building applications, the outside-in approach facilitates more rapid prototyping, which can shorten the feedback cycle.
- When you want a high degree of modularity in your application, you need to apply the Constructor Injection pattern and build object graphs in the Composition Root, which is located close to the application’s entry point.
- Programming to interfaces is a cornerstone of DI. It allows you to replace, mock, and Intercept a Dependency, without having to make changes to its consumers. When implementation and Abstraction are placed in different assemblies, it enables whole libraries to be replaced.
- Programming to interfaces doesn’t mean that all classes should implement an
interface. Short-lived objects, such as Entities, view models, and DTOs, typically contain no behavior that requires mocking, Interception, decoration, or replacement.
- With respect to DI, it doesn’t matter whether you use interfaces or purely abstract classes. From a general development perspective, as authors, we typically prefer interfaces over abstract classes.
- A reusable library is a library that has clients that aren’t known at compile time. Reusable libraries are typically shipped via NuGet. Libraries that only have callers within the same (Visual Studio) solution aren’t considered to be reusable libraries.
- DI is closely related to the Dependency Inversion Principle. This principle implies that you should program against interfaces, and that a layer must be in control over the interfaces it uses.
- The use of a DI Container can help in making the application’s Composition Root more maintainable, but it won’t magically make tightly coupled code loosely coupled. For an application to become maintainable, it must be designed with DI patterns and techniques in mind.


# 4 Catalog

>  Constructor Injection and Composition Root are by far the most important design patterns, whereas all the other patterns should be treated as fringe cases that can be applied in specialized circumstances.

> design patterns help us talk about how code is structured.

> The main purpose of a design pattern is to provide a detailed and self-contained description of a particular way of attaining a goal—a recipe, if you will. 

> When you write loosely coupled code, you create many classes to create an application. It can be tempting to compose these classes at many different locations in order to create small subsystems, but that limits your ability to Intercept those systems to modify their behavior. Instead, you should compose classes in one single area of your application.

