using LINQSetOperators.Models;


/////////////////////////////////////////////
/////// Find distinct elements
/////////////////////////////////////////////

int[] factorsOf300 = { 2, 2, 3, 5, 5 };

var uniqueFactors = factorsOf300.Distinct();

Console.WriteLine("Prime factors of 300:");
foreach (var uniqueFactor in uniqueFactors)
{
    Console.WriteLine(uniqueFactor);
}
Console.ReadKey();


/////////////////////////////////////////////
/////// Find distinct values of a property
/////////////////////////////////////////////

List<Product> products = GetProductList();

//var categoryNames = (from product in products
//                     select product.Category)
//                     .Distinct();

var categoryNames = products.Select(product => product.Category).Distinct();

Console.WriteLine("Category names:");
foreach (var categoryName in categoryNames)
{
    Console.WriteLine(categoryName);
}
Console.ReadKey();

List<Product> GetProductList()
{
    var products = new List<Product>();
    Product product0 = new Product() { Category = "Tools", ProductName = "Hammer" };
    Product product1 = new Product() { Category = "Home Decor", ProductName = "Shade" };
    Product product2 = new Product() { Category = "Utensils", ProductName = "Fork" };
    Product product3 = new Product() { Category = "Tools", ProductName = "Nail" };
    products.Add(product0);
    products.Add(product1);
    products.Add(product2);
    products.Add(product3);

    return products;
}



/////////////////////////////////////////////
/////// Find the union of sets
/////////////////////////////////////////////

int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };

var uniqueNumbers = numbersA.Union(numbersB);

Console.WriteLine("Unique numbers from both arrays:");
foreach (var uniqueNumber in uniqueNumbers)
{
    Console.WriteLine(uniqueNumber);
}
Console.ReadKey();


/////////////////////////////////////////////
/////// Union of query results
/////////////////////////////////////////////

List<Product> products2 = GetProductList();
List<Customer> customers2 = GetCustomerList();

//var productFirstChars = from product in products2
//                        select product.ProductName[0];
//var customerFirstChars = from customer in customers2
//                         select customer.CompanyName[0];

var productFirstChars = products2.Select(product => product.ProductName[0]);
var customerFirstChars = customers2.Select(customer => customer.CompanyName[0]);

var uniqueFirstChars = productFirstChars.Union(customerFirstChars);

Console.WriteLine("Unique first letters from Product names and Customer names:");
foreach (var uniqueFirstChar in uniqueFirstChars)
{
    Console.WriteLine(uniqueFirstChar);
}
Console.ReadKey();

List<Customer> GetCustomerList()
{
    List<Customer> customerList = new List<Customer>();
    Customer customer1 = new Customer() { CompanyName = "Kellogs" };
    Customer customer2 = new Customer() { CompanyName = "Nestle" };
    Customer customer3 = new Customer() { CompanyName = "Hellmans" };
    Customer customer4 = new Customer() { CompanyName = "Krogers" };
    customerList.Add(customer1);
    customerList.Add(customer2);
    customerList.Add(customer3);
    customerList.Add(customer4);
    return customerList;
}



/////////////////////////////////////////////
/////// Find the intersection of two sets
/////////////////////////////////////////////

int[] numbersA2 = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB2 = { 1, 3, 5, 7, 8 };

var commonNumbers = numbersA2.Intersect(numbersB2);

Console.WriteLine("Common numbers shared by both arrays:");
foreach (var commonNumber in commonNumbers)
{
    Console.WriteLine(commonNumber);
}
Console.ReadKey();

//////////////////////////////////////////////////
/////// Find the intersection of query results
//////////////////////////////////////////////////

List<Product> products3 = GetProductList();
List<Customer> customers3 = GetCustomerList();

//var productFirstChars3 = from product in products3
//                         select product.ProductName[0];
//var customerFirstChars3 = from customer in customers3
//                          select customer.CompanyName[0];

var productFirstChars3 = products3.Select(product => product.ProductName[0]);
var customerFirstChars3 = customers3.Select(customer => customer.CompanyName[0]);

var commonFirstChars = productFirstChars3.Intersect(customerFirstChars3);

Console.WriteLine("Common first letters from Product names and Customer names:");
foreach (var commonFirstChar in commonFirstChars)
{
    Console.WriteLine(commonFirstChar);
}
Console.ReadKey();


/////////////////////////////////////////////
/////// Difference of two sets
/////////////////////////////////////////////

int[] numbersA4 = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB4 = { 1, 3, 5, 7, 8 };

IEnumerable<int> aOnlyNumbers = numbersA4.Except(numbersB4);

Console.WriteLine("Numbers in first array but not second array:");
foreach (var aOnlyNumber in aOnlyNumbers)
{
    Console.WriteLine(aOnlyNumber);
}
Console.ReadKey();


/////////////////////////////////////////////
/////// Difference of two queries
/////////////////////////////////////////////

List<Product> products4 = GetProductList();
List<Customer> customers4 = GetCustomerList();

//var productFirstChars4 = from product in products4
//                        select product.ProductName[0];
//var customerFirstChars4 = from customer in customers4
//                         select customer.CompanyName[0];

var productFirstChars4 = products4.Select(product => product.ProductName[0]);
var customerFirstChars4 = customers4.Select(customer => customer.CompanyName[0]);

var productOnlyFirstChars4 = productFirstChars4.Except(customerFirstChars4);

Console.WriteLine("First letters from Product names, but not from Customer names:");
foreach (var productOnlyFirstChar in productOnlyFirstChars4)
{
    Console.WriteLine(productOnlyFirstChar);
}
Console.ReadKey();