using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


using System.Collections.ObjectModel;

using relis.Models;


namespace relis.Views
{
   
    
    [DesignTimeVisible(false)]
    public partial class frm_lista_livro : ContentPage
    {


        public frm_lista_livro()
        {
            
            //Application.Current.MainPage.DisplayAlert("Sobre", "Seção de abertura de frm_lista_cartao.", "OK");

            ClasseUserControl ccu = new ClasseUserControl();
            ClasseCalendario cca = new ClasseCalendario();

            InitializeComponent();


            

            chama();


            Label lblatualiza = ccu.pTrixBotao(620, 80, "  Atualiza", rlt_container_relative_man);
            Label lblretorno = ccu.pTrixBotao(620, 230, "  Novo", rlt_container_relative_man);


            var tgr2 = new TapGestureRecognizer();
            tgr2.Tapped += OnRefreshTapped;
            lblatualiza.GestureRecognizers.Add(tgr2);



            var tgr = new TapGestureRecognizer();
            tgr.Tapped += OnClicaTapped;
            lblretorno.GestureRecognizers.Add(tgr);


            BindingContext = this;

            Task.Delay(50);

            chama();

            


        }


        async void OnClicaTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new frm_tela_livro(0));
        }

        async void OnRefreshTapped(object sender, EventArgs args)
        {
            chama();

            
        }








        void chama()
        {
            
                sumarizaImagensMobile();
             
        }



        async Task sumarizaImagensMobile()
        {

            ClasseLancamento oCl = new ClasseLancamento();

            ObservableCollection<tb_livro> ListaLivro = new ObservableCollection<tb_livro>();


         
            var listalivro = new ObservableCollection<tb_livro>();
          



            var reader = oCl.ObtemRelacaoLivro();

           // this.QtdItensLocal = 0.00;
            while (reader.Read())
            {
                
                ListaLivro.Add(new tb_livro
                {
                    id_livro = reader.GetInt32("id_livro"),
                    nm_isbn = reader.GetString("nm_isbn"),
                    nm_autor = reader.GetString("nm_autor"),
                    nm_nome = reader.GetString("nm_nome"),
                    vl_preco = reader.GetDecimal("vl_preco"),
                    dt_publicacao = reader.GetDateTime("dt_publicacao"),
                 });

              //  this.QtdItensLocal = this.QtdItensLocal + 1;

            }

            await Task.Delay(30);
            //await DisplayAlert("Depois do Loop", this.QtdItensLocal.ToString(), "ok");
            //await Task.Delay(200);

           // this.DadoQtdTela = this.QtdItensLocal.ToString();

            //lbl_vl_total.Text = this.DadoQtdTela;

            
            ClasseDownload cd = new ClasseDownload();
         
            await Task.Delay(500);

            
            lst.ItemsSource =  ListaLivro;
            lst.ItemSelected += LivroSelecionado;


        }

        private async void LivroSelecionado(object sender, SelectedItemChangedEventArgs e)
        {

            await Application.Current.MainPage.DisplayAlert("Livro Selecionado", "Antes", "ok");
            try
            {
                tb_livro objetoselecionado;
                Image imgs = new Image();


                objetoselecionado = (tb_livro)e.SelectedItem;

                await Application.Current.MainPage.DisplayAlert("Livro Selecionado", "Antes push", "ok");

                //await Navigation.PushAsync(new frm_tela_livro(objetoselecionado.id_livro));
                await Navigation.PushAsync(new frm_tela_livro(3));

            } catch (Exception ex) {
                await Application.Current.MainPage.DisplayAlert("Livro Selecionado", ex.Message, "ok");
            }

   



        }


    }
}


///
//     string s = "http://www.microlix.com.br/img_meuacesso.jpg";
///    ClasseDownload cd = new ClasseDownload();
//   Stream stream4 = new MemoryStream(await cd.downloadImagem(s));
//  imgs.Source = ImageSource.FromStream(() => { return stream4; });


// await DisplayAlert("Clique Banco Selecionado", objetoselecionado.Nome,"OK");




///Image imagetemp = new Image();
//Stream stream1 = new MemoryStream(await cd.downloadImagem("http://www.microlix.com.br/leao.png"));
// imagetemp.Source = ImageSource.FromStream(() => { return stream1; });



//  listaCartao.Add(new IndiceCartaoCredito { Url = "http://www.microlix.com.br/img_bb.jpg", Nome = "Banco do Brasil", Apelido = "Banco do Brasil" });
// listaCartao.Add(new IndiceCartaoCredito { Url = "http://www.microlix.com.br/img_santander.jpg", Nome = "Santander", Apelido = "Santander" });
// listaCartao.Add(new IndiceCartaoCredito { Url = "http://www.microlix.com.br/img_bv.jpg", Nome = "B V", Apelido = "B V" });
// listaCartao.Add(new IndiceCartaoCredito { Url = "http://www.microlix.com.br/img_meuacesso.jpg", Nome = "Meu Acesso", Apelido = "Meu Acesso" });









