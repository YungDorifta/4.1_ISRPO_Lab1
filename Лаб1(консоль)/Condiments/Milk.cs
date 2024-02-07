using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_консоль_
{
    public class Milk : CondimentDecorator
    {
        Beverage beverage;

        public Milk(Beverage beverage)
        {
            this.beverage = beverage;

        }

        public override double cost()
        {
            return beverage.cost() + .10;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Milk";
        }
    }
}
