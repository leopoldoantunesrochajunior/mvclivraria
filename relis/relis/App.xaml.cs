using relis.Services;
using relis.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace relis
{
    public partial class App : Application
    {
        public ContentPage On_frm_menu;
        public ContentPage On_frm_lista_cartao;
        public ContentPage On_frm_pgto_corrente;

        

      

       
       
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockConexaoSgbd>();

            MainPage = new AppShell();
           
            
                       
        }

        void OnModalPushed(object sender, ModalPushedEventArgs e)
        {
        //    App.Current.MainPage.DisplayAlert("A","Página abrindo",  "OK");
            // ModalPages.Push(e.Modal);
            // PageService.CurrentPage = FindCurrentPage();
        }

        void OnModalPopped(object sender, ModalPoppedEventArgs e)
        {
        //    App.Current.MainPage.DisplayAlert("A", "Página em situação", "OK");
            //ModalPages.Pop();
            // PageService.CurrentPage = FindCurrentPage();

            
        }

        protected override void OnStart()
        {
            //            App.Current.MainPage.DisplayAlert("App aberto", "A", "OK");

          

         

        }

        async void PageAppearing()
        {
          //  await App.Current.MainPage.DisplayAlert("Pagina aberta", "A", "OK");
        }

        async void PageDisappearing()
        {
         //   await App.Current.MainPage.DisplayAlert("Pagina fechada", "A", "OK");
        }

        protected override void OnSleep()
        {
            //App.Current.MainPage.DisplayAlert("segundo plano", "A", "OK");
            
        }

        protected override void OnResume()
        {
          //  App.Current.MainPage.DisplayAlert("Retorno", "A", "OK");
            FindCurrentPage();
            
        }


        public Page FindCurrentPage()
        {

            

            Page currentPage;
            int index = Application.Current.MainPage.Navigation.NavigationStack.Count - 1;
            
            
            if (index >= 1)
            {
                currentPage = Application.Current.MainPage.Navigation.NavigationStack[index];
                App.Current.MainPage.DisplayAlert("A", index.ToString() + "páginas", "OK");

            } else
            {
                currentPage = Application.Current.MainPage;
                App.Current.MainPage.DisplayAlert("A", "Apenas uma página", "OK");

            }

            return currentPage;
            
            
        }
    }
}
