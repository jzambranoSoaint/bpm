﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace Backend.Shared.Utilities
{
    public static class ConvertTypes
    {

        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var table = CreateDataTableForPropertiesOfType<T>();
            PropertyInfo[] piT = typeof(T).GetProperties();
            foreach (var item in items)
            {
                var dr = table.NewRow();
                for (int property = 0; property < table.Columns.Count; property++)
                {
                    if (piT[property].CanRead)
                    {
                        var value = piT[property].GetValue(item, null);
                        if (piT[property].PropertyType.IsGenericType)
                        {
                            if (value == null)
                            {
                                dr[property] = DBNull.Value;
                            }
                            else
                            {
                                dr[property] = piT[property].GetValue(item, null);
                            }
                        }
                        else
                        {
                            dr[property] = piT[property].GetValue(item, null);
                        }
                    }
                }
                table.Rows.Add(dr);
            }
            return table;
        }

        public static DataTable CreateDataTableForPropertiesOfType<T>()
        {
            DataTable dt = new DataTable();
            PropertyInfo[] piT = typeof(T).GetProperties();
            foreach (PropertyInfo pi in piT)
            {
                Type propertyType;
                if (pi.PropertyType.IsGenericType)
                {
                    propertyType = pi.PropertyType.GetGenericArguments()[0];
                }
                else
                {
                    propertyType = pi.PropertyType;
                }
                DataColumn dc = new DataColumn(pi.Name, propertyType);
                if (pi.CanRead)
                {
                    dt.Columns.Add(dc);
                }
            }
            return dt;
        }

        public static List<dynamic> ToDynamic(this DataTable dt)
        {
            var dynamicDt = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            return dynamicDt;
        }

        /// <summary>
        /// Converts to dynamic.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static List<T> ToDynamic<T>(this DataTable dt)
        {
            var dynamicDt = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            return dynamicDt;
        }

        public static T ToObjectList<T>(this DataRow dr) where T : new()
        {
            var props = typeof(T).GetProperties();
            T obj = new T();
            foreach (DataColumn dc in dr.Table.Columns)
            {
                foreach (var prop in props)
                {
                    if (prop.Name == dc.ColumnName && dr[dc.ColumnName] != DBNull.Value)
                    {
                        prop.SetValue(obj, dr[dc.ColumnName], null);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }

        public static List<T> ToObjectList<T>(this DataTable dt) where T : new()
        {
            List<T> result = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(row.ToObjectList<T>());
            }
            return result;
        }

        /// <summary>
        /// Converts to stringbase64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToStringBase64(this string value)
        {
            if (value.IsBase64())
            {
                byte[] data = Convert.FromBase64String(value);
                return Encoding.ASCII.GetString(data);
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Determines whether this instance is base64.
        /// </summary>
        /// <param name="base64String">The base64 string.</param>
        /// <returns>
        ///   <c>true</c> if the specified base64 string is base64; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBase64(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
            {
                return false;
            }

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch { }

            return false;
        }

        public static DateTime ToDate(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return DateTime.Now;
                }

                var valueConf = value.Split('-');

                if (valueConf.Length != 3)
                {
                    return DateTime.Now;
                }

                return new DateTime(int.Parse(valueConf[0]), int.Parse(valueConf[1]), int.Parse(valueConf[2]));
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static List<double> ToListFromSplit(this string value)
        {
            List<double> listReturn = new List<double>();

            if (string.IsNullOrEmpty(value))
            {
                return listReturn;
            }

            foreach (var item in value.Split(','))
            {
                try
                {
                    double valueDouble = double.Parse(item);
                    listReturn.Add(valueDouble);
                }
                catch { }
            }

            return listReturn;
        }

        public static List<T> ToListFromSplit<T>(this string value)
        {
            List<T> listReturn = new List<T>();

            if (string.IsNullOrEmpty(value))
            {
                return listReturn;
            }

            foreach (var item in value.Split(','))
            {
                try
                {
                    listReturn.Add((T)Convert.ChangeType(item, typeof(T)));
                }
                catch { }
            }

            return listReturn;
        }

        public static string Clear(this object value)
        {
            return $"{value}".Replace("\n", string.Empty).Trim();
        }

        public static DateTime ToDateNotHours(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
        }

        public static double ConvertDateTimeToTimestamp(this DateTime value)
        {
            TimeSpan timeSpan = value.ToDateNotHours() - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)timeSpan.TotalSeconds;
        }

        /// <summary>
        /// Converts to enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }


        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The dr.</param>
        /// <returns></returns>
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name != column.ColumnName)
                    {
                        continue;
                    }

                    if (dr[column.ColumnName] is DBNull)
                    {
                        continue;
                    }

                    pro.SetValue(obj, dr[column.ColumnName], null);
                }
            }
            return obj;
        }

        /// <summary>
        /// Converts the data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static List<T> ConvertDataTable<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
    }
}
