using DevopsCase4.View;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;  
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevopsCase4
{
    public class UserDataContext : DbContext
    {
        public static IDbConnection GetConnection()
        {
            return new SqliteConnection("Data Source = DataFile.db");
        }
    }
}
