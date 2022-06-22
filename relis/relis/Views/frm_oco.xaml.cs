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
    public partial class frm_oco : ContentPage
    {


       
        IndiceCartaoCredito cartaoescolhido  = null;
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

        public IndiceCartaoCredito CartaoEscolhido
        {

            get { return cartaoescolhido; }

            set { cartaoescolhido = value; }


        }
        public List<tb_livro> ListaOcorrencia;
        ClasseLancamento oCl = new ClasseLancamento();


        public List<tb_livro> Ocorrencias
        {
            get
            {
                try
                {
                    ListaOcorrencia = new List<tb_livro>();
                    var reader = oCl.ObtemRelacaoLivro();

                    this.ValorTotalGrade = 0.00;

                    while (reader.Read())
                    {
                        ListaOcorrencia.Add(new tb_livro
                        {
                            nm_isbn = reader.GetString("nm_isbn"),
                            nm_nome = reader.GetString("nm_nome"),
                            nm_autor = reader.GetString("nm_autor"),
                            vl_preco = reader.GetDecimal("vl_preco")



                        });

                        this.ValorTotalGrade += Convert.ToDouble(reader.GetDecimal("vl_lanc"));

                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro Tela", ex.Message, "OK");
                }



                return ListaOcorrencia;
            }
        }


     

        public frm_oco(IndiceCartaoCredito bancochave)
        {
            InitializeComponent();

          
            this.CartaoEscolhido = bancochave;

            chamaBloco();

            this.ValorTotalTela = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", this.ValorTotalGrade);




               

            BindingContext = this;







        }

        async void chamaBloco()
        {
            await configura();
        }

        async Task configura()
        {
               

            stl_emb.Children.Add(
                new Label
                {
                    Text = "Descritivos Ocorrências",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start
                });


            var listView = new ListView { HasUnevenRows = true };

            var template = new DataTemplate(typeof(CelulaListViewOcorrencia));

           
            listView.ItemsSource = Ocorrencias;
            listView.ItemTemplate = template;
            listView.ItemSelected += LancamentoSelecionado;



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

        private async void LancamentoSelecionado(object sender, SelectedItemChangedEventArgs e)
        {
            tb_livro lancamentoselecionado;
           
            lancamentoselecionado = (tb_livro)e.SelectedItem;

         //   await DisplayAlert("Clique Sub Lançamento Lanc", lancamentoselecionado.nm_lanc, "ok");
           // await DisplayAlert("Clique Sub Lançamento Banco", lancamentoselecionado.nm_banco, "ok");

          //  await Navigation.PushAsync(new frm_sub_detalhe_oco(lancamentoselecionado));



        }


    }





}