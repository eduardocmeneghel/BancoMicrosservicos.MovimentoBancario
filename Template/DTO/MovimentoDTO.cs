using ContaBancaria;

namespace MovimentoBancaria
{
    public class InserirMovimentoDTO
    {
        public int CodigoConta { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }
    }
}
