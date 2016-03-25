﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Albrus
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PriceChecker")]
	public partial class DataClasses2DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDevice(Device instance);
    partial void UpdateDevice(Device instance);
    partial void DeleteDevice(Device instance);
    partial void InsertDeviceLog(DeviceLog instance);
    partial void UpdateDeviceLog(DeviceLog instance);
    partial void DeleteDeviceLog(DeviceLog instance);
    #endregion
		
		public DataClasses2DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["PriceCheckerConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Device> Devices
		{
			get
			{
				return this.GetTable<Device>();
			}
		}
		
		public System.Data.Linq.Table<DeviceLog> DeviceLogs
		{
			get
			{
				return this.GetTable<DeviceLog>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Devices")]
	public partial class Device : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _ipAdress;
		
		private string _idDevice;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnipAdressChanging(string value);
    partial void OnipAdressChanged();
    partial void OnidDeviceChanging(string value);
    partial void OnidDeviceChanged();
    #endregion
		
		public Device()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ipAdress", DbType="NChar(15)")]
		public string ipAdress
		{
			get
			{
				return this._ipAdress;
			}
			set
			{
				if ((this._ipAdress != value))
				{
					this.OnipAdressChanging(value);
					this.SendPropertyChanging();
					this._ipAdress = value;
					this.SendPropertyChanged("ipAdress");
					this.OnipAdressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idDevice", DbType="NChar(20)")]
		public string idDevice
		{
			get
			{
				return this._idDevice;
			}
			set
			{
				if ((this._idDevice != value))
				{
					this.OnidDeviceChanging(value);
					this.SendPropertyChanging();
					this._idDevice = value;
					this.SendPropertyChanged("idDevice");
					this.OnidDeviceChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DeviceLogs")]
	public partial class DeviceLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _ipAdress;
		
		private string _idDevice;
		
		private System.Nullable<System.DateTime> _dataLog;
		
		private string _logMessage;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnipAdressChanging(string value);
    partial void OnipAdressChanged();
    partial void OnidDeviceChanging(string value);
    partial void OnidDeviceChanged();
    partial void OndataLogChanging(System.Nullable<System.DateTime> value);
    partial void OndataLogChanged();
    partial void OnlogMessageChanging(string value);
    partial void OnlogMessageChanged();
    #endregion
		
		public DeviceLog()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ipAdress", DbType="NChar(15)")]
		public string ipAdress
		{
			get
			{
				return this._ipAdress;
			}
			set
			{
				if ((this._ipAdress != value))
				{
					this.OnipAdressChanging(value);
					this.SendPropertyChanging();
					this._ipAdress = value;
					this.SendPropertyChanged("ipAdress");
					this.OnipAdressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idDevice", DbType="NChar(10)")]
		public string idDevice
		{
			get
			{
				return this._idDevice;
			}
			set
			{
				if ((this._idDevice != value))
				{
					this.OnidDeviceChanging(value);
					this.SendPropertyChanging();
					this._idDevice = value;
					this.SendPropertyChanged("idDevice");
					this.OnidDeviceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dataLog", DbType="DateTime")]
		public System.Nullable<System.DateTime> dataLog
		{
			get
			{
				return this._dataLog;
			}
			set
			{
				if ((this._dataLog != value))
				{
					this.OndataLogChanging(value);
					this.SendPropertyChanging();
					this._dataLog = value;
					this.SendPropertyChanged("dataLog");
					this.OndataLogChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logMessage", DbType="NChar(200)")]
		public string logMessage
		{
			get
			{
				return this._logMessage;
			}
			set
			{
				if ((this._logMessage != value))
				{
					this.OnlogMessageChanging(value);
					this.SendPropertyChanging();
					this._logMessage = value;
					this.SendPropertyChanged("logMessage");
					this.OnlogMessageChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
