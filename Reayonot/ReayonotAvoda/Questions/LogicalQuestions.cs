using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Questions
{
    class LogicalQuestions
    {
        /**
         * Questions:
         *      1. The egg and the building: (xtremeio)
         *          1.a. You have 1 egg and a building with 100 floors, when the egg is droped from a certain floor it breaks.
         *          What is the max floor from which the egg breaks? how many tries will it take to find out?
         *          
         *          1.b. Same question but you have 2 eggs.
         *          
         *      2.The array high score game: (CheckPoint)
         *      You have an array of even (2n) size with random integers in ever slot. You can go over the array and whatever
         *      but not touch it. There are two players, each player can pick a number only from the edges, once he picks it
         *      it is removed from the array and added to their personal score. The winner is the player with the highest score
         *      when the array is empty.
         *      Considering you are the first player to start, Can you diffinetly say if you can always win lose or get zero no
         *      matter the array? If yes how, if no why?
         *      
         *      3. The horse race:
         *      There are 25 racing horses each with a different speed so that they can be ranked from top to last.
         *      You can run races between whatever horses you want but at most 5 horses can race in each race.
         *      How can you find what the 3 fastest horses are in as few races as possible?
         *      
         *      4.The coin game:
         *      There are two players and a table, each player has an unlimited number of coins that they can place on the tabel
         *      where every coin must be fully on the table and not half on and not on the side and not on another coin.
         *      The player that loses is the player that cant place a coin on their turn.
         *      If you start - how can you make sure you win the game 100%?
         *      
         *      5.How many gas stations are there in Tel-Aviv?
         *      
         *      
         *      
         * 
         * 
         * 
         * 
         * 
         * Answers:
         *      1.The egg and the building:
         *      You have x egg and a building with 100 floors, when the egg is droped from a certain floor it breaks.
         *      What is the max floor from which the egg breaks? how many tries will it take to find out?
         *      
         *          1.a. 
         *          With 1 egg there isnt much of a choice - you need to check every floor from the bottom up until you reach a
         *          floor that crashes. The run time for this is O(n) : O(n-1) because you dont need to check the top floor if the floor
         *          before it doesnt crash then the top floor is the floor where the egg breaks, so 99 (or O(99)) steps.
         *      
         *          1.b. In the case of two eggs there are 2 thought steps to this solution:
         *              1.b.*. The wrong solution that shows you are thinking:
         *                  You divide the floors into blocks and those blocks into sub blocks and those are the eggs jumps.
         *                  The first egg will jump at (n / t) floors where n is the number of floors in total and the second egg will make
         *                  a (t - 1) amount of jumps in the sub blocks. I'll explain:
         *                  The first egg jumps in segments 1, 11, 21..., once the egg breaks the second egg needs to make sumps from the
         *                  last "good" floor the first egg tested upwards just like in 1.a. this will result in the equation t-1+(t/n).
         *                  The worst case scenario for this is that the first egg jumps all the way to the last batch of 10 floors and then the
         *                  second egg makes the additional jumps in the floor so 10 + 9 = 19 total jumps O(19) worst case.
         *                  
         *              1.b.*. The complete solution:
         *                  What was written above is NOT the optimal answer and just a trail of thought to reach the true answer:
         *                  The floors are not divided into equal segments.
         *                  The answer is a series that starts at 14 and keeps getting smaller.
         *                  This is because we want to save that 14 number of steps - in case the first egg fails at floor 14 we have 13 more
         *                  floors we can test with egg 2 - so a total of 14. If the first egg doesnt break it will perform anouther test at
         *                  floor 27 - 13 floors up for a total of 2 checks now for the first egg and if it breaks there the first egg will
         *                  have 12 tests to make for total of 14 again.
         *                  In this way we can keep the total amount of tests at 14 no matter the floor and the run complexity of this algorithm
         *                  will be O(14).
         *                  on a note - 15 is worse beacuse its worst case is 15 and 13 wont make it to 100 if you reduct by 1 for every floor
         *                  block jump and therefore the best starting point is 14.
         *               
         *      2.The Array high score game
         *          The solution is to force the other player to take the moves you want them to make.
         *          Since the array is of even size, by always choosing either even or odd placed numbers from the origional array
         *          You can force the other player to take either even or odd numbers respectively (the oposite of what you take)
         *          At that point all thats left is to sum all the even numbers and all the odd numbers in the origional array
         *          and check which is greater then choose the corresponding sub array.
         *          for example
         *          [1, 3, 5, 6, 1, 9]
         *          the odd sub array is [1, 5, 1] = 7 total
         *          the even sub array is [3, 6, 9] = 18 total
         *          the even sub array is far greater --> we want to choose the even numbers so we start with the last number in
         *          the origional array
         *                  
         *      3.The 25 horses question:
         *          The soltion is crossreferencing and assumptions:
         *          At first you race 5 races each with 5 horses so that all 25 horses race. The result will be a grid of horses
         *          Where we know the fastest horses in each group:
         *          
         *         |  g1 | g2 | g3 | g4 | g5
         *       1 |  h    h    h    h    h
         *       2 |  h    h    h    h    h
         *       3 |  h    h    h    h    h
         *       4 |  h    h    h    h    h
         *       5 |  h    h    h    h    h
         *          
         *          Next we must race the first five horses of each group, so we get this:
         *          
         *         |  g1 | g2 | g3 | g4 | g5
         *       1 |  1    2    3    4    5
         *       2 |  h    h    h    h    h
         *       3 |  h    h    h    h    h
         *       4 |  h    h    h    h    h
         *       5 |  h    h    h    h    h
         *          
         *          Now, we want the fastest three horses so we already know that group 4-5 are obsolete since 1,2,3 are all
         *          faster than them:
         *          
         *         |  g1 | g2 | g3 | g4 | g5
         *       1 |  1    2    3    x    x
         *       2 |  h    h    h    x    x
         *       3 |  h    h    h    x    x
         *       4 |  h    h    h    x    x
         *       5 |  h    h    h    x    x
         *       
         *          Lets try and minimize using the same logic:
         *          We dont know if horses 2-3 in group 1 are faster than horse 1 in group 2 so we have to test them but even
         *          if they are we dont need to use horses 4-5 in that group even in the worst case scenario since we will alreay
         *          have 3:
         *          
         *         |  g1 | g2 | g3 | g4 | g5
         *       1 |  1    2    3    x    x
         *       2 |  h    h    h    x    x
         *       3 |  h    h    h    x    x
         *       4 |  x    h    h    x    x
         *       5 |  x    h    h    x    x
         * 
         *          By the same logic if both horses 2-3 in group 1 are slower than 1 in group 2 we still know that 1 in group one
         *          is faster so we already have 1 horse locked in and 2 places left so the worst case scenario for group 2 will be
         *          testing horse 2 and if horse 2 is slower than horse 1 of group 3 then we are left with only 1 place and whe know
         *          horse 1 of group 3 is the fastest of group 3 therefore it will be the third horse:
         *          
         *         |  g1 | g2 | g3 | g4 | g5
         *       1 |  1    2    3    x    x
         *       2 |  h    h    x    x    x
         *       3 |  h    x    x    x    x
         *       4 |  x    x    x    x    x
         *       5 |  x    x    x    x    x
         *       
         *          And since we know horse 1 of group 1 is the fastest of all we dont need to test it, just the remaining 5 horses
         *          This meens we can determin the fastest 3 horses with just one more race.
         *          
         *          This will allow us to finish the question with a total of 7 races.
         *          
         *          4.The coin Game:
         *          The solution is simple, since every coin is placed by turn on the table, if you start you can conquere the only
         *          point that is available only once - the center and then mimic the other player.
         *          By doing this the second player will always have to find a "new" place to put a coin while you only need to
         *          mimic their choice of free space on the table until there is non left.
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
         * 
         * 
         * 
         * 
         * 
         */
    }
}
