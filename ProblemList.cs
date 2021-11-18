using System;
using System.Collections.Generic;

namespace CodingRange
{
    public static class ProblemList
    {
        /* SPECIAL NOTES
         * - unless otherwise noted, you do not need to check for over/underflow or divide by zero.
         * 
         * 
         */
        public static List<Problem> List { get; } = new()
        {
            // 0
            new Problem("Hello World", "Return the string \"Hello World!\".", "(no parameters)", "string", new[] { 
                new TestCase(null, "Hello World!")
            }),
            // 1
            new Problem("Cringe?", "Given an input representing whether or not a person is epic, return a boolean representing whether or not they are cringe (NOT epic).", "bool x", "bool", new[]
            {
                new TestCase(new object[] { true }, false),
                new TestCase(new object[] { false }, true),
            }),
            // 2
            new Problem("Pills", "You are given two inputs, the first represents whether or not a person is red-pilled. The second represents whether or not a person is blue-pilled. We don't care about colors, so just return whether or not they are pilled at all.", "bool redPilled, bool bluePilled", "bool", new[]
            {
                new TestCase(new object[] { false, false }, false),
                new TestCase(new object[] { false, true }, true),
                new TestCase(new object[] { true, false }, true),
                new TestCase(new object[] { true, true }, true),
            }),
            // 3
            new Problem("TRULY Epic", "As we all know, there is only one way to be TRULY epic. You must be a. Gay, b. a Ram Ranch Cowboy, AND c. a Programmer. You are given three inputs, representing whether or not a person is Gay, a Ram Ranch Cowboy, and a Programmer, respectively. Your job is to determine and return whether or not the given person is TRULY epic.", "bool gay, bool ramRanch, bool programmer", "bool", new[]
            {
                new TestCase(new object[] { false, true, true }, false),
                new TestCase(new object[] { false, true, false }, false),
                new TestCase(new object[] { false, false, true }, false),
                new TestCase(new object[] { false, false, false }, false),
                new TestCase(new object[] { true, true, true }, true),
                new TestCase(new object[] { true, true, false }, false),
                new TestCase(new object[] { true, false, true }, false),
                new TestCase(new object[] { true, false, false }, false),
            }),
            // 4
            new Problem("Cat Person", "You are given two inputs. The first is a boolean representing whether or not a person in question owns a cat.\nThe second refers to whether or not a person owns a dog. Return whether or not the person is a cat person, meaning they own a cat but not a dog.", "bool cat, bool dog", "bool", new[]
            {
                new TestCase(new object[] { false, false }, false),
                new TestCase(new object[] { false, true }, false),
                new TestCase(new object[] { true, false }, true),
                new TestCase(new object[] { true, true }, false),
            }, "Bonus! Can you solve this problem without using the NOT operator?"),
            // 5
            new Problem("Matchmaking <3", "A wise man once said, \"A relationship can only succeed if both partners have the same opinion on whether or not popcorn is tasty.\" This is of course, a true fact of life. Given two inputs, the first representing whether or not the first partner likes popcorn, and the second representing whether or not the second partner likes popcorn, determine whether or not this couple is truly meant to be.", "bool heLiksPopcorn, bool sheLikesPopcorn", "bool", new[]
            {
                new TestCase(new object[] { false, false }, true),
                new TestCase(new object[] { false, true }, false),
                new TestCase(new object[] { true, false }, false),
                new TestCase(new object[] { true, true }, true),
            }),
            // 6
            new Problem("Pills 2", "Alright, now we care about pill colors. In the spirit of Mr. Lamers, this time we only want to accept purple-pilled people. You are given two inputs, the first represents whether or not a person is red-pilled. The second represents whether or not a person is blue-pilled. Return whether or not the person in question is purple-pilled (both red and blue pilled).", "bool redPilled, bool bluePilled","bool", new[]
            {
                new TestCase(new object[] { false, false }, false),
                new TestCase(new object[] { false, true }, false),
                new TestCase(new object[] { true, false }, false),
                new TestCase(new object[] { true, true }, true),
            }),
            // 7
            new Problem("Horse Girl", "You are given three inputs. The first represents whether or not a person is a horse, the second represents whether or not a person is a girl, and the third represents whether or not a person likes horses. Your job is to determine and return whether or not they are a horse girl, meaning a girl who either likes horses or is in fact a horse.", "bool horse, bool girl, bool likesHorses", "bool", new[]
            {
                new TestCase(new object[] { false, true, true }, true),
                new TestCase(new object[] { false, true, false }, false),
                new TestCase(new object[] { false, false, true }, false),
                new TestCase(new object[] { false, false, false }, false),
                new TestCase(new object[] { true, true, true }, true),
                new TestCase(new object[] { true, true, false }, true),
                new TestCase(new object[] { true, false, true }, false),
                new TestCase(new object[] { true, false, false }, false),
            }),
            // 8
            new Problem("Boomers", "Another true fact of life is that everybody who is at or over the age of twenty is a boomer. Given an input representing the age of a person, determine and return whether or not they are a boomer.", "int age", "bool", new[]
            {
                new TestCase(new object[] { 7 }, false),
                new TestCase(new object[] { 15 }, false),
                new TestCase(new object[] { 18 }, false),
                new TestCase(new object[] { 19 }, false),
                new TestCase(new object[] { 20 }, true),
                new TestCase(new object[] { 21 }, true),
                new TestCase(new object[] { 22 }, true),
                new TestCase(new object[] { 30 }, true),
                new TestCase(new object[] { 53 }, true),
                new TestCase(new object[] { 75 }, true),
                new TestCase(new object[] { 300 }, true),
                new TestCase(new object[] { 2000 }, true),
            }),
            // 9
            new Problem("Vibes", "Good vibes only! Given an integer input in the range [-100, 100] representing how good a person's vibes are, return whether or not they have good (positive, non-zero) vibes.", "int vibe", "bool", new[]
            {
                new TestCase(new object[] { -74 }, false),
                new TestCase(new object[] { 15 }, true),
                new TestCase(new object[] { 0 }, false),
                new TestCase(new object[] { 100 }, true),
                new TestCase(new object[] { 39 }, true),
                new TestCase(new object[] { 1 }, true),
                new TestCase(new object[] { -1 }, false),
                new TestCase(new object[] { 2 }, true),
                new TestCase(new object[] { -45 }, false),
                new TestCase(new object[] { -100 }, false),
                new TestCase(new object[] { -69 }, false),
                new TestCase(new object[] { 69 }, true),
            }),
            // 10
            new Problem("Zoomers", "Man, I can't believe zoomers are teenagers now! Given the age of a person, return whether or not they are a teenager.", "int age", "bool", new[]
            {
                new TestCase(new object[] { 9 }, false),
                new TestCase(new object[] { 10 }, false),
                new TestCase(new object[] { 11 }, false),
                new TestCase(new object[] { 12 }, false),
                new TestCase(new object[] { 13 }, true),
                new TestCase(new object[] { 14 }, true),
                new TestCase(new object[] { 15 }, true),
                new TestCase(new object[] { 16 }, true),
                new TestCase(new object[] { 17 }, true),
                new TestCase(new object[] { 18 }, true),
                new TestCase(new object[] { 19 }, true),
                new TestCase(new object[] { 20 }, false),
                new TestCase(new object[] { 21 }, false),
                new TestCase(new object[] { 22 }, false),
                new TestCase(new object[] { 23 }, false),
                new TestCase(new object[] { 24 }, false),
                new TestCase(new object[] { 25 }, false),
            }),
            // 11
            new Problem("Drinking Time", "Being a responsible parent, my children are only allowed to have three alcoholic drinks a day, and they're not allowed to drink in the morning. Given two inputs, the first representing how many drinks they've had and the second representing whether or not it's morning, return whether or not my children are allowed to drink.", "int drinks, bool isMorning", "bool", new[]
            {
                new TestCase(new object[] { 5, true }, false),
                new TestCase(new object[] { 0, true }, false),
                new TestCase(new object[] { 0, false }, true),
                new TestCase(new object[] { 2, true }, false),
                new TestCase(new object[] { 3, true }, false),
                new TestCase(new object[] { 3, false }, false),
                new TestCase(new object[] { 2, false }, true),
                new TestCase(new object[] { 7, false }, false),
                new TestCase(new object[] { 1, false }, true),
            }),
            // 12
            new Problem ("Kinsey Scale", "A beautiful example of progress in our society is the fact that a person who experiences ANY homosexual thoughts can achieve the illustrious title of Gay. Given two inputs, one being a person's Kinsey scale rating (an integer in the range [0, 6], with 0 representing exclusively heterosexual and 6 representing exclusively homosexual) and the other whether or not a person believes they can achieve gaydom, determine whether or not that person is correct in their self-assessment.", "int kinseyScale, bool gay", "bool", new[]
            {
                new TestCase(new object[] { 0, true }, false),
                new TestCase(new object[] { 1, true }, true),
                new TestCase(new object[] { 2, true }, true),
                new TestCase(new object[] { 3, true }, true),
                new TestCase(new object[] { 4, true }, true),
                new TestCase(new object[] { 5, true }, true),
                new TestCase(new object[] { 6, true }, true),
                new TestCase(new object[] { 0, false }, true),
                new TestCase(new object[] { 1, false }, false),
                new TestCase(new object[] { 2, false }, false),
                new TestCase(new object[] { 3, false }, false),
                new TestCase(new object[] { 4, false }, false),
                new TestCase(new object[] { 5, false }, false),
                new TestCase(new object[] { 6, false }, false),
            }, "Note: This has nothing to do with a person's self-identity, but rather whether or not they could honestly identify as gay. Sad 0 Kinsey rating individuals like myself can only be an honorary gay at best."),
            // 13
            new Problem ("Older Teenagers", "Oh wait, aren't people between 113 and 119 teenagers too? Given the age of a person, return whether or not they are either kind of teenager.", "int age", "bool", new[]
            {
                new TestCase(new object[] { 9 }, false),
                new TestCase(new object[] { 10 }, false),
                new TestCase(new object[] { 11 }, false),
                new TestCase(new object[] { 12 }, false),
                new TestCase(new object[] { 13 }, true),
                new TestCase(new object[] { 14 }, true),
                new TestCase(new object[] { 15 }, true),
                new TestCase(new object[] { 16 }, true),
                new TestCase(new object[] { 17 }, true),
                new TestCase(new object[] { 18 }, true),
                new TestCase(new object[] { 19 }, true),
                new TestCase(new object[] { 20 }, false),
                new TestCase(new object[] { 21 }, false),
                new TestCase(new object[] { 22 }, false),
                new TestCase(new object[] { 23 }, false),
                new TestCase(new object[] { 24 }, false),
                new TestCase(new object[] { 25 }, false),
                new TestCase(new object[] { 109 }, false),
                new TestCase(new object[] { 110 }, false),
                new TestCase(new object[] { 111 }, false),
                new TestCase(new object[] { 112 }, false),
                new TestCase(new object[] { 113 }, true),
                new TestCase(new object[] { 114 }, true),
                new TestCase(new object[] { 115 }, true),
                new TestCase(new object[] { 116 }, true),
                new TestCase(new object[] { 117 }, true),
                new TestCase(new object[] { 118 }, true),
                new TestCase(new object[] { 119 }, true),
                new TestCase(new object[] { 120 }, false),
                new TestCase(new object[] { 121 }, false),
                new TestCase(new object[] { 122 }, false),
                new TestCase(new object[] { 123 }, false),
                new TestCase(new object[] { 124 }, false),
                new TestCase(new object[] { 125 }, false),
            }),
            // 14
            new Problem("Money Printer", "Brrrrr. The US government is working on a new device and they need YOU to help complete it. This new device takes all of the money you currently have, and doubles it! You are given an input representing how much money somebody has. Return how much money the person will have after it goes through the money printer.", "int x", "int", new[] 
            {
                new TestCase(new object[] { 1 }, 2),
                new TestCase(new object[] { 0 }, 0),
                new TestCase(new object[] { -700 }, -1400),
                new TestCase(new object[] { 500 }, 1000),
                new TestCase(new object[] { 81700 }, 163400),
                new TestCase(new object[] { -5100 }, -10200),
                new TestCase(new object[] { 4200 }, 8400),
            }, "NOTE: Remember, this is America. People can very much have negative money."),
            // 15
            new Problem("Money Printer v2", "We've gone too deep in debt, the money printer needs to be upgraded! The new money printer will actually square a person (or government)'s money. Since the square of a negative number is positive, this could solve our debt crisis!", "int x", "int", new[] 
            {
                new TestCase(new object[] { 1 }, 1),
                new TestCase(new object[] { 0 }, 0),
                new TestCase(new object[] { -700 }, 490000),
                new TestCase(new object[] { -500 }, 250000),
                new TestCase(new object[] { 8170 }, 66748900),
                new TestCase(new object[] { 400 }, 160000),
                new TestCase(new object[] { -2100 }, 4410000),
            }, "Remember, to square a number is to multiply that number by itself."),
            // 16
            new Problem("Money Gun", "You've done your country proud, eternal president Obama thanks you for your service... But we'r e gonna need a money gun now so we can help out our allies and destroy our enemies. Given an input representing how much money our target has, return the inverse of that amount.", "int x", "int", new[] 
            {
                new TestCase(new object[] { 1 }, -1),
                new TestCase(new object[] { 0 }, 0),
                new TestCase(new object[] { -7 }, 7),
                new TestCase(new object[] { 6 }, -6),
                new TestCase(new object[] { -523 }, 523),
                new TestCase(new object[] { 375 }, -375),
                new TestCase(new object[] { 23 }, -23),
            }, "Bonus! Can you do this without multiplying by negative one?"),
            // 17
            new Problem("Cult of Dionysus", "According to the Orion Experience song \"Cult of Dionysus\", the couple in question created their cult because he was feeling devious and she thought he was looking glamorous. You are given two inputs: one representing whether or not he feels devious, and the other representing whether or not she thinks he looks glamorous. Return whether or not these two are ready to create the Cult of Dionysus.", "bool feelingDevious, bool lookingGlamorous", "bool", new[]
            {
                new TestCase(new object[] { false, false }, false),
                new TestCase(new object[] { false, true }, false),
                new TestCase(new object[] { true, false }, false),
                new TestCase(new object[] { true, true }, true),
            }),
            // 18
            new Problem("Carrying", "Carry the team! A person is carrying the team if their score is at least double the score of the team's second-place player. Given two integer inputs, the first representing the top player's score, and the second representing the second-place player's score, determine and return whether or not the top player is carrying the team. Both scores will always be positive, and the top player's score will always be greater than the second-place player's score.", "int topScore, int secondScore", "bool", new[]
            {
                new TestCase(new object[] { 100, 0 }, true),
                new TestCase(new object[] { 30, 20 }, false),
                new TestCase(new object[] { 100, 50 }, true),
                new TestCase(new object[] { 2, 1 }, true),
                new TestCase(new object[] { 1, 0 }, true),
                new TestCase(new object[] { 1999, 1000 }, false),
                new TestCase(new object[] { 2000, 1000 }, true),
                new TestCase(new object[] { 100, 51 }, false),
                new TestCase(new object[] { 16, 15 }, false),
                new TestCase(new object[] { 200, 175 }, false),
            }),
            // 19
            new Problem("Order of Operations", "Add one to the input and return that new value multplied by negative two.", "int x", "int", new[] 
            {
                new TestCase(new object[] { 1 }, -4),
                new TestCase(new object[] { 0 }, -2),
                new TestCase(new object[] { -7 }, 12),
                new TestCase(new object[] { 5 }, -12),
                new TestCase(new object[] { 817 }, -1636),
                new TestCase(new object[] { 4 }, -10),
                new TestCase(new object[] { 27 }, -56),
            }, "I ran out of ideas for funny word problems, so the next few will be generic math questions. Sorry!"),
            // 20
            new Problem("Binomial Multiplication", "Given an input x, calculate and return y = (x + 2)(3x - 1).", "int x", "int", new[]
            {
                new TestCase(new object[] { 5 }, 98),
                new TestCase(new object[] { -7 }, 110),
                new TestCase(new object[] { 0 }, -2),
                new TestCase(new object[] { 1 }, 6),
                new TestCase(new object[] { -1 }, -4),
                new TestCase(new object[] { 523}, 823200),
                new TestCase(new object[] { -1024 }, 3140606),
                new TestCase(new object[] { 96 }, 28126),
                new TestCase(new object[] { 98 }, 29300),
            }),
            // 21
            new Problem("Polynomial", "Given an input x, calculate and return y = 7x^5 + 4x^3 - 9x^2 + x - 27", "int x", "int", new[]
            {
                new TestCase(new object[] { 0 }, -27),
                new TestCase(new object[] { 1 }, -24),
                new TestCase(new object[] { -1 }, -48),
                new TestCase(new object[] { 2 }, 195),
                new TestCase(new object[] { 3 }, 1704),
                new TestCase(new object[] { -5 }, -22632),
                new TestCase(new object[] { -10 }, -704937),
                new TestCase(new object[] { 7 }, 118560),
            }),
            // 22
            new Problem("Addition", "Return the two inputs added together", "int x, int y", "int", new[]
            {
                new TestCase(new object[] { 0, 0 }, 0),
                new TestCase(new object[] { -1, 0 }, -1),
                new TestCase(new object[] { 0, 73 }, 73),
                new TestCase(new object[] { 4, 4 }, 8),
                new TestCase(new object[] { 91, 8 }, 99),
                new TestCase(new object[] { -100, 1 }, -99),
                new TestCase(new object[] { -75, -33 }, -108),
                new TestCase(new object[] { 10383757, 5393826 }, 15777583),
                new TestCase(new object[] { -30, -30 }, -60),
            }),
            // 23
            new Problem("Division", "Return the first input divided by the second", "int x, int y", "double", new[] 
            {
                new TestCase(new object[] { 10, 5 }, 10D / 5),
                new TestCase(new object[] { 72, 9 }, 72D / 9),
                new TestCase(new object[] { -25, 5 }, -25D / 5),
                new TestCase(new object[] { 33, 11 }, 33D / 11),
                new TestCase(new object[] { 431156, 451 }, 431156D / 451),
                new TestCase(new object[] { -3230, 34 }, -3230D / 34),
                new TestCase(new object[] { 75, -5 }, 75D / -5),
                new TestCase(new object[] { 5, 2 }, 5D / 2),
                new TestCase(new object[] { -32, 128 }, -32D / 128),
            }),
            // 24
            new Problem("Circle", "Given the radius of a circle, calculate and return its area.", "double r", "double", new[]
            {
                new TestCase(new object[] { 0 }, 0 * 0 * Math.PI),
                new TestCase(new object[] { 1 }, 1 * Math.PI),
                new TestCase(new object[] { 7 }, 49 * Math.PI),
                new TestCase(new object[] { 3 }, 9 * Math.PI),
                new TestCase(new object[] { 1033 }, 1067089 * Math.PI),
                new TestCase(new object[] { 51 }, 2601 * Math.PI),
                new TestCase(new object[] { 2.5 }, 6.25 * Math.PI),
            }, "If you add the line \"using System;\" at the top, you can use Math.PI anywhere in your code for a good approximation of pi."),
            // 25
            new Problem("Surface Area of a Sphere", "Given the **diameter** of a sphere, calculate and return its surface area", "int d", "int", new[]
            {
                new TestCase(new object[] { 0 }, 4 * Math.PI * 0 * 0),
                new TestCase(new object[] { 8 }, 4 * Math.PI * 4 * 4),
                new TestCase(new object[] { 16 }, 4 * Math.PI * 8 * 8),
                new TestCase(new object[] { 36 }, 4 * Math.PI * 18 * 18),
                new TestCase(new object[] { 60 }, 4 * Math.PI * 30 * 30),
                new TestCase(new object[] { 48 }, 4 * Math.PI * 24 * 24),
                new TestCase(new object[] { 900 }, 4 * Math.PI * 450 * 450),
            }, "All inputs are even numbers... Dealing with test-cases for doubles is a hassle."),
            // 26
            new Problem("Distance Between Points", "Given inputs x1, y1, x2, and y2 representing two points, calculate and return the distance between the points.", "int x1, int y1, int x2, int y2", "double", new[]
            {
                new TestCase(new object[] { 2, 3, 4, 5 }, Math.Sqrt(Math.Pow(4 - 2, 2) + Math.Pow(5 - 3, 2))),
                new TestCase(new object[] { -10, 7, 4, -3 }, Math.Sqrt(Math.Pow(4 + 10, 2) + Math.Pow(-3 - 7, 2))),
                new TestCase(new object[] { 0, 0, 0, 0 }, Math.Sqrt(Math.Pow(0 - 0, 2) + Math.Pow(0 - 0, 2))),
                new TestCase(new object[] { 0, 0, 0, 1 }, Math.Sqrt(Math.Pow(0 - 0, 2) + Math.Pow(1 - 0, 2))),
            }, "You can use Math.Sqrt(x) to the square root of x, and Math.Pow(x, 2) to get x squared. Do not use x^2, as ^ actually refers to the XOR operator."),
            // 27
            new Problem("First!", "You know this dude on tinder once wrote a poem where if you combined the first letter of each line it said a uhh... interesting message. Let's do that here! Given a string input, return the first character of the string.", "string x", "char", new[]
            {
                new TestCase(new object[] { "Hello World!" }, 'H'),
                new TestCase(new object[] { "Mellow World?" }, 'M'),
                new TestCase(new object[] { "Bellow World..." }, 'B'),
                new TestCase(new object[] { "..-. . .-.. .-.. --- .-- / .-- --- .-. .-.. -.." }, '.'),
                new TestCase(new object[] { "01101001 00100111 01101101 00100000 01101111 01110101 01110100 00100000 01101111 01100110 00100000 01110010 01101000 01111001 01101101 01100101 01110011", '0'}),
                new TestCase(new object[] { "rip" }, 'r'),
            })
            // 28
            new Problem ("Last!", "Alright, now do it with the last character instead. Given a string input, return the last character of the string.", "string x", "char", new[]
            {
                new TestCase(new object[] { "Hello World!" }, '!'),
                new TestCase(new object[] { "Mellow World?" }, '?'),
                new TestCase(new object[] { "Bellow World..." }, '.'),
                new TestCase(new object[] { "..-. . .-.. .-.. --- .-- / .-- --- .-. .-.. -.." }, '.'),
                new TestCase(new object[] { "01101001 00100111 01101101 00100000 01101111 01110101 01110100 00100000 01101111 01100110 00100000 01110010 01101000 01111001 01101101 01100101 01110011", '1'}),
                new TestCase(new object[] { "rip" }, 'p'),
            })
            // 29
            new Problem("Middle?", "Alright those were too easy, let's make it a bit harder. Given a string of non-zero length, return the *middle* character of the string. If a string is of even length, choose the left of the two middle characters.", "string x", "char", new[]
            {
               new TestCase(new object[] { "tacocat" }, 'o'), 
               new TestCase(new object[] { "racecar" }, 'e'), 
               new TestCase(new object[] { "dad" }, 'a'), 
               new TestCase(new object[] { "Anna" }, 'n'), 
               new TestCase(new object[] { "noon" }, 'o'), 
               new TestCase(new object[] { "reeeeeeeeeeeeeeeeeeeeeeeeeeeee" }, 'e'), 
            }),
            // 30
            new Problem("Epic", "Oh my god, did you know there are still people in *2021* that say epic!? This guy literally writes \"epic! \" at the start of every single one of his messages. Given an input representing this fool's message, return the message but without the \"epic! \" at the start.", "string epic", "string", new[]
            {
                new TestCase(new object[] { "epic! I love cats!!!" }, "I love cats!!!"),
                new TestCase(new object[] { "epic! you are sooooooo cool!" }, "you are sooooooo cool!"),
                new TestCase(new object[] { "epic! epic!" }, "epic!"),
                new TestCase(new object[] { "epic! I should touch grass and stop saying epic!" }, "I should touch grass and stop saying epic!"),
                new TestCase(new object[] { "epic! reeeeeeeeeeeeeeeeee" }, "reeeeeeeeeeeeeeeeee"),
            }),
            // 31
            new Problem("More Middle", "Sometimes, we want to get both of the middle characters", "string x", "string", new[]
            {
               new TestCase(new object[] { "tacocat" }, "o"), 
               new TestCase(new object[] { "racecar" }, "e"), 
               new TestCase(new object[] { "dad" }, "a"), 
               new TestCase(new object[] { "Anna" }, "nn"), 
               new TestCase(new object[] { "noon" }, "oo"), 
               new TestCase(new object[] { "rawr" }, "aw"), 
               new TestCase(new object[] { "Hello!" }, "ll"), 
               new TestCase(new object[] { "doge" }, "og"), 
            }),
            // 32
            new Problem("String Concatenation", "Given two strings, concatenate (add) them together and return the result.", "string x, string y", "string", new[]
            {
                new TestCase(new object[] {"Hello ", "World!"}, "Hello World!"),
                new TestCase(new object[] {"Sometimes all I think about is ", "youuuuu"}, "Sometimes all I think about is youuuuu"),
                new TestCase(new object[] {"Take me home", " down country roads"}, "Take me home down country roads"),
                new TestCase(new object[] {"SomeBODY ", "once told me"}, "SomeBODY once told me"),
                new TestCase(new object[] {"Never gonna give you up,", " never gonna let you down"}, "Never gonna give you up, never gonna let you down"),
                new TestCase(new object[] {"Who lives in a ", "pineapple under the sea"}, "Who lives in a pineapple under the sea"),
            }),
            // 33
            new Problem("Allergens", "You are trying to get the allergen information for a meal. The API has returned two strings, each of the form \"contains x\". Please concatenate the two strings together, but with the second \"contains\" replaced with \"and\".", new[]
            {
                new TestCase(new object[] { "contains peanuts", "contains soy" }, "contains peanuts and soy"),
                new TestCase(new object[] { "contains milk", "contains soy" }, "contains milk and soy"),
                new TestCase(new object[] { "contains milk", "contains peanuts" }, "contains milk and peanuts"),
                new TestCase(new object[] { "contains soy", "contains peanuts" }, "contains soy and peanuts"),
                new TestCase(new object[] { "contains peanuts", "contains tree nuts" }, "contains peanuts and tree nuts"),
                new TestCase(new object[] { "contains wheat", "contains fish" }, "contains wheat and fish"),
                new TestCase(new object[] { "contains rhinoceros horn", "contains unicorn tears" }, "contains rhinoceros horn and unicorn tears"),
            }, "For example: given first = \"contains peanuts\" and second = \"contains soy\", return \"contains peanuts and soy\". (this is based off of a real problem I had to solve!)"),
        };
    }
}