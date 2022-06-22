using System;

using MySqlConnector;
using MySql.Data.MySqlClient;

namespace relis.Models
{
    public class ErroOperacao
    {
        public string RetIdErro { get; set; }
        public string RetErroDescricao { get; set; }
        public MySqlConnection RetMysqlConnection { get; set; }
        public MySqlDataReader RetmySqlDatareader { get; set; }
    }
}