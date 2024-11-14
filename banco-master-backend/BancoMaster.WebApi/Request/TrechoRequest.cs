using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.WebApi.Request
{
    [ExcludeFromCodeCoverage]
    public class TrechoRequest
    {
        [Required(ErrorMessage = "A aplicação requer que o campo Destino seja preenchida!")]
        public required string DescDestino { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Origem seja preenchida!")]
        public required string DescOrigem { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "A aplicação requer que o campo Vlr Custo seja preenchido!")]
        public decimal VlrCusto { get; set; }
    }
}
