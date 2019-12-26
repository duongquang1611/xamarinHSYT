using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
