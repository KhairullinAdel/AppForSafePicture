using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace AppForSafePicture
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Items.db"
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static ItemBag db;
        public static ItemBag DB
        {
            get
            {
                if (db == null)
                {
                    db = new ItemBag(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
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
