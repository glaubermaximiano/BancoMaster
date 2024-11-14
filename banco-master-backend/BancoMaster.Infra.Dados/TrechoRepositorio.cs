using BancoMaster.Dominio.Entidade;
using BancoMaster.Dominio.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BancoMaster.Infra.Dados
{
    [ExcludeFromCodeCoverage]
    public sealed class TrechoRepositorio: BaseRepositorio, ITrechoRepositorio
    {
        const string _nomArquivoDados = "trechos.txt";

        public TrechoRepositorio(string dirArquivoDados)
            : base(dirArquivoDados) { }

        public List<TrechoDominio> ListaTodos()
        {
            try
            {
                if (!File.Exists($@"{base.GetPath}\{_nomArquivoDados}"))
                    return new List<TrechoDominio>();

                var _lst = new List<TrechoDominio>();

                foreach (var line in File.ReadAllLines($@"{base.GetPath}\{_nomArquivoDados}"))
                {
                    if (!TrechoDominio.TryParse(line, out var trecho) || (trecho == null))
                    {
                        return new List<TrechoDominio>();
                    }

                    _lst.Add(trecho);
                }

                return _lst;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Salvar(TrechoDominio obj)
        {
            try
            {
                var _lst = this.ListaTodos();

                _lst.Add(obj);

                using var _s = new FileStream($@"{base.GetPath}\{_nomArquivoDados}", FileMode.Create, FileAccess.ReadWrite);
                using var _w = new StreamWriter(_s);

                try
                {
                    foreach (var t in _lst)
                    {
                        _w.WriteLine(t.ToString());
                    }
                }
                finally
                {
                    _w.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
