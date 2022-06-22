using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




using System.Runtime.CompilerServices;

using relis.Models;

using System.Threading;
using System.Threading.Tasks;
using relis;
using System.Linq;

using System.Diagnostics;

namespace relis.Views
{
    
    [DesignTimeVisible(false)]
    public partial class frm_tela_livro : ContentPage
    {
        ClasseLancamento oCl = new ClasseLancamento();
        public FuncoesOperacoes fo = new FuncoesOperacoes();


        public Entry txt_nm_isbn = new Entry();
        public Entry txt_nm_autor = new Entry();
        public Entry txt_nm_nome = new Entry();
        public Entry txt_vl_preco = new Entry();
        public Entry txt_dt_publicacao = new Entry();

        Label lblsalvar = new Label();
        Label lblalterar = new Label();
        Label lblexcluir = new Label();

        public Int32 IdLivro { get; set; }



        public Item Item { get; set; }

        public bool Andamento { get; set; }


        Boolean boutdoor;
        Boolean bExito = false;

        public Boolean Outdoor
        {
            get
            {
                return boutdoor;
            }
            set
            {
                boutdoor = value;
            }
        }

        public Boolean Exito
        {
            get
            {
                return bExito;
            }
            set
            {
                bExito = value;
            }
        }






        public int nNu_Banco_Selecionado = 0;
        public string cNm_Banco_Selecionado = "";

      

       // public List<tb_livro> ListaBanco;



        public frm_tela_livro(Int32 idlivro)
        {

            try
            {
                this.IdLivro = idlivro;

                ClasseUserControl ccu = new ClasseUserControl();
                ClasseCalendario cca = new ClasseCalendario();

                this.IdLivro = idlivro;

                Application.Current.MainPage.DisplayAlert("Livro Selecionado", "initialize component", "ok");

                InitializeComponent();


                BindingContext = this;


                txt_nm_isbn = ccu.pTrixEntry(150, "ISBN", "ISBN", rlt_container_relative_man);
                txt_nm_autor = ccu.pTrixEntry(250, "Autor", "Autor", rlt_container_relative_man);
                txt_nm_nome = ccu.pTrixEntry(350, "Nome", "Nome", rlt_container_relative_man);
                txt_vl_preco = ccu.pTrixEntry(450, "Preço", "Preço", rlt_container_relative_man);
                txt_dt_publicacao = ccu.pTrixEntry(550, "Dt.Publicação", "Dt. Publicação", rlt_container_relative_man);


                lblsalvar = ccu.pTrixBotao(620, 5, "Salvar", rlt_container_relative_man);
                lblalterar = ccu.pTrixBotao(620, 125, "Alterar", rlt_container_relative_man);
                lblexcluir = ccu.pTrixBotao(620, 250, "Excluir", rlt_container_relative_man);

 

                Application.Current.MainPage.DisplayAlert("Livro Selecionado", "antes maior", "ok");
                if (this.IdLivro > 0)
                {
                    Application.Current.MainPage.DisplayAlert("Livro Selecionado", "antes dados", "ok");
                    DadosLivro(this.IdLivro);
                }



                var tgr = new TapGestureRecognizer();
                tgr.Tapped += cmd_gravar_Clicked;
                lblsalvar.GestureRecognizers.Add(tgr);


                var tgralterar = new TapGestureRecognizer();
                tgralterar.Tapped += cmd_alterar_Clicked;
                lblalterar.GestureRecognizers.Add(tgralterar);


                txt_vl_preco.TextChanged += monetarioChanged;
                txt_dt_publicacao.TextChanged += maskedChanged;












            } catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Construtor frm_tela_livro", ex.Message,"ok");
            }



        }

