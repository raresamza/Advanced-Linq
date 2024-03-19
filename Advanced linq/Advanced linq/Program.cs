using System.Diagnostics.Tracing;
using System.Threading.Tasks.Dataflow;

namespace Advanced_linq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("hello");
            Electronics electronic1 = new Electronics(1, "phone", 100);
            Electronics electronic2 = new Electronics(2, "laptop", 1000);
            Electronics electronic3 = new Electronics(3, "headphones", 250);
            Electronics electronic4 = new Electronics(4, "blender", 843);
            Electronics electronic5 = new Electronics(5, "monitor", 312);
            Electronics electronic6 = new Electronics(6, "coffee machine", 645);
            //Electronics electronic7= new Electronics(7,"mouse",634);
            //Electronics electronic8= new Electronics(8,"TV",483);
            //Electronics electronic9= new Electronics(9,"smartwatch",585);
            Manufacturer manufacturer1 = new Manufacturer("AAA", 1530, electronic1);
            Manufacturer manufacturer2 = new Manufacturer("BBB", 1750, electronic1);
            Manufacturer manufacturer4 = new Manufacturer("BBB", 1750, electronic2);
            Manufacturer manufacturer3 = new Manufacturer("CCC", 1710, electronic3);

            var electronics = new List<Electronics> { electronic1, electronic2, electronic3 };
            var electronics2 = new List<Electronics> { electronic4, electronic5, electronic6,electronic1 };
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
                    ElectronicPrice= string.Join(", ", x.Select(x => x.Electronic.Price)),
                    ElectronicName =string.Join(", ",x.Select(x => x.Electronic.Name)),
                }).ToList();

            foreach (var group in groupBy) {
                Console.WriteLine($"Group {group.Name} has {group.Count} elements:");
                Console.WriteLine($"{group.ElectronicName}: {group.ElectronicPrice}$");
                Console.WriteLine("\n");
            }
            
            var groupBy2 = manufacturers.GroupBy(manufacturer => manufacturer.Electronic);
                

            Console.WriteLine("GroupBy 2:");
            foreach (var group in groupBy2) Console.WriteLine($"{group.Key.Name} made by {group.Count()} companies");

            Console.WriteLine("Concat:");
            var concat = electronics.Concat(electronics2);
            foreach(var itm in concat)
            {
                Console.WriteLine(itm.Name);
            }
            Console.WriteLine("Union:");
            var union = electronics.Union(electronics2);
            foreach (var itm in union)
            {
                Console.WriteLine(itm.Name);
            }
            Console.WriteLine("Intersect:");
            var intersect = electronics.Intersect(electronics2);
            foreach (var itm in intersect)
            {
                Console.WriteLine(itm.Name);
            }
            Console.WriteLine("Except:");
            var except = electronics2.Except(electronics);
            foreach (var itm in except)
            {
                Console.WriteLine(itm.Name);
            }
        }
            


        public static void JoinMethod(List<Manufacturer> manufacturers,List<Electronics> electronics)
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

        public static void GroupJoin(List<Manufacturer> manufacturers, List<Electronics> electronics)
        {
            var result = electronics.Join(manufacturers,
                electronic => electronic,
                manufacturer => manufacturer.Electronic,
                (electronic, manufacturer) => new { ElectronicName = electronic.Name, Manufacturer = manufacturer });
        }

        public static void ZipJoin(List<Electronics> electronics1, List<Electronics> electronics2)
        {
            var result = electronics1.Zip(electronics2, (f, s) => f.Name +" "+ s.Price);
            foreach(var item in result)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}