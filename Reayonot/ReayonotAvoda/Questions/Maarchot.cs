using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Questions
{
    internal class Maarchot
    {
        /**
         * Questions:
         *      1. What is Physical memory?
         *      2. What is Virtual memory? (xtremeio)
         *          2.*. Why is Virtual memory good?
         *          2.*. What is not so good about Virtual memory?
         *          2.a. What is paging?
         *      3. Stack\Heap:
         *          3.*. What is the Stack?
         *          3.*. What is the Heap?
         *              3.*.a. What is the managed heap?
         *      4. Boxing & Unboxing
         *      5.Garbage Collector:
         *          4.*.What is the garbage collector?
         *      6.Why are there different assembly languages?
         *          6.*.What is an assembly language?
         *      
         * 
         * 
         * 
         * Answers:
         *      1. What is Physical memory?
         *      
         *      Physical memory is the RAM (random access memory).
         *      Physical memory is the only memory that is directly accessible to the CPU. CPU reads the instructions 
         *      stored in the physical memory and executes them continuously. The data that is operated will also be 
         *      stored in physical memory in uniform manner (It is stored one after the other and cannot be store randomly).
         *      
         *      2. What is Virtual memory?
         *      
         *      Virtual memory is when the OS places pages in the disk storage (hard disk) instead of the RAM. This is done by mapping
         *      the addresses of the pages stores in the disk storage using a virtual memory table. All the addresses in the
         *      virtual memory table must be sequencial and this allows the data pages in the disk storage to be non sequential.
         *      
         *      Note: paging based virtal memory is not the only type of virtual memory but it is the most common type today.
         *      
         *      The OS uses virtual memory to compensate for lack of RAM.
         *      
         *      The OS uses virtual memory as a memory management technique in which non-contiguous memory is presented 
         *      to software as contiguous memory. If the RAM falls short of memory to accommodate more running processes, 
         *      the OS allocates a portion of your hard drive to act as though it were RAM. That's what is referred to as 
         *      virtual memory.
         *      
         *      Virtual memory is one classification of memory which was created by using the hard disk for simulating 
         *      additional RAM, the addressable space available for the user. Virtual addresses are mapped into real addresses.
         *      
         *      2.*. Why is Virtual memory good?
         *      
         *      It allows to continue running processes even when there is no RAM left to allocate.
         *      
         *      2.*. What is not so good about Virtual memory?
         *      
         *      Its far slower than RAM and is much more of a backup plan just in case of.
         *      In the past when RAM was much more expensive this was a big issue but nowadays RAM is cheap enouph that there
         *      isnt much reason for virtual memory to be active and that is one reason why many programmers limit virtual
         *      memory in the system so that non is used unless its really needed.
         *      
         *      2.a. What is paging?
         *      
         *      Paging is a type of virtual memory -
         *      
         *      it has a different name because there are different types of virtual memory but today its the most common type.
         *      
         *      In paging you split the memory into blocks of equal size (they can be of non equal size but equal size is
         *      much better since it makes the blocks interchangable and accessible in the same way).
         *      
         *      Paging is a memory management technique in which the memory is divided into fixed size pages. A paging
         *      table is created mapping logical addresses to physical addresses and the mmu (memory managment unit)
         *      searches the table to know what to access in the main memory.
         *      
         *      Paging is used for faster access to data. When a program needs a page, it is available in the main memory 
         *      as the OS copies a certain number of pages from your storage device to main memory. 
         *      Paging allows the physical address space of a process to be noncontiguous (not adjacent).
         *      
         *      Paging is a technique used by virtual memory operating systems to help ensure that the data you need is 
         *      available as quickly as possible. 
         *      
         *      In paging each process receives its own logical memory space with its own address space - its own logical
         *      addresses.
         *      
         *      the page descriptors are normally arranged into page tables, and (the important part) you normally have 
         *      a separate set of page tables for each process in the system (and another for the OS kernel itself). 
         *      Having separate page tables for each process means that each process can use the same set of linear addresses, 
         *      but those get mapped to different set of physical addresses as needed. You can also map the same physical 
         *      memory to more than one process by just creating two separate page descriptors (one for each process) that 
         *      contain the same physical address. Most OSes use this so that, for example, if you have two or three copies 
         *      of the same program running, it'll really only have one copy of the executable code for that program in memory 
         *      -- but it'll have two or three sets of page descriptors that point to that same code so all of them can use it 
         *      without making separate copies for each.
         *      
         *      3.Stack & Heap:
         *      A good explenation on stach-heap can be found here:
         *      https://www.simple-talk.com/dotnet/.net-framework/.net-memory-management-basics/
         *      
         *      3.*. What is the Stack?
         *      When a method is called, .NET creates a container (a stack frame) that contains all of the data necessary to 
         *      complete the call, including parameters, locally declared variables and the address of the line of code to 
         *      execute after the method finishes.     
         *      For every method call made in a call tree (i.e. one method that calls another, which calls another… etc.), 
         *      stack containers are stacked on top of each other. When a method completes, its’ container is removed from 
         *      the top of the stack and the execution returns to the next line of code within the calling method (with its 
         *      own stack frame). The frame at the top of the stack is always the one used by the current executing method.
         *      
         *      If an application has multiple threads - each thread will have its own stack.
         *      
         *      Stacks ususaly stores the primitive data types (byte... int... single... double... bool... char... otherly known as
         *      value types).
         *      
         *      Both the stack and the heap are stored in the RAM (Unless Virtual Memory is used but this is already an OS issue
         *      and not managed by the .NET system).
         * 
         *      3.*. What is the Heap?
         *      When a .NET application runs it creates 4 types of heaps:
         *          1.The code heap - stores the actual code
         *          2.The small object heap - stores objects less than 85kb in size
         *          3.The large object heap - stores objects larger than 85kb in size
         *          4.The process heap - ??
         *      Everything on the heap has an address and these adresses are used to track program execution and statuses.
         *      
         *      Heaps store the reference types (Classes, interfaces, delegates, strings, instances of objects).
         *      
         *      When an instance of a reference type is created (usually involving the new keyword), only an object reference is
         *      stored on stack. The actual instance itself is created on the heap, and its’ address held on the stack.
         *      
         *      In this way if two objects are created then two object references will be added to the stack each pointing to a
         *      different object (with its actual data) stored in the heap.
         *      On the other hand if One object is created and passed by reference then two object references will be created
         *      on the stack where each will point to a the same object in the heap.
         *      
         *      4. Boxing & Unboxing:
         *      Boxing is when you convert a value type into an object type and unboxing is converting an object type into
         *      a value type.
         *      When the CLR boxes a value type, it wraps the value inside a System.Object and stores it on the managed heap.
         *      Unboxing extracts the value type from the object.
         *      
         *      In general boxing creates a new object that is stored in the heap with an object reference in the stack wheras
         *      unboxing takes the onject from the heap and stores it (after typecasting) as a value type in the stack.
         *      
         *      5. Garbage Collector:
         *      5.*. What is the garbage collector?
         *      
         *      The garbage collector is an automatic memory manager that runs on the CLR (common language runtime).
         *      The main responsebilities of the garbage collector are:
         *          1. Automatically managing memory - allowing you to not have to deal with freeing memory
         *          2. Allocating object efficiently on the managed heap.
         *          3. Reclaims object that are no longer being used.
         *          4. Making sure object can impede on other objects memories (this can happen in c++ for instance where
         *          an object takes up memory in sections that are also used by other objects).
         *          
         *      
         *      The garbage collector has object trees where it knows what memory is used by what process (for example a method)
         *      In this way when a process ends the garbage collection can mark it and its child objects as no longer in use and
         *      collect their memory.
         *      
         *      The garbage collection has three levels:
         *      1. Generation 0 - All new objects that have just not been created
         *      2. Generation 1 - 
         *      3. Generation 2 - Includes onject in the large object heap that are not likely to be deleted anytime soon. This
         *      is also done this way because it takes a lot of power to collect these objects
         *      
         *      Every once in a while a garbage collection is done - this is done by starting from the root and going over the
         *      objects and marking all the objects that cannot be reached (those that are connected, being used, not used and
         *      in this way so on), What is being used - the survivors - are sent to generation 1, those that do not survived are
         *      deleted (most of the generation 0 are deleted during this first round).
         *      In addition the garbage collector reduces empty sections in the stack heap to make sure everything is compact as
         *      it can be - this does cost time during the garbage collection process but makes it easier to access on all further
         *      function later on.
         *      The same goes for generation 1 - every once in a while the garbage collector goes over generation 1, what isnt used
         *      is deleted and what is is passed to generation 2 where it is likely to stay until the end of the program.
         *      
         *      When the garbage collection cycle runs it stops all other functions - it cannot be controlled when the garbage
         *      collector will make its round but when it does it stops all processes and threads and performs its tasks (this is
         *      also done to ensure that there are no concurency issues - where you are using an object but its deleted or whatnot)
         *      This meens that in general the garbage collection cycle does try to be as fast as possible and is a reason why
         *      there is such a thing called the warming phase that during this time the programmer creates as many objects as it
         *      can or things such as object pools which are objects that are constantly used and are not deleted during the garbage
         *      collection.
         *      
         *      6.Why are there different assemly languages?   
         *      The general idea of the assembly language is one. But its embodiments are many and different 
         *      (e.g. MASM, TASM, NASM, (G)AS, etc etc). They differ in what CPUs they support and what instruction (sub)sets, 
         *      what features they support (e.g. expressions, macros, support for structured programming, object/binary file 
         *      formats) and what it all looks like (syntax, mnemonics, directives, comments).
         *      
         *      Different assemblers (e.g. Gnu's and Microsoft's) for the same CPU may have different assembly language syntax;
         *      but the difference is trivial, because they're both targeting the same CPU, and there's a 1-to-1 mapping (if you 
         *      ignore macros) between assembly instructions and CPU opcodes.
         *      The bigger difference is between different types of CPU.
         *      Sometimes different CPU support the same opcodes (and can therefore be targeted by the same assemblers), because 
         *      they're designed to be compatible with or competitive against each other, by executing the same machine language.
         * 
         *      6.*.What is an assembly language?
         *      An assembly (or assembler) language, is a low-level programming language for a computer, or other programmable 
         *      device, in which there is a very strong (generally one-to-one) correspondence between the language and the
         *      architecture's machine code instructions.
         *      Assembly language is converted into executable machine code by a utility program referred to as an assembler. 
         *      The conversion process is referred to as assembly, or assembling the source code. Assembly time is the computational
         *      step where an assembler is run.
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
         * 
         * 
         * 
         * 
         * 
         */
    }
}
