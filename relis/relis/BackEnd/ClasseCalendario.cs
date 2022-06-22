using System;
using System.Collections.Generic;
using System.Text;


using MySqlConnector;
using MySql.Data.MySqlClient;
//using Plugin.DeviceInfo;

using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace relis.Models
{
    class ClasseCalendario
    {

        public VinculoRotuloObjeto vro;
        ObservableCollection<VinculoRotuloObjeto> mapeamentolotes = new ObservableCollection<VinculoRotuloObjeto>();

        public ObservableCollection<VinculoRotuloObjeto> MapeamentoLotes
        {
            get
            {
                return mapeamentolotes;
            }
            set
            {
                mapeamentolotes = value;
            }

        }

      


      


        public Label LoteDia(Int32 nTopo,Int32 nLeft ,string Titulo, RelativeLayout containerpai)
        {
            Int32 nY = nTopo;


            /*

                Default 16  14
                Micro   11  10
                Small   13  14
                Medium  16  17 
            */


            Image imgcaixa = new Image();
            StackLayout containertitulo = new StackLayout();


            imgcaixa.Margin = 10;
            imgcaixa.Source = "img_fundo_dia";
            imgcaixa.Aspect = Aspect.AspectFit;
            imgcaixa.HorizontalOptions = LayoutOptions.Center;
            imgcaixa.VerticalOptions = LayoutOptions.Start;

         

            Label lbltitulo = new Label();
            lbltitulo.Text = " " + Titulo;
            lbltitulo.FontSize = 16;
            lbltitulo.HorizontalOptions = LayoutOptions.Start;
            lbltitulo.VerticalOptions = LayoutOptions.Start;
            lbltitulo.TextColor = Color.Black;


            containertitulo.Children.Add(lbltitulo);


            //x(0), e y(0)

            containerpai.Children.Add(imgcaixa, Constraint.Constant(nLeft), Constraint.Constant(nTopo));
            containerpai.Children.Add(containertitulo, Constraint.Constant(nLeft+20), Constraint.Constant(nTopo + 26));
            //containerpai.Children.Add(containerconteudo, Constraint.Constant(0), Constraint.Constant(0));


            nY = nTopo + 30 + 10;

            return lbltitulo;
        }


        public void Loteamento(int nTopIni,int nLeftIni, RelativeLayout containerpai,ObservableCollection<Label> lblColecaoDias)
        {
            int posx = nLeftIni;
            int posy = nTopIni;
            int percorrex = 1;
            int percorrey = 1;
 
            for (int x = 1; x < 43; x++)
            {

                //Coluna e Linha

               var lotetemp = this.LoteDia(posy, posx , "0", containerpai);

                vro = new VinculoRotuloObjeto();
                vro.NomeRotulo = "poscal_" + percorrex.ToString() + "_" + percorrey.ToString() + "_" + x.ToString();
                vro.LabelRecipLot = lotetemp;


                this.MapeamentoLotes.Add(vro);
            

                if (percorrex == 7)
                {
                    percorrex = 1;
                    posx = nLeftIni;
                    posy += 45;

                    percorrey = percorrey + 1;

                }
                else
                {
                    posx += 45;
                    percorrex += 1;
                }


            }
        }

        public String ObtemNomeRotulo(int posabsoluta)
        {


            string retornonome = "";
            char separador = Convert.ToChar(@"_");


            foreach (VinculoRotuloObjeto rotulopercorre in this.MapeamentoLotes)
            {
                string nomeciclo = rotulopercorre.NomeRotulo.ToLower().ToString();

                if (nomeciclo.IndexOf("poscal") > -1)
                {
                    string nomename = nomeciclo.Split(separador)[0];
                    string nomeposicaox = nomeciclo.Split(separador)[1];
                    string nomeposicaoy = nomeciclo.Split(separador)[2];
                    string nomepposicabsoltuta = nomeciclo.Split(separador)[3];


                    if (Convert.ToInt32(nomepposicabsoltuta) == posabsoluta)
                    {

                        retornonome = rotulopercorre.NomeRotulo;
                        break;
                    }


                }



            }


            return retornonome;



        }






            public Label ObtemRecipienteporRotulo(int posabsoluta)
        {


            string retornonome = "";
            Label retornolabelrecipiente = new Label();

            char separador = Convert.ToChar(@"_");


            foreach (VinculoRotuloObjeto rotulopercorre in this.MapeamentoLotes)
            {
                string nomeciclo = rotulopercorre.NomeRotulo.ToLower().ToString();

                if (nomeciclo.IndexOf("poscal") > -1)
                {
                    string nomename = nomeciclo.Split(separador)[0];
                    string nomeposicaox = nomeciclo.Split(separador)[1];
                    string nomeposicaoy = nomeciclo.Split(separador)[2];
                    string nomepposicabsoltuta = nomeciclo.Split(separador)[3];


                    if (Convert.ToInt32(nomepposicabsoltuta) == posabsoluta)
                    {

                        retornonome = rotulopercorre.NomeRotulo;
                        retornolabelrecipiente = rotulopercorre.LabelRecipLot;
                        break;
                    }


                }



            }


            return retornolabelrecipiente;



        }


















        public void Cepalizacao(int numes, int nuano)
        {

            DateTime dtpri = new DateTime(nuano, numes, 1);
            int ndiasemana = Convert.ToInt16(dtpri.DayOfWeek);


            //Ruas
            for (int x = 1; x < 43; x++)
            {

                
                Label retlabel = this.ObtemRecipienteporRotulo(x);
                retlabel.Text = " ";

            }

            //Números
            int posinicio = ndiasemana;
            int ndia = 1;
            for (int x = posinicio + 1; x < 43; x++)
            {


                try
                {
                   
                    DateTime corrente = new DateTime(nuano, numes, ndia);
                    //   string nameobjeto = XA_NomePosicao(x);
                    //  this.Controls[nameobjeto].Text = ndia.ToString();

                    Label retlabel = this.ObtemRecipienteporRotulo(x);
                    retlabel.Text = ndia.ToString();
                }
                catch (Exception ex)
                {
                 //   MessageBox.Show(x.ToString(), ex.ToString(), MessageBoxButtons.OK);
                    break;
                }

                ndia = ndia + 1;

            }







        }














    }

    class VinculoRotuloObjeto
    {
                

        string nomerotulo = "";
        
        public string NomeRotulo
        {
            get
            {
                return nomerotulo;
            }
            set
            {
                nomerotulo = value;
            }

        }


        Label reciplot = new Label();
        public Label LabelRecipLot
        {
            get
            {
                return reciplot;
            }
            set
            {
                reciplot = value;
            }

        }





    }








}


