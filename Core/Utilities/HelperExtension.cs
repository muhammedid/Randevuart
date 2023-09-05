using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public static class HelperExtension
    {

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool NotIsNull(this object obj)
        {
            return !IsNull(obj);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool NotIsNullOrEmpty(this string str)
        {
            return !str.IsNullOrEmpty();
        }
    }
}
