var lines = File.ReadAllLines("input.txt");
var timestamp = int.Parse(lines[0]);
var nextBus = lines[1]
    .Split(',')
    .Where(l => l != "x")
    .Select(int.Parse)
    .Select(id => (Id: id, Time: id * ((timestamp / id) + 1)))
    .OrderBy(b => b.Time)
    .First();

var result = nextBus.Id * (nextBus.Time - timestamp);
Console.WriteLine(result);
