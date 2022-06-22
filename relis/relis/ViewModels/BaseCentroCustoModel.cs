using relis.Models;
using relis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace relis.ViewModels
{
    public class BaseCentroCustoModel : INotifyPropertyChanged
    {
        public IDataCentroCusto<tb_livro> DataCentroCusto => DependencyService.Get<IDataCentroCusto<tb_livro>>();
        public IConexaoSgbd<string> ConexaoSgbd => DependencyService.Get<IConexaoSgbd<string>>();


        bool errooperacao = false;
        public bool ErroOperacao
        {
            get { return errooperacao; }
            set { SetProperty(ref errooperacao, value); }
        }


        string titulocentrocusto = string.Empty;
        public string TituloCentroCusto
        {
            get { return titulocentrocusto; }
            set { SetProperty(ref titulocentrocusto, value); }
        }

        int idtitulocentrocusto = 99;
        public int IdTituloCentroCusto
        {
            get { return idtitulocentrocusto; }
            set { SetProperty(ref idtitulocentrocusto, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
