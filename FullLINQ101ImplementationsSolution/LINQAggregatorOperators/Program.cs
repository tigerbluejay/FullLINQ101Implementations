using LINQAggregatorOperators.Models;


//////////////////////////////////////////////
/////////// Count all elements in a sequence
//////////////////////////////////////////////

int[] factorsOf300 = { 2, 2, 3, 5, 5 };

int uniqueFactors = factorsOf300.Distinct().Count();

Console.WriteLine($"There are {uniqueFactors} unique factors of 300.");
Console.ReadKey();



////////////////////////////////////////////////////
/////////// Count all elements matching a condition
////////////////////////////////////////////////////

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

int oddNumbers = numbers.Count(number => number % 2 == 1);

Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);
Console.ReadKey();


//////////////////////////////////////////////////
/////////// Count all elements nested in a query
//////////////////////////////////////////////////

List<Customer> customers = GetCustomerList();

var orderCounts = from customer in customers
                  select (customer.CustomerID, OrderCount: customer.Orders.Count());

foreach (var customer in orderCounts)
{
    Console.WriteLine($"ID: {customer.CustomerID}, count: {customer.OrderCount}");
}
Console.ReadKey();
List<Customer> GetCustomerList()
{
    List<Customer> customerList = new List<Customer>();
    List<Order> orderList1 = new List<Order> {
        new Order() { OrderID=01},
        new Order() { OrderID=02},
        new Order() { OrderID=03}
    };
    List<Order> orderList2 = new List<Order> {
        new Order() { OrderID=04},
        new Order() { OrderID=05},
        new Order() { OrderID=06}
    };
    List<Order> orderList3 = new List<Order> {
        new Order() { OrderID=07},
        new Order() { OrderID=08},
        new Order() { OrderID=09}

    };
    Customer customer1 = new Customer() { CustomerID = 101, Orders = orderList1 };
    Customer customer2 = new Customer() { CustomerID = 201, Orders = orderList2 };
    Customer customer3 = new Customer() { CustomerID = 301, Orders = orderList3 };
    customerList.Add(customer1);
    customerList.Add(customer2);
    customerList.Add(customer3);
    return customerList;
}



///////////////////////////////////////////////////////////
/////////// Count all elements that are members of a group
///////////////////////////////////////////////////////////

List<Product> products = GetProductList();

var categoryCounts = from product in products
                     group product by product.Category into g
                     select (Category: g.Key, ProductCount: g.Count());

foreach (var categoryCount in categoryCounts)
{
    Console.WriteLine($"Category: {categoryCount.Category}: Product count: {categoryCount.ProductCount}");
}
Console.ReadKey();
List<Product> GetProductList()
{
    List<Product> productList = new List<Product>();
    Product product1 = new Product()
    { Category = "Home Furnishings", UnitsInStock = 10, UnitPrice = 1.00m };
    Product product2 = new Product()
    { Category = "Tools", UnitsInStock = 12, UnitPrice = 2.0m };
    Product product3 = new Product()
    { Category = "Appliances", UnitsInStock = 5, UnitPrice = 5.0m };
    Product product4 = new Product()
    { Category = "Appliances", UnitsInStock = 10, UnitPrice = 4.0m };
    productList.Add(product1); productList.Add(product2); productList.Add(product3);
    productList.Add(product4);
    return productList;
}



///////////////////////////////////////////////////
/////////// Sum all numeric elements in a sequence
///////////////////////////////////////////////////

int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

double numSum = numbers2.Sum();

Console.WriteLine($"The sum of the numbers is {numSum}");
Console.ReadKey();


//////////////////////////////////////////////
/////////// Sum a projection from a sequence
//////////////////////////////////////////////

string[] words = { "cherry", "apple", "blueberry" };

double totalChars = words.Sum(w => w.Length);

Console.WriteLine($"There are a total of {totalChars} characters in these words.");
Console.ReadKey();


/////////////////////////////////////////////////////////
/////////// Sum all elements that are members of a group
/////////////////////////////////////////////////////////

List<Product> products2 = GetProductList();

var categories = from product in products2
                 group product by product.Category into g
                 select (Category: g.Key, TotalUnitsInStock: g.Sum(product => product.UnitsInStock));

foreach (var pair in categories)
{
    Console.WriteLine($"Category: {pair.Category}, Units in stock: {pair.TotalUnitsInStock}");
}
Console.ReadKey();


////////////////////////////////////////////////////////
/////////// Find the minimum of a sequence of elements
///////////////////////////////////////////////////////

int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

int minNum = numbers3.Min();

Console.WriteLine($"The minimum number is {minNum}");
Console.ReadKey();


//////////////////////////////////////////////
/////////// Find the minimum of a projection
//////////////////////////////////////////////

