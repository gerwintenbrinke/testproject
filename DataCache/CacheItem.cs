using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrenRegistratie.Framework.DataCache
{
    public class CacheItem<T>
    {
        public DateTime TimeCreated { get; set; }
        public bool Loaded { get; set; }
        public T Data { get; set; }
        public Func<T> LoadFunction { get; set; }
    }
}


