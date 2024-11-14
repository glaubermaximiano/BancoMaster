using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.Infra.Dados
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseRepositorio
    {
        readonly string _dirArquivoDados;

        public BaseRepositorio(string dirArquivoDados)
            => _dirArquivoDados = dirArquivoDados;

        protected string GetPath
        {
            get
            {
                return _dirArquivoDados;
            }
        }
    }
}
