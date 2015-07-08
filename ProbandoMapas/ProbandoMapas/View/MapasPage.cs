using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xam.Plugin.MapExtend.Abstractions;

namespace ProbandoMapas.View
{
    public class MapasPage : ContentPage
    {
        MapExtend mapa;
        ScrollView svContenedor;
        Label lblAdress, lblError;
        Entry txtAdress, txtOrigen, txtDestino;
        Button btnPin, btnDibujarRuta, btnInicio, btnFin;
        Model.PosicionamientoLogica plObj;

        public MapasPage()
        {
            this.BindingContext = new ViewModel.VMClass();

            initConfig();

            StackLayout stContenedor = new StackLayout() 
            { 
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    mapa,
                    svContenedor
                }
            };

            Content = stContenedor;
        }

        public void initConfig()
        {
            plObj = new Model.PosicionamientoLogica();

            mapa = new MapExtend()
            {
                WidthRequest = 320,
                HeightRequest = 200,
                IsShowingUser = true,
                MapType = MapType.Hybrid
            };

            lblAdress = new Label();
            lblAdress.VerticalOptions = LayoutOptions.Center;
            lblAdress.HorizontalOptions = LayoutOptions.Center;
            lblAdress.SetBinding(Label.TextProperty, new Binding("AdressLabel"));

            txtAdress = new Entry();
            txtAdress.Placeholder = "Enter your adress here";

            btnPin = new Button();
            btnPin.Text = "Pin direction";
            btnPin.Clicked += async (sender, e) =>
                {
                    if (txtAdress.Text == null || txtAdress.Text == "")
                        return;
                    else
                        await plObj.GetDireccion(txtAdress.Text, mapa);
                };

            txtOrigen = new Entry();
            txtOrigen.Placeholder = "Ingresar origen...";

            txtDestino = new Entry();
            txtDestino.Placeholder = "Ingresar destino...";

            btnDibujarRuta = new Button();
            btnDibujarRuta.Text = "Dibujar ruta";
            btnDibujarRuta.Clicked += async (sender, e) =>
                {
                    if (txtOrigen.Text == null || txtOrigen.Text == "" || txtDestino.Text == null || txtDestino.Text == "")
                    {
                        // TODO: Implementar un mensaje de error
                        return;
                    }
                    else
                    {
                        await plObj.DrawPins(txtOrigen.Text, txtDestino.Text, mapa);
                    }
                };

            lblError = new Label() 
            { 
                TextColor = Color.Red,
                IsVisible = false
            };

            btnInicio = new Button();
            btnInicio.Text = "Inicio";
            btnInicio.Clicked += (sender, e) =>
                {
                    //TODO
                };

            btnFin = new Button();
            btnFin.Text = "Fin";
            btnFin.Clicked += (sender, e) =>
                {
                    //TODO
                };

            svContenedor = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Content = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 10,
                    Children =
                    {
                        lblAdress,
                        txtAdress,
                        btnPin,
                        txtOrigen,
                        txtDestino,
                        btnDibujarRuta,
                        lblError,
                        btnInicio,
                        btnFin
                    }
                }
            };
        }
    }
}
