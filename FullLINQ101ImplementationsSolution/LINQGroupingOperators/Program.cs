using LINQGroupingOperators.Models;


////////////////////////////////////////
//// Groupby into buckets
////////////////////////////////////////

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var numberGroups = from number in numbers
                   group number by number % 5 into g
                   select (Remainder: g.Key, Numbers: g);

foreach (var numberGroup in numberGroups)
{
    Console.WriteLine($"Numbers with a remainder of {numberGroup.Remainder} when divided by 5:");
    foreach (var number in numberGroup.Numbers)
    {
        Console.WriteLine(number);
    }
}
Console.ReadKey();


////////////////////////////////////////
//// Groupby using a property
////////////////////////////////////////
string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

var wordGroups = from word in words
                 group word by word[0] into g
                 select (FirstLetter: g.Key, Words: g);

foreach (var wordGroup in wordGroups)
{
    Console.WriteLine("Words that start with the letter '{0}':", wordGroup.FirstLetter);
    foreach (var word in wordGroup.Words)
    {
        Console.WriteLine(word);
    }
}
Console.ReadKey();


////////////////////////////////////////
//// Grouping using a key property
////////////////////////////////////////
List<Product> products = GetProductList();

var orderGroups = from product in products
                  group product by product.Category into g
                  select (Category: g.Key, Products: g);

foreach (var orderGroup in orderGroups)
{
    Console.WriteLine($"Products in {orderGroup.Category} category:");
    foreach (var product in orderGroup.Products)
    {
        Console.WriteLine($"\t{product}");
    }
}
Console.ReadKey();

List<Product> GetProductList()
{
    List<Product> productsList = new List<Product>();
    Product product1 = new Product() { Category = "New" };
    Product product2 = new Product() { Category = "Used" };
    Product product3 = new Product() { Category = "New" };
    Product product4 = new Product() { Category = "Used" };
    productsList.Add(product1);
    productsList.Add(product2);
    productsList.Add(product3);
    productsList.Add(product4);
    return productsList;
}



////////////////////////////////////////
//// Nested Group by Queries
////////////////////////////////////////
/* In this example we have a customer list which has many customers.
 * Each customer in turn has a list of orders with some data, including
 * the date time from which we extract the year and the month.
 * Months are not nested into years.*/

List<Customer> customers = GetCustomerList();

var customerOrderGroups = from customer in customers
                          select
                          (
                          customer.CompanyName,
                          YearGroups: from order in customer.Orders
                                      group order by order.OrderDate.Year into yg
                                      select
                                      (
                                      Year: yg.Key,
                                      MonthGroups: from o in yg
                                                   group o by o.OrderDate.Month into mg
                                                   select (Month: mg.Key, Orders: mg)
                                      )
                          );

foreach (var ordersByCustomer in customerOrderGroups)
{
    Console.WriteLine($"Customer Name: {ordersByCustomer.CompanyName}");
    foreach (var ordersByYear in ordersByCustomer.YearGroups)
    {
        Console.WriteLine($"\tYear: {ordersByYear.Year}");
        foreach (var ordersByMonth in ordersByYear.MonthGroups)
        {
            Console.WriteLine($"\t\tMonth: {ordersByMonth.Month}");
            foreach (var order in ordersByMonth.Orders)
            {
                Console.WriteLine($"\t\t\tOrder: {order}");
            }
        }
    }
}
Console.ReadKey();

List<Customer> GetCustomerList()

{

    List<Customer> customerList = new List<Customer>();
    List<Order> orderList1 = new List<Order>();
    List<Order> orderList2 = new List<Order>();
    Order order1 = new Order() { OrderDate = DateTime.Today.AddDays(-4) };
    Order order2 = new Order() { OrderDate = DateTime.Today.AddDays(-15) };
    Order order3 = new Order() { OrderDate = DateTime.Today.AddDays(-27) };
    Order order4 = new Order() { OrderDate = DateTime.Today.AddDays(-40) };
    Order order5 = new Order() { OrderDate = DateTime.Today.AddDays(-57) };
    orderList1.Add(order1);
    orderList1.Add(order2);
    orderList1.Add(order3);
    orderList1.Add(order4);
    orderList1.Add(order5);
    Order order6 = new Order() { OrderDate = DateTime.Today.AddDays(-41) };
    Order order7 = new Order() { OrderDate = DateTime.Today.AddDays(-50) };
    Order order8 = new Order() { OrderDate = DateTime.Today.AddDays(-62) };
    Order order9 = new Order() { OrderDate = DateTime.Today.AddDays(-70) };
    Order order10 = new Order() { OrderDate = DateTime.Today.AddDays(-75) };
    orderList2.Add(order6);
    orderList2.Add(order7);
    orderList2.Add(order8);
    orderList2.Add(order9);
    orderList2.Add(order10);
    Customer customerA = new Customer() { CompanyName = "Fravega", Orders = orderList1 };
    Customer customerB = new Customer() { CompanyName = "Rodo", Orders = orderList2 };
    customerList.Add(customerA);
    customerList.Add(customerB);

    return customerList;
};



////////////////////////////////////////
//// Groupby with a custom comparaer
////////////////////////////////////////

string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

var orderGroups2 = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());

foreach (var set in orderGroups2)
{
    // The key would be the first item in the set
    foreach (var word in set)
    {
        Console.WriteLine(word);
    }
    Console.WriteLine("...");
}
Console.ReadKey();


/////////////////////////////////////////////
//// Groupby with a custom comparer with Key
/////////////////////////////////////////////

string[] anagrams3 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

var orderGroups3 = anagrams3.GroupBy(
            w => w.Trim(),
            a => a.ToUpper(),
            new AnagramEqualityComparer()
            );
foreach (var set in orderGroups3)
{
    Console.WriteLine(set.Key);
    foreach (var word in set)
    {
        Console.WriteLine($"\t{word}");
    }
}
Console.ReadKey();


/// <summary>
/// Equality Comparer Code. Compares if words are anagrams
/// </summary>
public class AnagramEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y) => getCanonicalString(x) == getCanonicalString(y);

    public int GetHashCode(string obj) => getCanonicalString(obj).GetHashCode();

    private string getCanonicalString(string word)
    {
        char[] wordChars = word.ToCharArray();
        Array.Sort<char>(wordChars);
        return new string(wordChars);
    }
}