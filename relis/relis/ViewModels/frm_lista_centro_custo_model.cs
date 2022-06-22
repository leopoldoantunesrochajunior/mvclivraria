using relis.Models;
using relis.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


using System.ComponentModel;

using Xamarin.Forms.Xaml;



namespace relis.ViewModels
{
    public class frm_lista_centro_custo_model : BaseCentroCustoModel
    {
        private tb_livro _selectedItem;
        private tb_livro registro;
        private tb_livro registroselecionado;



             
        
       
       public ObservableCollection<tb_livro> Registros { get; }





        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<tb_livro> ItemTapped { get; }

        public frm_lista_centro_custo_model()
        {
           // Application.Current.MainPage.DisplayAlert("Construtor custo model", "construtor custo model", "OK");
            TituloCentroCusto = "Listagem CC";
            IdTituloCentroCusto = 99;
            Registros = new ObservableCollection<tb_livro>();
            //Application.Current.MainPage.DisplayAlert("Antes load Construtor custo model", "antes load construtor custo model", "OK");
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<tb_livro>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            ErroOperacao = true;
            ErroOperacao eolocal = new ErroOperacao();
          
            eolocal.RetErroDescricao = "tablocal";

            try
            {
                eolocal = await ConexaoSgbd.DbSetSgbdTeste();
            
            }

            catch (Exception ex)
            {
                eolocal.RetErroDescricao = ex.Message;

            }
            

            ErroOperacao eoquery = new ErroOperacao();
            eoquery.RetErroDescricao = "tabquery";

            try
            {
                eoquery = await ConexaoSgbd.DbSetSgbdReader();

            }

            catch (Exception ex)
            {
                eoquery.RetErroDescricao = ex.Message;

            }

            await Application.Current.MainPage.DisplayAlert("SGBD Query", eoquery.RetErroDescricao, "OK");

            ErroOperacao = true;
            try
            {
                Registros.Clear();
                               

                while (eoquery.RetmySqlDatareader.Read())
                {

                    Registros.Add(new tb_livro
                    {
                        nm_nome = eoquery.RetmySqlDatareader.GetString("nm_nome"),
                        nm_autor  = "Fixo",
                        nm_isbn = "Fixo"


                    });

                    

                }

                await Task.Delay(10);


                //   var registros = await DataCentroCusto.GetListagemCentroCusto(true);
                // foreach (var registro in registros)
                //  {
                //     Registros.Add(registro);
                // }


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Carregamento conteudo try SGBD", ex.Message, "OK");
            }
            finally
            {
                ErroOperacao = false;
            }
        }

        public void OnAppearing()
        {
            ErroOperacao = true;
            SelectedItem = null;
        }

        tb_livro bancoescolhido = null;
        public tb_livro BancoEscolhido
        {

            get { return bancoescolhido; }

            set { bancoescolhido = value; }


        }












        public tb_livro SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public tb_livro Registro
        {
            get => registro;
            set
            {
                SetProperty(ref registro, value);
                OnItemSelected(value);
            }
        }

        public tb_livro RegistroSelecionado
        {
            get => registroselecionado;
            set
            {
                SetProperty(ref registroselecionado, value);
                
            }
        }

        private async void OnAddItem(object obj)
        {
          //  await Application.Current.MainPage.DisplayAlert("Novo Item", "Novo item", "OK");
            await Shell.Current.GoToAsync(nameof(frm_lista_centro_custo_item_novo));
        }

        async void OnItemSelected(tb_livro registro)
        {

            //início

            this.bancoescolhido = new tb_livro();

            ErroOperacao eoquery = new ErroOperacao();
            
            eoquery = await ConexaoSgbd.DbSetSgbdReader();
            eoquery.RetmySqlDatareader.Read();

            this.BancoEscolhido.nm_nome = eoquery.RetmySqlDatareader.GetString("nm_nome");
            this.BancoEscolhido.nm_autor = eoquery.RetmySqlDatareader.GetString("nm_autor");
                    
            await Task.Delay(10);
            
            //fim
            


            if (registro == null)
                return;

         //   await Application.Current.MainPage.DisplayAlert("Clique esc OnItemSelected", this.BancoEscolhido.Resumido, "OK");
           // await Application.Current.MainPage.DisplayAlert("Clique esc OnItemSelected", this.BancoEscolhido.Nome, "OK");

           // await Shell.Current.Navigation.PushAsync(new frm_lista_centro_custo_item(this.));

            // await Shell.Current.GoToAsync($"{nameof(frm_lista_centro_custo_item)}?{nameof(frm_lista_centro_custo_item_model.Nome)}={registro.Nome}");
        }
    }
}