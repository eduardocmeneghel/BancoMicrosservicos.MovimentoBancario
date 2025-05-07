namespace MovimentoBancaria.DTO
{
    public class BuscarContaDTO
    {
        public int Id { get; set; }

        public string Titular { get; set; }

        public string NumeroConta { get; set; }

        public int TipoConta { get; set; }

        public bool Ativo { get; set; }
    }
}
