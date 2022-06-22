using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using relis.Models;

namespace relis.Views
{
    public partial class frm_menu : ContentPage
    {
        Label lbl_1 = new Label();
        Label lbl_2 = new Label();
        Label lbl_3 = new Label();
        Label lbl_4 = new Label();

        public frm_menu()
        {
            InitializeComponent();

            configura();

            BindingContext = this;



            

        }

        async void OnClicaTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new frm_lista_livro());
        }



        async void OnRefreshTapped(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new frm_lista_livrocartao());

           
        }


        public void configura()
        {


            ClasseUserControl ccu = new ClasseUserControl();
            ClasseCalendario cca = new ClasseCalendario();

            int x = 0;

            lbl_1 = ccu.pTrixLabel(150, "Analista Programador", "Leopoldo A. da Rocha Júnior", rlt_container_relative_man);
            lbl_2 = ccu.pTrixLabel(250, "PJ", "Microlix-PJ", rlt_container_relative_man);
            lbl_3 = ccu.pTrixLabel(350, "Estado", "Rio de Janeiro", rlt_container_relative_man);
            lbl_4 = ccu.pTrixLabel(450, "Contato", "(24) 998289357", rlt_container_relative_man);

            Label lblatualiza = ccu.pTrixBotao(610, 80, "Ok", rlt_container_relative_man);
            Label lblretorno = ccu.pTrixBotao(610, 230, "Livros", rlt_container_relative_man);

            var tgr2 = new TapGestureRecognizer();
            tgr2.Tapped += OnRefreshTapped;
            lblatualiza.GestureRecognizers.Add(tgr2);

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += OnClicaTapped;
            lblretorno.GestureRecognizers.Add(tgr);

        }
    }
}