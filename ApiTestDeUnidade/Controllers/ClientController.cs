using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTestDeUnidade.Entities;
using ApiTestDeUnidade.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace ApiTestDeUnidade.Controllers
{
    [ApiController]
    // [Route("")]
    public class ClientController : ControllerBase
    {
        private readonly IClient _client;

        public ClientController(IClient client)
        {
            _client = client;
        }

        [Route("Home")]
        [HttpGet]
        public Client Customer()
        {
            /* var client = new Client()
             {
                Name = "fred",
                Age = 35
             };*/
            var client = new Mock<Client>();
            var c = _client.GetClient(client.Object);
            return c;
           /*   
            // Arrange
            var controller = new ClientController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            */
        }
    }
}
