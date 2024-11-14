using BancoMaster.Dominio.Validacao;
using BancoMaster.WebApi.Request;

namespace BancoMaster.Teste
{
    public class TrechoRequest_Teste
    {
        [Fact]
        public void ValidaPreenchimentocDestino_Ok()
        {
            var _objTrecho = new TrechoRequest() { DescDestino = "SP", DescOrigem = "BH", VlrCusto = 20 };

            var _resultado = ValidaPreenchimento.Validar(_objTrecho);

            Assert.Empty(_resultado);
        }

        [Fact]
        public void ValidaPreenchimentocDestino_NaoOk()
        {
            var _objTrecho = new TrechoRequest() { DescDestino = string.Empty, DescOrigem = "BH", VlrCusto = 20 };

            var _resultado = ValidaPreenchimento.Validar(_objTrecho);

            Assert.NotEmpty(_resultado);
        }


        [Fact]
        public void ValidaPreenchimentocOrigem_Ok()
        {
            var _objTrecho = new TrechoRequest() { DescDestino = "SP", DescOrigem = "BH", VlrCusto = 20 };

            var _resultado = ValidaPreenchimento.Validar(_objTrecho);

            Assert.Empty(_resultado);
        }

        [Fact]
        public void ValidaPreenchimentocOrigem_NaoOk()
        {
            var _objTrecho = new TrechoRequest() { DescDestino = "SP", DescOrigem = string.Empty, VlrCusto = 20 };

            var _resultado = ValidaPreenchimento.Validar(_objTrecho);

            Assert.NotEmpty(_resultado);
        }


        [Fact]
        public void ValidaPreenchimentocVlrCusto_Ok()
        {
            var _objTrecho = new TrechoRequest() { DescDestino = "SP", DescOrigem = "BH", VlrCusto = 20 };

            var _resultado = ValidaPreenchimento.Validar(_objTrecho);

            Assert.Empty(_resultado);
        }

        [Fact]
        public void ValidaPreenchimentocVlrCusto_NaoOk()
        {
            var _objTrecho = new TrechoRequest() { DescDestino = "SP", DescOrigem = "BH", VlrCusto = 0 };

            var _resultado = ValidaPreenchimento.Validar(_objTrecho);

            Assert.NotEmpty(_resultado);
        }
    }
}
