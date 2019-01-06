using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TheCrew2CompanionApp.Droid.Classes;
using TheCrew2CompanionApp.Interfaces;
using Toast = TheCrew2CompanionApp.Interfaces.Toast;

[assembly: Xamarin.Forms.Dependency(typeof(Toast_Android))]
namespace TheCrew2CompanionApp.Droid.Classes
{
    public class Toast_Android : Toast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}