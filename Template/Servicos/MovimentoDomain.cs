using ContaBancaria;
using Exemplo;
using MovimentoBancaria;
using MovimentoBancaria.Servicos;
using Template.Infra;

namespace Servicos
{
    public class MovimentoDomain
    {
        public DataContext _dataContext;
        public ContasClient _contasClient;

        public MovimentoDomain()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
            _contasClient = new ContasClient();
        }

        public void Saque(InserirMovimentoDTO dadosDoSaque)
        {
            var conta = _contasClient.BuscarConta(dadosDoSaque.CodigoConta);

            if (conta == null)
            {
                throw new Exception("Conta não encontrada!");
            }

            if (!conta.Ativo)
            {
                throw new Exception("Conta inativa.");
            }

            var movimento = new Movimento();

            movimento.CodigoConta = dadosDoSaque.CodigoConta;
            movimento.Data = dadosDoSaque.Data;
            movimento.TipoMovimento = EnumTipoMovimento.Saque;
            movimento.Valor = dadosDoSaque.Valor * -1;

            _dataContext.Add(movimento);

            _dataContext.SaveChanges();
        }

        public void Deposito(InserirMovimentoDTO dadosDoDeposito)
        {
            var movimento = new Movimento();

            movimento.CodigoConta = dadosDoDeposito.CodigoConta;
            movimento.Data = dadosDoDeposito.Data;
            movimento.TipoMovimento = EnumTipoMovimento.Saque;
            movimento.Valor = dadosDoDeposito.Valor;

            _dataContext.Add(movimento);

            _dataContext.SaveChanges();
        }

        public List<Movimento> BuscarPorConta(int codigoConta)
        {
            var listaMovimentos = _dataContext.Movimentos.Where(p => p.CodigoConta == codigoConta).ToList();

            return listaMovimentos;
        }
    }
}
