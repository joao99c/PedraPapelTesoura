using Jogo.Controllers;

namespace Jogo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServerController srvCtrl = new ServerController();
            srvCtrl.Start();
        }
    }
}