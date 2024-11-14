using BancoMaster.Aplicacao;
using BancoMaster.Dominio.Entidade;
using BancoMaster.Dominio.Interface.Servico;
using BancoMaster.Dominio.Validacao;
using BancoMaster.WebApi.Request;
using Moq;

namespace BancoMaster.Teste
{
    public class TrechoAppService_Teste
    {
        [Fact]
        public void Grava_OK()
        {
            var _servico = new Mock<ITrechoServico>();

            _servico.Setup(s => s.Salvar(It.IsAny<TrechoDominio>())).Returns(string.Empty);

            var _resultado = new TrechoAppServico(_servico.Object).Salvar(It.IsAny<TrechoDominio>());

            Assert.Empty(_resultado);
        }

        [Fact]
        public void Grava_NaoOK()
        {
            var _servico = new Mock<ITrechoServico>();

            _servico.Setup(s => s.Salvar(It.IsAny<TrechoDominio>())).Returns( ValidaPreenchimento.Validar(new TrechoRequest() { DescDestino = "SP", DescOrigem = "BH", VlrCusto = 0 } ) );

            var _resultado = new TrechoAppServico(_servico.Object).Salvar(It.IsAny<TrechoDominio>());

            Assert.NotEmpty(_resultado);
        }
    }
}
