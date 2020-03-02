using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jogo.Settings;
using Newtonsoft.Json;
using PedraPapelTesoura.Model;

namespace Jogo.Controllers
{
    public class ServerController
    {
        private List<IPEndPoint> _connectedUsersList;
        public ServerController()
        {
            _connectedUsersList = new List<IPEndPoint>();
        }

        public async Task Start()
        {
            var result = await ReceiveUdpMessage();
            Console.WriteLine(Encoding.UTF8.GetString(result));
        }

        private async Task SendUdpMessage(byte[] messageBytes, IPEndPoint ipEndPoint)
        {
            using (UdpClient client = new UdpClient())
            {
                await client.SendAsync(messageBytes, messageBytes.Length, ipEndPoint);
            }
        }

        private async Task<byte[]> ReceiveUdpMessage()
        {
            UdpReceiveResult udpReceiveResult;
            using (var client = new UdpClient(ServerSettings.ReceiveMessagePort))
            {
                udpReceiveResult =  await client.ReceiveAsync();
            }

            if (_connectedUsersList.
                    FirstOrDefault(
                        u => u.Address.Equals(udpReceiveResult.RemoteEndPoint.Address)) 
                != null)
            {
                _connectedUsersList.Add(udpReceiveResult.RemoteEndPoint);
            }
            
            return udpReceiveResult.Buffer;
        }
    }
}