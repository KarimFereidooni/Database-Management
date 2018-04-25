using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace ZeroAndOne.Sql
{
    public class SqlHelper
    {
        public static bool RunQueryWithRollback(string query, string connectionString, out string error)
        {
            return RunQueryWithRollback(query, connectionString, null, out error);
        }
        public static bool RunQueryWithRollback(string query, string connectionString, string database, out string error)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            SqlTransaction transaction;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                if (!string.IsNullOrEmpty(database))
                    Connection.ChangeDatabase(database);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            Regex regex = new Regex("^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] lines = regex.Split(query);
            for (int i = 0; i <= lines.Length - 1; i++)
            {
                if (lines[i].Length > 0)
                {
                    try
                    {
                        Command.CommandText = lines[i];
                        Command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Connection.Close();
                        error = ex.Message;
                        return false;
                    }
                }
            }
            transaction.Commit();

            Connection.Close();
            transaction.Dispose();
            Command.Dispose();
            Connection.Dispose();
            error = null;
            return true;
        }
        public static bool RunQuery(string query, string connectionString, string database, out string error)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            try
            {
                Connection.Open();
                if (!string.IsNullOrEmpty(database))
                    Connection.ChangeDatabase(database);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            Regex regex = new Regex("^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] lines = regex.Split(query);
            for (int i = 0; i <= lines.Length - 1; i++)
            {
                if (lines[i].Length > 0)
                {
                    try
                    {
                        Command.CommandText = lines[i];
                        Command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Connection.Close();
                        error = ex.Message;
                        return false;
                    }
                }
            }
            Connection.Close();
            Command.Dispose();
            Connection.Dispose();
            error = null;
            return true;
        }
        public static void RunQuery(string query, DatabaseManagement.DataAccess dataAccess, params object[] parameters)
        {
            Regex regex = new Regex("^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] lines = regex.Split(query);
            for (int i = 0; i <= lines.Length - 1; i++)
            {
                if (lines[i].Length > 0)
                {
                    dataAccess.Execute(lines[i], parameters);
                }
            }
        }
        public static string GetDataPath(DatabaseManagement.DataAccess dataAccess)
        {
            string script = "SELECT * FROM [sys].[database_files]";
            System.Data.DataTable databaseFiles = dataAccess.GetData(script);
            string path = databaseFiles.Rows[0]["physical_name"].ToString();
            path = System.IO.Path.GetDirectoryName(path);
            if (path.EndsWith("\\"))
                path = path.Substring(0, path.Length - 1);
            return path;
        }
    }
}
