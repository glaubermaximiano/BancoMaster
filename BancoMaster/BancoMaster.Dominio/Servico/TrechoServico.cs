using BancoMaster.Dominio.Entidade;
using BancoMaster.Dominio.Interface.Repositorio;
using BancoMaster.Dominio.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BancoMaster.Dominio.Servico
{
    [ExcludeFromCodeCoverage]
    public class TrechoServico : ITrechoServico
    {
        readonly IUnitOfWork _repositorio;

        public TrechoServico(IUnitOfWork repositorio)
            => _repositorio = repositorio;

        public List<TrechoDominio> ListaTodos()
        {
            try
            {
                return _repositorio.Trecho.ListaTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string Salvar(TrechoDominio obj)
        {
            try
            {
                _repositorio.Trecho.Salvar(obj);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
