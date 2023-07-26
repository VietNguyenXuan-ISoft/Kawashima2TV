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
  public class SqliteConfigurationContext : SqliteContext
  {
    public delegate void SendStatus(object sender, string status);
    public event SendStatus OnSendStatus;
    public SqliteConfigurationContext(string datasource, string password = "") : base(datasource, password)
    {
      this._configurations = null;
      if (File.Exists(datasource) == false)
      {
        this._db.CreateTable<AM_5AM>();
        this._db.CreateTable<Barcode>();
        this._db.CreateTable<ChangoverMatrix>();
        this._db.CreateTable<ChangoverMatrix>();
        this._db.CreateTable<Configuration>();
        this._db.CreateTable<Factory>();
        this._db.CreateTable<LossTable>();
        this._db.CreateTable<Machines>();
        this._db.CreateTable<MailAddressSupport>();
        this._db.CreateTable<MailConfig>();
        this._db.CreateTable<ProductCategory>();
        this._db.CreateTable<ProductionPlan>();
        this._db.CreateTable<ProtocolCommunication>();
        this._db.CreateTable<SerialSettings>();
        this._db.CreateTable<User>();
        this._db.CreateTable<UserGroup>();
        this._db.CreateTable<YearSupport>();

      }
      base.Setup(datasource, password);

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

        //*****************************************************************************
        //------- Copy AM_5M
        if (OnSendStatus != null) OnSendStatus(this, "Clone AM_5AM");
        dest_connection.CreateTable<AM_5AM>();
        List<AM_5AM> AM_5AMs = AM_5AM.LoadAll(source_connection);
        foreach (AM_5AM itm in AM_5AMs)
        {
          AM_5AM.Insert(dest_connection, itm);
        }


        //------- Copy Configuration
        if (OnSendStatus != null) OnSendStatus(this, "Clone Configuration");
        dest_connection.CreateTable<Configuration>();
        List<Configuration> Configurations = Configuration.LoadAll(source_connection);
        foreach (Configuration itm in Configurations)
        {
          Configuration.Insert(dest_connection, itm);
        }

        //------ Copy Barcode
        if (OnSendStatus != null) OnSendStatus(this, "Clone Barcode");
        dest_connection.CreateTable<Barcode>();
        List<Barcode> Barcodes = Barcode.LoadAll(source_connection);
        foreach (Barcode itm in Barcodes)
        {
          Barcode.Insert(dest_connection, itm);
        }

        //------ Copy ChangoverMatrixs
        if (OnSendStatus != null) OnSendStatus(this, "Clone ChangoverMatrix");
        dest_connection.CreateTable<ChangoverMatrix>();
        List<ChangoverMatrix> ChangoverMatrixs = ChangoverMatrix.LoadAll(source_connection);
        foreach (ChangoverMatrix itm in ChangoverMatrixs)
        {
          ChangoverMatrix.Insert(dest_connection, itm);
        }

        //------ Copy Factory
        if (OnSendStatus != null) OnSendStatus(this, "Clone Factory");
        dest_connection.CreateTable<Factory>();
        List<Factory> Factorys = Factory.LoadAll(source_connection);
        foreach (Factory itm in Factorys)
        {
          Factory.Insert(dest_connection, itm);
        }

        //------ Copy LossTable
        dest_connection.CreateTable<LossTable>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone LossTable");
        List<LossTable> LossTables = LossTable.LoadAll(source_connection);
        foreach (LossTable itm in LossTables)
        {
          LossTable.Insert(dest_connection, itm);
        }

        //------ Copy Machines
        dest_connection.CreateTable<Machines>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone Machines");
        List<Machines> Machiness = Machines.LoadAll(source_connection);
        foreach (Machines itm in Machiness)
        {
          Machines.Insert(dest_connection, itm);
        }

        //------ Copy MailAddressSupport
        dest_connection.CreateTable<MailAddressSupport>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone MailAddressSupport");
        List<MailAddressSupport> MailAddressSupports = MailAddressSupport.LoadAll(source_connection);
        foreach (MailAddressSupport itm in MailAddressSupports)
        {
          MailAddressSupport.Insert(dest_connection, itm);
        }

        //------ Copy MailConfig
        dest_connection.CreateTable<MailConfig>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone MailConfig");
        List<MailConfig> MailConfigs = MailConfig.LoadAll(source_connection);
        foreach (MailConfig itm in MailConfigs)
        {
          MailConfig.Insert(dest_connection, itm);
        }


        //------ Copy ProductCategory
        dest_connection.CreateTable<ProductCategory>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone ProductCategory");
        List<ProductCategory> ProductCategorys = ProductCategory.LoadAll(source_connection);
        foreach (ProductCategory itm in ProductCategorys)
        {
          ProductCategory.Insert(dest_connection, itm);
        }


        //------ Copy ProductionPlans
        dest_connection.CreateTable<ProductionPlan>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone ProductionPlans");
        List<ProductionPlan> ProductionPlans = ProductionPlan.LoadAll(source_connection);
        foreach (ProductionPlan itm in ProductionPlans)
        {
          ProductionPlan.Insert(dest_connection, itm);
        }


        //------ Copy ProtocolCommunication
        dest_connection.CreateTable<ProtocolCommunication>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone ProtocolCommunication");
        List<ProtocolCommunication> ProtocolCommunications = ProtocolCommunication.LoadAll(source_connection);
        foreach (ProtocolCommunication itm in ProtocolCommunications)
        {
          ProtocolCommunication.Insert(dest_connection, itm);
        }

        //------ Copy SerialSettings
        dest_connection.CreateTable<SerialSettings>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone SerialSettings");
        List<SerialSettings> SerialSettingss = SerialSettings.LoadAll(source_connection);
        foreach (SerialSettings itm in SerialSettingss)
        {
          SerialSettings.Insert(dest_connection, itm);
        }

        //------ Copy User
        dest_connection.CreateTable<User>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone User");
        List<User> Users = User.LoadAll(source_connection);
        foreach (User itm in Users)
        {
          User.Insert(dest_connection, itm);
        }
        //------ Copy UserGroups
        dest_connection.CreateTable<UserGroup>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone UserGroups");
        List<UserGroup> UserGroups = UserGroup.LoadAll(source_connection);
        foreach (UserGroup itm in UserGroups)
        {
          UserGroup.Insert(dest_connection, itm);
        }
        //------ Copy UserGroups
        dest_connection.CreateTable<YearSupport>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone UserGroups");
        List<YearSupport> YearSupports = YearSupport.LoadAll(source_connection);
        foreach (YearSupport itm in YearSupports)
        {
          YearSupport.Insert(dest_connection, itm);
        }
        //------ Copy Position
        dest_connection.CreateTable<Position>();
        if (OnSendStatus != null) OnSendStatus(this, "Clone Position");
        List<Position> Positions = Position.LoadAll(source_connection);
        foreach (Position itm in Positions)
        {
          Position.Insert(dest_connection, itm);
        }











        if (OnSendStatus != null) OnSendStatus(this, "Clone done..");
        source_connection.Close();
        dest_connection.Close();
      }
    }




    #region Variables
    /// <summary>
    /// AM_5AM
    /// </summary>
    private List<AM_5AM> _am_5ams = null;
    public List<AM_5AM> AM_5AMs
    {
      get
      {
        if (_am_5ams == null)
        {
          this._am_5ams = AM_5AM.LoadAll(this._db);
        }
        return this._am_5ams;
      }
      set { this._am_5ams = value; }
    }

    /// <summary>
    /// Barcode
    /// </summary>
    private List<Barcode> _barcodes = null;
    public List<Barcode> Barcodes
    {
      get
      {
        if (_barcodes == null)
        {
          this._barcodes = Barcode.LoadAll(this._db);
        }
        return this._barcodes;
      }
      set { this._barcodes = value; }
    }


    /// <summary>
    /// ChangoverMatrix
    /// </summary>
    private List<ChangoverMatrix> _changoverMatrix = null;
    public List<ChangoverMatrix> ChangoverMatrixs
    {
      get
      {
        if (_changoverMatrix == null)
        {
          this._changoverMatrix = ChangoverMatrix.LoadAll(this._db);
        }
        return this._changoverMatrix;
      }
      set { this._changoverMatrix = value; }
    }


    /// <summary>
    /// Configuration
    /// </summary>
    private List<Configuration> _configurations = null;
    public List<Configuration> Configurations
    {
      get
      {
        if (_configurations == null)
        {
          this._configurations = Configuration.LoadAll(this._db);
        }
        return this._configurations;
      }
      set { this._configurations = value; }
    }

    /// <summary>
    /// Factory
    /// </summary>
    private List<Factory> _factory = null;
    public List<Factory> Factorys
    {
      get
      {
        if (_factory == null)
        {
          this._factory = Factory.LoadAll(this._db);
        }
        return this._factory;
      }
      set { this._factory = value; }
    }


    /// <summary>
    /// LossTable
    /// </summary>
    private List<LossTable> _lossTable = null;
    public List<LossTable> LossTables
    {
      get
      {
        if (_lossTable == null)
        {
          this._lossTable = LossTable.LoadAll(this._db);
        }
        return this._lossTable;
      }
      set { this._lossTable = value; }
    }





    /// <summary>
    /// Machines
    /// </summary>
    private List<Machines> _machines = null;
    public List<Machines> Machiness
    {
      get
      {
        if (_machines == null)
        {
          this._machines = Machines.LoadAll(this._db);
        }
        return this._machines;
      }
      set { this._machines = value; }
    }

    /// <summary>
    /// MailAddressSupport
    /// </summary>
    private List<MailAddressSupport> _mailAddressSupport = null;
    public List<MailAddressSupport> MailAddressSupports
    {
      get
      {
        if (_mailAddressSupport == null)
        {
          this._mailAddressSupport = MailAddressSupport.LoadAll(this._db);
        }
        return this._mailAddressSupport;
      }
      set { this._mailAddressSupport = value; }
    }



    /// <summary>
    /// MailConfig
    /// </summary>
    private List<MailConfig> _mailConfig = null;
    public List<MailConfig> MailConfigs
    {
      get
      {
        if (_mailConfig == null)
        {
          this._mailConfig = MailConfig.LoadAll(this._db);
        }
        return this._mailConfig;
      }
      set { this._mailConfig = value; }
    }
    /// <summary>
    /// ProductCategory
    /// </summary>
    private List<ProductCategory> _productCategory = null;
    public List<ProductCategory> ProductCategorys
    {
      get
      {
        if (_productCategory == null)
        {
          this._productCategory = ProductCategory.LoadAll(this._db);
        }
        return this._productCategory;
      }
      set { this._productCategory = value; }
    }

    /// <summary>
    /// ProductionPlan
    /// </summary>
    private List<ProductionPlan> _productionPlan = null;
    public List<ProductionPlan> ProductionPlans
    {
      get
      {
        if (_productionPlan == null)
        {
          this._productionPlan = ProductionPlan.LoadAll(this._db);
        }
        return this._productionPlan;
      }
      set { this._productionPlan = value; }
    }
    /// <summary>
    /// ProtocolCommunication
    /// </summary>
    private List<ProtocolCommunication> _protocolCommunication = null;
    public List<ProtocolCommunication> ProtocolCommunications
    {
      get
      {
        if (_protocolCommunication == null)
        {
          this._protocolCommunication = ProtocolCommunication.LoadAll(this._db);
        }
        return this._protocolCommunication;
      }
      set { this._protocolCommunication = value; }
    }
    /// <summary>
    /// SerialSettings
    /// </summary>
    private List<SerialSettings> _serialSettings = null;
    public List<SerialSettings> SerialSettingss
    {
      get
      {
        if (_serialSettings == null)
        {
          this._serialSettings = SerialSettings.LoadAll(this._db);
        }
        return this._serialSettings;
      }
      set { this._serialSettings = value; }
    }

    /// <summary>
    /// User
    /// </summary>
    private List<User> _user = null;
    public List<User> Users
    {
      get
      {
        if (this._user == null)
        {
          this._user = User.LoadAll(this._db);
        }
        return this._user;
      }
      set { this._user = value; }
    }


    /// <summary>
    /// UserGroup
    /// </summary>
    private List<UserGroup> _userGroup = null;
    public List<UserGroup> UserGroups
    {
      get
      {
        if (this._userGroup == null)
        {
          this._userGroup = UserGroup.LoadAll(this._db);
        }
        return this._userGroup;
      }
      set { this._userGroup = value; }
    }

    /// <summary>
    /// UserGroup
    /// </summary>
    private List<YearSupport> _yearSupport = null;
    public List<YearSupport> YearSupports
    {
      get
      {
        if (this._yearSupport == null)
        {
          this._yearSupport = YearSupport.LoadAll(this._db);
        }
        return this._yearSupport;
      }
      set { this._yearSupport = value; }
    }

    /// <summary>
    /// Positions
    /// </summary>
    private List<Position> _position = null;
    public List<Position> Positions
    {
      get
      {
        if (this._position == null)
        {
          this._position = Position.LoadAll(this._db);
        }
        return this._position;
      }
      set { this._position = value; }
    }

    /// <summary>
    /// Positions
    /// </summary>
    private List<Operators> _operators = null;
    public List<Operators> Operatorss
    {
      get
      {
        if (this._operators == null)
        {
          this._operators = Operators.LoadAll(this._db);
        }
        return this._operators;
      }
      set { this._operators = value; }
    }



    #endregion


    public int Update(object data)
    {
      int row_updated = 0;
      if (this._db != null)
      {
        if (data is AM_5AM) row_updated = (AM_5AM.Update(this._db, (AM_5AM)data));
        else if (data is Barcode) row_updated = (Barcode.Update(this._db, (Barcode)data));
        else if (data is ChangoverMatrix) row_updated = (ChangoverMatrix.Update(this._db, (ChangoverMatrix)data));
        else if (data is Configuration) row_updated = (Configuration.Update(this._db, (Configuration)data));
        else if (data is Factory) row_updated = (Factory.Update(this._db, (Factory)data));
        else if (data is LossTable) row_updated = (LossTable.Update(this._db, (LossTable)data));
        else if (data is Machines) row_updated = (Machines.Update(this._db, (Machines)data));
        else if (data is MailAddressSupport) row_updated = (MailAddressSupport.Update(this._db, (MailAddressSupport)data));
        else if (data is MailConfig) row_updated = (MailConfig.Update(this._db, (MailConfig)data));
        else if (data is ProductCategory) row_updated = (ProductCategory.Update(this._db, (ProductCategory)data));
        else if (data is ProductionPlan) row_updated = (ProductionPlan.Update(this._db, (ProductionPlan)data));
        else if (data is ProtocolCommunication) row_updated = (ProtocolCommunication.Update(this._db, (ProtocolCommunication)data));
        else if (data is SerialSettings) row_updated = (SerialSettings.Update(this._db, (SerialSettings)data));
        else if (data is User) row_updated = (User.Update(this._db, (User)data));
        else if (data is UserGroup) row_updated = (UserGroup.Update(this._db, (UserGroup)data));
        else if (data is YearSupport) row_updated = (YearSupport.Update(this._db, (YearSupport)data));
      }
      return row_updated;
    }

    public int Insert(object data)
    {
      int row_inserted = 0;
      if (this._db != null)
      {
        if (data is AM_5AM)
        {
          row_inserted = AM_5AM.Insert(this._db, (AM_5AM)data);
          AM_5AMs.Add((AM_5AM)data);
        }
        else if (data is Barcode)
        {
          row_inserted = Barcode.Insert(this._db, (Barcode)data);
          Barcodes.Add((Barcode)data);
        }
        else if (data is ChangoverMatrix)
        {
          row_inserted = ChangoverMatrix.Insert(this._db, (ChangoverMatrix)data);
          ChangoverMatrixs.Add((ChangoverMatrix)data);
        }
        else if (data is Configuration)
        {
          row_inserted = Configuration.Insert(this._db, (Configuration)data);
          Configurations.Add((Configuration)data);
        }
        else if (data is Factory)
        {
          row_inserted = Factory.Insert(this._db, (Factory)data);
          Factorys.Add((Factory)data);
        }
        else if (data is LossTable)
        {
          row_inserted = LossTable.Insert(this._db, (LossTable)data);
          LossTables.Add((LossTable)data);
        }
        else if (data is Machines)
        {
          row_inserted = Machines.Insert(this._db, (Machines)data);
          Machiness.Add((Machines)data);
        }
        else if (data is MailAddressSupport)
        {
          row_inserted = MailAddressSupport.Insert(this._db, (MailAddressSupport)data);
          MailAddressSupports.Add((MailAddressSupport)data);
        }
        else if (data is MailConfig)
        {
          row_inserted = MailConfig.Insert(this._db, (MailConfig)data);
          MailConfigs.Add((MailConfig)data);
        }
        else if (data is ProductCategory)
        {
          row_inserted = ProductCategory.Insert(this._db, (ProductCategory)data);
          ProductCategorys.Add((ProductCategory)data);
        }
        else if (data is ProductionPlan)
        {
          row_inserted = ProductionPlan.Insert(this._db, (ProductionPlan)data);
          ProductionPlans.Add((ProductionPlan)data);
        }
        else if (data is ProtocolCommunication)
        {
          row_inserted = ProtocolCommunication.Insert(this._db, (ProtocolCommunication)data);
          ProtocolCommunications.Add((ProtocolCommunication)data);
        }
        else if (data is SerialSettings)
        {
          row_inserted = SerialSettings.Insert(this._db, (SerialSettings)data);
          SerialSettingss.Add((SerialSettings)data);
        }
        else if (data is User)
        {
          row_inserted = User.Insert(this._db, (User)data);
          Users.Add((User)data);
        }
        else if (data is UserGroup)
        {
          row_inserted = UserGroup.Insert(this._db, (UserGroup)data);
          UserGroups.Add((UserGroup)data);
        }
        else if (data is YearSupport)
        {
          row_inserted = YearSupport.Insert(this._db, (YearSupport)data);
          YearSupports.Add((YearSupport)data);
        }
      }
      return row_inserted;
    }
  }

}
