using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TheCrew2CompanionApp.Views;
using DLToolkit.Forms.Controls;
using TheCrew2CompanionApp.Data;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TheCrew2CompanionApp
{
    public partial class App : Application
    {
        static VehiclesItemDatabase database;

        public App()
        {
            InitializeComponent();

            FlowListView.Init();

            MainPage = new MainPage();
        }

        public static VehiclesItemDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new VehiclesItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VehiclesDatabase.db3"));
                }

                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
