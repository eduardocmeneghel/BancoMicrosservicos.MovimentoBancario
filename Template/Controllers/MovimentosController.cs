using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovimentoBancaria;
using Servicos;

namespace ContaBancaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentosController : ControllerBase
    {
        private readonly MovimentoDomain _movimentoDomain;

        public MovimentosController()
        {
            _movimentoDomain = new MovimentoDomain();
        }

        [HttpPost("/api/[controller]/Saque")]
        public IActionResult Saque(InserirMovimentoDTO dadosDoSaque)
        {
            try
            {
                _movimentoDomain.Saque(dadosDoSaque);

                return Ok("Conta inserida com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/api/[controller]/Deposito")]
        public IActionResult Deposito(InserirMovimentoDTO dadosDoDeposito)
        {
            try
            {
                _movimentoDomain.Deposito(dadosDoDeposito);

                return Ok("Conta inserida com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        [HttpGet("/api/[controller]/{codigoConta}")]
        public IActionResult BuscarPorConta(int codigoConta)
        {
            try
            {
                var contas = _movimentoDomain.BuscarPorConta(codigoConta);

                return Ok(contas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
