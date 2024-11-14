using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.Aplicacao
{
    public abstract class BaseApp
    {
        [ExcludeFromCodeCoverage]
        protected void TrataErro(string msgErro)
        {
            NLog.LogManager.GetLogger("fileTarget").Error(msgErro);
        }
    }
}
