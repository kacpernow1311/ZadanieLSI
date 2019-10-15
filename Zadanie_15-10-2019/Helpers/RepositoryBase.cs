using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadanie_15_10_2019.Helpers
{
    public abstract class RepositoryBase<T> where T : new ()
    {
        public static T Instance { get; } = new T();
    }
}