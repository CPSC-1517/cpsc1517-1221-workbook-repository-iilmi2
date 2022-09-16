/* Test plan for Person
 * 
 * Test case
 * 1 - Valid Full Name 
 * 2- Null Full name
 * 3- Empty Fullnam
 * 4- whitespace full name
 * 5- full name < 3 characters
 * */
using NHLSystem;

Person validPerson = new Person("Connor McDavid");
Console.WriteLine(validPerson.FullName);

try
{
    Person validPerson1 = new Person("AB");
    Console.WriteLine(validPerson1.FullName);
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}