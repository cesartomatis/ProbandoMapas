using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ProbandoMapas.Model;

using Geolocator;
using Geolocator.Plugin;
using Xamarin.Forms.Maps;
using Xam.Plugin.MapExtend.Abstractions;

namespace ProbandoMapas.View
{
    public partial class TabMapas : ContentPage
    {

        PosicionamientoLogica plObj;

        public TabMapas()
        {
            InitializeComponent();
            plObj = new PosicionamientoLogica();
        }

        private async void GetDir_OnClicked(object sender, EventArgs args)
        {
            await plObj.GetDireccion(MyAdress.Text, Gmaps);
        }

        private async void DibujarMapa_OnClicked(object sender, EventArgs args)
        {
            var positionsUno = (await(new Geocoder()).GetPositionsForAddressAsync(txtOrigen.Text)).ToList();
            if (!positionsUno.Any())
            {
                lblError.Text = "Origen no existe";
                lblError.IsVisible = true;
            }

            var positionsDos = (await(new Geocoder()).GetPositionsForAddressAsync(txtDestino.Text)).ToList();
            if (!positionsDos.Any())
            {
                lblError.Text = "Destino no existe";
                lblError.IsVisible = true;
            }

            var pos1 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = positionsUno.First().Latitude,
                Longitude = positionsUno.First().Longitude
            };

            var pos2 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = positionsDos.First().Latitude,
                Longitude = positionsDos.First().Longitude
            };

            Gmaps.MoveToRegion(MapSpan.FromCenterAndRadius(positionsUno.First(), Distance.FromMiles(0.1)));

            //Gmaps.EPins.Add(new PinExtend
            //{
            //    Name = "Origen",
            //    Location = positionsUno.First(),
            //    Details = txtOrigen.Text
            //});

            //Gmaps.EPins.Add(new PinExtend
            //{
            //    Name = "Destino",
            //    Location = positionsDos.First(),
            //    Details = txtDestino.Text
            //});

            await Gmaps.CreateRoute(positionsUno.First(), positionsDos.First());
        }
    }
}
