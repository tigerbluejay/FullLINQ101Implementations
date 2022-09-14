using LINQProjectionOperators.Classes;

/////////////////////////////////////
//// Use select to create new types
/////////////////////////////////////

int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] strings3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

var digitOddEvens = from number in numbers4
                    select new { Digit = strings3[number], Even = (number % 2 == 0) };

foreach (var digitOddEven in digitOddEvens)
{
    Console.WriteLine($"The digit {digitOddEven.Digit} is {(digitOddEven.Even ? "even" : "odd")}.");
}

/// tuples

int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] strings2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

var digitOddEvens2 = from number in numbers3
                    select (Digit: strings2[number], Even: (number % 2 == 0));

foreach (var digitOddEven in digitOddEvens2)
{
    Console.WriteLine($"The digit {digitOddEven.Digit} is {(digitOddEven.Even ? "even" : "odd")}.");
}


/////////////////////////////////////
//// Select Anonymous Types or Tuples
/////////////////////////////////////

string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

var upperLowerWords = from word in words
                      select new { Upper = word.ToUpper(), Lower = word.ToLower() };

foreach (var upperLowerWord in upperLowerWords)
{
    Console.WriteLine($"Uppercase: {upperLowerWord.Upper}, Lowercase: {upperLowerWord.Lower}");
}

/// tuples:

string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };

var upperLowerWords2 = from word in words2
                      select (Upper: word.ToUpper(), Lower: word.ToLower());

foreach (var upperLowerWord in upperLowerWords2)
{
    Console.WriteLine($"Uppercase: {upperLowerWord.Upper}, Lowercase: {upperLowerWord.Lower}");
}


///////////////////////////////
//// Transform with Select
///////////////////////////////

int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

var textNumbers = from number in numbers2
               select strings[number];

Console.WriteLine("Number strings:");
foreach (var textNumber in textNumbers)
{
    Console.WriteLine(textNumber);
}

///////////////////////////////
//// Select a Single Property
///////////////////////////////

List<Product> products = GetProductList();

var productNames = from product in products
                   select product.ProductName;

Console.WriteLine("Product Names:");
foreach (var productName in productNames)
{
    Console.WriteLine(productName);
}

List<Product> GetProductList()
{
    List<Product> products = new List<Product>();
    products.Add(new Product { ProductName = "scissors" });
    products.Add(new Product { ProductName = "paper" });
    products.Add(new Product { ProductName = "glue" });
    products.Add(new Product { ProductName = "pencil" });
    products.Add(new Product { ProductName = "pen" });
    return products;
}


///////////////////////////////
//// Select Clause
///////////////////////////////

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var numbersPlusOne = from number in numbers
                  select number + 1;

Console.WriteLine("Numbers + 1:");
foreach (var numberPlusOne in numbersPlusOne)
{
    Console.WriteLine(numberPlusOne);
}
return 0;