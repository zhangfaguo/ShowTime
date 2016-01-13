using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.Core.ViewModel
{
    public abstract class BaseDTO<T>
        where T : class,new()
    {
        public T Source
        {
            get;
            set;
        }

        public BaseDTO()
        {
            Source = new T();
        }
    }
}
