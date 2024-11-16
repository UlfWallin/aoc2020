string[] outlet = {"0"};
var adapters = outlet
    .Concat(File.ReadAllLines("sample2.txt"))
    .Select(line => int.Parse(line))
    .Order()
    .ToArray();

var diffs = adapters
    .Zip(adapters[1..], (first, second) => second - first)
    .Append(3); // Device always max + 3

var countOnes = diffs.Count(n => n == 1);
var countThrees = diffs.Count(n => n == 3);
Console.WriteLine($"{countOnes} * {countThrees} = {countOnes * countThrees}");

static long Factorial(long n) => n == 1 ? 1 : n * Factorial(n - 1);