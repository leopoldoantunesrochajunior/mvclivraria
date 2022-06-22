using relis.ViewModels;
using relis.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace relis
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

       
        public AppShell()
        {
            InitializeComponent();
           
            //Routing.RegisterRoute(nameof(frm_lista_livro), typeof(frm_lista_livro));
            

          


        }

        


//protected override bool OnBackButtonPressed()  {
//
  //         
    //    }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
            

        }

    }
}
