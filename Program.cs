using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
 Challenge animalOfScotland = new Challenge(
                @"What's the national animal of Scotland?
    1) Dragon
    2) Wolf
    3) Unicorn
    4) Stag
",
                3, 20
            );
             Challenge largestOrganism = new Challenge(
                @"What's the largest living organism on Earth?
    1) An aspen grove
    2) The Blue Whale
    3) Galactus
    4) Your mom
",
                1, 30
            );
             Challenge elvisGrammys = new Challenge(
                "How many grammy's did Elvis win?",
                3, 15
            );
             Challenge mouseSpeed = new Challenge(
                @"What's a computer mouse's speed measured in?
    1) Mickeys
    2) Clicks
    3) Knots
    4) mm/s
",
                1, 25
            );
            Challenge grapes = new Challenge(
                @"Approximately how many grapes go into one bottle of wine?
    1) 500
    2) 600
    3) 700
    4) 800
",
                3, 10
            );
            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;
            var rainbowRobe = new Robe
            {
                Length = 72,
                Colors = ["cerulean", "vermillion", "chartreuse", "peridot", "violet"]
            };
            var myHat = new Hat();
            myHat.ShininessLevel = 11;
            // Make a new "Adventurer" object using the "Adventurer" class
            var pizzaHutCoupon = new Prize("A Pizza Hut coupon valid for a free large pizza with the purchase of two or more large pizzas.");
            Console.WriteLine("--------------------------");
             Console.WriteLine("Prepare for a quest!");
             Console.WriteLine("--------------------------");
             Console.WriteLine("What's your name adventurer?");
             string Name = Console.ReadLine();
            Adventurer theAdventurer = new Adventurer(Name, rainbowRobe, myHat);
            
            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                animalOfScotland,
                elvisGrammys,
                grapes,
                largestOrganism,
                mouseSpeed
            };
           
           RunQuest();
            void RunQuest()
            {
            theAdventurer.GetDescription();
           
            // Loop through all the challenges and subject the Adventurer to them
            List<int> selectedChallenges = new List<int>();
            void RunRandomChallenges(){
                 Random r = new Random();
                int randomChallengeIndex = r.Next(0, challenges.Count - 1);
                if(!selectedChallenges.Contains(randomChallengeIndex)){
                    selectedChallenges.Add(randomChallengeIndex);
                    challenges[randomChallengeIndex].RunChallenge(theAdventurer);
                } else {
                    RunRandomChallenges();
                }
            }
            void RunThisQuest (){
                
            for(int i = 0; i < 5; i++){
                Console.WriteLine("--------------------------");
                Console.WriteLine($" Successful Guesses: {theAdventurer.SuccessCount} ");
                Console.WriteLine("--------------------------");
               RunRandomChallenges();
            }
            }
            RunThisQuest();

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }

            Console.WriteLine("");
            pizzaHutCoupon.ShowPrize(theAdventurer);
            void Repeat()
            {
                Console.WriteLine("Repeat the Quest? (y/n)");
                string Answer = Console.ReadLine();
                if (Answer == "y" || Answer == "n")
                {
                if (Answer == "y"){
                    theAdventurer.Awesomeness += theAdventurer.SuccessCount * 10;
                    theAdventurer.SuccessCount = 0;
                    RunQuest();
                }
                } else {
                    Console.WriteLine("Not a valid repsonse");
                    Repeat();
                }
            }

            Repeat();
            }
        }
    }
}