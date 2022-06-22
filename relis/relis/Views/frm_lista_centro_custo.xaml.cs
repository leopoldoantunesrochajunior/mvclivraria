using relis.Models;
using relis.ViewModels;
using relis.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace relis.Views
{
    public partial class frm_lista_centro_custo : ContentPage
    {
        frm_lista_centro_custo_model _viewModel;

        public frm_lista_centro_custo()
        {
            InitializeComponent();

            BindingContext = _viewModel = new frm_lista_centro_custo_model();

            //Application.Current.MainPage.DisplayAlert("frm_lista_centro_custo.xaml.cs", "frm_lista_centro_custo.xaml.cs", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}