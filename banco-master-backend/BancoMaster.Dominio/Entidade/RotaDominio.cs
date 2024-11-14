using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BancoMaster.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public record RotaDominio
    {
        public string DescOrigem => Trechos[0].DescOrigem;

        public string DescDestino => Trechos[Trechos.Count - 1].DescDestino;

        public decimal VlrCusto => Trechos.Sum(x => x.VlrCusto);

        public required IReadOnlyList<TrechoDominio> Trechos { get; init; }

        public override string ToString()
        {
            var _t = new StringBuilder();
            _t.Append(DescOrigem);

            foreach (var item in this.Trechos)
            {
                _t.Append($" - {item.DescDestino}");
            }

            _t.Append($" = ${VlrCusto}");

            return _t.ToString();
        }
    }
}
