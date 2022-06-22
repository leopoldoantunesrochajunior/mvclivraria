using relis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySqlConnector;
using MySql.Data.MySqlClient;

using relis.Models;

namespace relis.Services
{
    public class MockConexaoSgbd : IConexaoSgbd<string>
    {
        readonly List<tb_livro> registros;
        public string StringConexao { get; set; }

        public ErroOperacao ErroOperacao {get;set;}

        public MockConexaoSgbd()
        {
            this.StringConexao = "uid=ordebroc;pwd=;database=ordebroc;server=mysql.ordebroc.com.br";
        }

        public async Task<ErroOperacao> DbSetSgbdReader()
        {
            string s = "";
            ErroOperacao eoreader = new ErroOperacao();

            eoreader.RetmySqlDatareader = null;
            eoreader.RetErroDescricao = "iniciação";
            eoreader.RetMysqlConnection = null;

            
            try
            {
                eoreader = await DbSetSgbdTeste();

                s = "";
                s = s + "select * ";
                s = s + "from tb_banco order by nm_banco";

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = eoreader.RetMysqlConnection;
                comando.CommandText = s;
                comando.Prepare();
                MySqlDataReader reader = comando.ExecuteReader();

                eoreader.RetmySqlDatareader = reader;
                eoreader.RetErroDescricao = "exito na consulta";


            }
            catch (Exception ex)
            {
                
                eoreader.RetmySqlDatareader = null;
                eoreader.RetErroDescricao = ex.Message;
                eoreader.RetMysqlConnection = null;


            }

            return await Task.FromResult(eoreader);
        }





        public async Task<ErroOperacao> DbSetSgbdTeste()
        {
            ErroOperacao eo = new ErroOperacao();

            eo.RetmySqlDatareader = null;
            eo.RetErroDescricao = "erro sem";
            eo.RetMysqlConnection = null;

            MySqlConnection oConexao = null;

            try
            {
                string cs = "uid=ordebroc;pwd=123456;database=ordebroc;server=mysql.ordebroc.com.br";
                oConexao = new MySqlConnection(cs);
                oConexao.Open();

                eo.RetmySqlDatareader = null;
                eo.RetErroDescricao = "exito na conexao";
                eo.RetMysqlConnection = oConexao;



            }
            catch (Exception ex)
            {

                eo.RetmySqlDatareader = null;
                eo.RetErroDescricao = ex.Message;
                eo.RetMysqlConnection = null;

            }

            return await Task.FromResult(eo);

        }





        public async Task<ErroOperacao> DbSetSgbdOpen()
        {
            ErroOperacao.RetmySqlDatareader = null;
            ErroOperacao.RetErroDescricao = null;
            ErroOperacao.RetMysqlConnection = null;

            
            

            return await Task.FromResult(ErroOperacao);

        }

        public Task<ErroOperacao> DbSetSgbdReader(string tabelatemp)
        {

            ErroOperacao.RetmySqlDatareader = null;
            ErroOperacao.RetErroDescricao = null;
            ErroOperacao.RetMysqlConnection = null;

            string s = "";

            ClasseConexao cc = new ClasseConexao();
            MySqlConnection olook = null;
            MySqlDataReader reader = null;

            try
            {

                cc = new ClasseConexao();
                olook = cc.droidConexao();

                s = "";
                s = s + "select * ";
                s = s + "from tb_banco order by nm_banco";

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = olook;
                comando.CommandText = s;
                comando.Prepare();
                reader = comando.ExecuteReader();

            } catch(Exception ex)
            {
                ErroOperacao.RetmySqlDatareader = reader;
                ErroOperacao.RetErroDescricao = ex.Message;
                ErroOperacao.RetMysqlConnection = null;
            }

            ErroOperacao.RetmySqlDatareader = reader;
            ErroOperacao.RetErroDescricao = "-";
            ErroOperacao.RetMysqlConnection = olook;

            return Task.FromResult(ErroOperacao);

        }

        public Task<ErroOperacao> DbSetSgbdReaderItem()
        {

            ErroOperacao.RetmySqlDatareader = null;
            ErroOperacao.RetErroDescricao = null;
            ErroOperacao.RetMysqlConnection = null;

            string s = "";

            ClasseConexao cc = new ClasseConexao();
            MySqlConnection olook = null;
            MySqlDataReader reader = null;

            try
            {

                cc = new ClasseConexao();
                olook = cc.droidConexao();

                s = "";
                s = s + "select nm_banco,nm_resumido ";
                s = s + "from tb_banco order by nm_banco";

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = olook;
                comando.CommandText = s;
                comando.Prepare();
                reader = comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                ErroOperacao.RetmySqlDatareader = reader;
                ErroOperacao.RetErroDescricao = ex.Message;
                ErroOperacao.RetMysqlConnection = null;
            }

            ErroOperacao.RetmySqlDatareader = reader;
            ErroOperacao.RetErroDescricao = "-";
            ErroOperacao.RetMysqlConnection = olook;

            return Task.FromResult(ErroOperacao);

        }








        public Task<ErroOperacao> DbSetSgbdExecute(string temp)
        {

            string s = "";

            ClasseConexao cc = new ClasseConexao();


            MySqlConnection olook = cc.droidConexao();

            s = "";
            s = s + "select nm_banco,nm_resumido ";
            s = s + "from tb_banco order by nm_banco";

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = olook;
            comando.CommandText = s;
            comando.Prepare();
            MySqlDataReader reader = comando.ExecuteReader();

            ErroOperacao.RetmySqlDatareader = reader;
            ErroOperacao.RetErroDescricao = "-";
            ErroOperacao.RetMysqlConnection = olook;

            return Task.FromResult(ErroOperacao);

        }









    }





}