using System;
using System.Collections;
using Jd.ACES.Common;
using Jd.ACES.Common.Exceptions;

namespace Jd.ACES.Utils
{
    public static class EnumHelper
    {
        public static int GetValue(this Enum em)
        {
            return Convert.ToInt32(em);
        }

        public static bool EqualValue(this Enum expected, object actual)
        {
            return GetValue(expected).Equals(actual);
        }

        public static bool TryParse<T>(string name, out T value)
        {
            try
            {
                value = FromValue<T>(name);
            }
            catch (Exception)
            {
                value = default(T);
                return false;
            }
            return value != null;
        }

        public static string GetMessage(this Enum em)
        {
            Type enumType = em.GetType();
            object[] objects = enumType.GetField(em.ToString()).GetCustomAttributes(typeof(TDEStatusAttribute), false);
            if (objects == null || objects.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                TDEStatusAttribute attr = objects[0] as TDEStatusAttribute;
                return attr.Message;
            }
        }

        public static T FromValue<T>(string name)
        {
            if (name == null)
            {
                throw new MalformedException("Input value is null");
            }
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new MalformedException("Not enum type");
            }
            return FromValue<T>(enumType, name);
        }

        public static T FromValue<T>(int value)
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new MalformedException("Not enum type");
            }
            return FromValue<T>(enumType, GetName(enumType, value));
        }

        private static T FromValue<T> (this Type type, string name)
        {
            var values = Enum.GetValues(type);
            var ht = new Hashtable();
            foreach (var val in values)
            {
                ht.Add(Enum.GetName(type, val), val);
            }
            return (T) ht[name];
        }

        public static string GetName(this Type type, int status)
        {
            string name = Enum.GetName(type, status);
            if (name == null)
            {
                throw new MalformedException($"Unknown value for enum: {type}.");
            }
            return name;
        }
    }
}