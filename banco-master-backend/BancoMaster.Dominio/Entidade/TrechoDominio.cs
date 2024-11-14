using System.Diagnostics.CodeAnalysis;

namespace BancoMaster.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public record TrechoDominio
    {
        public required string DescOrigem { get; init; }

        public required string DescDestino { get; init; }

        public decimal VlrCusto { get; init; }

        public string Pk => $"{DescOrigem}-{DescDestino}".ToLower();

        public override string ToString()
        {
            return $"{DescOrigem},{DescDestino},{VlrCusto}";
        }

        public static bool TryParse(string linha, out TrechoDominio? t)
        {
            if (string.IsNullOrWhiteSpace(linha))
            {
                t = default;
                return false;
            }

            var _p = linha.Split(',');

            if (_p.Length < 3)
            {
                t = default;
                return false;
            }

            if (!decimal.TryParse(_p[2], out decimal vlrCusto))
            {
                t = default;
                return false;
            }

            t = new TrechoDominio
            {
                DescOrigem = _p[0].ToUpper(),
                DescDestino = _p[1].ToUpper(),
                VlrCusto = vlrCusto
            };

            return true;
        }
    }
}
