using relis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace relis.Services
{
    public class MockDataCentroCusto : IDataCentroCusto<tb_livro>
    {
        readonly List<tb_livro> registros;

        public MockDataCentroCusto()
        {
          
        }

        public async Task<bool> AddCentroCusto(tb_livro registro)
        {
            registros.Add(registro);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCentroCusto(tb_livro registro)
        {
            var registroantigo = registros.Where((tb_livro arg) => arg.nm_isbn == registro.nm_isbn).FirstOrDefault();
            registros.Remove(registroantigo);
            registros.Add(registro);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCentroCusto(string nome)
        {
            var registroantigo = registros.Where((tb_livro arg) => arg.nm_isbn == nome).FirstOrDefault();
            registros.Remove(registroantigo);

            return await Task.FromResult(true);
        }

        public async Task<tb_livro> GetCentroCusto(string nome)
        {
            await Application.Current.MainPage.DisplayAlert("GetCentroCusto", nome, "OK");
            
            return await Task.FromResult(registros.FirstOrDefault(s => s.nm_isbn == nome));

        }

        public async Task<IEnumerable<tb_livro>> GetListagemCentroCusto(bool forceRefresh = false)
        {
            return await Task.FromResult(registros);
        }
    }
}