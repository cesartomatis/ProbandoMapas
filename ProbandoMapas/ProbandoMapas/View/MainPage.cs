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

        public MainPage()
        {
            Icon = "settings.png";
            Title = "menu"; // The Title property must be set.
            BackgroundColor = Color.FromHex("333333");

            Menu = new MenuListView();

            var menuLabel = new ContentView
            {
                Padding = new Thickness(10, 36, 0, 5),
                Content = new Label
                {
                    TextColor = Color.FromHex("AAAAAA"),
                    Text = "Menu",
                }
            };

            var layout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //layout.Children.Add(menuLabel);
            layout.Children.Add(Menu);

            Content = layout;
        }
    }
}
