using relis.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;


using relis.Models;

using System;


using Xamarin.Forms.Xaml;


namespace relis.Views
{
    public partial class frm_lista_centro_custo_item : ContentPage
    {
        tb_livro bancoescolhido = null;

        ClasseLancamento oCl = new ClasseLancamento();
        public FuncoesOperacoes fo = new FuncoesOperacoes();


        public Label lbl_nm_nome = new Label();
        public Label lbl_nm_resumido = new Label();
        
        public tb_livro BancoEscolhido
        {

            get { return bancoescolhido; }

            set { bancoescolhido = value; }


        }
        public frm_lista_centro_custo_item(tb_livro dadoselecionado)
        {
            ClasseUserControl ccu = new ClasseUserControl();
            ClasseCalendario cca = new ClasseCalendario();

            InitializeComponent();
            
             
            this.BancoEscolhido = dadoselecionado;

            //Application.Current.MainPage.DisplayAlert("frm_lista_centro_custo_item", this.BancoEscolhido.Resumido, "OK");
            //Application.Current.MainPage.DisplayAlert("frm_lista_centro_custo_item", this.BancoEscolhido.Nome, "OK");

            BindingContext = new frm_lista_centro_custo_item_model();

            lbl_nm_nome= ccu.pTrixLabel(200, "Nome", "-", rlt_container_relative_man);
            lbl_nm_resumido= ccu.pTrixLabel(350, "Resumido" ,"-", rlt_container_relative_man);

            Label lblatualiza = ccu.pTrixBotao(610, 80, "Voltar", rlt_container_relative_man);
            Label lblretorno = ccu.pTrixBotao(610, 230, "Despesa", rlt_container_relative_man);

            var tgr2 = new TapGestureRecognizer();
            tgr2.Tapped += OnRefreshTapped;
            lblatualiza.GestureRecognizers.Add(tgr2);

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += OnClicaTapped;
            lblretorno.GestureRecognizers.Add(tgr);


            chama();
         //   Application.Current.MainPage.DisplayAlert("Construtor centro custo item", "Constrtutor centro custo item", "OK");
        }

        async void OnClicaTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new frm_tela_livro(0));
        }



        async void OnRefreshTapped(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();


        }

        public void chama()
        {
            lbl_nm_nome.Text = this.BancoEscolhido.nm_nome;
            lbl_nm_resumido.Text = this.BancoEscolhido.nm_autor;
        }
    }
}