        async void DadosLivro(Int32 idlivro)
        {

            try
            {
                await Application.Current.MainPage.DisplayAlert("Livro Selecionado", "antes obtem dados livro", "ok");
                var reader = oCl.ObtemDadosLivro(idlivro);


                reader.Read();

                this.Andamento = true;

                this.IdLivro = reader.GetInt32("id_livro");
                this.txt_nm_isbn.Text = reader.GetString("nm_isbn");
                this.txt_nm_autor.Text = reader.GetString("nm_autor");
                this.txt_nm_nome.Text = reader.GetString("nm_nome");
                this.txt_vl_preco.Text = reader.GetDecimal("vl_preco").ToString();
                this.txt_dt_publicacao.Text =reader.GetDateTime("dt_publicacao").ToString().Substring(0,10);

                this.Andamento = false;

                await Application.Current.MainPage.DisplayAlert("Livro Selecionado", "depois preenchimento", "ok");

            } catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Dados do Livro", ex.Message, "ok");
            }
           
            

        }

          












        

        async void LimpaDados()
        {


            String cDt_Atual = DateTime.Today.ToString().Substring(0, 10);

           this.txt_vl_preco.Text = "0";
            await Task.Delay(10);

        }

        async Task conglomerado(ContentPage paginaatual, tb_livro dadosregistro)
        {


            ClasseLancamento cl = new ClasseLancamento();

            this.Exito = cl.IncluirLivro(dadosregistro);

            if (this.Exito == true)
            {
                LimpaDados();
            }

            await Task.Delay(10);



        }

        async Task conglomeradoalterar(ContentPage paginaatual, tb_livro dadosregistro)
        {


            ClasseLancamento cl = new ClasseLancamento();

            this.Exito = cl.AlterarLivro(this.IdLivro, dadosregistro);

            await DisplayAlert("Dados Alterados", "Alterar Livro", "OK");
            if (this.Exito == true)
            {
                await DisplayAlert("Dados Alterados", "Dados Alterados", "OK");
            }

            await Task.Delay(10);



        }

        async void SelecionaCampo(object sender, EventArgs e)
        {

            fo.S_EDICAO_SelecionaTexto(sender);

            await Task.Delay(10);


        }

        String zeroEsquerda(String dado)
        {
            String str = dado;
            String str2 = "";


            bool bnum = false;

            for (int x = 0; x < str.Length; x++)
            {

                string carac = str.Substring(x, 1);

                if (carac != "0")
                {
                    bnum = true;

                }

                if (bnum == true)
                {

                    str2 = str2 + str.Substring(x, 1);

                }

            }

            str = str2;
            return str;
        }


        async void monetarioChanged(object sender, TextChangedEventArgs e)
        {

            string strinteiro;
            string strdecimal;
            string str = "";


            Entry txt = (Entry)sender;

            //await DisplayAlert("Antes Posterior", txt.Text, "OK");

            await Task.Delay(10);

            str = txt.Text.Replace(",", "");
            await Task.Delay(10);
            //  await DisplayAlert("Antes Zero esquerda", txt.Text, "OK");
            str = zeroEsquerda(str);
            //  await DisplayAlert("Depois Zero esquerda", txt.Text, "OK");


            if (str.Length > 0)
            {


                if (str.Length > 2)
                {



                }
                else
                {
                    str = "00" + str;
                    int ini = str.Length - 3;

                    str = str.Substring(ini, 3);
                }

                strinteiro = str.Substring(0, str.Length - 2);
                strdecimal = str.Substring(str.Length - 2, 2);

                str = strinteiro + "," + strdecimal;



                await Task.Delay(10);

                txt.Text = str;




            }
        }


        async void maskedChanged(object sender, TextChangedEventArgs e)
        {


            await Task.Delay(10);

            fo.editMask(sender, "99/99/9999");
            await Task.Delay(10);

        }

        async Task ExibeAnimaniacs(Boolean exibe)
        {
            await Task.Delay(50);

            this.Outdoor = exibe;

            // sta_quadro_animacao.IsVisible = exibe;

            //  act_processamento.IsVisible = exibe;
            // act_processamento.IsRunning = exibe;

            await Task.Delay(50);
        }

            async void cmd_gravar_Clicked(object sender, EventArgs e)
            {
                tb_livro dadosregistro = new tb_livro();
                         

                string txtnmisbn = txt_nm_isbn.Text.ToString();
                string txtnmautor = txt_nm_autor.Text.ToString();
                string txtnmnome = txt_nm_nome.Text.ToString();
                string txtvlpreco = txt_vl_preco.Text.ToString();
                string txtdtpublicacao = txt_dt_publicacao.Text.ToString();



            dadosregistro.nm_isbn = fo.S_MYSQL_RemoveReservado(txtnmisbn, false);
            dadosregistro.nm_autor = fo.S_MYSQL_RemoveReservado(txtnmautor, false);
            dadosregistro.nm_nome = fo.S_MYSQL_RemoveReservado(txtnmnome, false);
            dadosregistro.vl_preco = fo.S_MYSQL_numNulo(fo.S_MYSQL_InterpretaMonetario(txtvlpreco));
            dadosregistro.dt_publicacao = Convert.ToDateTime(fo.S_MYSQL_dataFormat(txtdtpublicacao));
         
               
                await ExibeAnimaniacs(true);

                await conglomerado(this, dadosregistro);

                await ExibeAnimaniacs(false);




            }

        async void cmd_alterar_Clicked(object sender, EventArgs e)
        {
            tb_livro dadosregistro = new tb_livro();

            await DisplayAlert("Dados Alterados", "início alterar", "OK");

            string txtnmisbn = txt_nm_isbn.Text.ToString();
            string txtnmautor = txt_nm_autor.Text.ToString();
            string txtnmnome = txt_nm_nome.Text.ToString();
            string txtvlpreco = txt_vl_preco.Text.ToString();
            string txtdtpublicacao = txt_dt_publicacao.Text.ToString();



            dadosregistro.nm_isbn = fo.S_MYSQL_RemoveReservado(txtnmisbn, false);
            dadosregistro.nm_autor = fo.S_MYSQL_RemoveReservado(txtnmautor, false);
            dadosregistro.nm_nome = fo.S_MYSQL_RemoveReservado(txtnmnome, false);
            dadosregistro.vl_preco = fo.S_MYSQL_numNulo(fo.S_MYSQL_InterpretaMonetario(txtvlpreco));
            dadosregistro.dt_publicacao = Convert.ToDateTime(fo.S_MYSQL_dataFormat(txtdtpublicacao));


            await ExibeAnimaniacs(true);

            await conglomeradoalterar(this, dadosregistro);

            await ExibeAnimaniacs(false);




        }















        async void Cancel_Clicked(object sender, EventArgs e)
            {
                await Navigation.PopModalAsync();
            
                
            }



            static async Task movimentaData(ContentPage paginaatual, Boolean Frente, Entry ObjetoData)
            {

                string t = ObjetoData.Text.ToString();
                DateTime trab = new DateTime(Convert.ToInt16(t.Substring(6, 4)), Convert.ToInt16(t.Substring(3, 2)), Convert.ToInt16(t.Substring(0, 2)));

                if (Frente == true)
                {
                    trab = trab.AddDays(1);
                }
                else
                {
                    trab = trab.AddDays(-1);
                }

                String cAtual = trab.ToString().Substring(0, 10);
                ObjetoData.Text = cAtual;

                await Task.Delay(50);


            }



        }


    
}