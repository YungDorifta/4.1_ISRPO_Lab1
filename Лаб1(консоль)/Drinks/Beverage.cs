using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_консоль_
{
    public abstract class Beverage
    {
        protected string description = "Unknown Beverage";
        public abstract double cost();

        public virtual string getDescription()
        {
            return description;
        }
    }
}
