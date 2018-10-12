using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServers
{
    class Program
    {
            private static readonly int PORT = 7070;
        static void Main(string[] args)

        {
            IPAddress localAddress = IPAddress.Loopback;
            // ip and port of servers
            TcpListener serverSocket = new TcpListener(localAddress, PORT);
            //starting server
            serverSocket.Start();
            Console.WriteLine("TCP Server running on port " + PORT);

            while (true) // server loop keeps it running
            {
                try
                {
                    // waiting for incoming client
                    TcpClient client = serverSocket.AcceptTcpClient();
                    Console.WriteLine("incoming client");

                   //allows multiple clients
                    Task.Run(() => Conversion.DoIt(client));

                }
                catch (IOException ex)
                {
                    Console.WriteLine("exception. it will continue");


                }
            }
        }
    }
}
   


