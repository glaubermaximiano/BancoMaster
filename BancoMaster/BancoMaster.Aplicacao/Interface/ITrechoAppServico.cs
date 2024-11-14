using BancoMaster.Dominio.Entidade;

namespace BancoMaster.Aplicacao.Interface
{
    public interface ITrechoAppServico
    {
        RotaDominio? BuscaRotaMaisBarata(string? origemDestino);

        string Salvar(TrechoDominio obj);
    }
}
