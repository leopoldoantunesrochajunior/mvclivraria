using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Web;

using System.Xml;
using System.Reflection;

using Xamarin.Essentials;
using System.Threading;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net;
using System.IO;



using System.Collections.Generic;
using System.Linq;
using System.Text;





using Xamarin.Forms.Core;









using System.Globalization;





//using MySqlConnector;
using MySql.Data.MySqlClient;

namespace relis.Models
{
    public class ClasseDownload {

        public async Task<byte[]> downloadImagem(string urlp)
        {
            WebClient webClient = new WebClient();

            byte[] imageBytesLocal = null;

            Uri uri = new Uri(urlp);
            imageBytesLocal = await webClient.DownloadDataTaskAsync(uri);
            webClient.Dispose();
            webClient = null;

            return imageBytesLocal;
        }

    }


}
