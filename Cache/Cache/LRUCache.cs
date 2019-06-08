using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public class LRUCache<Tkey, Tvalue> : ICache<Tkey, Tvalue>
    {
        private int _Capacity;
        private LinkedList<KeyValuePair<Tkey, Tvalue>> _Cache;
        private Dictionary<Tkey, LinkedListNode<KeyValuePair<Tkey, Tvalue>>> _CachePolicy;

        public LRUCache(int capactiy)
        {
            _Capacity = capactiy;
            _Cache = new LinkedList<KeyValuePair<Tkey, Tvalue>>();
            _CachePolicy = new Dictionary<Tkey, LinkedListNode<KeyValuePair<Tkey, Tvalue>>>();
        }

        public void Put(Tkey key, Tvalue value)
        {
            if(_CachePolicy.ContainsKey(key) == false)
            {
                if(_Capacity == _Cache.Count)
                {
                    LinkedListNode<KeyValuePair<Tkey, Tvalue>> toBeRetired = _Cache.Last;

                    _CachePolicy.Remove(toBeRetired.Value.Key);
                    _Cache.RemoveLast();
                }
            }
            else
            {
                _Cache.Remove(_CachePolicy[key]);
            }

            _Cache.AddFirst(new LinkedListNode<KeyValuePair<Tkey, Tvalue>>(new KeyValuePair<Tkey, Tvalue>(key, value)));
            _CachePolicy[key] = _Cache.First;
        }

        public Tvalue Get(Tkey key)
        {
            Tvalue ret = default(Tvalue);

            if(_CachePolicy.ContainsKey(key) == false)
            {
                throw new KeyNotFoundException("Searched key is not found in the cache");
            }
            else
            {
                LinkedListNode<KeyValuePair<Tkey, Tvalue>> item = _CachePolicy[key];

                ret = item.Value.Value;

                _Cache.Remove(item);
                _Cache.AddFirst(item);
                _CachePolicy[key] = _Cache.First;
            }

            return ret;
        }
    }
}
