using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

using System.IO;
using Xamarin.Forms;

namespace relis.Models
{
    public class tb_livro
    {
        public Int32 id_livro { get; set; }
        public string nm_isbn { get; set; }
        public string nm_autor { get; set; }
        public string nm_nome { get; set; }
        public decimal vl_preco { get; set; }
        public DateTime dt_publicacao { get; set; }
        
        public ImageSource img_capa { get; set; }

    }
}
