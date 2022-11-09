

//////////////////////////////////////
//////// Queries execute lazily
//////////////////////////////////////
//The following sample shows how query execution is deferred
// until the query is enumerated at a foreach statement.
// This is the default for LINQ

// Sequence operators form first-class queries that
// are not executed until you enumerate over them.

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

int i = 0;
//var query = from number in numbers
//            select ++i;

var query = numbers.Select(number => ++i);

// Note, the local variable 'i' is not incremented
// until each element is evaluated (as a side-effect):
// On this for each loop is when the query is executed
foreach (var value in query)
{
    Console.WriteLine($"v = {value}, i = {i}");
}
Console.ReadKey();


////////////////////////////////////////
//////// Request Eager Query Execution
////////////////////////////////////////
// The following sample shows how queries can be executed
// immediately with operators such as ToList().


// Methods like ToList() cause the query to be
// executed immediately, caching the results.
// The query has been executed when we call the ToList() method.

int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

int j = 0;
//var query2 = (from number in numbers2
//              select ++j)
//         .ToList();

var query2 = numbers2.Select(number => ++j).ToList();

// The local variable j has already been fully
// incremented before we iterate the results:
foreach (var value in query2)
{
    Console.WriteLine($"v = {value}, j = {j}");
}
Console.ReadKey();


/////////////////////////////////////////
//////// Reuse Queries with New Results 
/////////////////////////////////////////
// The following sample shows how, because of deferred execution,
// queries can be used again after data changes
// and will then operate on the new data.

// Deferred execution lets us define a query once
// and then reuse it later after data changes.

int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var lowNumbers = from number in numbers3
//                 where number <= 3
//                 select number;

var lowNumbers = numbers3.Where(number => number <= 3);

Console.WriteLine("First run numbers <= 3:");
foreach (int number in lowNumbers)
{
    Console.WriteLine(number);
}

for (int k = 0; k < 10; k++)
{
    numbers3[k] = -numbers3[k];
}

// During this second run, the same query object,
// lowNumbers, will be iterating over the new state
// of numbers[], producing different results:
Console.WriteLine("Second run numbers <= 3:");
foreach (int n in lowNumbers)
{
    Console.WriteLine(n);
}
Console.ReadKey();