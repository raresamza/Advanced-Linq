
using Advanced_linq;

Console.WriteLine("hello");
Electronics electronic1 = new Electronics(1, "phone", 100);
Electronics electronic2 = new Electronics(2, "laptop", 1000);
Electronics electronic3 = new Electronics(3, "headphones", 250);
Electronics electronic4 = new Electronics(4, "blender", 843);
Electronics electronic5 = new Electronics(5, "monitor", 312);
Electronics electronic6 = new Electronics(6, "coffee machine", 645);
//Electronics electronic7= new Electronics(7,"phone",634);
//Electronics electronic8= new Electronics(8,"TV",483);
//Electronics electronic9= new Electronics(9,"smartwatch",585);
Manufacturer manufacturer1 = new Manufacturer("AAA", 1530, electronic1);
Manufacturer manufacturer2 = new Manufacturer("BBB", 1750, electronic1);
Manufacturer manufacturer4 = new Manufacturer("BBB", 1750, electronic2);
Manufacturer manufacturer3 = new Manufacturer("CCC", 1710, electronic3);

var electronics = new List<Electronics> { electronic1, electronic2, electronic3 };
var electronics2 = new List<Electronics> { electronic4, electronic5, electronic6, electronic1 };
var manufacturers = new List<Manufacturer> { manufacturer1, manufacturer2, manufacturer3, manufacturer4 };
JoinMethod(manufacturers, electronics);
Console.WriteLine("GroupJoin:");
Console.WriteLine("ZipJoin:");
ZipJoin(electronics, electronics2);
Console.WriteLine("GroupBy:");
var groupBy = manufacturers.GroupBy(manufacturer => manufacturer.Name)
    .Select(x => new
    {
        Name = x.Key,
        Count = x.Count(),
        ElectronicPrice = string.Join(", ", x.Select(x => x.Electronic.Price)),
        ElectronicName = string.Join(", ", x.Select(x => x.Electronic.Name)),
    }).ToList();

foreach (var group in groupBy)
{
    Console.WriteLine($"Group {group.Name} has {group.Count} elements:");
    Console.WriteLine($"{group.ElectronicName}: {group.ElectronicPrice}$");
    Console.WriteLine("\n");
}

var groupBy2 = manufacturers.GroupBy(manufacturer => manufacturer.Electronic);


Console.WriteLine("GroupBy 2:");
foreach (var group in groupBy2) Console.WriteLine($"{group.Key.Name} made by {group.Count()} companies");

Console.WriteLine("Concat:");
var concat = electronics.Concat(electronics2);
foreach (var itm in concat)
{
    Console.WriteLine(itm.Name);
}

Console.WriteLine("\nUnion:");
var union = electronics.Union(electronics2);
foreach (var itm in union)
{
    Console.WriteLine(itm.Name);
}

Console.WriteLine("\nIntersect:");
var intersect = electronics.Intersect(electronics2);
foreach (var itm in intersect)
{
    Console.WriteLine(itm.Name);
}

Console.WriteLine("\nExcept:");
var except = electronics2.Except(electronics);
foreach (var itm in except)
{
    Console.WriteLine(itm.Name);
}

Console.WriteLine("\nOfType example");
var phoneElectronics = electronics.OfType<Electronics>().Where(e => e.Name == "phone");
Console.WriteLine("Phone electronics:");
foreach (var electronic in phoneElectronics)
{
    Console.WriteLine($"Name: {electronic.Name}, Price: {electronic.Price}");
}

var electronicsDictionary = electronics.ToDictionary(e => e.Name);
Console.WriteLine("\nDictionary example:");
foreach (var kvp in electronicsDictionary)
{
    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value.Price}");
}

var electronicsLookup = electronics.ToLookup(e => e.Name);
Console.WriteLine("\nLookup Example:");
foreach (var group in electronicsLookup)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var electronic in group)
    {
        Console.WriteLine($"Name: {electronic.Name}");
    }
}

IEnumerable<Electronics> enumerableElectronics = electronics.AsEnumerable();
Console.WriteLine("\nEnumerable Example:");
foreach (var electronic in enumerableElectronics)
{
    Console.WriteLine($"Name: {electronic.Name}, Price: {electronic.Price}");
}

IQueryable<Electronics> queryableElectronics = electronics.AsQueryable();
Console.WriteLine("\nQueryable Example:");
foreach (var electronic in queryableElectronics)
{
    Console.WriteLine($"Name: {electronic.Name}, Price: {electronic.Price}");
}

var electronicsArray = electronics.ToArray();
Console.WriteLine("\nArray example(using array syntax to get first element):");
Console.WriteLine($"Name: {electronicsArray[0].Name}, Price: {electronicsArray[0].Price}");

var electronicsList = electronics.ToList();
Console.WriteLine("\nList example after using add method:");
electronicsList.Add(new Electronics(10, "new phone", 10000));
foreach (var electronic in electronicsList)
{
    Console.WriteLine($"Name: {electronic.Name}, Price:  {electronic.Price}");
}


