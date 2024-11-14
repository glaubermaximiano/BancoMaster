using BancoMaster.Dominio.Entidade;

namespace BancoMaster.Dominio.Interface.Servico
{
    public interface ITrechoServico
    {
        List<TrechoDominio> ListaTodos();

        string Salvar(TrechoDominio obj);
    }
}
