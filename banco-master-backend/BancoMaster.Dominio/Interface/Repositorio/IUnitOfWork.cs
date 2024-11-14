
namespace BancoMaster.Dominio.Interface.Repositorio
{
    public interface IUnitOfWork
    {
        string DirArquivoDados { set; get; }

        ITrechoRepositorio Trecho { get; }
    }
}
