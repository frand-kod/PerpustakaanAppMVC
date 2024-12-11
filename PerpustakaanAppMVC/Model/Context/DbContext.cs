using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//sqlite
using System.Data;
using System.Data.SQLite;

namespace PerpustakaanAppMVC.Model.Context
{
    public class DbContext : IDisposable
    {

        private SQLiteConnection _connection;
        public SQLiteConnection Connection
        {
            get { return _connection ?? (_connection = getOpenConnection()); }
        }

        private SQLiteConnection getOpenConnection()
        {
            SQLiteConnection conn = null; //object coneksi

            try
            {
                string dbName = @".\PerpustakaanAppMVC\Database\DbPerpustakaan.db";
                string connectionString = string.Format("Data Source={0};FailIfMissing=True", dbName);
                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error",ex.Message);
            }
            return conn;
        }

        //object dispose
        public void Dispose()
        {
            if(_connection!= null)
            {
                try
                {
                    if (_connection.State != ConnectionState.Closed) _connection.Close();
                }
                finally
                {
                    _connection.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }


    }
}
