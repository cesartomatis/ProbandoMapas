using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ProbandoMapas.View
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "Dashboard",
                IconSource = ImageSource.FromFile("ic_home_variant_white.png"),                
                TargetType = typeof(WelcomePage)
            });

            this.Add(new MenuItem()
            {
                Title = "Map",
                IconSource = ImageSource.FromFile("ic_google_maps_white.png"),
                TargetType = typeof(MapasPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Locations",
                IconSource = ImageSource.FromFile("ic_details_white.png"),
                TargetType = typeof(LocalizacionPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Distances",
                IconSource = ImageSource.FromFile("ic_map_marker_multiple_white.png"),
                TargetType = typeof(DistanciasPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Itineraries",
                IconSource = ImageSource.FromFile("ic_clipboard_outline_white.png"),
                TargetType = typeof(TabItinerarios)
            });
        }
    }
}
