using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            int Capacity = 2;

            LRUCache<int, int> Cache = new LRUCache<int, int>(Capacity);
            int ret = 0;

            Cache.Put(1, 1);

            Cache.Put(2, 2);

            try
            {
                ret = Cache.Get(1);       // returns 1
                Console.WriteLine("Value for key {0} = {1}", 1, ret);
            }catch(KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Cache.Put(3, 3);    // evicts key 2

            try
            {
                ret = Cache.Get(2);   //returns (not found)
                Console.WriteLine("Value for key {0} = {1}", 2, ret);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Cache.Put(4, 4);    // evicts key 1

            try
            {
                ret = Cache.Get(1);       //returns (not found)
                Console.WriteLine("Value for key {0} = {1}", 1, ret);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                ret = Cache.Get(3);       // returns 3
                Console.WriteLine("Value for key {0} = {1}", 3, ret);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                ret = Cache.Get(4);       // returns 4
                Console.WriteLine("Value for key {0} = {1}", 4, ret);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
