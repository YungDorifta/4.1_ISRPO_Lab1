using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_консоль_
{
    class Program
    {
        static void Main(string[] args)
        {
            Mocha bev1 = new Mocha(new Milk(new Espresso()));
            Console.WriteLine(bev1.getDescription() + "\n" + bev1.cost());
            Console.WriteLine();

            Milk bev2 = new Milk(new Milk(new Milk(new Milk(new Milk(new HouseBlend())))));
            Console.WriteLine(bev2.getDescription() + "\n" + bev2.cost());

            Beverage bev3 = new Soy(new Milk(new Whip(new Decaf())));
            Console.WriteLine(bev3.getDescription() + "\n" + bev3.cost());
            Console.ReadKey();
        }
    }
}
