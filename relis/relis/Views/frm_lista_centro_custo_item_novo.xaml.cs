using relis.Models;
using relis.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace relis.Views
{
    public partial class frm_lista_centro_custo_item_novo : ContentPage
    {
        public tb_livro Item { get; set; }

        public frm_lista_centro_custo_item_novo()
        {
            InitializeComponent();
            Application.Current.MainPage.DisplayAlert("Antes da aplicação do novo item", "Antes da aplicação do novo item", "OK");

            BindingContext = new frm_lista_centro_custo_item_novo_model();
        }
    }
}