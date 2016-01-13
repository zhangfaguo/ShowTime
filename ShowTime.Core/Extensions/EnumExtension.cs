using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace System
{
    public static class EnumExtension
    {
        public static string GetEnumDescription<T>(this object source)
        {

            var result = string.Empty;
            try
            {

                var enumValue = System.Enum.Parse(typeof(T), source.ToString(), true);
                result = GetEnumDescription(enumValue);
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 获取枚举的描述文本
        /// </summary>
        /// <param name="e">枚举成员</param>
        /// <returns></returns>
        public static string GetEnumDescription(object e)
        {
            //获取字段信息
            System.Reflection.FieldInfo[] ms = e.GetType().GetFields();

            Type t = e.GetType();
            foreach (System.Reflection.FieldInfo f in ms)
            {
                //判断名称是否相等
                if (f.Name != e.ToString()) continue;

                //反射出自定义属性
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    //类型转换找到一个Description，用Description作为成员名称
                    System.ComponentModel.DescriptionAttribute dscript = attr as System.ComponentModel.DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }

            }
            //如果没有检测到合适的注释，则用默认名称
            return e.ToString();
        }

        public static IList<SelectListItem> GetEnumSelectViewList<T>(SelectListItem firstItem = null, int? selectValue = null)
        {
            IList<SelectListItem> list = new List<SelectListItem>();
            Type type = typeof(T);
            var values = Enum.GetValues(type);
            foreach (var item in values)
            {
                var v = item;
                var name = GetEnumDescription<T>(item);
                var sele = false;
                if (selectValue.HasValue && (int)v == selectValue.Value)
                {
                    sele = true;
                }
                SelectListItem sl = new SelectListItem()
                {
                    Text = name,
                    Selected = sele,
                    Value = ((int)v).ToString()
                };
                list.Add(sl);
            }

            if (firstItem != null)
            {
                list.Insert(0, firstItem);
            }
            return list;
        }
    }
}
