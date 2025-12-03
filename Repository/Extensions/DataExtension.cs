using System.Data;
using System.ComponentModel;
using System.Data.Common;
using Newtonsoft.Json;
using PMS.CustomAttributes;
// using PMS.CustomAttributes;

namespace PMS.Repository.Extensions
{
    public static class DataExtension
    {
        public static void SetTableName(this DataSet dataSet, string tableName = "table_name")
        {
            foreach (DataTable dataTable in dataSet.Tables)
            {
                if (dataTable.Columns.Contains(tableName) && dataTable.Rows.Count > 0)
                {
                    string? table_name_value = Convert.ToString(dataTable.Rows[0][tableName]);
                    if (!string.IsNullOrEmpty(table_name_value))
                        dataTable.TableName = table_name_value;
                    dataTable.Columns.Remove(tableName);
                }
            }
        }

        public static void SetParams<T>(this DbCommand cmd, T objParams)
        {
            if (Equals(objParams, null))
                return;

            cmd.Parameters.Clear();
            var props = TypeDescriptor.GetProperties(objParams);
            foreach (PropertyDescriptor prop in props)
            {
                bool isIgnoreType = prop.Attributes.OfType<PMSIgnore>().Any();
                if (!Equals(prop.GetValue(objParams), null) && !isIgnoreType)
                {
                    //cmd.Parameters.Add(new SqlParameter(prop.Name, prop.GetValue(objParams)));
                    DbParameter dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = prop.Name;
                    if (!Equals(prop.Attributes[typeof(TableTypeAttribute)], null))
                    {
                        var ListValue = prop.GetValue(objParams) ?? throw new ArgumentNullException();
                        if (ListValue.GetType().IsSerializable)
                        {
                            string JsonData = JsonConvert.SerializeObject(ListValue);
                            DataTable? dt = JsonConvert.DeserializeObject<DataTable>(JsonData);
                            dbParameter.Value = dt; 
                        }
                    }
                    else
                    {
                        dbParameter.Value = prop.GetValue(objParams);
                    }
                    cmd.Parameters.Add(dbParameter);
                }
            }
        }


        public static void SetParams(this DbCommand cmd, object objParams)
        {
            if (Equals(objParams, 0))
                return;

            cmd.Parameters.Clear();

            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.ParameterName = "id";
            dbParameter.Value = objParams;

            cmd.Parameters.Add(dbParameter);
        }

    }
}