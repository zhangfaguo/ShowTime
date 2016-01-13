using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.LockLab
{
    public interface ILockHelper
    {

        bool Lock(string uniKey);

        void ReleaseLock(string uniKey);
    }
}
