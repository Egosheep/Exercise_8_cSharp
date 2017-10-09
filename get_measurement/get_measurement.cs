using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace get_measurement
{
	class get_measurement
	{
		const int PORT = 9000;

		private get_measurement(string[] args)
		{
			IPAddress serverAddress = IPAddress.Parse("10.0.0.1");
			var udpClient = new UdpClient(PORT);
			IPEndPoint serverEP = new IPEndPoint(serverAddress, PORT);
			Console.WriteLine("Client started.");
			switch (args.ToString().ToLower())
			{
				case "l":
					Byte[] sendL = Encoding.ASCII.GetBytes(args[1]);
					udpClient.Send(sendL, sendL.Length);
					udpClient.Receive(ref serverEP);
					break;

				case "u":
					Byte[] sendU = Encoding.ASCII.GetBytes(args[1]);
					udpClient.Send(sendU, sendU.Length);
					break;

				default:
					Console.WriteLine("U or L, you stupido idioti.");
					break;
			}
		}

		static void Main(string[] args)
		{
			new get_measurement(args);
		}
	}
}
