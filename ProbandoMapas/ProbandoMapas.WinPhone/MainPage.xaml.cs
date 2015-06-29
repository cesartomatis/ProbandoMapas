using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xam.Plugin.MapExtend;
using Xam.Plugin.MapExtend.WindowsPhone;

namespace ProbandoMapas.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            string applicationId = "APP_ID_FROM_PORTAL", authToken = "AUTH_TOKEN_FROM_PORTAL";
            MapExtendRenderer.Init(applicationId, authToken);
            LoadApplication(new ProbandoMapas.App());
        }
    }
}
