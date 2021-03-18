# C# 


## LINQ
---
### First()
It has two overloaded versions. One overloaded version does not accept any parameter as input ,it returns the first element of the sequence and throws an InvalidOperation Exception if the sequence is empty.
```c#
int[] num = {2,3,4,5,6,7,8}  
Console.WriteLine(num.First())  // Output will be 2
```
```c#
int[] num = { }  
Console.WriteLine(num.First()) // Will throw an InvalidOperation Exception
```
```c#
int[] num = {2,3,4,5,6,7,8}  
Console.WriteLine(num.First(x => x % 4==0))  // Output will be 4
```
```c#
int[] num = { }  
Console.WriteLine(num.First(x => x % 4 == 0)) //InvalidOperation Exception
```
### FirstOrDefault()
It also has two overloaded versions and works the same as First(), except it will not throw an error if sequence is empty or no element is found that
satisfies the condition. Instead it will return default values, for reference type default value is NULL and for value type the default value depends on actual type expected. 
```c#
int[] num = { }  
Console.WriteLine(num.FirstOrDefault(x => x % 4 == 0))  // 0
```
```c#
int[] num = {2,3,4,5,6,7,8}  
Console.WriteLine(num.FirstOrDefault(x => x % 10==0))   // 0
```
```c#
string[] name = { "ABC", "DE", "XYZH", "LMNO" };  
Console.WriteLine(name.FirstOrDefault(x => x.Length > 5));    // Output will be blank
```