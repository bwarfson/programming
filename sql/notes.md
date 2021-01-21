# SQL Server CROSS APPLY and OUTER APPLY

> SQL Server 2005 introduced the APPLY operator, which is like a join clause and it allows joining between two table expressions i.e. joining a left/outer table expression with a right/inner table expression. The difference between the join and APPLY operator becomes evident when you have a table-valued expression on the right side and you want this table-valued expression to be evaluated for each row from the left table expression. In this tip I am going to demonstrate the APPLY operator, how it differs from regular JOINs and some uses.

> The APPLY operator allows you to join two table expressions; the right table expression is processed every time for each row from the left table expression. As you might have guessed, the left table expression is evaluated first and then the right table expression is evaluated against each row of the left table expression for the final result set. The final result set contains all the selected columns from the left table expression followed by all the columns of the right table expression.

## SQL Server APPLY operator has two variants; CROSS APPLY and OUTER APPLY
- The CROSS APPLY operator returns only those rows from the left table expression (in its final output) if it matches with the right table expression. In other words, the right table expression returns rows for the left table expression match only.
- The OUTER APPLY operator returns all the rows from the left table expression irrespective of its match with the right table expression. For those rows for which there are no corresponding matches in the right table expression, it contains NULL values in columns of the right table expression.
- So you might conclude, the CROSS APPLY is equivalent to an INNER JOIN (or to be more precise its like a CROSS JOIN with a correlated sub-query) with an implicit join condition of 1=1 whereas the OUTER APPLY is equivalent to a LEFT OUTER JOIN.

> You might be wondering if the same can be achieved with a regular JOIN clause, so why and when do you use the APPLY operator? Although the same can be achieved with a normal JOIN, the need of APPLY arises if you have a table-valued expression on the right part and in some cases the use of the APPLY operator boosts performance of your query. 

# SQL INNER JOIN Keyword

> The INNER JOIN keyword selects records that have matching values in both tables. The INNER JOIN keyword selects all rows from both tables as long as there is a match between the columns. 