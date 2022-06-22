using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MySqlConnector;
using MySql.Data.MySqlClient;

using relis.Models;


namespace relis.Services
{
    public interface IConexaoSgbd<T>
    {
        Task<ErroOperacao> DbSetSgbdExecute(T querytabelatemp);
        Task<ErroOperacao> DbSetSgbdReader();
        Task<ErroOperacao> DbSetSgbdReaderItem();
        Task<ErroOperacao> DbSetSgbdOpen();
        Task<ErroOperacao> DbSetSgbdTeste();
    }
}
