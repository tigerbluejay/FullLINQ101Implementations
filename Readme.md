# Full LINQ 101 Implementations

This project is a fork of the original **101 LINQ Examples by Microsoft**.

The 101 LINQ Examples by Microsoft is a *collection of queries that demonstrate
the full power of LINQ syntax*. These examples utilize mainly query style syntax and some times, when there is no alternative, fluent syntax.

This project maintains the core queries intact except for some variable renaming to improve readability, and **its main contribution is the _addition of relevant models such as Product, Order and Customer_, which should allow you understand how queries work when using custom classes.**

Thus, ***there are now method definitions initializing classes with data which map to the empty method calls in the original examples***.

## Project Organization

The project is organized around the original category query divisions Microsoft provided only now they are organized as individual projects alphabetically:

- Aggregator Operators
- Conversion Operatros
- Eager and Lazy Query Execution
- Element Operators
- Generate Sequences
- Grouping Operators
- Join Opertaions
- Ordering Operators
- Projection Operators
- Quantifying Members
- Sequence Operations
- Set Operators
- Partition Operators

Each project consists of a number of subsections corresponding to the original subsections, each with a query example, only now the examples provided at the start are placed at the bottom, with the end examples at the top. So it makes sense to read the examples from the bottom up in each project.

## Variable Renaming

Some variables have now a number appended only to distinguish them from similarly named variables in the same project. I did this because I wanted to maintain readable names for the variables. I didn't want to sacrifice changing variables to names that were not meaningful.

## This Project's Contribution

The idea behind this project is to lay everything bare, so when you execute the queries, particularly those that use custom classes, you can see the data flow from beginning to end through the query. **You can see in the method calls how lists of classes are being initialized, the values they are receiving, and how to the query uses that data to display results**. 

I did this because, before I created this project I wasn't sure how many levels of nesting inside custom classes were required by some of the queries, especially in those queries that have three or more levels of nesting. 

Now all the data is visible so it is easier to make sense of it. Although some queries are nested, in general classes nest one level deep, and so you may have a List of Customers, each with a property set to a List of Products, but in no case does nesting go deeper than that.

## Future Developments

Additional work is needed in terms of formatting for query results. For example there is no spacing or headings in the output, so all results stick together within each project - still you should be able to make out what each query's output is.