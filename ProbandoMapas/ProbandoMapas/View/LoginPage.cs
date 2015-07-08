using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var btn = new Button
            {
                Text = "Providers",
                BackgroundColor = Color.FromHex("#195174"),
                TextColor = Color.White,
                HeightRequest = 40,
                WidthRequest = 260,
                HorizontalOptions = LayoutOptions.Center
            };

            btn.Clicked += async (s, e) => this.SetupFirstPage(new MasterMainPage());

            Content = new StackLayout
            {
                Children = {
					btn
				}
            };
        }

        private void SetupFirstPage(Page firstPage)
        {
            var nav = new NavigationPage(firstPage);
            nav.BarBackgroundColor = Color.FromHex("#195174");
            nav.BarTextColor = Color.White;
        }
    }
}
