using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowTime.LockLab
{
    public interface ILockProvider
    {
        LockObject GetLockItem(string uniKey);

        bool UpLockItem(LockObject lockItem);

        void ReleaseLock(string uniKey);
    }
}
