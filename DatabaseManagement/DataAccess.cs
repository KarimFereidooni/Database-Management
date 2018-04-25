using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseManagement
{
    public class DataAccess : IDisposable
    {
        private static DataAccess _Instance;
        public static DataAccess Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DataAccess("");
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        private static string _ConnectionString;
        public static string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }
        public void Dispose()
        {
            this.Command.Dispose();
            if (this.Connection.State == System.Data.ConnectionState.Open)
                this.Connection.Close();
            this.Connection.Dispose();
            this.Adapter.Dispose();
        }
        public DataAccess(string ConnectionString)
        {
            this._Connection = new SqlConnection(ConnectionString);
            this._Command = new SqlCommand();
            this._Command.Connection = this._Connection;
            this._Adapter = new SqlDataAdapter();
            this._Adapter.SelectCommand = new SqlCommand();
            this._Adapter.SelectCommand.Connection = this._Connection;
            DataAccess.ConnectionString = ConnectionString;
        }
        //---------------------------------
        private SqlConnection _Connection;
        public SqlConnection Connection
        {
            get
            {
                return _Connection;
            }
        }
        private SqlCommand _Command;
        public SqlCommand Command
        {
            get
            {
                return _Command;
            }
        }
        private SqlDataAdapter _Adapter;
        public SqlDataAdapter Adapter
        {
            get
            {
                return _Adapter;
            }
        }
        private SqlTransaction _Transaction;
        public SqlTransaction Transaction
        {
            get
            {
                return _Transaction;
            }
            set
            {
                _Transaction = value;
                this.Command.Transaction = value;
                this.Adapter.SelectCommand.Transaction = value;
            }
        }
        //---------------------------------------------------------------------------------
        public int Execute(string command, params object[] parameters)
        {
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            int i;
            try
            {
                i = Command.ExecuteNonQuery();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }
        //-------------------------------------------------------------------------------
        public object ExecuteScalar(string command, params object[] parameters)
        {
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            object i;
            try
            {
                i = Command.ExecuteScalar();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }
        //-----------------------------------------------------------------------------------
        public DataTable GetData(string command, params object[] parameters)
        {
            if (!TestConnection())
            {
                throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست");
            }
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            Adapter.SelectCommand = Command;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            DataTable dt = new DataTable();
            try
            {
                Adapter.Fill(dt);
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return dt;
        }
        //----------------------------------------------------------------------------------
        public bool TestConnection()
        {
            string temp;
            return TestConnection(out temp);
        }
        public bool TestConnection(out string ErrorMessage)
        {
            System.Data.ConnectionState previousConnectionState = this.Connection.State;
            try
            {
                if (((this.Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
                    this.Connection.Open();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                this.Connection.Close();
                return false;
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    this.Connection.Close();
                }
            }
            ErrorMessage = "";
            return true;
        }
    }
}
