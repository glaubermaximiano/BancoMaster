using BancoMaster.Dominio.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.Infra.Dados
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork: IUnitOfWork
    {
        public string DirArquivoDados { set; get; }

        ITrechoRepositorio _trecho;
        public ITrechoRepositorio Trecho
        {
            get
            {
                if (_trecho == null)
                {
                    _trecho = new TrechoRepositorio(this.DirArquivoDados);
                }

                return _trecho;
            }
        }
    }
}
