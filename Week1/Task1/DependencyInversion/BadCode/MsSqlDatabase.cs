using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.BadCode
{
    internal class MsSqlDatabase
    {
        public void Connect()
        {
            Console.WriteLine("MsSql: connected");
        }

        public void Add(string data)
        {
            Console.WriteLine($"MsSql: data added: {data}");
        }
    }
}
