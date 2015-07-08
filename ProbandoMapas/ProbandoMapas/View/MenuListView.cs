using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using ProbandoMapas.Model;

namespace ProbandoMapas.View
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuItem> data = new MenuListData();

            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;
            SeparatorVisibility = SeparatorVisibility.Default;
            SeparatorColor = Color.Transparent;

            var cell = new DataTemplate(typeof(ViewCellExtend));
            cell.SetBinding(ViewCellExtend.BindableTextProperty, "Title");
            cell.SetBinding(ViewCellExtend.BindableImageProperty, "IconSource");

            ItemTemplate = cell;
        }
    }
}
