// See https://aka.ms/new-console-template for more information

using Kata;

var anagramFinder = new AnagramFinder();
var results = anagramFinder.Find("documenting");

if (!results.Any())
{
    Console.WriteLine("No Anagrams Found");   
}
else
{
    Console.WriteLine($"Found {results.Count} Anagrams:");
    foreach (var anagram in results)
    {
        Console.WriteLine(anagram);
    }
}
    