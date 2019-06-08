using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    interface ICache<Tkey, Tvalue>
    {
        void Put(Tkey key, Tvalue value);

        Tvalue Get(Tkey key);
    }
}
