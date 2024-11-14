using BancoMaster.Dominio.Config;
using BancoMaster.Dominio.Interface.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class BancoMasterController : Controller
    {
        readonly ConfigAmbiente _config;
        readonly IUnitOfWork _unitOfWork;

        public BancoMasterController(ConfigAmbiente config,
                                    IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;

            _unitOfWork.DirArquivoDados = this._config.DirArquivoDados;
        }
    }
}
