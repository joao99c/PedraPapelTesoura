using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using JogoCliente.Settings;

namespace JogoCliente.Controllers
{
    public class ClientController
    {
        private readonly IPEndPoint _serverIpEndPoint;
        
        public ClientController()
        {
            _serverIpEndPoint = new IPEndPoint(IPAddress.Parse(ClientSettings.IpAddress), ClientSettings.SendMessagePort);
        }

        public async Task Start()
        {
            var message = "Hello server";
            await SendUdpMessage(Encoding.UTF8.GetBytes(message));
        }
        
        private async Task SendUdpMessage(byte[] messageBytes)
        {
            using (var client = new UdpClient())
            {
                await client.SendAsync(messageBytes, messageBytes.Length, _serverIpEndPoint);
            }
        }

        private async Task<byte[]> ReceiveUdpMessage()
        {
            UdpReceiveResult udpReceiveResult;
            using (var client = new UdpClient(ClientSettings.ReceiveMessagePort))
            {
                udpReceiveResult =  await client.ReceiveAsync();
            }

            return udpReceiveResult.Buffer;
        }
    }
}