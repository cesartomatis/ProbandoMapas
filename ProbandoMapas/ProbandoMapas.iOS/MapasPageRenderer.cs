using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ProbandoMapas.iOS;
using Google.Maps;
using CoreGraphics;

[assembly: ExportRenderer(typeof(ProbandoMapas.View.MapasPage), typeof(MapasPageRenderer))]

namespace ProbandoMapas.iOS
{
    class MapasPageRenderer : PageRenderer
    {
        MapView mapView;

        public MapasPageRenderer()
        {
            LoadView();
            ViewWillAppear(true);
        }

        public override void LoadView()
        {
            base.LoadView();

            var camera = CameraPosition.FromCamera(latitude: 37.797865, longitude: -122.402526, zoom: 6);
            mapView = MapView.FromCamera(CGRect.Empty, camera);
            mapView.MyLocationEnabled = true;
            //mapView.UserInteractionEnabled = true;
            mapView.MapType = MapViewType.Normal;
            //mapView.AccessibilityElementsHidden = false;
            //mapView.Settings.CompassButton = true;
            mapView.Settings.MyLocationButton = true;
            View = mapView;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            mapView.StartRendering();
        }

        public override void ViewWillDisappear(bool animated)
        {
            mapView.StopRendering();
            base.ViewWillDisappear(animated);
        }
    }
}