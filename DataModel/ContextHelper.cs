using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.IO;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataModel
{
    public class ContextHelper
    {
        private static DataModelContainer _ctx = null;
        private static EntityConnection _connrction; 

        public static DataModelContainer GetContext()
        {
            return _ctx ?? GenerateContext();
        }

        private static DataModelContainer GenerateContext()
        {
            return new DataModelContainer(_connrction ?? GetConnection());
        }

        private static EntityConnection GetConnection()
        {

            var connectionString = DataModel.Properties.Settings.Default.ConnectionToLocal;
            SetConnection(connectionString);
            return _connrction;
        
        }

        public static void SetConnection(String conn)
        {
            var cb = new EntityConnectionStringBuilder();
            cb.Provider = "System.Data.SqlClient";
            cb.ProviderConnectionString = conn;
            cb.Metadata = "res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl";
            
            _connrction = new EntityConnection(cb.ConnectionString);
        }

        public void CloseContext()
        {
            _ctx.Dispose();
            _ctx = null;
        }

    }
}
