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
    public partial class TabItinerario : ContentPage
    {
        PosicionamientoLogica plObj;

        public TabItinerario()
        {
            String initialPosition = Origin.Text;
            String finalPosition = Destination.Text;
            InitializeComponent();
            plObj = new PosicionamientoLogica();

        }

        private async void DibujarMapa_OnClicked(object sender, EventArgs args)
        {


            var initialPosition = (await (new Geocoder()).GetPositionsForAddressAsync(Origin.Text)).ToList();


            var finalPosition = (await (new Geocoder()).GetPositionsForAddressAsync(Destination.Text)).ToList();


            var pos1 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = initialPosition.First().Latitude,
                Longitude = initialPosition.First().Longitude
            };

            var pos2 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = finalPosition.First().Latitude,
                Longitude = finalPosition.First().Longitude
            };


            /*Este código, teniendo en cuenta el radio promedio de la tierra,
             * calcula el punto medio entre dos lugares del mundo dadas sus 
             * coordenadas y centra el mapa en ese lugar. El radio del MapSpan
             * esta dado por la distancia entre ellos. Le sumo 0.2 KM para
             * que no queden muy pegados al borde de la pantalla.
             * Las distancias están todas expresadas en el sistema métrico
             * y por ninguna razón se debería usar este código para realizar 
             * cálculos fuera de los necesarios para la geolocalización y geodesia.
             * */
            var radioTierra = 6371000; //metros
            var latitud1Radianes = pos1.Latitude * (Math.PI / 180.0);
            var latitud2Radianes = pos2.Latitude * (Math.PI / 180.0);
            var longitud1Radianes = pos2.Longitude * (Math.PI / 180.0);
            var longitud2Radianes = pos2.Longitude * (Math.PI / 180.0);

            var deltaLatitud = (pos2.Latitude - pos1.Latitude) * (Math.PI / 180.0);
            var deltaLongitud = (pos2.Longitude - pos1.Longitude) * (Math.PI / 180.0);


            var sumando1 = Math.Sin(deltaLatitud / 2) * Math.Sin(deltaLatitud / 2);
            var sumando2 = Math.Cos(latitud1Radianes) * Math.Cos(latitud2Radianes) * Math.Sin(deltaLongitud / 2) * Math.Sin(deltaLongitud / 2);
            List<double> sumandos = new List<double>();
            sumandos.Add(sumando1);
            sumandos.Add(sumando2);
            var a = sumandos.Sum();
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = radioTierra * c;

            /* Δφ es deltaLatitud
             * Δλ es deltaLongitud*/
            var Bx = Math.Cos(latitud2Radianes) * Math.Cos(deltaLongitud);
            var By = Math.Cos(latitud2Radianes) * Math.Sin(deltaLongitud);
            var φ3 = Math.Atan2(Math.Sin(latitud1Radianes) + Math.Sin(latitud2Radianes),
                                Math.Sqrt((Math.Cos(latitud1Radianes) + Bx) * (Math.Cos(latitud2Radianes) + Bx) + By * By));//Latitud del punto medio
            var λ3 = longitud1Radianes + Math.Atan2(By, Math.Cos(longitud1Radianes) + Bx);//Longitud del punto medio

            var centro = new Xamarin.Forms.Maps.Position(φ3, λ3);
            Distance distancia = new Xamarin.Forms.Maps.Distance(distance + 0.2);

            Gmaps.MoveToRegion(MapSpan.FromCenterAndRadius(centro, distancia));
            /*************esto de acá arriba deberia estar en un metodo en otro lado, el View Model por ejemplo*********************/

            Gmaps.MoveToRegion(MapSpan.FromCenterAndRadius(centro, distancia));

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Origen",
                Location = initialPosition.First(),
                Details = Origin.Text
            });

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Destino",
                Location = finalPosition.First(),
                Details = Destination.Text
            });

            await Gmaps.CreateRoute(initialPosition.First(), finalPosition.First());
        }
    }
}

