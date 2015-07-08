using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using ImageCircle.Forms.Plugin.Droid;

namespace ProbandoMapas.Droid
{
    [Activity(Label = "Runzheimer International", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);
            global::Xam.Plugin.MapExtend.Droid.MapExtendRenderer.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App());

            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            ActionBar.SetIcon(Android.Resource.Color.Transparent);
        }
    }
}

