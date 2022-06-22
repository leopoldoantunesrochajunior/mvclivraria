
using System.Diagnostics;



using System.Collections.ObjectModel;

using relis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace relis.ViewModels
{
    //[QueryProperty(nameof(NomeId), nameof(NomeId))]
    [QueryProperty(nameof(Nome), nameof(Nome))]
    public class frm_lista_centro_custo_item_model : BaseCentroCustoModel
    {
        private string nomeId;
        private string nome;
        private string resumido;
        private tb_livro registroselecionado;


       



        public string Nome
        {
            get => nome;
            set {
                SetProperty(ref nome, value);
                Application.Current.MainPage.DisplayAlert("property Nome Query", value, "OK");
                LoadItemId(value);
            }
        }

        public string Resumido
        {
            get => resumido;
            set
            {
                SetProperty(ref resumido, value);
                Application.Current.MainPage.DisplayAlert("parameter resumido", value, "OK");
                
            }
        }

        public tb_livro RegistroSelecionado
        {
            get => registroselecionado;
            set
            {
                SetProperty(ref registroselecionado, value);
                Application.Current.MainPage.DisplayAlert("property registro selecionado", value.nm_nome +"", "OK");
                
            }
        }








        public string NomeId
        {
            get
            {
                return nomeId;
            }
            set
            {
                nomeId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string nomeId)
        {
            try
            {
                //var registro = await DataCentroCusto.GetCentroCusto(nomeId);

               // await Application.Current.MainPage.DisplayAlert("ANTES da fo first item_model", nomeId, "OK");

                //var registro = registros.FirstOrDefault(s => s.Nome == nomeId);

                

                await Application.Current.MainPage.DisplayAlert("LoadItemId nome", this.RegistroSelecionado.nm_nome, "OK");
                await Application.Current.MainPage.DisplayAlert("LoadItemId resumido", this.RegistroSelecionado.nm_autor, "OK");

                Nome  = this.RegistroSelecionado.nm_nome;
                Resumido = this.RegistroSelecionado.nm_autor;
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
