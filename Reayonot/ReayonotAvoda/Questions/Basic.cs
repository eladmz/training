using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Questions
{
    class Basic
    {
        /**
         * Questions:
         *      1. What is polymorphism?
         *          1.*. What is the difference between polymorphism and inheritance?
         *      2. What is Abstract:
         *          2.a.Method
         *              2.a.* Why not call the class an interface instead?
         *          2.b.Class
         *      3. What is Interface?
         *      4. What is the difference between abstract class and interface?
         *      5. What is protected?
         *      6. What is an internal
         *      7. What is a protected internal?
         *      8. What is a virtual method?
         *          8.*.What is a v-table?
         *          8.*.Why cant a constructor be a virtual function?
         *      9. What is a sealed method?
         *      10. what is an external method?
         * 
         * 
         * 
         * 
         * 
         * Answers:
         * 
         *      1. What is polymorphism?
         *      
         *      polymorphism is the ability to present the same interface for differing underlying forms
         * 
         *      Polymorphism describes a pattern in object oriented programming in which classes have different
         *      functionality while sharing a common interface.
         *      
         *      The beauty of polymorphism is that the code working with the different classes does not need to 
         *      know which class it is using since they’re all used the same way.
         *      
         *      A real world analogy for polymorphism is a button. Everyone knows how to use a button: you 
         *      apply pressure to it. What a button “does,” however, depends on what it is connected to and
         *      the context in which it is used — but the result does not affect how it is used. If your boss
         *      tells you to press a button, you already have all the information needed to perform the task.
         * 
         *      The classic example is the Shape class and all the classes that can inherit from it (square, circle,
         *      dodecahedron, irregular polygon, splat and so on).
         * 
         *      With polymorphism, each of these classes will have different underlying data. A point shape needs only 
         *      two co-ordinates (assuming it's in a two-dimensional space of course). A circle needs a center and radius.
         * 
         *      A square or rectangle needs two co-ordinates for the top left and bottom right corners (and possibly) a rotation. 
         *      An irregular polygon needs a series of lines. And, by making the class responsible for its code as well as its data, 
         *      you can achieve polymorphism. In this example, every class would have its own Draw() function and the client 
         *      code could simply do:
         * 
         *      shape.Draw()
         * 
         *      to get the correct behavior for any shape.
         *      
         *      1.*. What is the difference between polymorphism and inheritance?
         *      
         *      In polymorphism you must create the method - this meens that the method is there but can be different between
         *      classes.
         *      In inheritance you get the method as is - that meens that you get the implementation given to it.
         *      
         *      For example bird chirping - in polymorphism different bird classes would get different sounds and melodies while in
         *      inheritance every bird would sound the same
         * 
         * 
         *      2.a.What is an Abstract Method?
         *      
         *      An abstract method is a virtual method but does not provide implementation of the method. Instead, it is derived
         *      by a non-abstract method and implemented there.
         *      
         *      Abstract methods must be implemented in the deriving sub class and hold no implementation themselves and therfore
         *      simply end in a cemicolon instead of brakets - it is only a method signature (like the methods in an interface).
         *      
         *      An abstract method can only be implemented in an abstract class.
         *      
         *      If you have abstract method, it basically means that the method is unfinished. 
         *      But that also means the whole class is unfinished, so it also has to be abstract.
         *      Or another way to put it: if you had abstract method on a class that wasn't abstract, 
         *      that would mean you had a method that cannot be called. But that means the method is not useful, 
         *      you could remove it and it would all work the same.
         * 
         *      when inmplemented an abstract method must be overriden.
         *      
         *      An abstract method can overide a virtual method to force implementation in the subclass.
         *      
         *      An abstract method cannot be a constructor since it is created after the compilation.
         *      
         *      2.a.* Why not call the class an interface instead?
         *      
         *      When the class is an interface all the methods named in it must be implemented in the inheriting sub-class.
         *      On the other hand when inheriting from a class that is not an interface but contains some abstract methods
         *      The user does not need to implement the non abstract methods and can keep them with their origional implementation.
         *      
         *      2.b What is an Abstract class?
         *      
         *      Abstract classes are classes that may be incomplete and their methods may be implemented later by subclasses.
         * 
         *      When implementing an abstract class, you must implement each abstract (MustOverride) method in that class, 
         *      and each implemented method must receive the same number and type of arguments, and have the same return value, 
         *      as the method specified in the abstract class.
         * 
         *      Abstract classes may or may not include abstract methods
         *      
         *      if a class inheriting from an abstract class does not implement all of its abstract methods it must also be
         *      named abstract.
         *      
         *      3. What is an interface?
         *      
         *      An interface is a class that contains only the method names of methods inheriting classes are forced to implement.
         *      
         *      Implementing an interface allows a class to become more formal about the behavior it promises to provide. 
         *      Interfaces form a contract between the class and the outside world, and this contract is enforced at build 
         *      time by the compiler. If your class claims to implement an interface, all methods defined by that interface 
         *      must appear in its source code before the class will successfully compile.
         *      
         *      Implementing an interface consumes very little CPU, because it's not a class, just a bunch of names, and 
         *      therefore there is no expensive look-up to do. It's great when it matters such as in embedded devices.
         * 
         *      4. What is the difference between abstract class and interface?
         *      
         *      An interface is a contract: the guy writing the interface says, "hey, I accept things looking that way", 
         *      and the guy using the interface says "Ok, the class I write looks that way".
         *      
         *      An interface is an empty shell, there are only the signatures of the methods, which implies that the methods do not have a body. 
         *      The interface can't do anything. It's just a pattern.
         * 
         *      One key difference between abstract classes and interfaces is that a class may implement an unlimited number 
         *      of interfaces, but may inherit from only one abstract (or any other kind of) class.
         *      
         *      A class that is derived from an abstract class may still implement interfaces.
         * 
         *      5. What is a protected method?
         *      
         *      A protected method is an access modifier for a method that can be accessed only by elements of its class and\or
         *      inheriting classes.
         *      
         *      6.What is internal?
         *      
         *      Access is limited to the current assembly.
         *      
         *      7. What is protected internal?
         *      
         *      Access is limited to the current assembly or types derived from the containing class.
         *      
         *      8. What is a virtual method?
         *      
         *      A virtual method is a method that can be overiden in derived classes.
         *      
         *      8.*.What is a v-table?
         *      Whenever a class defines a virtual function (or method), most compilers add a hidden member variable to 
         *      the class which points to an array of pointers to (virtual) functions called the virtual method table 
         *      (VMT or Vtable). These pointers are used at runtime to invoke the appropriate function implementations, 
         *      because at compile time it may not yet be known if the base function is to be called or a derived one 
         *      implemented by a class that inherits from the base class.
         *      
         *      This also answers the question why you only know during runtime what the funciton is going to be - 
         *      Suppose a program contains several classes in an inheritance hierarchy: a superclass, Cat, and two subclasses, 
         *      HouseCat and Lion. Class Cat defines a virtual function named speak, so its subclasses may provide an appropriate 
         *      implementation (e.g. either meow or roar).
         *      When the program calls the speak method on a Cat pointer (which can point to a Cat class, or any subclass of Cat),
         *      the calling code must be able to determine which implementation to call, depending on the actual type of object that
         *      is pointed to. Because the type of object pointed to by the Cat pointer is not determined at compile-time, the 
         *      decision as to which branch to take cannot be decided at compile-time.
         *      
         *      8.*.Why cant a constructor be a virtual function?
         *      When an object written in C# is constructed, what happens is that the initializers run in order from the most 
         *      derived class to the base class, and then constructors run in order from the base class to the most derived class 
         *      (see Eric Lippert's blog for details as to why this is).
         *      Also in .NET objects do not change type as they are constructed, but start out as the most derived type, with the
         *      method table being for the most derived type. This means that virtual method calls always run on the most derived 
         *      type.
         *      When you combine these two facts you are left with the problem that if you make a virtual method call in a 
         *      constructor, and it is not the most derived type in its inheritance hierarchy, that it will be called on a class 
         *      whose constructor has not been run, and therefore may not be in a suitable state to have that method called.
         *      This problem is, of course, mitigated if you mark your class as sealed to ensure that it is the most derived type 
         *      in the inheritance hierarchy - in which case it is perfectly safe to call the virtual method.
         *      
         *      9. What is a sealed method?
         *      
         *      If an instance method declaration includes the sealed modifier, it must also include the override modifier. 
         *      Use of the sealed modifier prevents a derived class from further overriding the method.
         * 
         *      10. What is an external method?
         *      
         *      External methods are implemented externally, typically using a language other than C#. Because an external 
         *      method declaration provides no actual implementation, the method-body of an external method simply consists 
         *      of a semicolon.
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
         */
    }
}
