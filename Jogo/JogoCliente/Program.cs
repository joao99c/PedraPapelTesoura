using System.Threading.Tasks;
using JogoCliente.Controllers;

namespace JogoCliente
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            ClientController clientController = new ClientController();
            await clientController.Start();
        }
    }

  
}