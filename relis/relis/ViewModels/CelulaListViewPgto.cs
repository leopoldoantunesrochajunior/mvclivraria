using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Core;

using Xamarin.Essentials;

using System.Collections;




namespace relis.ViewModels
{


    public class CelulaListViewPgto : ViewCell
    {
        public CelulaListViewPgto()
        {
            //instantiate each of our views
            //   var image = new Image();
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();

            Label left = new Label();
            Label right = new Label();
            Label dtlanc = new Label();
            Label vllanc = new Label();
            Image img = new Image();

            //set bindings
            left.SetBinding(Label.TextProperty, "nm_cartao");
            right.SetBinding(Label.TextProperty, "nm_obs");

            dtlanc.SetBinding(Label.TextProperty, "dt_pgto");
            vllanc.SetBinding(Label.TextProperty, "vl_pgto");
   




            /// image.SetBinding(Image.SourceProperty,
            //new Binding("URLimagem", BindingMode.OneWay, new StringToImageConverter()));



            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Vertical;
            right.HorizontalOptions = LayoutOptions.EndAndExpand;

            dtlanc.HorizontalOptions = LayoutOptions.End;
            vllanc.HorizontalOptions = LayoutOptions.End;






            left.TextColor = Color.FromHex("#f35e20");
            right.TextColor = Color.FromHex("503026");

            //add views to the view hierarchy
            // horizontalLayout.Children.Add(image);
            horizontalLayout.Children.Add(left);
            horizontalLayout.Children.Add(right);

            horizontalLayout.Children.Add(dtlanc);
            horizontalLayout.Children.Add(vllanc);




            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }

}
