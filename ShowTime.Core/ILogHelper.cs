using System;
namespace ShowTime.Core
{
    public interface ILogHelper
    {
        void Write(CommonLogger logType, LogLevel level, Exception exp, string more = "");
        void Write(CommonLogger logType, LogLevel level, string info, Exception exp);
        void Write(CommonLogger logType, LogLevel level, string message);
        void Write(CommonLogger logType, Exception exp);
    }
}
