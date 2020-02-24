using System;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;
using PedraPapelTesoura.Model;

namespace Jogo.Controllers
{
    public class ServerController
    {
        private bool terminou = false;

        public ServerController()
        {
            
            Player player = new Player();
            player.Name = "teste";
            Console.WriteLine("Boas "+player.Name+"!");
            string serialiedPlayer = JsonConvert.SerializeObject(player);
            Player unserializedPlayer = JsonConvert.DeserializeObject<Player>(serialiedPlayer);
            
            Debugger.Break();

        }

        public void Start()
        {
            Thread t = new Thread(Espera2Seg);
            t.Start();
            while (!terminou)
            {
                Console.WriteLine("Running!");
            }
            Console.WriteLine("Not Running!");

        }

        private void Espera2Seg()
        {
            Thread.Sleep(2000);
            terminou = true;
        }
    }
}