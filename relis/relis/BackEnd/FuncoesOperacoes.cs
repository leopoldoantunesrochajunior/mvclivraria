using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;


using Xamarin.Forms;

namespace relis.Models
{
    public class FuncoesOperacoes
    {

        public bool andamento = false;

        public async void S_tiraAlerta()        {
            await Task.Delay(10);
        }


        public String S_primeiraQuebra(String Dado)
        {

            string formdado = Dado;

            formdado = formdado.Replace(@"-", " ");
            formdado = formdado.Replace(@"_", " ");
            formdado = formdado.Replace(@"/", " ");
            formdado = formdado.Replace(@"\", " ");


            int npostraco = formdado.IndexOf(' ');
            String res = "";

            if (npostraco >= 0)
            {
                res = Dado.Substring(0, npostraco);

            }
            else
            {
                res = Dado;
            }

            return res.Trim();
        }





        public async void S_EDICAO_SelecionaTexto(object sender)
        {
            await Task.Delay(100);

            Entry atual = (Entry)sender;

            atual.Focus();
            atual.CursorPosition = 0;
            atual.SelectionLength = 100;

            

            
        }

        public String S_MYSQL_InterpretaMonetario(String cValor)
        {

            String s = cValor;

            String pponto = ".";
            String vvirgula = ",";

            if (s.IndexOf(pponto) > 0 && s.IndexOf(vvirgula) > 0)
            {


                return s.Replace(".", "");
                

            }
            else
            {
                return s.Replace(".", ",");
            }

        }

        public string S_MYSQL_dataFormat(string cDado)
		{
			string t = cDado;
			string cRet = t.Substring(6, 4) + "-" + t.Substring(3, 2) + "-" + t.Substring(0, 2);

			return cRet;
		}

        public string S_DataFormat_DMY(string cDado)
        {
            string t = cDado;
            string cRet;
            try
            {
                Application.Current.MainPage.DisplayAlert("S_DataFormat_DMY", cDado, "ok");
                cRet = t.Substring(8, 2) + "/" + t.Substring(5, 2) + "/" + t.Substring(0, 4);
                Application.Current.MainPage.DisplayAlert("S_DataFormat_DMY", cRet, "ok");
            }
            catch (Exception ex)
            {
                cRet = "";
            }

            //2005-12-22 00:00:00
            return cRet;
        }



        public String S_MYSQL_RemoveReservado(String cDado, Boolean bLCase)
        {
            string s = "";
            if (cDado != null)
            {
                s = cDado;
            }
            else
            {
                s = "";
            }


            if (s == null)
            {

            }
            else
            {
                s = s.Trim();
            }

            if (bLCase == false)
            {
                s = s.ToUpper();
            }

            s = s.Replace("DELETE", "");
            s = s.Replace("UPDATE", "");
            s = s.Replace("SELECT", "");
            s = s.Replace("FROM", "");
            s = s.Replace("TRUNCATE", "");
            s = s.Replace(" AND ", "");
            s = s.Replace(" OR ", "");
            s = s.Replace("'", "''");
            s = s.Replace(";", "");
            s = s.Replace(" GO ", "");
            s = s.Replace("§", "");

            return s;

        }

        public String S_MYSQL_monetario(String cValor)
        {
            String s = cValor;

            s = s.Replace(",", ".");
            s = s.Replace(" ", "");

            return s;
        }

        public decimal S_MYSQL_numNulo(String cValor)
        {
            String s = cValor;

            if (s.Trim() == "")
            {

                s = "0";

            }
            else
            {
                s = cValor;
            }

            return Convert.ToDecimal(s);
        }



        public async void editMask(object sender, string maskedref) { 


            Entry txt = (Entry)sender;

            if (andamento == true)
            {
                return;
            }

            this.andamento = true;

            string formdado = ((Entry)sender).Text.ToString();
            string formmask = maskedref;

            formdado = formdado.Replace(@"-", "");
            formdado = formdado.Replace(@"_", "");
            formdado = formdado.Replace(@"/", "");
            formdado = formdado.Replace(@"\", "");

            int nlen = formdado.ToString().Length;
            int nlenmask = 0;
            string res = "";

            for (int z = 0; z < nlen; z++)
            {



                if (formmask.Substring(nlenmask, 1) != "9")
                {
                    res = res + formmask.Substring(nlenmask, 1);
                    nlenmask = nlenmask + 1;

                }

                if (formmask.Substring(nlenmask, 1) == "9")
                {


                    res = res + formdado.Substring(z, 1);

                }



                nlenmask = nlenmask + 1;





            }


            try
            {
                txt.Text = res;

                txt.Focus();
                txt.CursorPosition = res.Length + 1;
                txt.SelectionLength = 0;

            } catch(Exception ex)  {
                string s = ex.Message;
            }
                                 

            this.andamento = false;
        }



















    }
}
