using relis.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace relis.ViewModels
{
    public class frm_lista_centro_custo_item_novo_model : BaseCentroCustoModel 
    {

        private string nome;
        private string resumido;

        public frm_lista_centro_custo_item_novo_model()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nome)
                && !String.IsNullOrWhiteSpace(resumido);
        }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string Resumido
        {
            get => resumido;
            set => SetProperty(ref resumido, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            tb_livro newItem = new tb_livro()
            {
                nm_nome = Nome,
                nm_autor = Resumido
            };

            await DataCentroCusto.AddCentroCusto(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
