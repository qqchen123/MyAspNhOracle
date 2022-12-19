using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyAspNhOracle
{
    public class DataTableToModelUtil
    {
        /// <summary>
        ///     DataTable -> Model
        /// </summary>
        /// <typeparam name="T">数据项</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static T DataTableToModel<T>(DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0) return default;
            var t = new T();
            // 获取行数据
            var dr = dt.Rows[0];
            // 获取栏目
            var columns = dt.Columns;
            // 获得此模型的公共属性
            var property = t.GetType().GetProperties();
            foreach (var pi in property)
            {
                var name = pi.Name;
                // 检查DataTable是否包含此列    
                if (columns.Contains(name))
                {
                    if (!pi.CanWrite) continue;
                    var value = dr[name];
                    if (value != DBNull.Value) pi.SetValue(t, value, null);
                }
            }
            return t;
        }

        /// <summary>
        ///     DataTable -> List
        /// </summary>
        /// <typeparam name="T">数据项</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0) return new List<T>();

            // 定义集合
            var list = new List<T>();
            // 获取栏目
            var columns = dt.Columns;
            foreach (DataRow dr in dt.Rows)
            {
                var t = new T();
                // 获得此模型的公共属性
                var property = t.GetType().GetProperties();
                foreach (var pi in property)
                {
                    var name = pi.Name;
                    // 检查DataTable是否包含此列    
                    if (columns.Contains(name))
                    {
                        if (!pi.CanWrite) continue;
                        var value = dr[name];
                        if (value != DBNull.Value) pi.SetValue(t, value, null);
                    }
                }
                list.Add(t);
            }
            return list;
        }
    }
}