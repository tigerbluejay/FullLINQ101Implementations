

//////////////////////////////////////////////
////////// Create a range of numbers
//////////////////////////////////////////////

var numbers = from number in Enumerable.Range(100, 50)
              select (Number: number, OddEven: number % 2 == 1 ? "odd" : "even");

foreach (var number in numbers)
{
    Console.WriteLine("The number {0} is {1}.", number.Number, number.OddEven);
}
Console.ReadKey();


//////////////////////////////////////////////
////////// Repeat a number
//////////////////////////////////////////////

var numbers2 = Enumerable.Repeat(7, 10);

foreach (var number in numbers2)
{
    Console.WriteLine(number);
}
Console.ReadKey();