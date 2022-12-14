# Full LINQ 101 Implementations
This project is a fork of the original **101 LINQ Examples by Microsoft**.

The 101 LINQ Examples by Microsoft is a *collection of queries that demonstrate the full power of LINQ syntax*. These examples utilize mainly query style syntax and some times, when there is no alternative, fluent syntax.

This project maintains the core queries intact except for some variable renaming to improve readability, and **its main contribution is the addition of relevant models such as Product, Order and Customer, which should allow you understand how queries work when using custom classes.**

Thus, **there are now method definitions initializing classes with data which map to the empty method calls in the original examples.**

In addition, **fluent syntax alternatives have been appended to the original queries provided by Microsoft**, which have been modified to be comments where appropriate.

## Project Organization
The project is organized around the original category query divisions Microsoft provided only now they are organized as individual projects alphabetically:

Aggregator Operators
Conversion Operators
Eager and Lazy Query Execution
Element Operators
Generate Sequences
Grouping Operators
Join Operations
Ordering Operators
Projection Operators
Quantifying Members
Sequence Operations
Set Operators
Partition Operators
Variable Renaming
Some variables have now a number appended only to distinguish them from similarly named variables in the same project. I did this because I wanted to maintain readable names for the variables. I didn't want to sacrifice changing variables to names that were not meaningful.

## This Project's Contribution
The idea behind this project is to lay everything bare, so when you execute the queries, particularly those that use custom classes, you can see the data flow from beginning to end through the query. You can see in the method calls how lists of classes are being initialized, the values they are receiving, and how to the query uses that data to display results.

I did this because, before I created this project I wasn't sure how many levels of nesting inside custom classes were required by some of the queries, especially in those queries that have three or more levels of nesting.

Now all the data is visible so it is easier to make sense of it. Although some queries are nested, in general classes nest one level deep, and so you may have a List of Customers, each with a property set to a List of Products, but in no case does nesting go deeper than that.

The addition of fluent syntax alternative queries is another contribution to the original project by Microsoft.

## Release Publication
Learn more about how to use this repo in the following link:

[Read Article](https://dev.to/josemariairiarte/learn-linq-with-101-examples-and-sample-data-query-syntax-26an)