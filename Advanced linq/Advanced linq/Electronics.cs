using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_linq
{
    public class Electronics
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Electronics(int id,string name,int price) {
            ID = id;
            Name = name;
            Price = price;
        }

    }
}
