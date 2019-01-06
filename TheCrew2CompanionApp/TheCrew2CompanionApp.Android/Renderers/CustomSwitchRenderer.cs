using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TheCrew2CompanionApp.Droid.Renderers;
using TheCrew2CompanionApp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace TheCrew2CompanionApp.Droid.Renderers
{
    public class CustomSwitchRenderer : SwitchRenderer
    {
        private CustomSwitch view;

        public CustomSwitchRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);

            this.Control.ThumbDrawable.SetColorFilter(this.Control.Checked ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.Red, PorterDuff.Mode.SrcAtop);
            this.Control.TrackDrawable.SetColorFilter(this.Control.Checked ? Android.Graphics.Color.Green : Android.Graphics.Color.Red, PorterDuff.Mode.SrcAtop);

            this.Control.CheckedChange += this.OnCheckedChange;
        }

        private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            this.Control.ThumbDrawable.SetColorFilter(this.Control.Checked ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.Red, PorterDuff.Mode.SrcAtop);
            this.Control.TrackDrawable.SetColorFilter(this.Control.Checked ? Android.Graphics.Color.Green : Android.Graphics.Color.Red, PorterDuff.Mode.SrcAtop);

            this.Element.IsToggled = Control.Checked;
        }
    }
}