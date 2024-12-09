using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.BadCode
{
    internal class MongoDatabase
    {
        public void Connect()
        {
            Console.WriteLine("MongoDB: connected");
        }

        public void Add(string data)
        {
            Console.WriteLine($"MongoDB: data added: {data}");
        }
    }
}
