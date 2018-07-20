using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Infrastructure
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
