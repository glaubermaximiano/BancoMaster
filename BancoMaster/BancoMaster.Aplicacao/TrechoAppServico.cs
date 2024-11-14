using BancoMaster.Aplicacao.Interface;
using BancoMaster.Dominio.Entidade;
using BancoMaster.Dominio.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BancoMaster.Aplicacao
{
    public sealed class TrechoAppServico : BaseApp, ITrechoAppServico
    {
        readonly ITrechoServico _servico;

        [ExcludeFromCodeCoverage]
        public TrechoAppServico(ITrechoServico servico)
           => _servico = servico;

        [ExcludeFromCodeCoverage]
        List<RotaDominio> ListaRotasPossiveis(string descOrigem, string descDestino)
        {
            try
            {
                var _lstTrechos = _servico.ListaTodos();

                var _lstRotas = new List<RotaDominio>();

                GetRotas(descOrigem, descDestino, _lstTrechos, [], _lstRotas);

                return _lstRotas;
            }
            catch (Exception ex) 
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        [ExcludeFromCodeCoverage]
        void GetRotas(string descOrigem, string descDestino, IEnumerable<TrechoDominio> lstTrechos, List<TrechoDominio> lstTrechoAtual, List<RotaDominio> lstRotas)
        {
            try
            {
                foreach (var trecho in lstTrechos.Where(x => x.DescOrigem.Equals(descOrigem, StringComparison.InvariantCultureIgnoreCase)))
                {
                    var novaRota = new List<TrechoDominio>(lstTrechoAtual) { trecho };

                    if (trecho.DescDestino.Equals(descDestino, StringComparison.InvariantCultureIgnoreCase))
                    {
                        lstRotas.Add(new RotaDominio { Trechos = novaRota });
                        continue;
                    }

                    GetRotas(trecho.DescDestino, descDestino, lstTrechos, novaRota, lstRotas);
                }
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        [ExcludeFromCodeCoverage]
        public RotaDominio? BuscaRotaMaisBarata(string? origemDestino)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(origemDestino))
                    return default;

                var _obj = origemDestino.Split('-');

                if (_obj.Length < 2)
                    return default;

                var rotas = ListaRotasPossiveis(_obj[0], _obj[1]);

                return rotas.OrderBy(x => x.VlrCusto).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public string Salvar(TrechoDominio obj)
        {
            try
            {
                return _servico.Salvar(obj);
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }
    }
}