string[] words2 = { "cherry", "apple", "blueberry" };

int shortestWord = words2.Min(word => word.Length);

Console.WriteLine($"The shortest word is {shortestWord} characters long.");
Console.ReadKey();


//////////////////////////////////////////////
/////////// Find the minimum in each group
//////////////////////////////////////////////

List<Product> products3 = GetProductList();

var categories2 = from product in products3
                  group product by product.Category into g
                  select (Category: g.Key, CheapestPrice: g.Min(product => product.UnitPrice));

foreach (var category in categories2)
{
    Console.WriteLine($"Category: {category.Category}, Lowest price: {category.CheapestPrice}");
}
Console.ReadKey();


///////////////////////////////////////////////////
/////////// Find all elements matching the minimum
///////////////////////////////////////////////////

List<Product> products4 = GetProductList();

var categories3 = from product in products4
                  group product by product.Category into g
                  let minPrice = g.Min(product => product.UnitPrice)
                  select (Category: g.Key, CheapestProducts: g.Where(product => product.UnitPrice == minPrice));

foreach (var category in categories3)
{
    Console.WriteLine($"Category: {category.Category}");
    foreach (var product in category.CheapestProducts)
    {
        Console.WriteLine($"\tProduct: {product}");
    }
}
Console.ReadKey();


///////////////////////////////////////////////////////
/////////// Find the maximum of a sequence of elements
///////////////////////////////////////////////////////

int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

int maxNum = numbers4.Max();

Console.WriteLine($"The maximum number is {maxNum}");
Console.ReadKey();


///////////////////////////////////////////////////
/////////// Find the maximum of a projection
///////////////////////////////////////////////////

string[] words3 = { "cherry", "apple", "blueberry" };

int longestLength = words3.Max(word => word.Length);

Console.WriteLine($"The longest word is {longestLength} characters long.");
Console.ReadKey();


///////////////////////////////////////////////////
/////////// Find the maximum in each group
///////////////////////////////////////////////////

List<Product> products5 = GetProductList();

var categories4 = from product in products5
                  group product by product.Category into g
                  select (Category: g.Key, MostExpensivePrice: g.Max(product => product.UnitPrice));

foreach (var category in categories4)
{
    Console.WriteLine($"Category: {category.Category} Most expensive product: {category.MostExpensivePrice}");
}
Console.ReadKey();


///////////////////////////////////////////////////
/////////// Find all elements matching the maximum
///////////////////////////////////////////////////

List<Product> products6 = GetProductList();

var categories5 = from product in products6
                  group product by product.Category into g
                  let maxPrice = g.Max(product => product.UnitPrice)
                  select (Category: g.Key, MostExpensiveProducts: g.Where(product => product.UnitPrice == maxPrice));

foreach (var category in categories5)
{
    Console.WriteLine($"Category: {category.Category}");
    foreach (var product in category.MostExpensiveProducts)
    {
        Console.WriteLine($"\t{product}");
    }
}
Console.ReadKey();


///////////////////////////////////////////////////////
/////////// Find the average of a sequence of elements
///////////////////////////////////////////////////////

int[] numbers5 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

double averageNum = numbers5.Average();

Console.WriteLine($"The average number is {averageNum}.");
Console.ReadKey();


///////////////////////////////////////////////////
/////////// Find the average of a projection
///////////////////////////////////////////////////

string[] words4 = { "cherry", "apple", "blueberry" };

double averageLength = words4.Average(word => word.Length);

Console.WriteLine($"The average word length is {averageLength} characters.");
Console.ReadKey();


///////////////////////////////////////////////////
/////////// Find the average in each group
///////////////////////////////////////////////////

List<Product> products7 = GetProductList();

var categories6 = from product in products7
                  group product by product.Category into g
                  select (Category: g.Key, AveragePrice: g.Average(product => product.UnitPrice));

foreach (var category in categories6)
{
    Console.WriteLine($"Category: {category.Category}, Average price: {category.AveragePrice}");
}
Console.ReadKey();


//////////////////////////////////////////////////////////////////////
/////////// Compute an aggreate value from all elements of a sequence
//////////////////////////////////////////////////////////////////////

double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

double productAggregate = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

Console.WriteLine($"Total product of all numbers: {productAggregate}");
Console.ReadKey();


/////////////////////////////////////////////////////////////////////////////////////////
/////////// Compute an aggregate value from a seed value and all elements of a sequence
/////////////////////////////////////////////////////////////////////////////////////////

double startBalance = 100.0;

int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

double endBalance =
    attemptedWithdrawals.Aggregate(startBalance,
        (balance, nextWithdrawal) =>
            ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));

Console.WriteLine($"Ending balance: {endBalance}");
Console.ReadKey();

