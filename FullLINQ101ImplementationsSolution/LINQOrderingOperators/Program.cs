using LINQOrderingOperators.Models;

///////////////////////////////////////////////////////
/// Muliple descending ordering with a custom comparer
///////////////////////////////////////////////////////

string[] words6 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

var sortedWords6 = words6
    .OrderBy(word => word.Length)
    .ThenByDescending(word => word, new CaseInsensitiveComparer());

foreach (var sortedWord in sortedWords6)
{
    Console.WriteLine(sortedWord);
}

////////////////////////////////////////////
/// Muliple ordering with a custom comparer
////////////////////////////////////////////

string[] words5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

var sortedWords5 = words5
    .OrderBy(word => word.Length)
    .ThenBy(word => word, new CaseInsensitiveComparer());

foreach (var sortedWord in sortedWords5)
{
    Console.WriteLine(sortedWord);
}


////////////////////////////////////////////
/// Descending orders with custom comparer
////////////////////////////////////////////

string[] words4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

var sortedWords4 = words4.OrderByDescending(word => word, new CaseInsensitiveComparer());

foreach (var sortedWord in sortedWords4)
{
    Console.WriteLine(sortedWord);
}

////////////////////////////////////
/// Ordering with a custom comparer
////////////////////////////////////

string[] words3 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

var sortedWords3 = words3.OrderBy(word => word, new CaseInsensitiveComparer());

foreach (var sortedWord in sortedWords3)
{
    Console.WriteLine(sortedWord);
}

/////////////////////////////////
/// Reverse the sequence
/////////////////////////////////

string[] digits2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

var reversedIDigits = (
    from digit in digits2
    where digit[1] == 'i'
    select digit)
    .Reverse();

Console.WriteLine("A backwards list of the digits with a second character of 'i':");
foreach (var reversedIDigit in reversedIDigits)
{
    Console.WriteLine(reversedIDigit);
}

/////////////////////////////////
/// Multiple ordering descending
/////////////////////////////////

List<Product> products3 = GetProductList();

var sortedProducts3 = from product in products3
                     orderby product.Category, product.UnitPrice descending
                     select product;

foreach (var sortedProduct in sortedProducts3)
{
    Console.WriteLine(sortedProduct.ProductName + " -- " + sortedProduct.Category + " " + sortedProduct.UnitPrice);
}

/////////////////////////////////
/// Orderby multiple properties
/////////////////////////////////

string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

var sortedDigits = from digit in digits
                   orderby digit.Length, digit
                   select digit;

Console.WriteLine("Sorted digits:");
foreach (var sortedDigit in sortedDigits)
{
    Console.WriteLine(sortedDigit);
}

///////////////////////////////////////////
/// Descending ordering user defined types
///////////////////////////////////////////

List<Product> products2 = GetProductList();

var sortedProducts2 = from product in products2
                     orderby product.UnitsInStock descending
                     select product;

foreach (var sortedProduct in sortedProducts2)
{
    Console.WriteLine(sortedProduct.ProductName + " " + sortedProduct.UnitsInStock);
}

/////////////////////////////////
/// Orderby descending
/////////////////////////////////

double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

var sortedDoubles = from d in doubles
                    orderby d descending
                    select d;

Console.WriteLine("The doubles from highest to lowest:");
foreach (var d in sortedDoubles)
{
    Console.WriteLine(d);
}

/////////////////////////////////
/// Ordering user defined types
/////////////////////////////////

List<Product> products = GetProductList();

var sortedProducts = from product in products
                     orderby product.ProductName
                     select product;

foreach (var sortedProduct in sortedProducts)
{
    Console.WriteLine(sortedProduct.ProductName);
}

List<Product> GetProductList()
{
    var products = new List<Product>();
    Product product1 = new Product() 
    { ProductName = "Wrench", UnitsInStock = 4, Category = "New", UnitPrice = 10.0m };
    Product product2 = new Product() 
    { ProductName = "Key", UnitsInStock = 3, Category = "Used", UnitPrice = 5.0m };
    Product product3 = new Product()
    { ProductName = "Screwdriver", UnitsInStock = 10, Category = "New", UnitPrice = 15m };
    Product product4 = new Product() 
    { ProductName = "Bolt", UnitsInStock = 0, Category = "Used", UnitPrice = 20m };
    Product product5 = new Product() 
    { ProductName = "Hammer", UnitsInStock = 1, Category = "New", UnitPrice = 25m };
    products.Add(product1);
    products.Add(product2);
    products.Add(product3);
    products.Add(product4);
    products.Add(product5);

    return products;
}


/////////////////////////////////
/// Orderby using a property
/////////////////////////////////

string[] words2 = { "cherry", "apple", "blueberry" };

var sortedWords2 = from word in words2
                  orderby word.Length
                  select word;

Console.WriteLine("The sorted list of words (by length):");
foreach (var sortedWord in sortedWords2)
{
    Console.WriteLine(sortedWord);
}

/////////////////////////////////
/// Orderby sorts elements
/////////////////////////////////

string[] words = { "cherry", "apple", "blueberry" };

var sortedWords = from word in words
                  orderby word
                  select word;

Console.WriteLine("The sorted list of words:");
foreach (var sortedWord in sortedWords)
{
    Console.WriteLine(sortedWord);
}





// Custom comparer for use with ordering operators
public class CaseInsensitiveComparer : IComparer<string>
{
    public int Compare(string x, string y) =>
        string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
}