using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geolocator;
using Geolocator.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xam.Plugin.MapExtend.Abstractions;

namespace ProbandoMapas.Model
{
    public class PosicionamientoLogica
    {

        public PosicionamientoLogica()
        {

        }

        public async Task<string> GetCoordenadas()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(timeout: 10000);

            return "Lat" + position.Latitude.ToString() + "Long" + position.Longitude.ToString();
        }

        public async Task<string> ShowMyAdress()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(timeout: 10000);

            var pos = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var locationAddress = (await (new Geocoder()).GetAddressesForPositionAsync(pos));

            return locationAddress.First().ToString();
        }

        public async Task<double> GetDistancia(string posUno, string posDos)
        {
            var positionsUno = (await (new Geocoder()).GetPositionsForAddressAsync(posUno)).ToList();
            if (!positionsUno.Any())
            {
                return -1.0;
            }

            var positionsDos = (await (new Geocoder()).GetPositionsForAddressAsync(posDos)).ToList();
            if (!positionsDos.Any())
            {
                return -1.0;
            }

            var pos1 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = positionsUno.First().Latitude,
                Longitude = positionsUno.First().Longitude
                //Latitude = 48.4568664,
                //Longitude = 35.0352648
            };

            var pos2 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = positionsDos.First().Latitude,
                Longitude = positionsDos.First().Longitude
                //Latitude = 48.3837615903,
                //Longitude = 35.0011338294
            };


            var distance = Xamarin.Forms.Labs.Services.Geolocation.PositionExtensions.DistanceFrom(pos1, pos2);

            return distance;

            //System.Diagnostics.Debug.WriteLine(distance);
        }

        public async Task<List<string>> GetListado()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(timeout: 10000);

            var pos = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var locationAddress = (await (new Geocoder()).GetAddressesForPositionAsync(pos));

            List<string> lista = new List<string>();

            foreach (var p in locationAddress)
            {
                lista.Add(p.ToString());
            }

            return lista;
        }

        public async Task GetDireccion(string addressQuery, MapExtend map)
        {
            var positions = (await (new Geocoder()).GetPositionsForAddressAsync(addressQuery)).ToList();
            if (!positions.Any())
                return;

            var position = positions.First();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(position,
            Distance.FromMiles(0.1)));

            map.EPins.Add(new PinExtend
            {
                Name = addressQuery,
                Location = position,
                Details = addressQuery
            });
        }

        public async Task DrawPins(string p, string p2, MapExtend Gmaps)
        {
            var positionsUno = (await (new Geocoder()).GetPositionsForAddressAsync(p)).ToList();
            if (!positionsUno.Any())
            {
                return;
            }

            var positionsDos = (await (new Geocoder()).GetPositionsForAddressAsync(p2)).ToList();
            if (!positionsDos.Any())
            {
                return;
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
            Distance distancia = new Xamarin.Forms.Maps.Distance(distance);

            Gmaps.MoveToRegion(MapSpan.FromCenterAndRadius(centro, distancia));

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Origen",
                Location = positionsUno.First(),
                Details = p
            });

            Gmaps.EPins.Add(new PinExtend
            {
                Name = "Destino",
                Location = positionsDos.First(),
                Details = p2
            });

            await Gmaps.CreateRoute(positionsUno.First(), positionsDos.First());
        }
    }
}
