﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConsoleApp
{
    internal interface ICacheService
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
        void Delete(string key);
    }
}
