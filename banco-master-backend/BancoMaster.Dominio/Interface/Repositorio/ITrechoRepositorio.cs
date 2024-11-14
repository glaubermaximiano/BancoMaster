using BancoMaster.Dominio.Entidade;

namespace BancoMaster.Dominio.Interface.Repositorio
{
    public interface ITrechoRepositorio
    {
        List<TrechoDominio> ListaTodos();

        void Salvar(TrechoDominio obj);
    }
}