int count = electronics.Count();
Console.WriteLine($"\nTotal Electronics Count: {count}");

long longCount = electronics.LongCount();
Console.WriteLine($"\nTotal Electronics Long Count: {longCount}");

int minPrice = electronics.Min(e => e.Price);
Console.WriteLine($"\nMinimum Price: {minPrice}");

int maxPrice = electronics.Max(e => e.Price);
Console.WriteLine($"\nMaximum Price: {maxPrice}");

double averagePrice = electronics.Average(e => e.Price);
Console.WriteLine($"\nAverage Price: {averagePrice}");

double totalPrice = electronics.Aggregate(0.0, (acc, e) => acc + e.Price);
Console.WriteLine($"\nTotal Price (using Aggregate): {totalPrice}");

bool anyCheck = electronics.Any(e => e.Price == 100);
Console.WriteLine($"\nThere is at least one items with price 100: {anyCheck}");

bool allCheck = electronics.All(e => e.Price == 100);
Console.WriteLine($"\nAll items have price 100: {allCheck}");

bool containsCheck = electronics.Contains(electronic1);
Console.WriteLine($"\nThe list contains the phone electronic: {containsCheck}");

bool sequenceEqualCheck = electronics.SequenceEqual(electronics2);
Console.WriteLine($"\nThe first list of electronics is equal to the second list of electronics: {sequenceEqualCheck}");

var firstElectronic = electronics.First();
Console.WriteLine($"\nFirst Electronic: {firstElectronic.Name}");

var firstOrDefaultElectronic = electronics.FirstOrDefault(e => e.Price > 2000);
Console.WriteLine($"\nFirst or Default Electronic: {(firstOrDefaultElectronic != null ? firstOrDefaultElectronic.Name : "None")}");

var lastElectronic = electronics.Last();
Console.WriteLine($"\nLast Electronic: {lastElectronic.Name}");

var lastOrDefaultElectronic = electronics.LastOrDefault(e => e.Price > 2000);
Console.WriteLine($"\nLast or Default Electronic: {(lastOrDefaultElectronic != null ? lastOrDefaultElectronic.Name : "None")}");

try
{
    var singleElectronic = electronics.Single(e => e.Name == "headphones");
    Console.WriteLine($"\nSingle Electronic: {singleElectronic.Name}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"\nException: {ex.Message}");
}

var singleOrDefaultElectronic = electronics.SingleOrDefault(e => e.Name == "headphones");
Console.WriteLine($"\nSingle or Default Electronic: {(singleOrDefaultElectronic != null ? singleOrDefaultElectronic.Name : "None")}");

var secondElectronic = electronics.ElementAt(1);
Console.WriteLine($"\nSecond Electronic: {secondElectronic.Name}");

var tenthElectronic = electronics.ElementAtOrDefault(9);
Console.WriteLine($"\nTenth Electronic or Default: {(tenthElectronic != null ? tenthElectronic.Name : "None")}");

List<Electronics> emptyList = new List<Electronics>();
var defaultEmptyList = emptyList.DefaultIfEmpty();
Console.WriteLine($"\nDefault Empty List Count: {defaultEmptyList.Count()}");

var empty = Enumerable.Empty<string>();
Console.WriteLine("\nEmpty enumerable:");
Console.WriteLine($"Enumerable count: {empty.Count()}");

var repeat = Enumerable.Repeat("repeat string", 5);
Console.WriteLine("\nReapeating a string 5 times with repeat:");
foreach (var item in repeat)
{
    Console.WriteLine(item);
}

var range = Enumerable.Range(0, 5);
Console.WriteLine("\nCreating a list of integers with range:");
foreach (var item in range)
{
    Console.WriteLine(item);
}

var anonymousType = electronics.Where(x => x.Price < 1000).Select(x => new { ItemName = x.Name }).ToList();
Console.WriteLine("\nAnonymous type list:");
foreach (var item in anonymousType)
{
    Console.WriteLine(item);
}

static void JoinMethod(List<Manufacturer> manufacturers, List<Electronics> electronics)
{
    var result = electronics.Join(manufacturers,
        electronic => electronic,
        manufacturer => manufacturer.Electronic,
        (electronic, manufacturer) => new { ElectronicName = electronic.Name, ManufacturerName = manufacturer.Name });

    Console.WriteLine("Join result:");
    foreach (var item in result)
    {
        Console.WriteLine($"Manufacturer: {item.ManufacturerName} is making: {item.ElectronicName}");
    }
}

static void GroupJoin(List<Manufacturer> manufacturers, List<Electronics> electronics)
{
    var result = electronics.Join(manufacturers,
        electronic => electronic,
        manufacturer => manufacturer.Electronic,
        (electronic, manufacturer) => new { ElectronicName = electronic.Name, Manufacturer = manufacturer });
}

static void ZipJoin(List<Electronics> electronics1, List<Electronics> electronics2)
{
    var result = electronics1.Zip(electronics2, (f, s) => f.Name + " " + s.Price);
    foreach (var item in result)
    {
        Console.WriteLine($"{item}");
    }
}