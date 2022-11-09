using LINQProjectionOperators.Classes;


///////////////////////////////
//// Select Clause
///////////////////////////////

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

//var numbersPlusOne = from number in numbers
//                     select number + 1;

var numbersPlusOne = numbers.Select(number => number + 1);

Console.WriteLine("Numbers + 1:");
foreach (var numberPlusOne in numbersPlusOne)
{
    Console.WriteLine(numberPlusOne);
}
Console.ReadKey();


///////////////////////////////
//// Select a Single Property
///////////////////////////////

List<Product> products = GetProductList();

//var productNames = from product in products
//                   select product.ProductName;

var productNames = products.Select(product => product.ProductName);

Console.WriteLine("Product Names:");
foreach (var productName in productNames)
{
    Console.WriteLine(productName);
}
Console.ReadKey();

List<Product> GetProductList()
{
    List<Product> products = new List<Product>();
    products.Add(new Product { ProductName = "scissors", Category = "tools", UnitPrice = 10m });
    products.Add(new Product { ProductName = "paper", Category = "supplies", UnitPrice = 12m });
    products.Add(new Product { ProductName = "glue", Category = "tools", UnitPrice = 14m });
    products.Add(new Product { ProductName = "pencil", Category = "supplies", UnitPrice = 7m });
    products.Add(new Product { ProductName = "pen", Category = "supplies", UnitPrice = 20m });
    return products;
}



///////////////////////////////
//// Transform with Select
///////////////////////////////

int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

//var textNumbers = from number in numbers2
//                  select strings[number];

var textNumbers = numbers2.Select(number => strings[number]);

Console.WriteLine("Number strings:");
foreach (var textNumber in textNumbers)
{
    Console.WriteLine(textNumber);
}
Console.ReadKey();


/////////////////////////////////////
//// Select Anonymous Types or Tuples
/////////////////////////////////////

string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

//var upperLowerWords = from word in words
//                      select new { Upper = word.ToUpper(), Lower = word.ToLower() };

var upperLowerWords = words.Select(word => new { Upper = word.ToUpper(), Lower = word.ToLower() }).ToList();


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
Console.ReadKey();


/////////////////////////////////////
//// Use select to create new types
/////////////////////////////////////

int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] strings3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

//var digitOddEvens = from number in numbers4
//                    select new { Digit = strings3[number], Even = (number % 2 == 0) };

var digitOddEvens = numbers4.Select( number => new { Digit = strings3[number], Even = number % 2 == 0 });

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
Console.ReadKey();


/////////////////////////////////////
//// Select a subset of properties
/////////////////////////////////////

List<Product> products2 = GetProductList();

//var productInfos = from product in products2
//                   select (product.ProductName, product.Category, Price: product.UnitPrice);

var productInfos = products2.Select(product => new { product.ProductName, product.Category, Price = product.UnitPrice });

Console.WriteLine("Product Info:");
foreach (var productInfo in productInfos)
{
    Console.WriteLine($"{productInfo.ProductName} is in the category {productInfo.Category} and costs {productInfo.Price} per unit.");
}
Console.ReadKey();


/////////////////////////////////////
//// Select with index of item
/////////////////////////////////////

int[] numbers5 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var numbersInPlace = numbers5.Select((number, index) => (Num: number, InPlace: (number == index)));

Console.WriteLine("Number: In-place?");
foreach (var numberInPlace in numbersInPlace)
{
    Console.WriteLine($"{numberInPlace.Num}: {numberInPlace.InPlace}");
}
Console.ReadKey();


/////////////////////////////////////
//// Select combined with where
/////////////////////////////////////

int[] numbers6 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] digits6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

//var lowNumbers = from number in numbers6
//                 where number < 5
//                 select digits6[number];

var lowNumbers = numbers6.Where(number => number < 5).Select(number => digits6[number]);

Console.WriteLine("Numbers < 5:");
foreach (var lowNumber in lowNumbers)
{
    Console.WriteLine(lowNumber);
}
Console.ReadKey();


//////////////////////////////////////////
//// Select from multiple input sequences !!!!
//////////////////////////////////////////

int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };

var pairs = from numberA in numbersA
            from numberB in numbersB
            where numberA < numberB
            select (numberA, numberB);


Console.WriteLine("Pairs where a < b:");

foreach (var pair in pairs)
{
    Console.WriteLine($"{pair.numberA} is less than {pair.numberB}");
}
Console.ReadKey();


