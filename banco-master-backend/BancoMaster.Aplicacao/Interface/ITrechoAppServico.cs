using BancoMaster.Dominio.Entidade;

namespace BancoMaster.Aplicacao.Interface
{
    public interface ITrechoAppServico
    {
        RotaDominio? BuscaRotaMaisBarata(string? origemDestino);

        List<TrechoDominio> ListaTodos();

        string Salvar(TrechoDominio obj);
    }
}
