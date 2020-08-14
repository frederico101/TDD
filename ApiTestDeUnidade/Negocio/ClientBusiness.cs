using ApiTestDeUnidade.Entities;
using ApiTestDeUnidade.Interfaces;

namespace ApiTestDeUnidade.Negocio
{
    public class ClientBusiness : IClient
    {
        public Client GetClient( Client client)
        {
            return client;
        }
    }
}