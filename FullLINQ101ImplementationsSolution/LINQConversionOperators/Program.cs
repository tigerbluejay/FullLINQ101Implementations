

///////////////////////////////////
//////// Convert to an Array
///////////////////////////////////

double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

var sortedDoubles = from d in doubles
                    orderby d descending
                    select d;
var doublesArray = sortedDoubles.ToArray();

Console.WriteLine("Every other double from highest to lowest:");
for (int d = 0; d < doublesArray.Length; d += 2)
{
    Console.WriteLine(doublesArray[d]);
}
Console.ReadKey();


///////////////////////////////////
//////// Convert to a list
///////////////////////////////////

string[] words = { "cherry", "apple", "blueberry" };

var sortedWords = from word in words
                  orderby word
                  select word;
var wordList = sortedWords.ToList();

Console.WriteLine("The sorted word list:");
foreach (var word in wordList)
{
    Console.WriteLine(word);
}
Console.ReadKey();


///////////////////////////////////
////// Convert to a dictionary
///////////////////////////////////

var scoreRecords = new[] { new {Name = "Alice", Score = 50},
                                new {Name = "Bob"  , Score = 40},
                                new {Name = "Cathy", Score = 45}
                            };

var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
Console.ReadKey();



///////////////////////////////////////////
////// Convert elements that match a type
///////////////////////////////////////////

object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

var doubles2 = numbers.OfType<double>();

Console.WriteLine("Numbers stored as doubles:");
foreach (var d in doubles2)
{
    Console.WriteLine(d);
}
Console.ReadKey();

