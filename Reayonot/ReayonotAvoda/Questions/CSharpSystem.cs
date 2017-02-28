using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Questions
{
    class CSharpSystem
    {
        /**
         * Questions:
         *      1. What is IDisposable?
         *      2. What is using when writen in the code? otherwise known as a "using statement".
         *      3. How does yield work?
         *      4. How does foreach work?
         * 
         * 
         * 
         * 
         * 
         * Answers:
         * 
         *      1. What is IDisposable?
         *          IDisposable is an interface whos primary purpose is to create unmanaged recources.
         *          Since we cant predict when the garbage collector will make its rounds and since it does not manage
         *          unmanaged recources such as open file streams and window handles we can use the IDisposable interface
         *          with the command Dispose to dispose of such recources manualy when it is no longer needed.
         *          
         *      2. What is a using statement?
         *          As a rule, when you use an IDisposable object, you should declare and instantiate it in a using statement.
         *          The using statement calls the Dispose method on the object in the correct way, and (when you use it as 
         *          shown earlier) it also causes the object itself to go out of scope as soon as Dispose is called. Within 
         *          the using block, the object is read-only and cannot be modified or reassigned.
         *          
         *          The using statement ensures that Dispose is called even if an exception occurs while you are calling methods 
         *          on the object. You can achieve the same result by putting the object inside a try block and then calling 
         *          Dispose in a finally block; in fact, this is how the using statement is translated by the compiler.
         *          
         *          Using statements are especialy useful in cases of unmanaged code when you need to ensure you disposed of
         *          something properly.
         *          
         *      3. How does yield work?
         *          When you use the yield keyword in a statement, you indicate that the method, operator, or get accessor in 
         *          which it appears is an iterator.
         *          You use a yield return statement to return each element one at a time.
         *          Every time yield return is called an expression is returned - usualy the iteration is done using loops such
         *          as foreach. Upon the return the current location in the iteration is retained and execution is restarted
         *          from that position the next time another element is requested (the next time the iterator is called).
         *          
         *          A yield break statement will end the iteration.
         *          
         *          Because of the way yield works, the function using yield return must specify that it is returning an iEnumerable.
         *          
         *          The yield return in contrast to what might be thought does not end the methods excecution but simply pauses
         *          it while returning the current value.
         *          
         *          Behind the scenes the yeild propery creates an additional state variable in the inumator that has a number
         *          of possibilities:
         *          -2: Initialized as Enumerable. (Not yet an Enumerator)
         *          -1: Closed
         *          0: Initialized as Enumerator.  
         *          1-n: Index of the yield return in the original function
         *          
         *          The -2, -1 and 0 are the initializers and state that make sure the Inumerator is accessed only when the state
         *          allows it and the 1-n is the current position (or the next position it is sent to) in the inumerator.
         *          The entire thing is transformed into a switch statment that is state based.
         *          for example the inumerator switch for a fibonachii sequence:
         *               bool MoveNext()
         *               {
         *                   switch (state)
         *                   {
         *                       case 0:
         *                           state = -1;
         *                           current = 1;
         *                           state = 1;
         *                           return true;
         *
         *                       case 1:
         *                           state = -1;
         *                           current = 2;
         *                           state = 2;
         *                           return true;
         *
         *                       case 2:
         *                           state = -1;
         *                           current = 3;
         *                           state = 3;
         *                           return true;
         * 
         *                       case 3:
         *                           state = -1;
         *                           current = 5;
         *                           state = 4;
         *                           return true;
         *
         *                       case 4:
         *                           state = -1;
         *                           break;
         *                   }
         *                   return false;
         *              }        
         *              
         *              This is of course a very very simple example and many of the enumerator functions such as foreach
         *              have a much more complex background providing them more checks capabilities and so on.
         *              
         *      3. How does foreach work?
         *          A foreach loop of the format foreach (V v in x) embedded-statement
         *          will expand to:
         *          {
         *              E e = ((C)(x)).GetEnumerator();
         *              try 
         *              {
         *                  V v;
         *                  while (e.MoveNext()) 
         *                  {
         *                      v = (V)(T)e.Current;
         *                      embedded-statement
         *                  }
         *              }
         *              finally 
         *              {
         *                   code to Dispose e if necessary
         *              }
         *          }
         *        this meens the an iterator will be created and while there is still a next value available the function will
         *        go over it and performed the desired task (the ebedded statement).
         *        Once the iteration over all the elements is complete the final will properly dispose of any remaining data.
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