//////////////////////////////////////////
//// Select from related input sequences
//////////////////////////////////////////

List<Customer> customers = GetCustomerList();

var orders = from customer in customers
             from order in customer.Orders
             where order.Total < 500.00M
             select (customer.CustomerID, order.OrderID, order.Total);

foreach (var order in orders)
{
    Console.WriteLine($"Customer: {order.CustomerID}, Order: {order.OrderID}, Total value: {order.Total}");
}
Console.ReadKey();

List<Customer> GetCustomerList()
{
    List<Order> orders1 = new List<Order>();
    orders1.Add(new Order { OrderID = 101, Total = 300m, OrderDate = new DateTime(1999, 1, 1) });
    orders1.Add(new Order { OrderID = 102, Total = 400m, OrderDate = new DateTime(2000, 7, 7) });
    orders1.Add(new Order { OrderID = 103, Total = 500m, OrderDate = new DateTime(2001, 7, 1) });

    List<Order> orders2 = new List<Order>();
    orders2.Add(new Order { OrderID = 201, Total = 400m, OrderDate = new DateTime(1994, 1, 1) });
    orders2.Add(new Order { OrderID = 202, Total = 500m, OrderDate = new DateTime(1995, 1, 1) });
    orders2.Add(new Order { OrderID = 203, Total = 600m, OrderDate = new DateTime(1999, 1, 1) });

    List<Order> orders3 = new List<Order>();
    orders3.Add(new Order { OrderID = 301, Total = 2500m, OrderDate = new DateTime(1991, 1, 1) });
    orders3.Add(new Order { OrderID = 302, Total = 600m, OrderDate = new DateTime(1997, 1, 1) });
    orders3.Add(new Order { OrderID = 303, Total = 2700m, OrderDate = new DateTime(1999, 1, 1) });

    List<Customer> customers = new List<Customer>();
    customers.Add(new Customer { CustomerID = 1, Orders = orders1, Region = "WA" });
    customers.Add(new Customer { CustomerID = 2, Orders = orders2, Region = "CA" });
    customers.Add(new Customer { CustomerID = 3, Orders = orders3, Region = "WA" });

    return customers;
}



//////////////////////////////////////////
//// Compound Select with Where clause
//////////////////////////////////////////

List<Customer> customers2 = GetCustomerList();

var orders2 = from customer in customers2
              from order in customer.Orders
              where order.OrderDate >= new DateTime(1998, 1, 1)
              select (customer.CustomerID, order.OrderID, order.OrderDate);

foreach (var order in orders2)
{
    Console.WriteLine($"Customer: {order.CustomerID}, Order: {order.OrderID}, Total date: {order.OrderDate.ToShortDateString()}");
}
Console.ReadKey();


/////////////////////////////////////////////////
//// Compound Select with Where and assignment
/////////////////////////////////////////////////

List<Customer> customers3 = GetCustomerList();

var orders3 = from customer in customers3
              from order in customer.Orders
              where order.Total >= 2000.0M
              select (customer.CustomerID, order.OrderID, order.Total);

foreach (var order in orders3)
{
    Console.WriteLine($"Customer: {order.CustomerID}, Order: {order.OrderID}, Total value: {order.Total}");
}
Console.ReadKey();


/////////////////////////////////////////////////
//// Compound Select with multiple where clauses
/////////////////////////////////////////////////

List<Customer> customers4 = GetCustomerList();

DateTime cutoffDate = new DateTime(1997, 1, 1);

var orders4 = from customer in customers4
              where customer.Region == "WA"
              from order in customer.Orders
              where order.OrderDate >= cutoffDate
              select (customer.CustomerID, order.OrderID);

foreach (var order in orders4)
{
    Console.WriteLine($"Customer: {order.CustomerID}, Order: {order.OrderID}");
}
Console.ReadKey();


/////////////////////////////////////////////////
//// Compound Select with index 
/////////////////////////////////////////////////

List<Customer> customers5 = GetCustomerList();

var customerOrders =
    customers5.SelectMany(
        (customer, customerIndex) =>
        customer.Orders.Select(order => "Customer #" + (customerIndex + 1) +
                                " has an order with OrderID " + order.OrderID));

foreach (var customerOrder in customerOrders)
{
    Console.WriteLine(customerOrder);
}
Console.ReadKey();