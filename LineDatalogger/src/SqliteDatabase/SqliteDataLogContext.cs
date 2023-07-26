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
  
  

  public class SqliteDataLogContext: SqliteContext
  {
    public delegate void SendStatus(object sender, string status);
    public event SendStatus OnSendStatus;
    public SqliteDataLogContext(string datasource, string password = "") : base(datasource, password)
    {
      if (File.Exists(datasource) == false)
      {
        base.Setup(datasource, password);
        //if (password == "")
        //{
        //  this._db = new SQLiteConnection(datasource);
        //}
        //else
        //{
        //  this._db = new SQLiteConnection(datasource, openFlags: SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.Create);
        //  this._db.Query<int>($"PRAGMA key={datasource}");
        //  var options = new SQLiteConnectionString(datasource, true, key: password);
        //  var encryptedDb = new SQLiteAsyncConnection(options);
        //}
        if (_db != null)
        {
          this._db.CreateTable<data_log>();
          this._db.CreateTable<FOS>();
          this._db.CreateTable<Models.Datalog.MaterialWaste>();
          this._db.CreateTable<loss_management>();
        }
      }
      else
      {
        base.Setup(datasource, password);
      }
    }
    public void Clone(string source, string source_password, string dest, string dest_password)
    {
      string error_message = "";
      try
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

          //*****************************************************************************
          //------- Copy datalog
          if (OnSendStatus != null) OnSendStatus(this, "Clone datalog");
          dest_connection.CreateTable<data_log>();
          List<data_log> data_logs = data_log.LoadAll(source_connection);
          foreach (data_log itm in data_logs)
          {
            data_log.Insert(dest_connection, itm);
          }


          //------- Copy FOS
          if (OnSendStatus != null) OnSendStatus(this, "Clone FOS");
          dest_connection.CreateTable<FOS>();
          List<FOS> foss = FOS.LoadAll(source_connection);
          foreach (FOS itm in foss)
          {
            FOS.Insert(dest_connection, itm);
          }


          //------- Copy loss_management
          if (OnSendStatus != null) OnSendStatus(this, "Clone loss_management");
          dest_connection.CreateTable<loss_management>();
          List<loss_management> loss_managements = loss_management.LoadAll(source_connection);
          foreach (loss_management itm in loss_managements)
          {
            loss_management.Insert(dest_connection, itm);
          }


          //------- Copy loss_management
          if (OnSendStatus != null) OnSendStatus(this, "Clone MaterialWaste");
          dest_connection.CreateTable<Models.Datalog.MaterialWaste>();
          List<Models.Datalog.MaterialWaste> MaterialWastes = Models.Datalog.MaterialWaste.LoadAll(source_connection);
          foreach (Models.Datalog.MaterialWaste itm in MaterialWastes)
          {
            Models.Datalog.MaterialWaste.Insert(dest_connection, itm);
          }







          if (OnSendStatus != null) OnSendStatus(this, "Clone datalog done..");
          source_connection.Close();
          dest_connection.Close();
        }
      }
      catch (Exception ex)
      {
        error_message = ex.Message.ToString();
      }
      if (error_message != "")
      {
        if (OnSendStatus != null) OnSendStatus(this, error_message);
      }
    }

    public int Update(object data)
    {
      int row_updated = 0;
      if (this._db != null)
      {
        if (data is data_log) row_updated = data_log.Update(this._db, (data_log)data);
        else if (data is FOS) row_updated = FOS.Update(this._db, (FOS)data);
        else if (data is Models.Datalog.MaterialWaste) row_updated = Models.Datalog.MaterialWaste.Update(this._db, (Models.Datalog.MaterialWaste)data);
        else if (data is loss_management) row_updated = loss_management.Update(this._db, (loss_management)data);
      }
      return row_updated;
    }

    public int Insert(object data)
    {
      int row_inserted = 0;
      if (this._db != null)
      {
        if (data is data_log)
        {
          row_inserted = data_log.Insert(this._db, (data_log)data);
          Data_logs.Add((data_log)data);
        }
        else if (data is FOS)
        {
          row_inserted = FOS.Insert(this._db, (FOS)data);
          FOSs.Add((FOS)data);
        }
        else if (data is Models.Datalog.MaterialWaste)
        {
          row_inserted = Models.Datalog.MaterialWaste.Insert(this._db, (Models.Datalog.MaterialWaste)data);
          MaterialWastes.Add((Models.Datalog.MaterialWaste)data);
        }
        else if (data is loss_management)
        {
          row_inserted = loss_management.Insert(this._db, (loss_management)data);
          Loss_managements.Add((loss_management)data);
        }

      }
      return row_inserted;
    }

    /// <summary>
    /// data_log
    /// </summary>
    private List<data_log> _data_log = null;
    public List<data_log> Data_logs
    {
      get
      {
        if (this._data_log == null)
        {
          this._data_log = data_log.LoadAll(this._db);
        }
        return this._data_log;
      }
      set { this._data_log = value; }
    }


    /// <summary>
    /// _fos
    /// </summary>
    private List<FOS> _fos = null;
    public List<FOS> FOSs
    {
      get
      {
        if (this._fos == null)
        {
          this._fos = FOS.LoadAll(this._db);
        }
        return this._fos;
      }
      set { this._fos = value; }
    }

    /// <summary>
    /// _materialWaste
    /// </summary>
    private List<Models.Datalog.MaterialWaste> _materialWaste = null;
    public List<Models.Datalog.MaterialWaste> MaterialWastes
    {
      get
      {
        if (this._materialWaste == null)
        {
          this._materialWaste = Models.Datalog.MaterialWaste.LoadAll(this._db);
        }
        return this._materialWaste;
      }
      set { this._materialWaste = value; }
    }

    /// <summary>
    /// _materialWaste
    /// </summary>
    private List<loss_management> _loss_management = null;
    public List<loss_management> Loss_managements
    {
      get
      {
        if (this._loss_management == null)
        {
          this._loss_management = loss_management.LoadAll(this._db);
        }
        return this._loss_management;
      }
      set { this._loss_management = value; }
    }

  }
}
