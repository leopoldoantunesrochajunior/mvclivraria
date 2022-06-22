
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using System.ComponentModel;
using System.Threading.Tasks;


using MySqlConnector;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace relis.Models
{
    class ClasseLancamento : ContentPage
    {




        public Boolean IncluirLivro(tb_livro registro)
        {
            string s = "";
            Boolean res = false;

            ClasseConexao cc = new ClasseConexao();
            MySqlConnection olook = cc.droidConexao();

            if (olook != null)
            {

                s = "";
                s = s + "insert into tb_livro(nm_isbn,nm_autor, nm_nome,vl_preco,dt_publicacao) ";
                s = s + "values(?param2,?param3,?param4,?param5,?param6);";

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = olook;

                comando.CommandText = s;
                comando.Prepare();

                 
                MySqlParameter p2 = new MySqlParameter();
                p2.ParameterName = "?param2";
                p2.Value = registro.nm_isbn;
                p2.MySqlDbType = MySqlDbType.String;

                MySqlParameter p3 = new MySqlParameter();
                p3.ParameterName = "?param3";
                p3.Value = registro.nm_autor;
                p3.MySqlDbType = MySqlDbType.String;

                MySqlParameter p4 = new MySqlParameter();
                p4.ParameterName = "?param4";
                p4.Value = registro.nm_nome;
                p4.MySqlDbType = MySqlDbType.String;

                MySqlParameter p5 = new MySqlParameter();
                p5.ParameterName = "?param5";
                p5.Value = registro.vl_preco;
                p5.MySqlDbType = MySqlDbType.Double;

                MySqlParameter p6 = new MySqlParameter();
                p6.ParameterName = "?param6";
                p6.Value = registro.dt_publicacao;
                p2.MySqlDbType = MySqlDbType.DateTime;

         
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);

                try
                {
                    comando.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                }


            }
            else
            {

                res = false;
            }


            return res;

        }

        public Boolean AlterarLivro(Int32 idlivro, tb_livro registro)
        {
            string s = "";
            Boolean res = false;

            ClasseConexao cc = new ClasseConexao();
            MySqlConnection olook = cc.droidConexao();

            if (olook != null)
            {

                s = "";
                s = s + "update tb_livro set ";
                s = s + "nm_isbn=?param2,nm_autor=?param3,nm_nome=?param4,vl_preco=?param5,dt_publicacacao=?param6 ";
                s = s + "where id_livro=" + idlivro.ToString();

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = olook;

                comando.CommandText = s;
                comando.Prepare();


                MySqlParameter p2 = new MySqlParameter();
                p2.ParameterName = "?param2";
                p2.Value = registro.nm_isbn;
                p2.MySqlDbType = MySqlDbType.String;

                MySqlParameter p3 = new MySqlParameter();
                p3.ParameterName = "?param3";
                p3.Value = registro.nm_autor;
                p3.MySqlDbType = MySqlDbType.String;

                MySqlParameter p4 = new MySqlParameter();
                p4.ParameterName = "?param4";
                p4.Value = registro.nm_nome;
                p4.MySqlDbType = MySqlDbType.String;

                MySqlParameter p5 = new MySqlParameter();
                p5.ParameterName = "?param5";
                p5.Value = registro.vl_preco;
                p5.MySqlDbType = MySqlDbType.Double;

                MySqlParameter p6 = new MySqlParameter();
                p6.ParameterName = "?param6";
                p6.Value = registro.dt_publicacao;
                p2.MySqlDbType = MySqlDbType.DateTime;


                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);

                try
                {
                    comando.ExecuteNonQuery();
                    Application.Current.MainPage.DisplayAlert("após nomquery", s, "OK");
                    res = true;
                }
                catch (Exception ex)
                {
                    Application.Current.MainPage.DisplayAlert("erro nonquery", ex.Message, "OK");
                    res = false;
                }


            }
            else
            {

                res = false;
            }


            return res;

        }





        public MySqlDataReader ObtemRelacaoLivro()
        {
            string s = "";

            ClasseConexao cc = new ClasseConexao();


            MySqlConnection olook = cc.droidConexao();

            s = "";
            s = s + "select * ";
            s = s + "from tb_livro order by nm_nome";
            
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = olook;
            comando.CommandText = s;
            comando.Prepare();
            MySqlDataReader reader =  comando.ExecuteReader();

           return reader;

        }


        public MySqlDataReader ObtemDadosLivro(Int32 idlivro)
        {
            string s = "";

            ClasseConexao cc = new ClasseConexao();
            MySqlDataReader reader = null;

                      
            try
            {

                //  MySqlParameter p1 = new MySqlParameter();
                //  p1.ParameterName = "?param1";
                //  p1.Value = regi;
                //  p1.MySqlDbType = MySqlDbType.Int32;

                MySqlConnection olook = cc.droidConexao();

                s = "";
                s = s + @"select * ";
                s = s + @"from tb_livro ";
                s = s + @"where id_livro=" + idlivro.ToString();

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = olook;
                comando.CommandText = s;
                comando.Prepare();
                reader = comando.ExecuteReader();
               
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Query Busca Livro", s, "ok");
            }
           
          
            

            return reader;

        }



    }



}
