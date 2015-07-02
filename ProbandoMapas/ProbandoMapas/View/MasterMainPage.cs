using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class MasterMainPage : MasterDetailPage
    {
        MainPage mainPage;

        public MasterMainPage()
        {
            mainPage = new MainPage();

            mainPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

            Master = mainPage;
            Detail = new NavigationPage(new WelcomePage());
        }

        void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            mainPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}
