using LINQPartitionOperators.Classes;


///////////////////////////////////////
/////// Indexed Skip While
///////////////////////////////////////


int[] numbers6 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var laterNumbers = numbers6.SkipWhile((number, index) => number >= index);

Console.WriteLine("All elements starting from first element less than its position:");
foreach (var number in laterNumbers)
{
    Console.WriteLine(number);
}


///////////////////////////////////////
/////// Skip While Synthax
///////////////////////////////////////

int[] numbers5 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// In the lambda expression, 'n' is the input parameter that identifies each
// element in the collection in succession. It is is inferred to be
// of type int because numbers is an int array.
var allButFirst3Numbers = numbers5.SkipWhile(number => number % 3 != 0);

Console.WriteLine("All elements starting from first element divisible by 3:");
foreach (var number in allButFirst3Numbers)
{
    Console.WriteLine(number);
}

///////////////////////////////////////
/////// Indexed Take While
///////////////////////////////////////


int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var firstSmallNumbers = numbers4.TakeWhile((number, index) => number >= index);

Console.WriteLine("First numbers not less than their position:");
foreach (var number in firstSmallNumbers)
{
    Console.WriteLine(number);
}


///////////////////////////////////////
/////// Take While Synthax
///////////////////////////////////////

int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var firstNumbersLessThan6 = numbers3.TakeWhile(number => number < 6);

Console.WriteLine("First numbers less than 6:");
foreach (var number in firstNumbersLessThan6)
{
    Console.WriteLine(number);
}

///////////////////////////////////////
/////// Nested Skip Partitions
///////////////////////////////////////

List<Customer> customers2 = GetCustomerList();

var waOrders = from customer in customers2
               from order in customer.Orders
               where customer.Region == "WA"
               select (customer.CustomerID, order.OrderID, order.OrderDate);

var allButFirst2Orders = waOrders.Skip(2);

Console.WriteLine("All but first 2 orders in WA:");
foreach (var order in allButFirst2Orders)
{
    Console.WriteLine(order);
}

///////////////////////////////////////
/////// Skip Elements
///////////////////////////////////////

int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var allButFirst4Numbers = numbers2.Skip(4);

Console.WriteLine("All but first 4 numbers:");
foreach (var number in allButFirst4Numbers)
{
    Console.WriteLine(number);
}

///////////////////////////////////////
/////// Nested Take Partitions
///////////////////////////////////////


List<Customer> customers = GetCustomerList();

var first3WAOrders = (from customer in customers
                      from order in customer.Orders
                      where customer.Region == "WA"
                      select (customer.CustomerID, order.OrderID, order.OrderDate))
                     .Take(3);

Console.WriteLine("First 3 orders in WA:");
foreach (var first3WAOrder in first3WAOrders)
{
    Console.WriteLine(first3WAOrder);
}

List<Customer> GetCustomerList()
{
    List<Customer> customers = new List<Customer>();

    List<Order> orders1 = new List<Order>();
    orders1.Add(new Order { OrderID = 101, OrderDate = new DateTime(1996, 1, 1) });
    orders1.Add(new Order { OrderID = 102, OrderDate = new DateTime(1998, 1, 1) });
    orders1.Add(new Order { OrderID = 103, OrderDate = new DateTime(1999, 1, 1) });
    List<Order> orders2 = new List<Order>();
    orders2.Add(new Order { OrderID = 204, OrderDate = new DateTime(1998, 1, 1) });
    orders2.Add(new Order { OrderID = 205, OrderDate = new DateTime(1999, 1, 1) });
    orders2.Add(new Order { OrderID = 206, OrderDate = new DateTime(2000, 1, 1) });
    List<Order> orders3 = new List<Order>();
    orders3.Add(new Order { OrderID = 307, OrderDate = new DateTime(1994, 1, 1) });
    orders3.Add(new Order { OrderID = 308, OrderDate = new DateTime(1995, 1, 1) });
    orders3.Add(new Order { OrderID = 309, OrderDate = new DateTime(2007, 1, 1) });

    customers.Add(new Customer { CustomerID = 1001, Orders = orders1, Region = "WA" });
    customers.Add(new Customer { CustomerID = 1002, Orders = orders2, Region = "WA" });
    customers.Add(new Customer { CustomerID = 1003, Orders = orders3, Region = "CA" });

    return customers;
}


///////////////////////////////////////
/////// Take Elements
///////////////////////////////////////

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var first3Numbers = numbers.Take(3);

Console.WriteLine("First 3 numbers:");
foreach (var number in first3Numbers)
{
    Console.WriteLine(number);
}