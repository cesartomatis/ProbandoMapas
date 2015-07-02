using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbandoMapas.View
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "Main Page",
                IconSource = "ic_home_variant_grey600_24dp.png",                
                TargetType = typeof(WelcomePage)
            });

            this.Add(new MenuItem()
            {
                Title = "Map",
                IconSource = "ic_google_maps_grey600_24dp.png",
                TargetType = typeof(TabMapas)
            });

            this.Add(new MenuItem()
            {
                Title = "Locations",
                IconSource = "ic_details_grey600_24dp.png",
                TargetType = typeof(TabLocalizacion)
            });

            this.Add(new MenuItem()
            {
                Title = "Distances",
                IconSource = "ic_map_marker_multiple_grey600_24dp.png",
                TargetType = typeof(TabDistancias)
            });

            this.Add(new MenuItem()
            {
                Title = "Itineraries",
                IconSource = "ic_clipboard_outline_grey600_24dp.png",
                TargetType = typeof(TabItinerarios)
            });
        }
    }
}
