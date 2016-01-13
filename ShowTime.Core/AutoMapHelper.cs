using AutoMapper;
using System;

namespace System
{
    public static class AutoMapHelperExtend
    {
        public static T MapTo<T>(this object source)
            where T : class
        {
            return AutoMapper.Mapper.Map<T>(source, (c) => { c.CreateMissingTypeMaps = true; });
        }
    }


}
