using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TheCrew2CompanionApp.Views;
using DLToolkit.Forms.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TheCrew2CompanionApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            FlowListView.Init();

            MainPage = new MainPage();
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
