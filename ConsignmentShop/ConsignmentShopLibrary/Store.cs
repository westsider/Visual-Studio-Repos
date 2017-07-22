using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Store
    {
        public string Name { get; set; }
        public List<Vendor> Vendors { get; set; }
        public List<Item> Items { get; set; }

        // instanciate to get rid of error: Object reference not set to instance of an object
        public Store()
        {
            Vendors = new List<Vendor>();
            Items = new List<Item>();
        }
    }
}
