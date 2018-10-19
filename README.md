# Lab08 - LINQ
Deserializes external JSON file and makes LINQ queries using regular linq and lambda expressions.

This program was written for Code Fellows Code 401 C#/.NET class to practice linq and JSON conversion.

It implements the following queries: 
1. Output all of the neighborhoods in this data list
2. Filter out all the neighborhoods that do not have any names
3. Remove the Duplicates / rewrite the queries from above, and consolidate all into one single query.
4. Rewrite at least one of these questions only using the opposing method (example: Use LINQ instead of a Lambda and vice versa.)

## Installation/Usage
Clone the repository, open the LINQ solution in Visual Studio, and run without debugging. The program will output the resulting list from each query, one after the other.

## Example Execution
1. Query #1: Gets all neighborhood names from each feature (picture below does not show every neighborhood in list)

![all-neighborhoods](/assets/query1.PNG)


2. Query #2: Chains off of query #1 to remove empty strings from the list of neighborhoods (picture below does not show every neighborhood in list)

![remove-empties](/assets/query2.PNG)


3. Queries 3 and 4: Chains off of query #2 to remove duplicates and also condenses getting each neighborhood and filtering out empty neighborhood strings into a single query (picture below does not show every neighborhood in list)

![remove-duplicates](/assets/query3_4.PNG)


4. Query #5: Refactors the previous query into a ye olde linq
![refactored-linq](/assets/query5.PNG)
