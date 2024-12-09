using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed.GoodCode
{
    internal class DoorPayment : IPayment
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"Door payment: {amount}");
        }
    }
}
