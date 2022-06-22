using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace relis.Services
{
    public interface IDataCentroCusto<T>
    {
        Task<bool> AddCentroCusto(T registro);
        Task<bool> UpdateCentroCusto(T registro);
        Task<bool> DeleteCentroCusto(string nome);
        Task<T> GetCentroCusto(string nome);
        Task<IEnumerable<T>> GetListagemCentroCusto(bool forceRefresh = false);
    }
}
