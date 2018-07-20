using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TodoApp.Droid
{
    [Activity(Label = "TodoApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            ToolbarResou;

            base.OnCreate(bundle);

#if DEBUG
            CopyDatabase();
#endif

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
#if DEBUG
        private async void CopyDatabase()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbpath = Path.Combine(path, "todo.db3");

            var external = Android.OS.Enviroment
                .GetExternalStoragePublicDirectory(Android.OS.Enviroment.DirectoryDownloads).AbsolutePath;
            var externalPath = Path.Combine(external, "todo-backup.db3");

            if (!File.Exists(dbPath)) return;
            var origin = File.OpenRead(dbPath);
            var destino = File.Exists(externalPath) ? File.OpenWrite(externalPath) : File.Create(externalPath);

            using (origin)
            using (destino)
            {
                await origin.CopyToAsync(destino);
            }
        }
#endif
    }
}

