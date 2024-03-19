using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_linq
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public int Profit { get; set; }
        public Electronics Electronic { get; set; }
        public Manufacturer(string name,int profit, Electronics electronics) {
            Name = name;
            Profit = profit;
            Electronic = electronics;
        }


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
