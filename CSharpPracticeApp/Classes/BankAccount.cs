using CSharpPracticeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp.Classes
{
    public class BankAccount : IInformation
    {
        // field
        private double balance;

        // property
        public double Balance
        {
            get
            {
                if(balance < 1000000)
                {
                    return balance;
                }
                return 1000000;
            }
            protected set
            {
                if(value > 0)
                {
                    balance = value;
                } 
                else
                {
                    balance = 0;
                }
            }
        }

        public BankAccount()
        {
            Balance = 100;
        }
        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }

        public virtual double AddToBalance(double balanceTobBeAdded)
        {
            Balance += balanceTobBeAdded; // Setter
            return Balance; // Getter
        }

        public string GetInformation()
        {
            return $"The Balance is { Balance:c}";
        }
    }

    public class ChildBankAccount : BankAccount
    {
        public ChildBankAccount()
        {
            Balance = 10;
        }

        public override double AddToBalance(double balanceTobBeAdded)
        {
            if(balanceTobBeAdded > 1000)
            {
                balanceTobBeAdded = 1000;
            }
            if (balanceTobBeAdded < -1000)
            {
                balanceTobBeAdded = -1000;
            }

            return base.AddToBalance(balanceTobBeAdded);
        }
    }

}
