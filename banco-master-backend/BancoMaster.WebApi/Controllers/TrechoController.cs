using BancoMaster.Aplicacao.Interface;
using BancoMaster.Dominio.Config;
using BancoMaster.Dominio.Interface.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using BancoMaster.WebApi.Request;
using BancoMaster.Dominio.Entidade;
using BancoMaster.Dominio.Validacao;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BancoMaster.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class TrechoController : BancoMasterController
    {
        readonly ITrechoAppServico _trechoApp;

        public TrechoController(ConfigAmbiente config,
                                IUnitOfWork unitOfWork,
                                ITrechoAppServico trechoApp)
            :base(config, unitOfWork) 
        {

            _trechoApp = trechoApp;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/BancoMaster/trechos")]
        public IActionResult ListaTodos()
        {
            try
            {
                var _obj = _trechoApp.ListaTodos();

                return _obj.Any() ? Ok(_obj): StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/BancoMaster/rota-mais-barata/{OrigemDestino}")]
        public IActionResult BuscaRotaMaisBarata(string OrigemDestino)
        {
            try
            {
                var _obj = _trechoApp.BuscaRotaMaisBarata(OrigemDestino);

                return _obj == null ? StatusCode(StatusCodes.Status204NoContent) : Ok(_obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/BancoMaster/trecho")]
        public IActionResult Gravar([FromBody] TrechoRequest obj)
        {
            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
                }

                _msg = _trechoApp.Salvar(new TrechoDominio {
                                                            VlrCusto = obj.VlrCusto,
                                                            DescDestino = obj.DescDestino,
                                                            DescOrigem = obj.DescOrigem,
                                                           });

                return string.IsNullOrEmpty(_msg) ? this.StatusCode(StatusCodes.Status201Created, _msg) : this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
