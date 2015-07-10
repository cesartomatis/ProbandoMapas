using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class MainPage : ContentPage
    {
        public ListView Menu { get; set; }
        CircleImage menuImage;
        Label menuLabel;

        public MainPage()
        {
            Icon = "settings.png";
            Title = "menu"; // The Title property must be set.
            BackgroundColor = Color.FromHex("#F44336");

            Menu = new MenuListView();

            menuImage = new CircleImage
            {
                BorderColor = Color.FromHex("#FFEBEE"),
                BorderThickness = 3,
                HeightRequest = 75,
                WidthRequest = 75,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Start,
                Source = UriImageSource.FromFile("fotoperfil.png")
            };

            menuLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                Text = "Pablo Gil",
            };

            StackLayout stContendorGral = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Vertical,
            };

            if (Device.OS == TargetPlatform.iOS)
            {
                stContendorGral.Padding = new Thickness(0, 20, 0, 0);
            }

            stContendorGral.Children.Add(CreateMenuBlock());
            stContendorGral.Children.Add(Menu);

            Content = stContendorGral;
        }


        Xamarin.Forms.View CreateMenuBlock()
        {
            return new Frame
            {
                OutlineColor = Color.Transparent,
                BackgroundColor = Color.Transparent,
                Content = new StackLayout
                {
                    
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
					{
                        new StackLayout
						{
                            //Padding = new Thickness(15,0,10,0),
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalOptions = LayoutOptions.Center,
							Children = 
							{ 
                                menuImage
							}
						},

						new StackLayout
						{
                            //Padding = new Thickness(0,5,10,0),
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            VerticalOptions = LayoutOptions.Center,
							Children = 
							{
								menuLabel
							}
						}
					}
                }
            };
        }
    }
}
