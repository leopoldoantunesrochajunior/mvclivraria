using System;
using System.Collections.Generic;
using System.Text;


using MySqlConnector;
using MySql.Data.MySqlClient;
//using Plugin.DeviceInfo;

using Xamarin.Forms;
using Xamarin.Essentials;

namespace relis.Models
{
    class ClasseUserControl
    {
        public Label pTrixLabel(Int32 nTopo, string Titulo, string Conteudo, RelativeLayout containerpai)
        {
            Int32 nY = nTopo;


            /*
              img_fundo_botao_tp1
                Default 16  14
                Micro   11  10
                Small   13  14
                Medium  16  17 
            */


            Image imgcaixa = new Image();
            StackLayout containertitulo = new StackLayout();
            StackLayout containerconteudo = new StackLayout();

            imgcaixa.Margin = 10;
            imgcaixa.Source = "img_fundo_edit_princ.bmp";
            imgcaixa.Aspect = Aspect.AspectFit;
            imgcaixa.HorizontalOptions = LayoutOptions.Center;
            imgcaixa.VerticalOptions = LayoutOptions.Start;



            Label lbltitulo = new Label();
            lbltitulo.Text = Titulo;
            lbltitulo.FontSize = 14;
            lbltitulo.HorizontalOptions = LayoutOptions.Start;
            lbltitulo.VerticalOptions = LayoutOptions.Start;
            lbltitulo.TextColor = Color.Black;


            Label lblconteudo = new Label();
            lblconteudo.Text = Conteudo;
            lblconteudo.FontSize = 18;
            lblconteudo.HorizontalOptions = LayoutOptions.Start;
            lblconteudo.VerticalOptions = LayoutOptions.Start;
            lblconteudo.TextColor = Color.Red;


            containertitulo.Children.Add(lbltitulo);
            containerconteudo.Children.Add(lblconteudo);


            //x(0),e y(0)

            int nleft = 0;

            nleft = 350 - ((Conteudo.ToString().Length *  8));
            nleft = nleft / 2; 

            containerpai.Children.Add(imgcaixa, Constraint.Constant(0), Constraint.Constant(nTopo));
            containerpai.Children.Add(containertitulo, Constraint.Constant(20), Constraint.Constant(nTopo + 8));
            containerpai.Children.Add(containerconteudo, Constraint.Constant(20 + nleft), Constraint.Constant(nTopo + 30));


            nY = nTopo + 30 + 10;

            return lblconteudo;
        }


        public Entry pTrixEntry(Int32 nTopo, string Titulo, string Conteudo, RelativeLayout containerpai)
        {
            Int32 nY = nTopo;


            /*
              img_fundo_botao_tp1
                Default 16  14
                Micro   11  10
                Small   13  14
                Medium  16  17 
            */


            Image imgcaixa = new Image();
            StackLayout containertitulo = new StackLayout();
            StackLayout containerconteudo = new StackLayout();

            imgcaixa.Margin = 10;
            imgcaixa.Source = "img_fundo_edit_princ.bmp";
            imgcaixa.Aspect = Aspect.AspectFit;
            imgcaixa.HorizontalOptions = LayoutOptions.Center;
            imgcaixa.VerticalOptions = LayoutOptions.Start;



            Label lbltitulo = new Label();
            lbltitulo.Text = Titulo;
            lbltitulo.FontSize = 14;
            lbltitulo.HorizontalOptions = LayoutOptions.Start;
            lbltitulo.VerticalOptions = LayoutOptions.Start;
            lbltitulo.TextColor = Color.Black;


            Entry txtconteudo = new Entry();
            txtconteudo.Placeholder = Conteudo;
            txtconteudo.FontSize = 18;
            txtconteudo.HorizontalOptions = LayoutOptions.Start;
            txtconteudo.VerticalOptions = LayoutOptions.Start;
            txtconteudo.TextColor = Color.Red;
            txtconteudo.WidthRequest = 350;


            containertitulo.Children.Add(lbltitulo);
            containerconteudo.Children.Add(txtconteudo);


            //x(0), e y(0)

            containerpai.Children.Add(imgcaixa, Constraint.Constant(0), Constraint.Constant(nTopo));
            containerpai.Children.Add(containertitulo, Constraint.Constant(20), Constraint.Constant(nTopo + 8));
            containerpai.Children.Add(containerconteudo, Constraint.Constant(40), Constraint.Constant(nTopo + 25));


            nY = nTopo + 30 + 10;

            return txtconteudo;
        }


        public Picker pTrixPicker(Int32 nTopo, string Titulo, string Conteudo, RelativeLayout containerpai)
        {
            Int32 nY = nTopo;


            /*
              img_fundo_botao_tp1
                Default 16  14
                Micro   11  10
                Small   13  14
                Medium  16  17 
            */


            Image imgcaixa = new Image();
            StackLayout containertitulo = new StackLayout();
            StackLayout containerconteudo = new StackLayout();

            imgcaixa.Margin = 10;
            imgcaixa.Source = "img_fundo_edit_princ.bmp";
            imgcaixa.Aspect = Aspect.AspectFit;
            imgcaixa.HorizontalOptions = LayoutOptions.Center;
            imgcaixa.VerticalOptions = LayoutOptions.Start;



            Label lbltitulo = new Label();
            lbltitulo.Text = Titulo;
            lbltitulo.FontSize = 14;
            lbltitulo.HorizontalOptions = LayoutOptions.Start;
            lbltitulo.VerticalOptions = LayoutOptions.Start;
            lbltitulo.TextColor = Color.Black;


            Picker txtpicker = new Picker();
            
            txtpicker.FontSize = 18;
            txtpicker.HorizontalOptions = LayoutOptions.Start;
            txtpicker.VerticalOptions = LayoutOptions.Start;
            txtpicker.TextColor = Color.Red;


            containertitulo.Children.Add(lbltitulo);
            containerconteudo.Children.Add(txtpicker);


            //x(0), e y(0)

            containerpai.Children.Add(imgcaixa, Constraint.Constant(0), Constraint.Constant(nTopo));
            containerpai.Children.Add(containertitulo, Constraint.Constant(20), Constraint.Constant(nTopo + 8));
            containerpai.Children.Add(containerconteudo, Constraint.Constant(40), Constraint.Constant(nTopo + 25));


            nY = nTopo + 30 + 10;

            return txtpicker;
        }




        public Label pTrixBotao(Int32 nTopo, Int32 nLeft,string Titulo,  RelativeLayout containerpai)
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
            imgcaixa.Source = "img_fundo_botao_tp3";
            imgcaixa.Aspect = Aspect.AspectFit;
            imgcaixa.HorizontalOptions = LayoutOptions.Center;
            imgcaixa.VerticalOptions = LayoutOptions.Start;



            Label lbltitulo = new Label();
            lbltitulo.Text = Titulo;
            lbltitulo.FontSize = 14;
            lbltitulo.HorizontalOptions = LayoutOptions.Start;
            lbltitulo.VerticalOptions = LayoutOptions.Start;
            lbltitulo.TextColor = Color.Black;



            containertitulo.Children.Add(lbltitulo);


            //x(0), e y(0)

            containerpai.Children.Add(imgcaixa, Constraint.Constant(nLeft), Constraint.Constant(nTopo));
            containerpai.Children.Add(containertitulo, Constraint.Constant(nLeft + 20 ), Constraint.Constant(nTopo + 25));
            //containerpai.Children.Add(containerconteudo, Constraint.Constant(0), Constraint.Constant(0));


            nY = nTopo + 30 + 10;

            return lbltitulo ;
        }

    }

}
