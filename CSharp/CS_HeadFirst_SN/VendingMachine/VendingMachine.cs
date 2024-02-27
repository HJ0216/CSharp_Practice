using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class VendingMachine
    {
        public virtual string Item { get; } = string.Empty;
        protected virtual bool CheckAmount(decimal money)
        {
            return false;
        }
        public string Dispense(decimal money)
        {
            if (CheckAmount(money)) { return Item; }
            else { return "Please enter the right amount."; }
        }
    }
    
    internal class AnimalFeedVendingMachine : VendingMachine
    {
        public override string Item
        {
            get { return "a handful of animal feed."; }
        }
        protected override bool CheckAmount(decimal money)
        {
            return money >= 1.25M;
        }
    }
}
