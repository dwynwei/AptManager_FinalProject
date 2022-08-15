using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Abstract
{
    /*
     *  Cache Manager Interface Which if want to implement other Manager Libraries
     */
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        void Add(string key, object data);
        void Remove(string key);
        bool IsAdd(string key);
        void RemovebyPattern(string pattern);
    }
}
