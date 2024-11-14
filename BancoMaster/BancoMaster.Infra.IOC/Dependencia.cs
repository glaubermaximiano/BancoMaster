using BancoMaster.Aplicacao;
using BancoMaster.Aplicacao.Interface;
using BancoMaster.Dominio.Interface.Repositorio;
using BancoMaster.Dominio.Interface.Servico;
using BancoMaster.Dominio.Servico;
using BancoMaster.Infra.Dados;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.Infra.IOC
{
    [ExcludeFromCodeCoverage]
    public static class Dependencia
    {
        public static void RegistrarDependencias(IServiceCollection servico)
        {
            servico.AddSingleton<IUnitOfWork, UnitOfWork>();

            servico.AddSingleton<ITrechoAppServico, TrechoAppServico>();
            servico.AddSingleton<ITrechoServico, TrechoServico>();
            servico.AddTransient<ITrechoRepositorio>(s => new TrechoRepositorio(string.Empty));
        }
    }
}
