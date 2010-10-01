using System;
using System.Collections.Generic;



namespace DomainModel.Repository.Utils
{
    public class Convert
    {
        internal static string ToString(object source)
        {
            string ret = "";

            try
            {
                if (source != null && source != DBNull.Value)
                {
                    ret = System.Convert.ToString(source).Trim();
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }



        internal static bool ToBool(object source)
        {
            bool ret = false;

            try
            {
                if (source != null && source != DBNull.Value)
                {
                    ret = System.Convert.ToBoolean(source);
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }



        internal static decimal? ToDecimal(object source)
        {
            decimal? ret = null;

            try
            {
                if (source != null && source != DBNull.Value)
                {
                    ret = System.Convert.ToDecimal(source);
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }



        internal static DateTime? ToDateTime(object source)
        {
            DateTime? ret = null;

            try
            {
                if (source != null && source != DBNull.Value)
                {
                    ret = System.Convert.ToDateTime(source);
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }



        internal static float? ToFloat(object source)
        {
            float? ret = null;

            try
            {
                if (source != null && source != DBNull.Value)
                {
                    ret = System.Convert.ToSingle(source);
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }



        internal static Int32 ToInt32(object source)
        {
            Int32 ret = -1;

            try
            {
                if (source != null && source != DBNull.Value)
                {
                    ret = System.Convert.ToInt32(source);
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }



        internal static Int64? ToInt64(object source)
        {
            Int64? ret = null;

            try
            {
                if (source != null && source != DBNull.Value)
                {
                    ret = System.Convert.ToInt64(source);
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }
    }
}
