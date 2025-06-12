using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace COALBPS_WebApplication.Helper
{
    public class Utility
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

        public static bool IsDate(string input)
        {
            DateTime temp;
            return DateTime.TryParse(input, CultureInfo.CurrentCulture, DateTimeStyles.NoCurrentDateDefault, out temp);
        }
        public static bool IsValidTime(string input)
        {
            TimeSpan temp;
            return TimeSpan.TryParse(input, out temp);
        }
        public static DateTime ConvertDate(string input)
        {
            DateTime temp;
            DateTime.TryParse(input, CultureInfo.CurrentCulture, DateTimeStyles.NoCurrentDateDefault, out temp);
            return temp;
        }
        public static string ChangeDateFormat(DateTime Date)
        {
            string ChangedDate = "";
            string Day = Convert.ToString(Date.Day);
            string Month = Convert.ToString(Date.Month);
            string Year = Convert.ToString(Date.Year);
            ChangedDate = Year + "-" + Month + "-" + Day;
            return ChangedDate;
        }

        public static bool IsValidDateRange(string FromDate,string ToDate)
        {
            bool result = false;

            if (FromDate != null && ToDate != null)
            {
                int FromDateDateValues = Convert.ToInt32(FromDate.Replace("-", ""));
                int ToDateDateValues = Convert.ToInt32(ToDate.Replace("-", ""));
                if (FromDateDateValues <= ToDateDateValues)
                    result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


        public static int DayDateRange(string FromDate, string ToDate)
        {
            int result = 0;

            if (FromDate != null && ToDate != null)
            {

                DateTime Fmdt = Utility.ConvertDate(FromDate);
                DateTime Todt = Utility.ConvertDate(ToDate);
                result = (int)(Todt - Fmdt).TotalDays;
            }

            return result;
        }
       
        public static string ChangeDateTimeFormat(DateTime Date)
        {
            string ChangedDate = "";
            string Day = Convert.ToString(Date.Day);
            string Month = Convert.ToString(Date.Month);
            string Year = Convert.ToString(Date.Year);
            string Time = Convert.ToString(Date.ToString("HH:mm"));
            string minute = Convert.ToString(Date.Minute.ToString("mm"));
            string second = Convert.ToString(Date.Second.ToString("ss"));
            ChangedDate = Year + "-" + Month + "-" + Day+" "+Time;
            return ChangedDate;
        }
        public static string CreateTableDataWithHeader(DataTable dt)
        {
            string data = "";
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (i == 0)
                    {
                        data += "[";
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            if (k == dt.Columns.Count - 1)
                            {
                                data += "\"" + Convert.ToString(dt.Columns[k].ColumnName).Replace(" ", "").Replace("(DD/MM/YYYY)", "").Replace("(24Hrs#)", "").Replace("(Y/N)", "") + "\"";
                            }
                            else
                            {
                                data += "\"" + Convert.ToString(dt.Columns[k].ColumnName).Replace(" ", "").Replace("(DD/MM/YYYY)", "").Replace("(24Hrs#)", "").Replace("(Y/N)", "") + "\",";
                            }
                        }
                        data += "],";
                    }
                    data += "[";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == dt.Columns.Count - 1)
                        {
                            data += "\"" + Convert.ToString(dt.Rows[i][j]) + "\"";
                        }
                        else
                        {
                            data += "\"" + Convert.ToString(dt.Rows[i][j]) + "\",";
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        data += "]";
                    }
                    else
                    {
                        data += "],";
                    }
                }
            }
            return data;
        }
        public static string CreateTableDataWithOutHeader(DataTable dt)
        {
            string data = "";
            if (dt.Rows.Count > 0)
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data += "[";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == dt.Columns.Count - 1)
                        {
                            data += "\"" + Convert.ToString(dt.Rows[i][j]) + "\"";
                        }
                        else
                        {
                            data += "\"" + Convert.ToString(dt.Rows[i][j]) + "\",";
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        data += "]";
                    }
                    else
                    {
                        data += "],";
                    }
                }
            }
            return data;
        }
        public string encryptText(string text)
        {
            string encryptedText = "";
            char val;
            foreach (char c in text)
            {
                try
                {
                    val = Convert.ToChar((int)c + 10);

                }
                catch
                {
                    val = 'A';
                }
                encryptedText = encryptedText + val;
                
            }

            return encryptedText;
        }
        public static DataTable RemoveBlankRow(DataTable dtRomoveBlank)
        {

            for (int h = 0; h < dtRomoveBlank.Rows.Count; h++)
            {
                if (dtRomoveBlank.Rows[h].IsNull(0) == true)
                {
                    dtRomoveBlank.Rows.RemoveAt(h);
                }
            }
            return dtRomoveBlank;
        }
        public static bool IsPastDate(DateTime input)
        {
            DateTime temp;
            bool IsPast;
            string Inputdate = Utility.ChangeDateFormat(input);
            temp = Convert.ToDateTime(Inputdate);
            string Current = Utility.ChangeDateFormat(DateTime.Now);
            DateTime CurrentDate = Convert.ToDateTime(Current);
            if (temp < CurrentDate)
            {
                IsPast = true;
                return IsPast;
            }
            else
            {
                IsPast = false;
                return IsPast;
            }
            //IsPast = DateTime.TryParse(input, CultureInfo.CurrentCulture, DateTimeStyles.NoCurrentDateDefault, out temp);

        }
        public static DataTable ChangeColumnDataType(DataTable table)
        {
            List<string> columnName= new List<string>();
            try
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {                    
                    columnName.Add(table.Columns[i].ColumnName);                    
                }
                foreach(string ColName in columnName)
                {
                    DataColumn newcolumn = new DataColumn("temporary", typeof(string));
                    table.Columns.Add(newcolumn);
                    foreach (DataRow row in table.Rows)
                    {
                        try
                        {
                            row["temporary"] = Convert.ChangeType(row[ColName], typeof(string));
                        }
                        catch
                        {
                        }
                    }
                    table.Columns.Remove(ColName);
                    newcolumn.ColumnName = ColName; 
                }
            }
            catch (Exception)
            {
                return new DataTable();
            }

            return table;
        }
    }
}