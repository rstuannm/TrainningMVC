using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesBase.Common
{
    public static class Utils
    {
        public static bool IsNumber(string str)
        {
            try
            {
                var a = Convert.ToInt64(str);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static long? ConvertStrToLong(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return null;
                else
                    return Convert.ToInt64(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int? ConvertStrToInt(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return null;
                else
                    return Convert.ToInt32(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double? ConvertStrToDouble(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return null;
                else
                    return Convert.ToInt64(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}