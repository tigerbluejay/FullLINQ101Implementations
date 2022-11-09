using LINQElementOperators.Models;


/////////////////////////////////////
//// Find the first element
/////////////////////////////////////

List<Product> products = GetProductList();

//Product product12 = (from product in products
//                     where product.ProductID == 12
//                     select product)
//                     .First();

var product12 = products.Where(product => product.ProductID == 12).First();

Console.WriteLine(product12);

List<Product> GetProductList()
{
    List<Product> productList = new List<Product>() {
        new Product { ProductID = 11 },
        new Product { ProductID = 11 },
        new Product { ProductID = 12 },
        new Product { ProductID = 12 },
        new Product { ProductID = 13 }
    };
    return productList;
}
Console.ReadKey();


/////////////////////////////////////
//// Find the first matching element
/////////////////////////////////////

string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

string startsWithO = strings.First(s => s[0] == 'o');

Console.WriteLine($"A string starting with 'o': {startsWithO}");
Console.ReadKey();


////////////////////////////////////////////////
//// First element of a possibly empty sequence
////////////////////////////////////////////////

// This sample uses FirstOrDefault to try to return the first element
// of the sequence, unless there are no elements, in which case the
// default value for that type is returned, in this case 0.

int[] numbers = { };

int firstNumOrDefault = numbers.FirstOrDefault();

Console.WriteLine(firstNumOrDefault);
Console.ReadKey();


///////////////////////////////////////
//// First matching element or default
///////////////////////////////////////

// This sample uses FirstOrDefault to try to return the first element
// of the sequence, unless there are no elements, in which case the
// default value for that type is returned, in this case null.
// We anticipate that and replace null with a boolean to indicate
// the sequence has no elements.

List<Product> products2 = GetProductList();

Product product789 = products2.FirstOrDefault(p => p.ProductID == 789);

Console.WriteLine($"Product 789 exists: {product789 != null}");
Console.ReadKey();


/////////////////////////////////////
//// Find element at position
/////////////////////////////////////

int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

//int fourthLowNum = (
//    from number in numbers2
//    where number > 5
//    select number)
//    .ElementAt(1);  // second number is index 1 because sequences use 0-based indexing

var fourthLowNum = numbers2.Where(number => number > 5).ElementAt(1); 

Console.WriteLine($"Second number > 5: {fourthLowNum}");
Console.ReadKey();

