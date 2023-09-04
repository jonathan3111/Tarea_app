using Sirenita5_app.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Sirenita5_app
{
    public partial class App : Application
    {
        static SQLiteHelper db;
        public static MasterDetailPage MAsterDet { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db_restaurante"));
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
