using MovimentoBancaria.DTO;

namespace MovimentoBancaria.Servicos
{
    public class ContaClient
    {
        public BuscarContaDTO BuscarConta(int codigoConta)
        {
            var httpClient = new HttpClient();

            var urlConta = "http://localhost:5089/";

            var uriConta = urlConta + "api/contas/" + codigoConta;

            var respostaBuscaConta = httpClient.GetAsync(uriConta).Result;

            if (!respostaBuscaConta.IsSuccessStatusCode)
            {
                throw new Exception("Conta não encontrada.");
            }

            var conta = respostaBuscaConta.Content.ReadFromJsonAsync<BuscarContaDTO>().Result;

            return conta;
        }
    }
}
