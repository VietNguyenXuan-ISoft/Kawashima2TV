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
  public class SqliteEventLogsContext: SqliteContext
  {
    public delegate void SendStatus(object sender, string status);
    public event SendStatus OnSendStatus;
    public SqliteEventLogsContext(string datasource, string password = "") : base(datasource, password)
    {
      if (this._db != null)
      {
        if (File.Exists(datasource) == false)
        {
          this._db.CreateTable<EventLogs>();
        }
        base.Setup(datasource, password);
      }

    }

    public void Clone(string source, string source_password, string dest, string dest_password)
    {
      if (this._db != null)
      {
        if (File.Exists(dest) == true)
        {
          File.Delete(dest);
        }
        SQLiteConnection dest_connection;
        if (dest_password == "")
        {
          dest_connection = new SQLiteConnection(dest);
        }
        else
        {
          dest_connection = new SQLiteConnection(dest, openFlags: SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.Create);
          dest_connection.Query<int>($"PRAGMA key={dest_password}");
          var options = new SQLiteConnectionString(dest, true, key: dest_password);
          var encryptedDb = new SQLiteAsyncConnection(options);
        }
        SQLiteConnection source_connection = new SQLiteConnection(source);
        //------- Copy AM_5M
        if (OnSendStatus != null) OnSendStatus(this, "Clone EventLogs");
        dest_connection.CreateTable<Models.EventLogs>();
        List<Models.EventLogs> eventLogs = Models.EventLogs.LoadAll(source_connection);
        foreach (Models.EventLogs itm in eventLogs)
        {
          Models.EventLogs.Insert(dest_connection, itm);
        }
        if (OnSendStatus != null) OnSendStatus(this, "Clone EventLogs done..");
        source_connection.Close();
        dest_connection.Close();
      }
    }

    #region Variables
    /// <summary>
    /// AM_5AM
    /// </summary>
    private List<EventLogs> _eventLogs = null;
    public List<EventLogs> EventLogs
    {
      get
      {
        if (_eventLogs == null)
        {
          this._eventLogs = Models.EventLogs.LoadAll(this._db);
        }
        return this._eventLogs;
      }
      set { this._eventLogs = value; }
    }

    public int Update(object data)
    {
      int row_updated = 0;
      if (this._db != null)
      {
        if (data is EventLogs) row_updated = (Models.EventLogs.Update(this._db, (Models.EventLogs)data));
      }
      return row_updated;
    }

    public int Insert(object data)
    {
      int row_inserted = 0;
      if (this._db != null)
      {
        if (data is Models.EventLogs)
        {
          row_inserted = Models.EventLogs.Insert(this._db, (Models.EventLogs)data);
          EventLogs.Add((Models.EventLogs)data);
        }
      }
      return row_inserted;
    }

    #endregion
  }
}
