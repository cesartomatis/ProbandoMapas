using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ProbandoMapas.View;
using Android.Graphics.Drawables;

namespace ProbandoMapas.Droid.Renderers
{
    public class MenuCellRenderer : ViewCellRenderer
    {
        global::Android.Views.View cell;

        protected override global::Android.Views.View GetCellCore(Cell item, global::Android.Views.View convertView, ViewGroup parent, Context context)
        {
            this.cell = base.GetCellCore(item, convertView, parent, context);

            return cell;

        }
        protected override void OnCellPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);

            if (args.PropertyName == ProbandoMapas.View.MenuCell.IsSelectedPropertyName)
            {
                var myCustomCell = sender as ProbandoMapas.View.MenuCell;

                if(myCustomCell.IsSelected)
                    this.cell.Background = new ColorDrawable(myCustomCell.SelectedBackgroundColor.ToAndroid());
            }
        }
    }
}