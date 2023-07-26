using SQLite;
using SqliteDatabase.Models;
using SqliteDatabase.Models.Datalog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SqliteDatabase
{
    public class SqliteContext
    {
        protected string _datasource = "";
        protected SQLiteConnection _db = null;
        public SqliteContext(string datasource, string password = "")
        {
            if (File.Exists(datasource) == true)
            {
                Setup(datasource, password);
            }
            //

        }

        public void Close()
        {
            if (_db != null)
            {
                _db.Close();
            }
        }

        protected void Setup(string datasource, string password = "")
        {
            this._datasource = datasource;

            if (password == "")
            {
                try
                {
                    this._db = new SQLiteConnection(datasource);
                }
                catch (Exception e)
                {
                    int mm;
                }
            }
            else
            {
                try
                {
                    this._db = new SQLiteConnection(datasource, openFlags: SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.Create);
                    this._db.Query<int>($"PRAGMA key={password}");

                    var options = new SQLiteConnectionString(datasource, true, key: password);
                    var encryptedDb = new SQLiteAsyncConnection(options);
                }
                catch
                {

                }
            }
        }


    }
}
