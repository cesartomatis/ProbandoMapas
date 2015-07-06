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
        bool start;
        DateTime l;
        List<Position> lstPos;
        public ObservableRangeCollection<Position> polilenes { get; set; }

        public TabMapas()
        {
            InitializeComponent();
            plObj = new PosicionamientoLogica();
            start = true;
            l = new DateTime();
            lstPos = new List<Position>();
        }

        private async void GetDir_OnClicked(object sender, EventArgs args)
        {
            if (MyAdress.Text == null || MyAdress.Text == "")
                return;
            else
                await plObj.GetDireccion(MyAdress.Text, Gmaps);
        }

        private async void DibujarMapa_OnClicked(object sender, EventArgs args)
        {
            var positionsUno = (await (new Geocoder()).GetPositionsForAddressAsync(txtOrigen.Text)).ToList();
            if (!positionsUno.Any())
            {
                lblError.Text = "Origen no existe";
                lblError.IsVisible = true;
            }

            var positionsDos = (await (new Geocoder()).GetPositionsForAddressAsync(txtDestino.Text)).ToList();
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

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Origen",
                Location = positionsUno.First(),
                Details = txtOrigen.Text
            });

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Destino",
                Location = positionsDos.First(),
                Details = txtDestino.Text
            });

            await Gmaps.CreateRoute(positionsUno.First(), positionsDos.First());
        }

        private async void GetStarted_OnClicked(object sender, EventArgs args)
        {
            l = DateTime.Now;

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(timeout: 10000);

            var pos1 = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            lstPos.Add(pos1);

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Origen",
                Location = pos1,
                Details = "Direccion de origen"
            });

            l.AddMilliseconds(30000);

            while (start == true)
            {
                var locator2 = CrossGeolocator.Current;
                locator2.DesiredAccuracy = 5;
                var position2 = await locator2.GetPositionAsync(timeout: 10000);

                var pos2 = new Xamarin.Forms.Maps.Position(position2.Latitude, position2.Longitude);

                //await Gmaps.CreateRoute(pos1, pos2);

                pos1 = pos2;

                lstPos.Add(pos1);

                l.AddMilliseconds(30000);
            }
        }

        private async void Finish_OnClicked(object sender, EventArgs args)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(timeout: 10000);

            var pos1 = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            lstPos.Add(pos1);

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Destino",
                Location = pos1,
                Details = "Direccion de destino"
            });
        }
    }
}
