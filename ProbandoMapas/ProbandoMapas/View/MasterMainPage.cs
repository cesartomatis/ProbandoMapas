using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using ProbandoMapas.Model;

namespace ProbandoMapas.View
{
    public class MasterMainPage : MasterDetailPage
    {
        MainPage mainPage;
        MenuItem selected;

        public MasterMainPage()
        {
            mainPage = new MainPage();

            selected = new MenuItem();

            mainPage.Menu.ItemSelected += (sender, e) =>
                {
                    if (selected != null)
                    {
                        selected.SetColors(false);
                    }

                    selected = (e.SelectedItem as MenuItem);

                    selected.SetColors(true);

                    NavigateTo(e.SelectedItem as MenuItem);
                };

            Master = mainPage;
            Detail = new NavigationPage(new WelcomePage());
        }

        void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            //mainPage.Menu.SelectedItem = menu;
            IsPresented = false;
        }
    }
}
