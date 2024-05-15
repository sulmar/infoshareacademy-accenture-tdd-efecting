
using Comments;

var names  = new List<string>();
List<decimal>? salaries = null;

// Iteracja po nazwach
foreach (var name in names)
{
    Console.WriteLine(name);
}

// Jeśli lista jest pusta wyświetlamy powiadomienie
if (names.IsNullOrEmpty())
{
    Console.WriteLine("Lista rezultatów jest pusta");
}


if (salaries.IsNullOrEmpty())
{
    Console.WriteLine("Lista rezultatów jest pusta");
}