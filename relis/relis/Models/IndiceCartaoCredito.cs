using System;
using System.Collections.Generic;
using System.Text;


using System.Threading;
using System.Threading.Tasks;

using System.IO;
using Xamarin.Forms;

namespace relis.Models
{



    public class IndiceCartaoCredito : ContentPage
    {


        string oNome = "";
        string oApelido = "";
        string oUrl = "";

        public string Nome
        {
            get
            {
                return oNome;
            }
            set
            {
                oNome = value;
               
            }
        }

        public string Apelido
        {
            get
            {
                return oApelido;
            }
            set
            {
                oApelido = value;

            }
        }

        public string Url
        {
            get
            {
                return oUrl;
            }
            set
            {
                oUrl = value;

                this.downloadFig(value);

            }
        }
        public string Family { get; set; }

        public ImageSource ImagemDown { get; set; }


        async Task downloadFig(string cUrl)
        {

            ClasseDownload cd = new ClasseDownload();
            Image imagetemp2 = new Image();
            Stream stream2 = new MemoryStream(await cd.downloadImagem(cUrl));
            imagetemp2.Source = ImageSource.FromStream(() => { return stream2; });

            this.ImagemDown = imagetemp2.Source;

            ////  await Application.Current.MainPage.DisplayAlert("entre linhaasss", this.Name, "ok");


        }


    }
}
