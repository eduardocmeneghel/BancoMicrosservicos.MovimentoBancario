namespace ContaBancaria
{
    public class Movimento
    {
        public int Id { get; set; }

        public int CodigoConta { get; set; }

        public EnumTipoMovimento TipoMovimento { get; set; }

        public DateTime Data {  get; set; }

        public decimal Valor {  get; set; }
    }

    public enum EnumTipoMovimento
    {
        Saque = 1,
        Deposito = 2
    }
}
