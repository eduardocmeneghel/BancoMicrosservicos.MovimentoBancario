using MovimentoBancaria.DTO;

namespace MovimentoBancaria.Servicos
{
    public class ContasClient
    {
        public ContasDTO BuscarConta(int codigoConta)
        {
            var httpClient = new HttpClient();

            var urlAplicacao = "http://localhost:5089/";

            var metodo = "api/Contas/";

            var urlChamada = urlAplicacao + metodo + codigoConta;

            var retorno = httpClient.GetAsync(urlChamada).Result;

            if (!retorno.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao buscar conta!");
            }

            var conta = retorno.Content.ReadFromJsonAsync<ContasDTO>().Result;

            return conta;
        }
    }
}
