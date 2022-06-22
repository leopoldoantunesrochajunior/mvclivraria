using System;
using System.Collections.Generic;
using System.Text;

using MySqlConnector;
using MySql.Data.MySqlClient;

namespace relis.Models
{
    class ClasseConexao
    {
                

        private String stringDroidConexao()
        {
            string s = "uid=ordebroc;pwd=;database=ordebroc;server=mysql.ordebroc.com.br";

            return s;
        }

        public MySqlConnection droidConexao()
        {
            string ConnectionString = stringDroidConexao();
            string cErro = "";
            MySqlConnection oConexao = new MySqlConnection(ConnectionString); 
            

            try
            {
                oConexao.Open();
                cErro = "";

            }
            catch (Exception ex)
            {
                cErro = ex.Message;
                oConexao = null;
            }
            finally {
                
            }

            return oConexao;


        }

    }

 


}
