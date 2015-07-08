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
            if (txtOrigen.Text == null || txtOrigen.Text == "" || txtDestino.Text == null || txtDestino.Text == "")
            {
                // TODO: Implementar un mensaje de error
                return;
            }

            else
            {
                await plObj.DrawPins(txtOrigen.Text, txtDestino.Text, Gmaps);
            }
<<<<<<< HEAD

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
=======
>>>>>>> 33ffe52085efbdf3ea5ca3b7daa1dada73bb44e8
        }

        private async void GetStarted_OnClicked(object sender, EventArgs args)
        {
            //l = DateTime.Now;

            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 5;
            //var position = await locator.GetPositionAsync(timeout: 10000);

            //var pos1 = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            //lstPos.Add(pos1);

            //Gmaps.EPins.Add(new PinExtend
            //{
            //    Name = "Origen",
            //    Location = pos1,
            //    Details = "Direccion de origen"
            //});

            //l.AddMilliseconds(30000);

            //while (start == true)
            //{
            //    var locator2 = CrossGeolocator.Current;
            //    locator2.DesiredAccuracy = 5;
            //    var position2 = await locator2.GetPositionAsync(timeout: 10000);

            //    var pos2 = new Xamarin.Forms.Maps.Position(position2.Latitude, position2.Longitude);

            //    //await Gmaps.CreateRoute(pos1, pos2);

            //    pos1 = pos2;

            //    lstPos.Add(pos1);

            //    l.AddMilliseconds(30000);
            //}
        }

        private async void Finish_OnClicked(object sender, EventArgs args)
        {
            //    var locator = CrossGeolocator.Current;
            //    locator.DesiredAccuracy = 5;
            //    var position = await locator.GetPositionAsync(timeout: 10000);

            //    var pos1 = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            //    lstPos.Add(pos1);

            //    Gmaps.EPins.Add(new PinExtend
            //    {
            //        Name = "Destino",
            //        Location = pos1,
            //        Details = "Direccion de destino"
            //    });
            //}
        }
    }
}
