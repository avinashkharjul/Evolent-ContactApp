using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ContactApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ContactApp.Data.Extensions
{
    public  static class DbContextExtensions
    {
        public static IEnumerable<T> ExecuteStoredProcedure<T>(this DbContext dbContext, string SPName)
        {
            var connection = (SqlConnection)dbContext.Database.GetDbConnection();

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = SPName;
            command.CommandTimeout = 6000;

            var dataAdaptor = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dataAdaptor.Fill(ds);
            IEnumerable<T> lts = null;
            if (ds.Tables[0].Rows.Count > 0)
                lts = JsonConvert.DeserializeObject<IEnumerable<T>>(FunctionClass.DataTableToJSON(ds.Tables[0]));

            return lts;
        }

        public static IEnumerable<T> ExecuteStoredProcedure<T>(this DbContext dbContext, string SPName,List<SqlParameter> sqlParameters)
        {
            var connection = (SqlConnection)dbContext.Database.GetDbConnection();

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = SPName;
            command.CommandTimeout = 6000;
            foreach (var item in sqlParameters)
            {
                command.Parameters.Add(item);
            }

            var dataAdaptor = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dataAdaptor.Fill(ds);
            IEnumerable<T> lts = null;
            if (ds.Tables[0].Rows.Count > 0)
                lts = JsonConvert.DeserializeObject<IEnumerable<T>>(FunctionClass.DataTableToJSON(ds.Tables[0]));

            return lts;
        }
    }
}
