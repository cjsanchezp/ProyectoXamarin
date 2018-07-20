using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;

using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly:Xamarin.Forms.Dependency(typeof(TodoApp.Droid.SQLite))]
namespace TodoApp.Droid
{
    public class SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(path, "todo.db3");
            return new SQLiteConnection(dbPath);
        }
    }
}