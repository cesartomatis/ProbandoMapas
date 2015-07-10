﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ImageCircle.Forms.Plugin.iOS;
using Xam.Plugin.MapExtend.iOSUnified;
using Google.Maps;

namespace ProbandoMapas.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //UIWindow window;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        const string MapsApiKey = "AIzaSyDMB-HU3Q1LDMT6zdOiqvTCG3pjf9q5JVc";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            MapServices.ProvideAPIKey(MapsApiKey);

            global::Xamarin.Forms.Forms.Init();
            global::Xam.Plugin.MapExtend.iOSUnified.MapExtendRenderer.Init();
            Xamarin.FormsMaps.Init();
            ImageCircleRenderer.Init();
            LoadApplication(new App());

            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(244, 68, 54);
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });
            //UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            //app.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);



            return base.FinishedLaunching(app, options);
        }
    }
}
