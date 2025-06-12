using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace COALBPS_Service
{
    public class Utils
    {
        public static List<T> ConvertDataTableToClassObjectList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, Convert.ToString(dr[column.ColumnName]), null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static T ConvertDataTableToClassObject<T>(DataTable Dt)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataRow dr in Dt.Rows)
            {
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, dr[column.ColumnName] == typeof(DBNull) ? "" : Convert.ToString(dr[column.ColumnName]), null);
                        else
                            continue;
                    }
                } 
            }
            return obj;

        }
    }
}