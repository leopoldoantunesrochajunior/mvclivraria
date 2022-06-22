using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;


using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;

using relis.ViewModels;
using relis.Models;

namespace relis.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class frm_sub_detalhe_oco : ContentPage
    {


       
        IndiceCartaoCredito cartaoescolhido  = null;
        tb_livro lancamentoescolhido = null;
        public FuncoesOperacoes fo = new FuncoesOperacoes();


        string vltotaloco = "0";
        Double vltotalgrade = 0.00;


        public double ValorTotalGrade
        {
            get
            {
                return vltotalgrade;
            }
            set
            {
                vltotalgrade = value;
            }

        }

        public string ValorTotalTela
        {
            get
            {
                return vltotaloco;
            }
            set {
                vltotaloco = value;
            }

        }


        public tb_livro LancamentoEscolhido
        {

            get { return lancamentoescolhido; }

            set { lancamentoescolhido = value; }


        }





        public IndiceCartaoCredito CartaoEscolhido
        {

            get { return cartaoescolhido; }

            set { cartaoescolhido = value; }


        }

        public List<tb_livro> ListaOcorrenciaPorLanc;
        ClasseLancamento oCl = new ClasseLancamento();

                






        public frm_sub_detalhe_oco(tb_livro lancescolhido)
        {
            InitializeComponent();

           this.LancamentoEscolhido = lancescolhido;

           
            chamaBloco();

            this.ValorTotalTela = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", this.ValorTotalGrade);


               

            BindingContext = this;







        }

        async void chamaBloco()
        {
           // await DisplayAlert("Dentro da listagem interna lancamento", this.LancamentoEscolhido.nm_lanc, "ok");
           // await DisplayAlert("Dentro da listagem interna lancamento", this.LancamentoEscolhido.nm_banco, "ok");
            await configura();
        }

        async Task configura()
        {
               

            stl_emb.Children.Add(
                new Label
                {
                    Text = "Ocorrências por Lançamento",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start
                });


            var listView = new ListView { HasUnevenRows = true };

            var template = new DataTemplate(typeof(CelulaListViewOcorrencia));

           
          //  listView.ItemsSource = OcorrenciasPorLanc;
            listView.ItemTemplate = template;
          


             var ctt = new StackLayout
             {
                 Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    new Label {
                       Text = "",
                       FontAttributes = FontAttributes.Bold,
                       HorizontalOptions = LayoutOptions.Center
                   },
                   listView
               }
              };

            stl_emb.Children.Add(ctt);

           

           

        }




    }
}