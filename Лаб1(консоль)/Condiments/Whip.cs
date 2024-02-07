using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_консоль_
{
    public class Whip : CondimentDecorator
    {
        Beverage beverage;

        public Whip(Beverage beverage)
        {
            this.beverage = beverage;

        }

        public override double cost()
        {
            return beverage.cost() + .35;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Whip";
        }
    }
}
