using System;
using System.Collections.Generic;
using System.Text;

namespace IRAO.Domain.Extensions
{
    public static class QueryExtention
    {
        //public static List<T> FromSql<T>(this DbContext context, string query, params object[] parameters)
        //{
        //    var result = new List<T>();
        //    query = string.Format(query, parameters);

        //    using (var command = context.Database.GetDbConnection().CreateCommand())
        //    {
        //        command.CommandText = query;
        //        context.Database.OpenConnection();
        //        using (var reader = command.ExecuteReader())
        //        {
        //            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToArray();
        //            var properties = typeof(T).GetProperties();

        //            while (reader.Read())
        //            {
        //                var data = new object[reader.FieldCount];
        //                reader.GetValues(data);

        //                var instance = (T)Activator.CreateInstance(typeof(T));

        //                for (var i = 0; i < data.Length; ++i)
        //                {
        //                    if (data[i] == DBNull.Value)
        //                    {
        //                        data[i] = null;
        //                    }

        //                    var property = properties.SingleOrDefault(x =>
        //                        x.GetCustomAttributes(typeof(ColumnAttribute), true).Any() &&
        //                        (x.GetCustomAttributes(typeof(ColumnAttribute), true)[0] as ColumnAttribute).Name.Equals(columns[i], StringComparison.InvariantCultureIgnoreCase)
        //                    );

        //                    if (property != null)
        //                    {
        //                        if (property.PropertyType.IsEnum)
        //                        {
        //                            property.SetValue(instance, Enum.Parse(property.PropertyType, data[i].ToString()));
        //                        }
        //                        else
        //                        {
        //                            property.SetValue(instance, data[i] == null ? null : Convert.ChangeType(data[i], Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType));
        //                        }
        //                    }
        //                }
        //                result.Add(instance);
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
